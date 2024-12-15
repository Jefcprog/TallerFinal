using System;
using System.Collections.Generic;

namespace TallerFinal.DTO.CONF;

public partial class Participante
{
    public int IdParticipante { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string? Compania { get; set; }

    public string? Telefono { get; set; }

    public string Email { get; set; } = null!;

    public string? Domicilio { get; set; }

    public string? CallesTransversales { get; set; }

    public string? Ciudad { get; set; }

    public string? Region { get; set; }

    public string? CodigoPostal { get; set; }

    public string? Pais { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string? UsuarioCrea { get; set; } = string.Empty;

    // Campos opcionales (nullable)
    public DateTime? FechaModificacion { get; set; }  // Fecha puede ser nula

    public string? UsuarioModifica { get; set; }  // Usuario puede ser nulo

    public bool Estado { get; set; } = false;

    public virtual ICollection<Participacion> Participacions { get; set; } = new List<Participacion>();
}
