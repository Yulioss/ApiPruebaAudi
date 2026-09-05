using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPruebaAudi.Domain.Entities
{
    public class Note
    {
        public int NoteId { get; set; }

        public required string Name { get; set; }

        public decimal Value { get; set; }

        public int StudentId { get; set; }
        public  Student? Student { get; set; }

        public int TeacherId { get; set; }
        public  Teacher? Teacher { get; set; }
    }
}
