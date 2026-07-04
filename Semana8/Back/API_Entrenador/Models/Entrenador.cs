namespace API_Entrenador.Models
{
    public class Entrenador
    {
        public int EntrenadorId { get; set; }
        public string Nombre { get; set; }
        public string Especialidad { get; set; }

        // Relación 1:N
        public ICollection<Miembro> Miembros { get; set; }
    }
}
