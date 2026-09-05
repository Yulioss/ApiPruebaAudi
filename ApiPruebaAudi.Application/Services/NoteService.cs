using ApiPruebaAudi.Application.DTOs;
using ApiPruebaAudi.Application.DTOs.Note;
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
    public class NoteService : INoteService
    {
        private readonly INoteRepository _repository;
        private readonly IStudentRepository _studentRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IMapper _mapper;

        public NoteService(INoteRepository repository, IMapper mapper, IStudentRepository studentRepository, ITeacherRepository teacherRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _studentRepository = studentRepository;
            _teacherRepository = teacherRepository;
        }

        public async Task<NoteDTO> Create(CreateNoteDTO dto)
        {
            var student = await _studentRepository.GetByIdAsync(dto.StudentId);

            if (student == null)
                throw new NotFoundException(
                    $"No existe un estudiante con el id {dto.StudentId}.");

            var teacher = await _teacherRepository.GetByIdAsync(dto.TeacherId);

            if (teacher == null)
                throw new NotFoundException(
                    $"No existe un profesor con el id {dto.TeacherId}.");

            var note = _mapper.Map<Note>(dto);

            await _repository.AddAsync(note);

            return _mapper.Map<NoteDTO>(note);
        }

        public async Task<IEnumerable<NoteDTO>> GetAllAsync()
        {
            var note = await _repository.GetAllAsync();

            return _mapper.Map<IEnumerable<NoteDTO>>(note);
        }

        public async Task<PagedResponse<NoteDTO>> GetNotes(
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

            return new PagedResponse<NoteDTO>
            {
                Items = _mapper.Map<IEnumerable<NoteDTO>>(response.Items),
                PageNumber = response.PageNumber,
                PageSize = response.PageSize,
                TotalItems = response.TotalItems,
                TotalPages = response.TotalPages
            };
        }

        public async Task<NoteDTO?> GetById(int id)
        {
            var note = await _repository.GetByIdAsync(id);

            if (note == null)
                throw new NotFoundException("Nota no encontrada.");

            return _mapper.Map<NoteDTO>(note);
        }

        public async Task Update(int id, CreateNoteDTO dto)
        {

            var student = await _studentRepository.GetByIdAsync(dto.StudentId);

            if (student == null)
                throw new NotFoundException(
                    $"No existe un estudiante con el id {dto.StudentId}.");

            var teacher = await _teacherRepository.GetByIdAsync(dto.TeacherId);

            if (teacher == null)
                throw new NotFoundException(
                    $"No existe un profesor con el id {dto.TeacherId}.");

            var note = await _repository.GetByIdAsync(id);

            if (note == null)
                throw new NotFoundException($"No existe una nota con el id {id}");

            _mapper.Map(dto, note);

            await _repository.UpdateAsync(note);
        }

        public async Task Delete(int id)
        {
            var note = await _repository.GetByIdAsync(id);

            if (note == null)
                throw new NotFoundException($"No existe una nota con el id {id}");

            await _repository.DeleteAsync(note);
        }

        public async Task GenerateNotes(int quantity)
        {
            if (quantity < 1 || quantity > 10000)
                throw new ArgumentException(
                    "La cantidad debe estar entre 1 y 10000.");

            var students = await _studentRepository.GetAllAsync();
            var teachers = await _teacherRepository.GetAllAsync();

            if (!students.Any())
                throw new NotFoundException(
                    "No existen estudiantes para generar las notas.");

            if (!teachers.Any())
                throw new NotFoundException(
                    "No existen profesores para generar las notas.");

            var random = new Random();

            const int batchSize = 1000;

            for (int i = 0; i < quantity; i += batchSize)
            {
                var currentBatchSize = Math.Min(
                    batchSize,
                    quantity - i);

                var notes = new List<Note>();

                for (int j = 0; j < currentBatchSize; j++)
                {
                    var student = students[
                        random.Next(students.Count)];

                    var teacher = teachers[
                        random.Next(teachers.Count)];

                    notes.Add(new Note
                    {
                        Name = $"Nota {i + j + 1}",

                        Value = Math.Round(
                            (decimal)(random.NextDouble() * 5),
                            1),

                        StudentId = student.StudentId,
                        TeacherId = teacher.TeacherId
                    });
                }

                await _repository.AddRangeAsync(notes);
            }
        }
    }
}
