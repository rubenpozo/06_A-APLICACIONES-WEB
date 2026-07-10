namespace Examen_Final.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Documento { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        // Relación: un cliente puede tener varias reservas
        public ICollection<Reserva> Reservas { get; set; }
    }
}
