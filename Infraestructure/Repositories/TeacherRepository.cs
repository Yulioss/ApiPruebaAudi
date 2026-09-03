using ApiPruebaAudi.Application.DTOs.Student;
using ApiPruebaAudi.Application.DTOs;
using ApiPruebaAudi.Domain.Entities;
using ApiPruebaAudi.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiPruebaAudi.Application.DTOs.Teacher;
using ApiPruebaAudi.Application.Interfaces;

namespace ApiPruebaAudi.Infraestructure.Repositories
{
    public class TeacherRepository: ITeacherRepository
    {
        private readonly AppDbContext _context;

        public TeacherRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Teacher> AddAsync(Teacher teacher)
        {
            await _context.Teachers.AddAsync(teacher);

            await _context.SaveChangesAsync();

            return teacher;
        }

        public async Task UpdateAsync(Teacher teacher)
        {
            _context.Teachers.Update(teacher);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Teacher teacher)
        {
            _context.Teachers.Remove(teacher);

            await _context.SaveChangesAsync();
        }

        public async Task<List<Teacher>> GetAllAsync()
        {
            return await _context.Teachers
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<PagedResponse<TeacherDTO>> GetPagedAsync(
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
                .Select(x => new TeacherDTO
                {
                    TeacherId = x.TeacherId,
                    Name = x.Name
                })
                .ToListAsync();

            return new PagedResponse<TeacherDTO>
            {
                Items = student,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalItems = totalItems,
                TotalPages = (int)Math.Ceiling(
                    totalItems / (double)pageSize)
            };
        }

        public async Task<Teacher?> GetByIdAsync(int id)
        {
            return await _context.Teachers
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.TeacherId == id);
        }
    }
}
