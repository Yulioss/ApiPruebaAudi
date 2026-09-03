using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPruebaAudi.Domain.Entities
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public required string  Name { get; set; }
        public ICollection<Note> Notes { get; set; } = new List<Note>();
    }
}
