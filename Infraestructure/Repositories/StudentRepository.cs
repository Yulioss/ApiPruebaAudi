using ApiPruebaAudi.Application.DTOs.Note;
using ApiPruebaAudi.Application.DTOs;
using ApiPruebaAudi.Domain.Entities;
using ApiPruebaAudi.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiPruebaAudi.Application.DTOs.Student;

namespace ApiPruebaAudi.Infraestructure.Repositories
{
    public class StudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Student> AddAsync(Student student)
        {
            await _context.Students.AddAsync(student);

            await _context.SaveChangesAsync();

            return student;
        }

        public async Task UpdateAsync(Student student)
        {
            _context.Students.Update(student);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Student student)
        {
            _context.Students.Remove(student);

            await _context.SaveChangesAsync();
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _context.Students
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<PagedResponse<StudentDTO>> GetPagedAsync(
       int pageNumber,
       int pageSize)
        {
            var query = _context.Notes
                .AsNoTracking();

            var totalItems = await query.CountAsync();

            var student = await query
                .OrderBy(x => x.NoteId)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(x => new StudentDTO
                {
                    StudentId = x.StudentId,
                    Name = x.Name
                })
                .ToListAsync();

            return new PagedResponse<StudentDTO>
            {
                Items = student,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalItems = totalItems,
                TotalPages = (int)Math.Ceiling(
                    totalItems / (double)pageSize)
            };
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            return await _context.Students
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.StudentId == id);
        }
    }
}
