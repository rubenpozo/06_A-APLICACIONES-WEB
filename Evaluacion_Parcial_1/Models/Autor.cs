using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Evaluacion_Parcial_1.Models
{
    public class Autor
    {
        [Key]
        public int AutorId { get; set; }

        [Required, MaxLength(50)]
        public string Nombre { get; set; }

        [Required, MaxLength(50)]
        public string Apellido { get; set; }

        public DateTime FechaNacimiento { get; set; }

        [MaxLength(50)]
        public string Nacionalidad { get; set; }

        // Relación: un autor puede tener muchos libros
        [ValidateNever]
        public ICollection<Libro> Libros { get; set; }
    }
}
