using System.ComponentModel.DataAnnotations;

namespace Web_Clientes.Models
{
    public class ClienteModel
    {
        [Key] // Marca como clave primaria
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 50 caracteres")]
        public string Nombres { get; set; } = string.Empty;

        [Required(ErrorMessage = "El apellido es obligatorio")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "El apellido debe tener entre 2 y 50 caracteres")]
        public string Apellidos { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "La dirección no puede superar los 100 caracteres")]
        public string Direccion { get; set; } = string.Empty;

        [Phone(ErrorMessage = "Formato de teléfono inválido")]
        [StringLength(15, ErrorMessage = "El teléfono no puede superar los 15 caracteres")]
        public string Telefono { get; set; } = string.Empty;

        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress(ErrorMessage = "Formato de correo inválido")]
        public string Correo { get; set; } = string.Empty;
    }
}
