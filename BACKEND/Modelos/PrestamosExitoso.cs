using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BACKEND.Modelos;

public partial class PrestamosExitoso
{
    [Key]
    public int ReservaDetalleId { get; set; }

    public DateTime? FechaRecogida { get; set; }

    public DateOnly? FechaVencimientoPrestamo { get; set; }

    public DateTime? FechaDevolucionReal { get; set; }

    public virtual ReservaDetalle ReservaDetalle { get; set; } = null!;
}
