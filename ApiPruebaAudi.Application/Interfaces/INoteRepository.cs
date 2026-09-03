using ApiPruebaAudi.Application.DTOs.Note;
using ApiPruebaAudi.Application.DTOs;
using ApiPruebaAudi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPruebaAudi.Application.Interfaces
{
    public interface INoteRepository
    {
        Task<Note> AddAsync(Note note);
        Task<List<Note>> GetAllAsync();
        Task<Note?> GetByIdAsync(int id);
        Task UpdateAsync(Note note);
        Task DeleteAsync(Note note);
        Task<PagedResponse<NoteDTO>> GetPagedAsync(
        int pageNumber,
        int pageSize);
    }
}
