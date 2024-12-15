using System;
using System.Collections.Generic;

namespace TallerFinal.DTO.CONF;

public partial class Conferencia
{
    public int IdConferencia { get; set; }

    public string Titulo { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public string Lugar { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public string? UsuarioCrea { get; set; } = string.Empty;

    // Campos opcionales (nullable)
    public DateTime? FechaModificacion { get; set; }  // Fecha puede ser nula

    public string? UsuarioModifica { get; set; }  // Usuario puede ser nulo

    public bool Estado { get; set; } = false;

    public virtual ICollection<Participacion> Participacions { get; set; } = new List<Participacion>();
}
