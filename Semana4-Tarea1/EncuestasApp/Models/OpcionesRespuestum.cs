using System;
using System.Collections.Generic;

namespace EncuestasApp.Models;

public partial class OpcionesRespuestum
{
    public int OpcionId { get; set; }

    public string Texto { get; set; } = null!;

    public int? PreguntaId { get; set; }

    public int Valor { get; set; }

    public bool Activa { get; set; }

    public virtual Pregunta? Pregunta { get; set; }

    public virtual ICollection<Respuesta> Respuesta { get; set; } = new List<Respuesta>();
}
