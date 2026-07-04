namespace API_Entrenador.Models
{
    public class EntrenadorDto
    {
        public int EntrenadorId { get; set; }
        public string Nombre { get; set; }
        public string Especialidad { get; set; }
        public List<MiembroDto> Miembros { get; set; }
    }
}
