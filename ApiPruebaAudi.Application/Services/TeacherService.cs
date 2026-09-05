using ApiPruebaAudi.Application.DTOs.Teacher;
using ApiPruebaAudi.Application.DTOs;
using ApiPruebaAudi.Application.Exceptions;
using ApiPruebaAudi.Application.Interfaces;
using ApiPruebaAudi.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPruebaAudi.Application.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _repository;
        private readonly IMapper _mapper;

        public TeacherService(ITeacherRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TeacherDTO> Create(CreateTeacherDTO dto)
        {
            var teacher = _mapper.Map<Teacher>(dto);

            await _repository.AddAsync(teacher);

            return _mapper.Map<TeacherDTO>(teacher);
        }

        public async Task<IEnumerable<TeacherDTO>> GetAllAsync()
        {
            var teacher = await _repository.GetAllAsync();

            return _mapper.Map<IEnumerable<TeacherDTO>>(teacher);
        }

        public async Task<PagedResponse<TeacherDTO>> GetTeachers(
        int pageNumber,
        int pageSize,
        string? searchTerm = null)
        {
            if (pageNumber < 1)
                throw new ArgumentException(
                    "El número de página debe ser mayor que 0.");

            if (pageSize < 1 || pageSize > 1000)
                throw new ArgumentException(
                    "El tamaño de página debe estar entre 1 y 1000.");

            var response = await _repository.GetPagedAsync(
                pageNumber,
                pageSize,
                searchTerm);

            return new PagedResponse<TeacherDTO>
            {
                Items = _mapper.Map<IEnumerable<TeacherDTO>>(response.Items),
                PageNumber = response.PageNumber,
                PageSize = response.PageSize,
                TotalItems = response.TotalItems,
                TotalPages = response.TotalPages
            };
        }

        public async Task<TeacherDTO?> GetById(int id)
        {
            var teacher = await _repository.GetByIdAsync(id);

            if (teacher == null)
                throw new NotFoundException("Profesor no encontrada.");

            return _mapper.Map<TeacherDTO>(teacher);
        }

        public async Task Update(int id, CreateTeacherDTO dto)
        {
            var teacher = await _repository.GetByIdAsync(id);

            if (teacher == null)
                throw new NotFoundException($"No existe un profesor con el id {id}");

            _mapper.Map(dto, teacher);

            await _repository.UpdateAsync(teacher);
        }

        public async Task Delete(int id)
        {
            var teacher = await _repository.GetByIdAsync(id);

            if (teacher == null)
                throw new NotFoundException($"No existe un profesor con el id {id}");

            await _repository.DeleteAsync(teacher);
        }
    }
}
