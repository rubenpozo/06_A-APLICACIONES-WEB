using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Examen_Final.Models
{
    public class Reserva
    {
        public int ReservaId { get; set; }
        public int ClienteId { get; set; }
        public int HabitacionId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        // Relaciones
        public Cliente Cliente { get; set; }
        public Habitacion Habitacion { get; set; }
        public ICollection<Pago> Pagos { get; set; }
    }
}
