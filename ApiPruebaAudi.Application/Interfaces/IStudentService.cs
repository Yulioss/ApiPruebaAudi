using ApiPruebaAudi.Application.DTOs;
using ApiPruebaAudi.Application.DTOs.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPruebaAudi.Application.Interfaces
{
     public interface IStudentService
    {
        Task<StudentDTO> Create(CreateStudentDTO dto);
        Task<StudentDTO> GetById(int id);
        Task<IEnumerable<StudentDTO>> GetAllAsync();
        Task<PagedResponse<StudentDTO>> GetStudents(
        int pageNumber,
        int pageSize);
        Task Update(int id, CreateStudentDTO dto);
        Task Delete(int id);
    }
}
