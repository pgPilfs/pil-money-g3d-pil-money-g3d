using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PILpw.Entitis
{
    public partial class dev_pwContext : DbContext
    {
        public dev_pwContext()
        {
        }

        public dev_pwContext(DbContextOptions<dev_pwContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contacto> Contactos { get; set; }
        public virtual DbSet<Cuenta> Cuentas { get; set; }
        public virtual DbSet<Operacione> Operaciones { get; set; }
        public virtual DbSet<TipoOperacion> TipoOperacions { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=DESKTOP-2EM8Q0T;Database=dev_pw;Trusted_Connection=True;");
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

                entity.Property(e => e.IdUsuarioAgendado).HasColumnName("id_usuario_agendado");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Contactos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_Contactos_Usuario");
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

                entity.Property(e => e.Saldo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("saldo");

                entity.Property(e => e.TipoCuenta)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tipo_cuenta");
            });

            modelBuilder.Entity<Operacione>(entity =>
            {
                entity.HasKey(e => e.IdOperacion);

                entity.Property(e => e.IdOperacion)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id_operacion");

                entity.Property(e => e.Destinatario).HasColumnName("destinatario");

                entity.Property(e => e.FechaOperacion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("fecha_operacion");

                entity.Property(e => e.IdCuenta).HasColumnName("id_cuenta");

                entity.Property(e => e.IdTipoOperacion).HasColumnName("id_tipo_operacion");

                entity.Property(e => e.Monto)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("monto");

                entity.HasOne(d => d.IdCuentaNavigation)
                    .WithMany(p => p.Operaciones)
                    .HasForeignKey(d => d.IdCuenta)
                    .HasConstraintName("FK_Operaciones_Cuentas");

                entity.HasOne(d => d.IdOperacionNavigation)
                    .WithOne(p => p.Operacione)
                    .HasForeignKey<Operacione>(d => d.IdOperacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Operaciones_Tipo_operacion");
            });

            modelBuilder.Entity<TipoOperacion>(entity =>
            {
                entity.HasKey(e => e.IdTipoOperacion);

                entity.ToTable("Tipo_operacion");

                entity.Property(e => e.IdTipoOperacion).HasColumnName("id_tipo_operacion");

                entity.Property(e => e.NombreOperacion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre_operacion");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.ToTable("Usuario");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Apelldio)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("apelldio");

                entity.Property(e => e.Calle)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("calle");

                entity.Property(e => e.Ciudad)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ciudad");

                entity.Property(e => e.Dni).HasColumnName("dni");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.NombreUsuario)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre_usuario");

                entity.Property(e => e.Pais)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("pais");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Provincia)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("provincia");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("telefono");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
