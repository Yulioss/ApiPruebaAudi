using ApiPruebaAudi.Application.DTOs;
using ApiPruebaAudi.Application.DTOs.Note;
using ApiPruebaAudi.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiPruebaAudi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    var notes = await _noteService.GetAllAsync();

        //    return Ok(notes);
        //}

        [HttpGet]
        public async Task<IActionResult> GetNotes(
        int pageNumber = 1,
        int pageSize = 10, 
        string? searchTerm = null)
        {
            var result = await _noteService.GetNotes(
                pageNumber,
                pageSize,
                searchTerm);

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var note = await _noteService.GetById(id);

            if (note == null)
                return NotFound(new
                {
                    message = "Nota no encontrada."
                });

            return Ok(note);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreateNoteDTO dto)
        {
            var note = await _noteService.Create(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = note.NoteId },
                note);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(
            int id,
            [FromBody] CreateNoteDTO dto)
        {
            await _noteService.Update(id, dto);

            return Ok(new
            {
                Message = $"Nota actualizada."
            });
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _noteService.Delete(id);

            return Ok(new
            {
                Message = $"Nota eliminada."
            });
        }

        [HttpPost("Generate")]
        public async Task<IActionResult> GenerateNotes(
        [FromBody] GenerateNotesDTO dto)
        {
            await _noteService.GenerateNotes(dto.Quantity);

            return Ok(new
            {
                message = $"Se generaron {dto.Quantity} notas correctamente."
            });
        }
    }
}

