using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BarberSoft.Models
{
    public partial class barber_softContext : DbContext
    {
        public barber_softContext()
        {
        }

        public barber_softContext(DbContextOptions<barber_softContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Empleados> Empleados { get; set; }
        public virtual DbSet<Servicios> Servicios { get; set; }
        public virtual DbSet<Ventas> Ventas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-939J3ID\\MSSQLSERVER1;Database=barber_soft;Trusted_Connection=True;");
                //optionsBuilder.UseSqlServer("Server=LAPTOP-I5VQ1DH4;Database=barber_soft;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empleados>(entity =>
            {
                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Documento)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Servicios>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Precio)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Ventas>(entity =>
            {
                entity.HasOne(d => d.Empleado)
                    .WithMany(p => p.Ventas)
                    .HasForeignKey(d => d.EmpleadoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ventas_Empleados");

                entity.HasOne(d => d.Servicio)
                    .WithMany(p => p.Ventas)
                    .HasForeignKey(d => d.ServicioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ventas_Servicios");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
