using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPruebaAudi.Application.DTOs.Teacher
{
    public class CreateTeacherDTO
    {
        [Required(ErrorMessage = "El nombre de el profesor es obligatorio.")]
        [StringLength(50, MinimumLength = 2,
            ErrorMessage = "El nombre debe tener entre 2 y 50 caracteres.")]
        public required string Name { get; set; }
    }
}
