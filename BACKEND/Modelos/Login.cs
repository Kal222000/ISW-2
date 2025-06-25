using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BACKEND.Modelos;

public partial class Login
{
    [Key]
    public int UsuarioId { get; set; }

    public string? Contrasena { get; set; }

    public virtual Usuario Usuario { get; set; } = null!;
}
