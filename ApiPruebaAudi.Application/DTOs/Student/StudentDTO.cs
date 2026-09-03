using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPruebaAudi.Application.DTOs.Student
{
    public class StudentDTO
    {
        public int StudentId { get; set; }
        public required string Name { get; set; }
    }
}
