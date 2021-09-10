using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PipayWallet.Models
{
    public partial class pilacortadaContext : DbContext
    {
        public pilacortadaContext()
        {
        }

        public pilacortadaContext(DbContextOptions<pilacortadaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contacto> Contactos { get; set; }
        public virtual DbSet<Cuenta> Cuentas { get; set; }
        public virtual DbSet<DatosDeUsuario> DatosDeUsuarios { get; set; }
        public virtual DbSet<Domicilio> Domicilios { get; set; }
        public virtual DbSet<Operacion> Operacions { get; set; }
        public virtual DbSet<TipoOperacione> TipoOperaciones { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=DESKTOP-2EM8Q0T;Database=pil-acortada;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Contacto>(entity =>
            {
                entity.HasKey(e => e.IdContacto);

                entity.Property(e => e.IdContacto)
                    .ValueGeneratedNever()
                    .HasColumnName("id_contacto");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.IdUsuarioagendado).HasColumnName("id_usuarioagendado");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Contactos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_Contactos_Usuarios");
            });

            modelBuilder.Entity<Cuenta>(entity =>
            {
                entity.HasKey(e => e.IdCuenta);

                entity.Property(e => e.IdCuenta).HasColumnName("id_cuenta");

                entity.Property(e => e.Alias)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("alias");

                entity.Property(e => e.Cvu)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CVU");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Saldo).HasColumnName("saldo");

                entity.Property(e => e.TipoCuenta)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tipo_cuenta");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Cuenta)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_Cuentas_Usuarios");
            });

            modelBuilder.Entity<DatosDeUsuario>(entity =>
            {
                entity.HasKey(e => e.IdDatousuario);

                entity.ToTable("Datos de Usuarios");

                entity.Property(e => e.IdDatousuario).HasColumnName("id_datousuario");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("apellido");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("fecha_nacimiento");

                entity.Property(e => e.IdDomicilio).HasColumnName("id_domicilio");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("telefono");

                entity.HasOne(d => d.IdDomicilioNavigation)
                    .WithMany(p => p.DatosDeUsuarios)
                    .HasForeignKey(d => d.IdDomicilio)
                    .HasConstraintName("FK_Datos de Usuarios_Domicilios");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.DatosDeUsuarios)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Datos de Usuarios_Usuarios");
            });

            modelBuilder.Entity<Domicilio>(entity =>
            {
                entity.HasKey(e => e.IdDomicilio);

                entity.Property(e => e.IdDomicilio).HasColumnName("id_domicilio");

                entity.Property(e => e.Altura)
                    .HasMaxLength(10)
                    .HasColumnName("altura")
                    .IsFixedLength(true);

                entity.Property(e => e.Barrio)
                    .HasMaxLength(10)
                    .HasColumnName("barrio")
                    .IsFixedLength(true);

                entity.Property(e => e.Calle)
                    .HasMaxLength(10)
                    .HasColumnName("calle")
                    .IsFixedLength(true);

                entity.Property(e => e.Ciudad)
                    .HasMaxLength(10)
                    .HasColumnName("ciudad")
                    .IsFixedLength(true);

                entity.Property(e => e.Pais)
                    .HasMaxLength(10)
                    .HasColumnName("pais")
                    .IsFixedLength(true);

                entity.Property(e => e.Provincia)
                    .HasMaxLength(10)
                    .HasColumnName("provincia")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Operacion>(entity =>
            {
                entity.HasKey(e => e.IdOperacion);

                entity.ToTable("Operacion");

                entity.Property(e => e.IdOperacion)
                    .ValueGeneratedNever()
                    .HasColumnName("id_operacion");

                entity.Property(e => e.CodSeguridad)
                    .HasMaxLength(10)
                    .HasColumnName("cod_seguridad")
                    .IsFixedLength(true);

                entity.Property(e => e.FechaOperacion)
                    .HasColumnType("date")
                    .HasColumnName("fecha_operacion");

                entity.Property(e => e.IdCuenta).HasColumnName("id_cuenta");

                entity.Property(e => e.IdTipoOperacion).HasColumnName("id_tipo_operacion");

                entity.Property(e => e.Monto)
                    .HasMaxLength(10)
                    .HasColumnName("monto")
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdCuentaNavigation)
                    .WithMany(p => p.Operacions)
                    .HasForeignKey(d => d.IdCuenta)
                    .HasConstraintName("FK_Operacion_Cuentas");

                entity.HasOne(d => d.IdTipoOperacionNavigation)
                    .WithMany(p => p.Operacions)
                    .HasForeignKey(d => d.IdTipoOperacion)
                    .HasConstraintName("FK_Operacion_Tipo_Operaciones");
            });

            modelBuilder.Entity<TipoOperacione>(entity =>
            {
                entity.HasKey(e => e.IdTipooperacion);

                entity.ToTable("Tipo_Operaciones");

                entity.Property(e => e.IdTipooperacion).HasColumnName("id_tipooperacion");

                entity.Property(e => e.NombreOperacion)
                    .HasMaxLength(10)
                    .HasColumnName("nombre_operacion")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuarios__4E3E04AD6AEF1362");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Email)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.NombreUsuario)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("nombre_usuario");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("password");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
