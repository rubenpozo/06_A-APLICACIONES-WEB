using System;
using System.Collections.Generic;

namespace EncuestasApp.Models;

public partial class Respuesta
{
    public int RespuestaId { get; set; }

    public int? UsuarioId { get; set; }

    public int? PreguntaId { get; set; }

    public int? OpcionId { get; set; }

    public string? TextoLibre { get; set; }

    public DateOnly FechaRespuesta { get; set; }

    public virtual OpcionesRespuestum? Opcion { get; set; }

    public virtual Pregunta? Pregunta { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
