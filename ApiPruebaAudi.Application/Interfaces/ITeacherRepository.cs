using ApiPruebaAudi.Application.DTOs.Student;
using ApiPruebaAudi.Application.DTOs;
using ApiPruebaAudi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiPruebaAudi.Application.DTOs.Teacher;

namespace ApiPruebaAudi.Application.Interfaces
{
    public interface ITeacherRepository
    {
        Task<Teacher> AddAsync(Teacher teacher);
        Task<List<Teacher>> GetAllAsync();
        Task<Teacher?> GetByIdAsync(int id);
        Task UpdateAsync(Teacher teacher);
        Task DeleteAsync(Teacher teacher);
        Task<PagedResponse<Teacher>> GetPagedAsync(
        int pageNumber,
        int pageSize);
    }
}
