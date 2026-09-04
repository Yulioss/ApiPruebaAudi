using ApiPruebaAudi.Application.DTOs.Note;
using ApiPruebaAudi.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPruebaAudi.Application.Mapings
{
    public class NoteProfile : Profile
    {
        public NoteProfile()
        {
            CreateMap<CreateNoteDTO, Note>();

            CreateMap<Note, NoteDTO>()
            .ForMember(
                dest => dest.StudentName,
                opt => opt.MapFrom(src => src.Student.Name))
            .ForMember(
                dest => dest.TeacherName,
                opt => opt.MapFrom(src => src.Teacher.Name));
        }
    }
}
