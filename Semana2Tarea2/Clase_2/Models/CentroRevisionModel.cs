using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Clase_2.Models
{
    public class CentroRevision
    {
        [Key]
        public int CentroRevisionId { get; set; }

        [Required]
        [StringLength(150)]
        public string Nombre { get; set; } = string.Empty;

        // FK hacia Provincia
        [Required]
        public int ProvinciaId { get; set; }

        [ValidateNever] // <- evita que se valide en el ModelState
        public Provincia Provincia { get; set; } = null!;
    }
}
