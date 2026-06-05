using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Evaluacion_Parcial_1.Models
{
    public class Libro
    {
        [Key]
        public int LibroId { get; set; }

        [Required, MaxLength(150)]
        public string Titulo { get; set; }

        [MaxLength(50)]
        public string Genero { get; set; }

        public DateTime FechaPublicacion { get; set; }

        [MaxLength(20)]
        public string ISBN { get; set; }

        // Relación: un libro pertenece a un autor
        public int AutorId { get; set; }

        [ValidateNever]
        public Autor Autor { get; set; }
    }
}
