using ApiPruebaAudi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPruebaAudi.Application.DTOs.Note
{
    public class NoteDTO
    {
        public int NoteId { get; set; }

        public  string Name { get; set; } = string.Empty;

        public decimal Value { get; set; }

        public int StudentId { get; set; }
        public string StudentName { get; set; } = string.Empty;

        public int TeacherId { get; set; }
        public string TeacherName { get; set; } = string.Empty;
    }
}
