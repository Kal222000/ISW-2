using System;
using System.Collections.Generic;
using BACKEND.Modelos;
using Microsoft.EntityFrameworkCore;

namespace BACKEND.Datos.SQL;

public partial class SQLConexion : DbContext
{
    public SQLConexion()
    {
    }

    public virtual DbSet<Login> Logins { get; set; }

    public virtual DbSet<PrestamosExitoso> PrestamosExitosos { get; set; }

    public virtual DbSet<ReservaDetalle> ReservaDetalles { get; set; }

    public virtual DbSet<SolicitudReserva> SolicitudReservas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder configuraciones)
    {
        configuraciones.UseSqlServer("Server=S1\\SQLEXPRESS;Database=BaseFinal3;Integrated Security=True;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PrestamosExitoso>()
            .HasKey(p => p.ReservaDetalleId); // clave primaria

        // Configura otras entidades si es necesario
    }
}
