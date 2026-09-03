using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPruebaAudi.Application.DTOs.Note
{
    public class CreateNoteDTO
    {
        [Required(ErrorMessage = "El nombre de la nota es obligatorio.")]
        [StringLength(50, MinimumLength = 2,
            ErrorMessage = "El nombre debe tener entre 2 y 50 caracteres.")]
        public required string Name { get; set; }

        [Range(0.0, 5.0,
            ErrorMessage = "La nota debe estar entre 0 y 5.")]
        public decimal Value { get; set; }

        [Range(1, int.MaxValue,
            ErrorMessage = "Debe seleccionar un estudiante válido.")]
        public int StudentId { get; set; }

        [Range(1, int.MaxValue,
            ErrorMessage = "Debe seleccionar un profesor válido.")]
        public int TeacherId { get; set; }
    }
}
