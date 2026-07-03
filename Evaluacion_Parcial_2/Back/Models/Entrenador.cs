using System.ComponentModel.DataAnnotations;

namespace EvaluacionParcial2.Models
{
    public class Entrenador
    {
        [Key]
        public int EntrenadorId { get; set; }

        [Required, MaxLength(50)]
        public string Nombre { get; set; }

        [Required, MaxLength(50)]
        public string Especialidad { get; set; }

        [Phone]
        public string Telefono { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        // Relación: un entrenador puede tener varias sesiones
        public ICollection<SesionEntrenamiento> Sesiones { get; set; }
    }
}
