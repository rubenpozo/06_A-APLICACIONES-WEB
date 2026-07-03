using System.ComponentModel.DataAnnotations;

namespace EvaluacionParcial2.Models
{
    public class Miembro
    {
        [Key]
        public int MiembroId { get; set; }

        [Required, MaxLength(50)]
        public string Nombre { get; set; }

        [Required, MaxLength(50)]
        public string Apellido { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        [Required, MaxLength(30)]
        public string TipoMembresia { get; set; }

        // Relación: un miembro puede tener varias sesiones
        public ICollection<SesionEntrenamiento> Sesiones { get; set; }
    }
}
