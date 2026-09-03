using ApiPruebaAudi.Application.DTOs.Student;
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
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<StudentDTO> Create(CreateStudentDTO dto)
        {
            var student = _mapper.Map<Student>(dto);

            await _repository.AddAsync(student);

            return _mapper.Map<StudentDTO>(student);
        }

        public async Task<IEnumerable<StudentDTO>> GetAllAsync()
        {
            var student = await _repository.GetAllAsync();

            return _mapper.Map<IEnumerable<StudentDTO>>(student);
        }

        public async Task<PagedResponse<StudentDTO>> GetStudentsAsync(
        int pageNumber,
        int pageSize)
        {
            if (pageNumber < 1)
                throw new ArgumentException(
                    "El número de página debe ser mayor que 0.");

            if (pageSize < 1 || pageSize > 100)
                throw new ArgumentException(
                    "El tamaño de página debe estar entre 1 y 100.");

            return await _repository.GetPagedAsync(
                pageNumber,
                pageSize);
        }

        public async Task<StudentDTO?> GetById(int id)
        {
            var student = await _repository.GetByIdAsync(id);

            if (student == null)
                throw new NotFoundException("Nota no encontrada.");

            return _mapper.Map<StudentDTO>(student);
        }

        public async Task Update(int id, CreateStudentDTO dto)
        {
            var student = await _repository.GetByIdAsync(id);

            if (student == null)
                throw new NotFoundException($"No existe una nota con el id {id}");

            _mapper.Map(dto, student);

            await _repository.UpdateAsync(student);
        }

        public async Task Delete(int id)
        {
            var student = await _repository.GetByIdAsync(id);

            if (student == null)
                throw new NotFoundException($"No existe una nota con el id {id}");

            await _repository.DeleteAsync(student);
        }
    }
}
