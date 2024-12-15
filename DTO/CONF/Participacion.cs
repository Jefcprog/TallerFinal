using System;
using System.Collections.Generic;

namespace TallerFinal.DTO.CONF;

public partial class Participacion
{
    public int IdParticipacion { get; set; }

    public int IdParticipante { get; set; }

    public int IdConferencia { get; set; }

    public string? Sesion { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string? UsuarioCrea { get; set; } = string.Empty;

    // Campos opcionales (nullable)
    public DateTime? FechaModificacion { get; set; }  // Fecha puede ser nula

    public string? UsuarioModifica { get; set; }  // Usuario puede ser nulo

    public bool Estado { get; set; } = false;


    public virtual Conferencia IdConferenciaNavigation { get; set; } = null!;

    public virtual Participante IdParticipanteNavigation { get; set; } = null!;
}
