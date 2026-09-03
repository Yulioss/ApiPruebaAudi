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

        public required string Name { get; set; }

        public decimal Value { get; set; }

        public int StudentId { get; set; }

        public int TeacherId { get; set; }
    }
}
