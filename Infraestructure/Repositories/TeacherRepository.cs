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

        public async Task<PagedResponse<Teacher>> GetPagedAsync(
        int pageNumber,
        int pageSize,
        string? searchTerm = null)
        {
            var query = _context.Teachers
                .AsNoTracking();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(x =>
                    x.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            var totalItems = await query.CountAsync();

            var teachers = await query
                .OrderBy(x => x.TeacherId)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResponse<Teacher>
            {
                Items = teachers,
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
