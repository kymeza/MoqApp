using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MoqApp.Models
{
    public partial class sistemaUsuariosContext : DbContext
    {
        public sistemaUsuariosContext()
        {
        }

        public sistemaUsuariosContext(DbContextOptions<sistemaUsuariosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cuenta> Cuentas { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<Transaccione> Transacciones { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Cuenta>(entity =>
            {
                entity.HasKey(e => new { e.CodigoUsuario, e.CodigoCuenta })
                    .HasName("PK_cuentas_1");

                entity.ToTable("cuentas");

                entity.Property(e => e.CodigoUsuario)
                    .HasMaxLength(64)
                    .HasColumnName("codigoUsuario");

                entity.Property(e => e.CodigoCuenta)
                    .HasMaxLength(64)
                    .HasColumnName("codigoCuenta");

                entity.Property(e => e.DescripcionCuenta)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("descripcionCuenta");

                entity.HasOne(d => d.CodigoUsuarioNavigation)
                    .WithMany(p => p.Cuenta)
                    .HasForeignKey(d => d.CodigoUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cuentas_usuarios");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.HasKey(e => new { e.CodigoUsuario, e.CodigoCuenta, e.LogId });

                entity.ToTable("logs");

                entity.Property(e => e.CodigoUsuario)
                    .HasMaxLength(64)
                    .HasColumnName("codigoUsuario");

                entity.Property(e => e.CodigoCuenta)
                    .HasMaxLength(64)
                    .HasColumnName("codigoCuenta");

                entity.Property(e => e.LogId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("logID");

                entity.Property(e => e.Fecha)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("fecha");

                entity.Property(e => e.Mensaje)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("mensaje");

                entity.HasOne(d => d.Codigo)
                    .WithMany(p => p.Logs)
                    .HasForeignKey(d => new { d.CodigoUsuario, d.CodigoCuenta })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_logs_cuentas");
            });

            modelBuilder.Entity<Transaccione>(entity =>
            {
                entity.HasKey(e => new { e.CodigoUsuario, e.CodigoCuenta, e.LineaTransaccion });

                entity.ToTable("transacciones");

                entity.Property(e => e.CodigoUsuario)
                    .HasMaxLength(64)
                    .HasColumnName("codigoUsuario");

                entity.Property(e => e.CodigoCuenta)
                    .HasMaxLength(64)
                    .HasColumnName("codigoCuenta");

                entity.Property(e => e.LineaTransaccion)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("lineaTransaccion");

                entity.Property(e => e.Monto).HasColumnName("monto");

                entity.HasOne(d => d.Codigo)
                    .WithMany(p => p.Transacciones)
                    .HasForeignKey(d => new { d.CodigoUsuario, d.CodigoCuenta })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_transacciones_cuentas1");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.CodigoUsuario);

                entity.ToTable("usuarios");

                entity.Property(e => e.CodigoUsuario)
                    .HasMaxLength(64)
                    .HasColumnName("codigoUsuario");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("email");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("password");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
