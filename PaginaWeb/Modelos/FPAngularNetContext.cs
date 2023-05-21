using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PaginaWeb.Modelos
{
    public partial class FPAngularNetContext : DbContext
    {
        public FPAngularNetContext()
        {
        }

        public FPAngularNetContext(DbContextOptions<FPAngularNetContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Candidatura> Candidaturas { get; set; } = null!;
        public virtual DbSet<DetalleCandidatura> DetalleCandidaturas { get; set; } = null!;
        public virtual DbSet<Proceso> Procesos { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Configuracion de la base de datos para conectar y que no este hardcodeada
            if (!optionsBuilder.IsConfigured)
            {   
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("SQL"));
                //optionsBuilder.UseSqlServer("Data Source=DESKTOP-52FC49J;Initial Catalog=FPAngularNet;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidatura>(entity =>
            {
                entity.HasKey(e => e.IdCandidatura);

                entity.ToTable("Candidatura");

                entity.Property(e => e.Empresa)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.FechaAlta).HasColumnType("datetime");

                entity.Property(e => e.FechaBaja).HasColumnType("datetime");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Candidaturas)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Candidatura_Usuarios");
            });

            modelBuilder.Entity<DetalleCandidatura>(entity =>
            {
                entity.HasKey(e => e.IdDetalleCandidatura);

                entity.ToTable("DetalleCandidatura");

                entity.HasOne(d => d.IdCandidaturaNavigation)
                    .WithMany(p => p.DetalleCandidaturas)
                    .HasForeignKey(d => d.IdCandidatura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetalleCandidatura_Candidatura");

                entity.HasOne(d => d.IdProcesoNavigation)
                    .WithMany(p => p.DetalleCandidaturas)
                    .HasForeignKey(d => d.IdProceso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetalleCandidatura_Procesos");
            });

            modelBuilder.Entity<Proceso>(entity =>
            {
                entity.HasKey(e => e.IdProceso);

                entity.Property(e => e.Cliente)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(1000)
                    .IsFixedLength();

                entity.Property(e => e.FechaAlta).HasColumnType("datetime");

                entity.Property(e => e.FechaBaja).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.FechaAlta).HasColumnType("datetime");

                entity.Property(e => e.FechaBaja).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.Password).HasMaxLength(500);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
