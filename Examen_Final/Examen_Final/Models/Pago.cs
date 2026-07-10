namespace Examen_Final.Models
{
    public class Pago
    {
        public int PagoId { get; set; }
        public int ReservaId { get; set; }
        public decimal Monto { get; set; }
        public string MetodoPago { get; set; } // Efectivo, Tarjeta, Transferencia
        public DateTime FechaPago { get; set; }

        // Relación
        public Reserva Reserva { get; set; }
    }
}
