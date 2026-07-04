namespace API_Entrenador.Models
{
    public class Miembro
    {
        public int MiembroId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        // FK
        public int EntrenadorId { get; set; }
        public Entrenador Entrenador { get; set; }
    }
}
