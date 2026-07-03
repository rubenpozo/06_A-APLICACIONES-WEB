using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvaluacionParcial2.Models
{
    public class SesionEntrenamiento
    {
        [Key]
        public int SesionId { get; set; }

        [Required]
        public DateTime FechaSesion { get; set; }

        [Required]
        public int Duracion { get; set; } // minutos

        [Required, MaxLength(50)]
        public string TipoSesion { get; set; }

        // Relaciones
        [ForeignKey("Miembro")]
        public int MiembroId { get; set; }
        public Miembro Miembro { get; set; }

        [ForeignKey("Entrenador")]
        public int EntrenadorId { get; set; }
        public Entrenador Entrenador { get; set; }
    }
}
