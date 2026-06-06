using System;
using System.Collections.Generic;

namespace EncuestasApp.Models;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string Rol { get; set; } = null!;

    public virtual ICollection<Encuesta> Encuesta { get; set; } = new List<Encuesta>();

    public virtual ICollection<Respuesta> Respuesta { get; set; } = new List<Respuesta>();
}
