using ApiPruebaAudi.Application.DTOs.Teacher;
using ApiPruebaAudi.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPruebaAudi.Application.Mapings
{
    public class TeacherProfile : Profile
    {
        public TeacherProfile()
        {
            CreateMap<CreateTeacherDTO, Teacher>();

            CreateMap<Teacher, TeacherDTO>();
        }
    }
}
