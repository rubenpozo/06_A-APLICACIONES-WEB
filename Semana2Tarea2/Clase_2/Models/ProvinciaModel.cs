using System.ComponentModel.DataAnnotations;

namespace Clase_2.Models
{
    public class Provincia
    {
        [Key]
        public int ProvinciaId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        // Relación con CentroRevision
        public ICollection<CentroRevision> CentrosRevision { get; set; } = new List<CentroRevision>();
    }
}
