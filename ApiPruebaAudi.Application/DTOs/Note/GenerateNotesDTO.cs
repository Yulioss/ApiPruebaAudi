using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPruebaAudi.Application.DTOs.Note
{
    public class GenerateNotesDTO
    {
        [Range(1, 10000,
            ErrorMessage = "La cantidad debe estar entre 1 y 10000.")]
        public int Quantity { get; set; }
    }
}
