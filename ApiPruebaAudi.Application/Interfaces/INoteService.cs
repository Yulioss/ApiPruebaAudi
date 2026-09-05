using ApiPruebaAudi.Application.DTOs;
using ApiPruebaAudi.Application.DTOs.Note;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPruebaAudi.Application.Interfaces
{
    public interface INoteService
    {
        Task<NoteDTO> Create(CreateNoteDTO dto);
        Task<IEnumerable<NoteDTO>> GetAllAsync();
        Task<PagedResponse<NoteDTO>> GetNotes(
        int pageNumber,
        int pageSize,
        string? searchTerm = null);
        Task<NoteDTO> GetById(int id);
        Task Update(int id, CreateNoteDTO dto);
        Task Delete(int id);
        Task GenerateNotes(int quantity);
    }
}
