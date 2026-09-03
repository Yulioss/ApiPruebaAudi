using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPruebaAudi.Application.DTOs.Note
{
    internal class NoteQueryDTO
    {
        public int Page { get; set; } = 1;

        public int PageSize { get; set; } = 10;

        public string? Search { get; set; }

        public int? StudentId { get; set; }

        public int? TeacherId { get; set; }

    }
}
