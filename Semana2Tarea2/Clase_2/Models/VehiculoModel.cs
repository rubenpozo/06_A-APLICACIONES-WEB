using System.ComponentModel.DataAnnotations;

namespace Clase_2.Models
{

public class Vehiculo
    {
        [Key] // Clave primaria
        public int Id { get; set; }

        [Required(ErrorMessage = "La marca es obligatoria")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "La marca debe tener entre 2 y 50 caracteres")]
        public string Marca { get; set; } = string.Empty;

        [Required(ErrorMessage = "El modelo es obligatorio")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "El modelo debe tener entre 2 y 50 caracteres")]
        public string Modelo { get; set; } = string.Empty;

        [Required(ErrorMessage = "La placa es obligatoria")]
        [RegularExpression(@"^[A-Z]{3}-\d{3,4}$", ErrorMessage = "Formato de placa inválido (ejemplo: ABC-1234)")]
        public string Placa { get; set; } = string.Empty;

        [Required(ErrorMessage = "El año de fabricación es obligatorio")]
        [Range(1900, 2100, ErrorMessage = "El año de fabricación debe estar entre 1900 y 2100")]
        public string Anio_Fabricacion { get; set; } = string.Empty;

        [Required(ErrorMessage = "El kilometraje es obligatorio")]
        [RegularExpression(@"^\d+$", ErrorMessage = "El kilometraje debe ser un número entero")]
        public string Kilometraje { get; set; } = string.Empty;

    }
}
