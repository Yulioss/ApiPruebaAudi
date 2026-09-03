using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPruebaAudi.Application.DTOs.Teacher
{
    public class TeacherDTO
    {
        public int TeacherId { get; set; }
        public required string Name { get; set; }
    }
}
