using ApiPruebaAudi.Application.DTOs;
using ApiPruebaAudi.Application.DTOs.Student;
using ApiPruebaAudi.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiPruebaAudi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    var students = await _studentService.GetAllAsync();

        //    return Ok(students);
        //}

        [HttpGet]
        public async Task<IActionResult> GetStudents(
        int pageNumber = 1,
        int pageSize = 10,
        string? searchTerm = null)
        {
            var result = await _studentService.GetStudents(
                pageNumber,
                pageSize,
                searchTerm);

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var student = await _studentService.GetById(id);

            if (student == null)
                return NotFound(new
                {
                    message = "Estudiante no encontrado."
                });

            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreateStudentDTO dto)
        {
            var student = await _studentService.Create(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = student.StudentId },
                student);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(
            int id,
            [FromBody] CreateStudentDTO dto)
        {
            await _studentService.Update(id, dto);

            return Ok(new
            {
                Message = $"Estudiante actualizado."
            });
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _studentService.Delete(id);

            return Ok(new
            {
                Message = $"Estudiante eliminado."
            });
        }
    }
}
