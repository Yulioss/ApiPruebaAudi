using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPruebaAudi.Domain.Entities
{
    public class Student
    {
        public int StudentId { get; set; }
        public required string Name { get; set; }
        public ICollection<Note> Notes { get; set; } = new List<Note>();
    }
}
