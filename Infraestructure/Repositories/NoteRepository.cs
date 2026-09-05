using ApiPruebaAudi.Application.DTOs;
using ApiPruebaAudi.Application.DTOs.Note;
using ApiPruebaAudi.Application.Interfaces;
using ApiPruebaAudi.Domain.Entities;
using ApiPruebaAudi.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPruebaAudi.Infraestructure.Repositories
{
    public class NoteRepository: INoteRepository
    {
        private readonly AppDbContext _context;

        public NoteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Note> AddAsync(Note note)
        {
            await _context.Notes.AddAsync(note);

            await _context.SaveChangesAsync();

            return note;
        }

        public async Task UpdateAsync(Note note)
        {
            _context.Notes.Update(note);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Note note)
        {
            _context.Notes.Remove(note);

            await _context.SaveChangesAsync();
        }

        public async Task<List<Note>> GetAllAsync()
        {
            return await _context.Notes
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<PagedResponse<Note>> GetPagedAsync(
        int pageNumber,
        int pageSize,
        string? searchTerm = null)
        {
            IQueryable<Note> query = _context.Notes
                .AsNoTracking()
                .Include(x => x.Student)
                .Include(x => x.Teacher);

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var term = searchTerm.Trim().ToLower();

                query = query.Where(x =>
                    x.Name.ToLower().Contains(term) ||
                    x.Value.ToString().Contains(term) ||
                    x.Student.Name.ToLower().Contains(term) ||
                    x.Teacher.Name.ToLower().Contains(term));
            }

            var totalItems = await query.CountAsync();

            var notes = await query
                .OrderBy(x => x.NoteId)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResponse<Note>
            {
                Items = notes,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalItems = totalItems,
                TotalPages = (int)Math.Ceiling(
                    totalItems / (double)pageSize)
            };
        }

        public async Task<Note?> GetByIdAsync(int id)
        {
            return await _context.Notes
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.TeacherId == id);
        }
    }
}
