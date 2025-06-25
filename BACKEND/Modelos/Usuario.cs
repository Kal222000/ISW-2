using System;
using System.Collections.Generic;

namespace BACKEND.Modelos;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string? Nombre { get; set; }

    public string? ApellidoPaterno { get; set; }

    public string? ApellidoMaterno { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public int? Carnet { get; set; }

    public int? Rol { get; set; }

    public virtual Login? Login { get; set; }

    public virtual ICollection<SolicitudReserva> SolicitudReservas { get; set; } = new List<SolicitudReserva>();
}
