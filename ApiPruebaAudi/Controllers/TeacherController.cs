using ApiPruebaAudi.Application.DTOs;
using ApiPruebaAudi.Application.DTOs.Teacher;
using ApiPruebaAudi.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiPruebaAudi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeachersController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    var teachers = await _teacherService.GetAllAsync();

        //    return Ok(teachers);
        //}

        [HttpGet]
        public async Task<IActionResult> GetTeachers(
        int pageNumber = 1,
        int pageSize = 10,
        string? searchTerm = null)
        {
            var result = await _teacherService.GetTeachers(
                pageNumber,
                pageSize,
                searchTerm);

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var teacher = await _teacherService.GetById(id);

            if (teacher == null)
                return NotFound(new
                {
                    message = "Profesor no encontrado."
                });

            return Ok(teacher);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreateTeacherDTO dto)
        {
            var teacher = await _teacherService.Create(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = teacher.TeacherId },
                teacher);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(
            int id,
            [FromBody] CreateTeacherDTO dto)
        {
            await _teacherService.Update(id, dto);

            return Ok(new
            {
                Message = $"Profesor actualizado."
            });
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _teacherService.Delete(id);

            return Ok(new
            {
                Message = $"Profesor eliminado."
            });
        }
    }
}
