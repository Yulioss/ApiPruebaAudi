using ApiPruebaAudi.Application.DTOs.Student;
using ApiPruebaAudi.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPruebaAudi.Application.Mapings
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<CreateStudentDTO, Student>();

            CreateMap<Student, StudentDTO>();
        }
    }
}
