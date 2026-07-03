namespace EvaluacionParcial2.Models
{
    public class SesionDTO
    {
        public int SesionId { get; set; }
        public DateTime FechaSesion { get; set; }
        public int Duracion { get; set; }
        public string TipoSesion { get; set; }

        // Datos simplificados de relaciones
        public string MiembroNombre { get; set; }
        public string EntrenadorNombre { get; set; }
    }
}
