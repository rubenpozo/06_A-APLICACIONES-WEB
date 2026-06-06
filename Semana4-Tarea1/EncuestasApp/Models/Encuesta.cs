using System;
using System.Collections.Generic;

namespace EncuestasApp.Models;

public partial class Encuesta
{
    public int EncuestaId { get; set; }

    public string Titulo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public DateOnly FechaCreacion { get; set; }

    public int? UsuarioId { get; set; }

    public string Estado { get; set; } = null!;

    public virtual ICollection<Pregunta> Pregunta { get; set; } = new List<Pregunta>();

    public virtual Usuario? Usuario { get; set; }
}
