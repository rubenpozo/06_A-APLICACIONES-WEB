using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Examen_Final.Models
{
    public class Habitacion
    {
        public int HabitacionId { get; set; }
        public string Numero { get; set; }
        public string Tipo { get; set; }
        public decimal PrecioNoche { get; set; }
        public string Estado { get; set; } // Disponible, Ocupada, Mantenimiento

        [ValidateNever]
        // Relación: una habitación puede tener varias reservas
        public ICollection<Reserva> Reservas { get; set; }
    }
}
