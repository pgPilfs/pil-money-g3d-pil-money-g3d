using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Prueba.Models
{
    public partial class PilContext : DbContext
    {
        public PilContext()
        {
        }

        public PilContext(DbContextOptions<PilContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CompraVentaDivisa> CompraVentaDivisas { get; set; }
        public virtual DbSet<Contacto> Contactos { get; set; }
        public virtual DbSet<Cuenta> Cuentas { get; set; }
        public virtual DbSet<Deposito> Depositos { get; set; }
        public virtual DbSet<Domicilio> Domicilios { get; set; }
        public virtual DbSet<Eleccione> Elecciones { get; set; }
        public virtual DbSet<Empresa> Empresas { get; set; }
        public virtual DbSet<Extraccione> Extracciones { get; set; }
        public virtual DbSet<FormaDePago> FormaDePagos { get; set; }
        public virtual DbSet<Inversione> Inversiones { get; set; }
        public virtual DbSet<Operacione> Operaciones { get; set; }
        public virtual DbSet<Pago> Pagos { get; set; }
        public virtual DbSet<Persona> Personas { get; set; }
        public virtual DbSet<Rendimiento> Rendimientos { get; set; }
        public virtual DbSet<Tarjeta> Tarjetas { get; set; }
        public virtual DbSet<TipoMonedum> TipoMoneda { get; set; }
        public virtual DbSet<TiposDepExtr> TiposDepExtrs { get; set; }
        public virtual DbSet<Transferencia> Transferencias { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=DESKTOP-2EM8Q0T;Database=Pil;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<CompraVentaDivisa>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("compra-venta_Divisas");

                entity.Property(e => e.IdDeposito).HasColumnName("id_deposito");

                entity.Property(e => e.IdExtraccion).HasColumnName("id_extraccion");

                entity.Property(e => e.IdMoneda).HasColumnName("id_moneda");

                entity.Property(e => e.IdTipo).HasColumnName("id_tipo");

                entity.Property(e => e.Monto)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("monto");

                entity.HasOne(d => d.IdDepositoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdDeposito)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_compra-venta_Divisas_Depositos");

                entity.HasOne(d => d.IdExtraccionNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdExtraccion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_compra-venta_Divisas_Extracciones");

                entity.HasOne(d => d.IdMonedaNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdMoneda)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_compra-venta_Divisas_tipo_moneda");

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdTipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_compra-venta_Divisas_Tipos_dep-extr");
            });

            modelBuilder.Entity<Contacto>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Cvu).HasColumnName("CVU");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.NombreUsuario)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("nombre_usuario");

                entity.HasOne(d => d.Usuario)
                    .WithMany()
                    .HasForeignKey(d => new { d.NombreUsuario, d.Email })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contactos_Usuarios");
            });

            modelBuilder.Entity<Cuenta>(entity =>
            {
                entity.HasKey(e => e.Cvu)
                    .HasName("PK__Cuentas__C1FE224F927F61E7");

                entity.Property(e => e.Cvu)
                    .ValueGeneratedNever()
                    .HasColumnName("CVU");

                entity.Property(e => e.Alias)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("alias");

                entity.Property(e => e.IdMoneda).HasColumnName("id_moneda");

                entity.Property(e => e.Saldo)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("saldo");

                entity.HasOne(d => d.IdMonedaNavigation)
                    .WithMany(p => p.Cuenta)
                    .HasForeignKey(d => d.IdMoneda)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cuentas_tipo_moneda");
            });

            modelBuilder.Entity<Deposito>(entity =>
            {
                entity.HasKey(e => e.IdDeposito)
                    .HasName("PK__Deposito__5A0B0BB16777CF44");

                entity.Property(e => e.IdDeposito)
                    .ValueGeneratedNever()
                    .HasColumnName("id_deposito");

                entity.Property(e => e.CodSeguridad)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cod_seguridad");

                entity.Property(e => e.IdTipo).HasColumnName("id_tipo");

                entity.Property(e => e.Monto)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("monto");

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.Depositos)
                    .HasForeignKey(d => d.IdTipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Depositos_Tipos_dep-extr");
            });

            modelBuilder.Entity<Domicilio>(entity =>
            {
                entity.HasKey(e => e.IdDomicilio)
                    .HasName("PK__domicili__A0CCE5C26B746C03");

                entity.ToTable("domicilios");

                entity.Property(e => e.IdDomicilio)
                    .ValueGeneratedNever()
                    .HasColumnName("id_domicilio");

                entity.Property(e => e.Altura).HasColumnName("altura");

                entity.Property(e => e.Barrio)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("barrio");

                entity.Property(e => e.Calle)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("calle");

                entity.Property(e => e.Ciudad)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ciudad");

                entity.Property(e => e.Pais)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("pais");

                entity.Property(e => e.Provincia)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("provincia");

                entity.Property(e => e.Referencia)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("referencia");
            });

            modelBuilder.Entity<Eleccione>(entity =>
            {
                entity.HasKey(e => e.AccionAlVto)
                    .HasName("PK__Eleccion__652EA92BCEA0150D");

                entity.Property(e => e.AccionAlVto)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("accion_al_vto");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.IdEmpresa)
                    .HasName("PK__Empresas__4A0B7E2C09F91B1B");

                entity.Property(e => e.IdEmpresa)
                    .ValueGeneratedNever()
                    .HasColumnName("id_empresa");

                entity.Property(e => e.NombreEmpresa)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre_empresa");
            });

            modelBuilder.Entity<Extraccione>(entity =>
            {
                entity.HasKey(e => e.IdExtraccion)
                    .HasName("PK__Extracci__53647F40DA7D68FF");

                entity.Property(e => e.IdExtraccion)
                    .ValueGeneratedNever()
                    .HasColumnName("id_extraccion");

                entity.Property(e => e.CodSeguridad)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cod_seguridad");

                entity.Property(e => e.IdTipo).HasColumnName("id_tipo");

                entity.Property(e => e.Monto)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("monto");

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.Extracciones)
                    .HasForeignKey(d => d.IdTipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Extracciones_Tipos_dep-extr");
            });

            modelBuilder.Entity<FormaDePago>(entity =>
            {
                entity.HasKey(e => e.IdFormaPago)
                    .HasName("PK__formaDeP__1E3475BA210E3DB2");

                entity.ToTable("formaDePago");

                entity.Property(e => e.IdFormaPago)
                    .ValueGeneratedNever()
                    .HasColumnName("id_formaPago");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");
            });

            modelBuilder.Entity<Inversione>(entity =>
            {
                entity.HasKey(e => e.IdInversion)
                    .HasName("PK__Inversio__82A93F1995805480");

                entity.Property(e => e.IdInversion)
                    .ValueGeneratedNever()
                    .HasColumnName("id_Inversion");

                entity.Property(e => e.AccionAlVto)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("accion_al_vto");

                entity.Property(e => e.FechaOperacion)
                    .HasColumnType("date")
                    .HasColumnName("fecha_operacion");

                entity.Property(e => e.FechaVencimiento)
                    .HasColumnType("date")
                    .HasColumnName("fecha_vencimiento");

                entity.Property(e => e.IdTasa).HasColumnName("id_tasa");

                entity.Property(e => e.Importe)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("importe");

                entity.Property(e => e.Plazo).HasColumnName("plazo");

                entity.Property(e => e.TipoInversion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tipo_Inversion");

                entity.HasOne(d => d.AccionAlVtoNavigation)
                    .WithMany(p => p.Inversiones)
                    .HasForeignKey(d => d.AccionAlVto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inversiones_Elecciones");

                entity.HasOne(d => d.Rendimiento)
                    .WithMany(p => p.Inversiones)
                    .HasForeignKey(d => new { d.TipoInversion, d.IdTasa })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inversiones_Rendimientos");
            });

            modelBuilder.Entity<Operacione>(entity =>
            {
                entity.HasKey(e => e.IdOperacion)
                    .HasName("PK__Operacio__AC60F4267E82C6B3");

                entity.Property(e => e.IdOperacion)
                    .ValueGeneratedNever()
                    .HasColumnName("id_operacion");

                entity.Property(e => e.Cvu).HasColumnName("CVU");

                entity.Property(e => e.FechaOperacion)
                    .HasColumnType("date")
                    .HasColumnName("fecha_operacion");

                entity.Property(e => e.HoraOprecion).HasColumnName("hora_oprecion");

                entity.Property(e => e.IdDeposito).HasColumnName("id_deposito");

                entity.Property(e => e.IdExtraccion).HasColumnName("id_extraccion");

                entity.Property(e => e.IdInversion).HasColumnName("id_inversion");

                entity.Property(e => e.IdPago).HasColumnName("id_pago");

                entity.Property(e => e.IdTransferencia).HasColumnName("id_transferencia");

                entity.HasOne(d => d.CvuNavigation)
                    .WithMany(p => p.Operaciones)
                    .HasForeignKey(d => d.Cvu)
                    .HasConstraintName("FK_Operaciones_Cuentas");

                entity.HasOne(d => d.IdDepositoNavigation)
                    .WithMany(p => p.Operaciones)
                    .HasForeignKey(d => d.IdDeposito)
                    .HasConstraintName("FK_Operaciones_Depositos");

                entity.HasOne(d => d.IdExtraccionNavigation)
                    .WithMany(p => p.Operaciones)
                    .HasForeignKey(d => d.IdExtraccion)
                    .HasConstraintName("FK_Operaciones_Extracciones");

                entity.HasOne(d => d.IdInversionNavigation)
                    .WithMany(p => p.Operaciones)
                    .HasForeignKey(d => d.IdInversion)
                    .HasConstraintName("FK_Operaciones_Inversiones");

                entity.HasOne(d => d.IdPagoNavigation)
                    .WithMany(p => p.Operaciones)
                    .HasForeignKey(d => d.IdPago)
                    .HasConstraintName("FK_Operaciones_Pagos");

                entity.HasOne(d => d.IdTransferenciaNavigation)
                    .WithMany(p => p.Operaciones)
                    .HasForeignKey(d => d.IdTransferencia)
                    .HasConstraintName("FK_Operaciones_Transferencias");
            });

            modelBuilder.Entity<Pago>(entity =>
            {
                entity.HasKey(e => e.IdPago)
                    .HasName("PK__Pagos__0941B07422ED5DE6");

                entity.Property(e => e.IdPago)
                    .ValueGeneratedNever()
                    .HasColumnName("id_pago");

                entity.Property(e => e.CodBarras)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cod_barras");

                entity.Property(e => e.IdEmpresa).HasColumnName("id_empresa");

                entity.Property(e => e.IdFormaPago).HasColumnName("id_formaPago");

                entity.Property(e => e.Monto)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("monto");

                entity.Property(e => e.NroCliente).HasColumnName("nro_cliente");

                entity.Property(e => e.Vencimiento)
                    .HasColumnType("date")
                    .HasColumnName("vencimiento");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Pagos)
                    .HasForeignKey(d => d.IdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pagos_Empresas");

                entity.HasOne(d => d.IdFormaPagoNavigation)
                    .WithMany(p => p.Pagos)
                    .HasForeignKey(d => d.IdFormaPago)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pagos_formaDePago");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => new { e.TipoDocumento, e.NroDocumento });

                entity.Property(e => e.TipoDocumento)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("tipo_documento")
                    .IsFixedLength(true);

                entity.Property(e => e.NroDocumento).HasColumnName("nro_documento");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("apellido");

                entity.Property(e => e.IdDomicilio).HasColumnName("id_domicilio");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.NroTarjeta).HasColumnName("nro_tarjeta");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("telefono");

                entity.HasOne(d => d.IdDomicilioNavigation)
                    .WithMany(p => p.Personas)
                    .HasForeignKey(d => d.IdDomicilio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Personas_domicilios");

                entity.HasOne(d => d.NroTarjetaNavigation)
                    .WithMany(p => p.Personas)
                    .HasForeignKey(d => d.NroTarjeta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Personas_Tarjetas");
            });

            modelBuilder.Entity<Rendimiento>(entity =>
            {
                entity.HasKey(e => new { e.TipoInversion, e.IdTasa })
                    .HasName("PK__Rendimie__945EB0C553887553");

                entity.Property(e => e.TipoInversion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tipo_Inversion");

                entity.Property(e => e.IdTasa).HasColumnName("id_tasa");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Tasa)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("tasa");
            });

            modelBuilder.Entity<Tarjeta>(entity =>
            {
                entity.HasKey(e => e.NroTarjeta);

                entity.Property(e => e.NroTarjeta)
                    .ValueGeneratedNever()
                    .HasColumnName("nro_tarjeta");

                entity.Property(e => e.Cvv)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CVV")
                    .IsFixedLength(true);

                entity.Property(e => e.Dni).HasColumnName("DNI");

                entity.Property(e => e.MarcaTc)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("marca_TC");

                entity.Property(e => e.Titular)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("titular");

                entity.Property(e => e.Vencimiento)
                    .HasColumnType("date")
                    .HasColumnName("vencimiento");
            });

            modelBuilder.Entity<TipoMonedum>(entity =>
            {
                entity.HasKey(e => e.IdMoneda)
                    .HasName("PK__tipo_mon__807063E3F3A42265");

                entity.ToTable("tipo_moneda");

                entity.Property(e => e.IdMoneda)
                    .ValueGeneratedNever()
                    .HasColumnName("id_moneda");

                entity.Property(e => e.Cotizacion)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("cotizacion");

                entity.Property(e => e.NomMoneda)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nom_moneda");
            });

            modelBuilder.Entity<TiposDepExtr>(entity =>
            {
                entity.HasKey(e => e.IdTipo)
                    .HasName("PK__Tipos_de__CF901089F4973647");

                entity.ToTable("Tipos_dep-extr");

                entity.Property(e => e.IdTipo)
                    .ValueGeneratedNever()
                    .HasColumnName("id_tipo");

                entity.Property(e => e.NombreTipo)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("nombre_tipo");
            });

            modelBuilder.Entity<Transferencia>(entity =>
            {
                entity.HasKey(e => e.IdTransferencia)
                    .HasName("PK__Transfer__0B5783B08C82C288");

                entity.Property(e => e.IdTransferencia)
                    .ValueGeneratedNever()
                    .HasColumnName("id_transferencia");

                entity.Property(e => e.Concepto)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("concepto");

                entity.Property(e => e.Cvu).HasColumnName("CVU");

                entity.Property(e => e.Mensaje)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("mensaje");

                entity.Property(e => e.Monto)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("monto");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => new { e.NombreUsuario, e.Email });

                entity.Property(e => e.NombreUsuario)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("nombre_usuario");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Contraseña)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("contraseña");

                entity.Property(e => e.Cvu).HasColumnName("CVU");

                entity.Property(e => e.NroDocumento).HasColumnName("nro_documento");

                entity.Property(e => e.TipoDocumento)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("tipo_documento")
                    .IsFixedLength(true);

                entity.HasOne(d => d.CvuNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.Cvu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuarios_Cuentas");

                entity.HasOne(d => d.Persona)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => new { d.TipoDocumento, d.NroDocumento })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuarios_Personas");
            });


           

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
