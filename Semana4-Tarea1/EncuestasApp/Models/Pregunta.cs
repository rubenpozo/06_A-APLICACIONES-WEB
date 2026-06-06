using System;
using System.Collections.Generic;

namespace EncuestasApp.Models;

public partial class Pregunta
{
    public int PreguntaId { get; set; }

    public string Texto { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public int? EncuestaId { get; set; }

    public int Orden { get; set; }

    public bool Obligatoria { get; set; }

    public virtual Encuesta? Encuesta { get; set; }

    public virtual ICollection<OpcionesRespuestum> OpcionesRespuesta { get; set; } = new List<OpcionesRespuestum>();

    public virtual ICollection<Respuesta> Respuesta { get; set; } = new List<Respuesta>();
}
