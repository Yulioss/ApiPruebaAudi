using ApiPruebaAudi.Application.DTOs;
using ApiPruebaAudi.Application.DTOs.Student;
using ApiPruebaAudi.Application.DTOs.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPruebaAudi.Application.Interfaces
{
    public interface ITeacherService
    {
        Task<TeacherDTO> Create(CreateTeacherDTO dto);
        Task<TeacherDTO> GetById(int id);
        Task<IEnumerable<TeacherDTO>> GetAllAsync();
        Task<PagedResponse<TeacherDTO>> GetTeachers(
        int pageNumber,
        int pageSize, 
        string? searchTerm = null);
        Task Update(int id, CreateTeacherDTO dto);
        Task Delete(int id);
    }
}
