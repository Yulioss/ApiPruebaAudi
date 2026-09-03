using ApiPruebaAudi.Application.DTOs.Note;
using ApiPruebaAudi.Application.DTOs;
using ApiPruebaAudi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiPruebaAudi.Application.DTOs.Student;

namespace ApiPruebaAudi.Application.Interfaces
{
    public interface IStudentRepository
    {
        Task<Student> AddAsync(Student student);
        Task<List<Student>> GetAllAsync();
        Task<Student?> GetByIdAsync(int id);
        Task UpdateAsync(Student student);
        Task DeleteAsync(Student student);
        Task<PagedResponse<StudentDTO>> GetPagedAsync(
        int pageNumber,
        int pageSize);
    }
}
