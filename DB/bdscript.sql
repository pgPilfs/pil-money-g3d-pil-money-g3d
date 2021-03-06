USE [PILPAY-DB]
GO
/****** Object:  Table [dbo].[compra-venta_Divisas]    Script Date: 27/08/2021 17:09:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[compra-venta_Divisas](
	[id_tipo] [int] NOT NULL,
	[id_extraccion] [int] NOT NULL,
	[id_deposito] [int] NOT NULL,
	[monto] [decimal](18, 0) NOT NULL,
	[id_moneda] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contactos]    Script Date: 27/08/2021 17:09:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contactos](
	[nombre_usuario] [varchar](25) NOT NULL,
	[CVU] [int] NOT NULL,
	[email] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cuentas]    Script Date: 27/08/2021 17:09:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cuentas](
	[CVU] [int] NOT NULL,
	[alias] [varchar](50) NOT NULL,
	[saldo] [decimal](18, 0) NOT NULL,
	[id_moneda] [int] NOT NULL,
 CONSTRAINT [PK__Cuentas__C1FE224F927F61E7] PRIMARY KEY CLUSTERED 
(
	[CVU] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Depositos]    Script Date: 27/08/2021 17:09:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Depositos](
	[id_deposito] [int] NOT NULL,
	[cod_seguridad] [varchar](50) NOT NULL,
	[id_tipo] [int] NOT NULL,
	[monto] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK__Deposito__5A0B0BB16777CF44] PRIMARY KEY CLUSTERED 
(
	[id_deposito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[domicilios]    Script Date: 27/08/2021 17:09:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[domicilios](
	[id_domicilio] [int] NOT NULL,
	[calle] [varchar](50) NULL,
	[altura] [int] NULL,
	[referencia] [varchar](50) NULL,
	[barrio] [varchar](50) NULL,
	[ciudad] [varchar](50) NOT NULL,
	[provincia] [varchar](50) NOT NULL,
	[pais] [varchar](50) NOT NULL,
 CONSTRAINT [PK__domicili__A0CCE5C26B746C03] PRIMARY KEY CLUSTERED 
(
	[id_domicilio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Elecciones]    Script Date: 27/08/2021 17:09:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Elecciones](
	[accion_al_vto] [varchar](30) NOT NULL,
	[descripcion] [varchar](60) NOT NULL,
 CONSTRAINT [PK__Eleccion__652EA92BCEA0150D] PRIMARY KEY CLUSTERED 
(
	[accion_al_vto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empresas]    Script Date: 27/08/2021 17:09:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empresas](
	[id_empresa] [int] NOT NULL,
	[nombre_empresa] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_empresa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Extracciones]    Script Date: 27/08/2021 17:09:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Extracciones](
	[id_extraccion] [int] NOT NULL,
	[cod_seguridad] [varchar](50) NOT NULL,
	[id_tipo] [int] NOT NULL,
	[monto] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK__Extracci__53647F40DA7D68FF] PRIMARY KEY CLUSTERED 
(
	[id_extraccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[formaDePago]    Script Date: 27/08/2021 17:09:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[formaDePago](
	[id_formaPago] [int] NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK__formaDeP__1E3475BA210E3DB2] PRIMARY KEY CLUSTERED 
(
	[id_formaPago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inversiones]    Script Date: 27/08/2021 17:09:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inversiones](
	[id_Inversion] [int] NOT NULL,
	[tipo_Inversion] [varchar](50) NOT NULL,
	[plazo] [int] NOT NULL,
	[importe] [decimal](18, 0) NOT NULL,
	[fecha_operacion] [date] NOT NULL,
	[fecha_vencimiento] [date] NOT NULL,
	[accion_al_vto] [varchar](30) NOT NULL,
	[id_tasa] [int] NOT NULL,
 CONSTRAINT [PK__Inversio__82A93F1995805480] PRIMARY KEY CLUSTERED 
(
	[id_Inversion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Operaciones]    Script Date: 27/08/2021 17:09:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Operaciones](
	[id_operacion] [int] NOT NULL,
	[CVU] [int] NULL,
	[fecha_operacion] [date] NULL,
	[hora_oprecion] [time](7) NULL,
	[id_deposito] [int] NULL,
	[id_extraccion] [int] NULL,
	[id_transferencia] [int] NULL,
	[id_inversion] [int] NULL,
	[id_pago] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_operacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pagos]    Script Date: 27/08/2021 17:09:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pagos](
	[id_pago] [int] NOT NULL,
	[id_empresa] [int] NOT NULL,
	[nro_cliente] [int] NOT NULL,
	[monto] [decimal](18, 0) NOT NULL,
	[vencimiento] [date] NOT NULL,
	[cod_barras] [varchar](50) NOT NULL,
	[id_formaPago] [int] NOT NULL,
 CONSTRAINT [PK__Pagos__0941B07422ED5DE6] PRIMARY KEY CLUSTERED 
(
	[id_pago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personas]    Script Date: 27/08/2021 17:09:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personas](
	[tipo_documento] [char](3) NOT NULL,
	[nro_documento] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[telefono] [varchar](10) NULL,
	[id_domicilio] [int] NOT NULL,
	[nro_tarjeta] [char](16) NOT NULL,
 CONSTRAINT [PK_Personas] PRIMARY KEY CLUSTERED 
(
	[tipo_documento] ASC,
	[nro_documento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rendimientos]    Script Date: 27/08/2021 17:09:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rendimientos](
	[tipo_Inversion] [varchar](50) NOT NULL,
	[id_tasa] [int] NOT NULL,
	[tasa] [decimal](18, 0) NOT NULL,
	[descripcion] [varchar](60) NULL,
 CONSTRAINT [PK__Rendimie__945EB0C553887553] PRIMARY KEY CLUSTERED 
(
	[tipo_Inversion] ASC,
	[id_tasa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tarjetas]    Script Date: 27/08/2021 17:09:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tarjetas](
	[marca_TC] [varchar](50) NOT NULL,
	[nro_tarjeta] [char](16) NOT NULL,
	[titular] [varchar](50) NOT NULL,
	[vencimiento] [date] NOT NULL,
	[CVV] [char](3) NOT NULL,
	[DNI] [int] NOT NULL,
 CONSTRAINT [PK_Tarjetas] PRIMARY KEY CLUSTERED 
(
	[nro_tarjeta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipo_moneda]    Script Date: 27/08/2021 17:09:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipo_moneda](
	[id_moneda] [int] NOT NULL,
	[nom_moneda] [varchar](50) NOT NULL,
	[cotizacion] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK__tipo_mon__807063E3F3A42265] PRIMARY KEY CLUSTERED 
(
	[id_moneda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipos_dep-extr]    Script Date: 27/08/2021 17:09:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipos_dep-extr](
	[id_tipo] [int] NOT NULL,
	[nombre_tipo] [varchar](15) NOT NULL,
 CONSTRAINT [PK__Tipos_de__CF901089F4973647] PRIMARY KEY CLUSTERED 
(
	[id_tipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transferencias]    Script Date: 27/08/2021 17:09:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transferencias](
	[id_transferencia] [int] NOT NULL,
	[CVU] [int] NOT NULL,
	[monto] [decimal](18, 0) NOT NULL,
	[concepto] [varchar](50) NULL,
	[mensaje] [varchar](50) NULL,
 CONSTRAINT [PK__Transfer__0B5783B08C82C288] PRIMARY KEY CLUSTERED 
(
	[id_transferencia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 27/08/2021 17:09:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[nombre_usuario] [varchar](25) NOT NULL,
	[password] [varchar](25) NOT NULL,
	[tipo_documento] [char](3) NOT NULL,
	[nro_documento] [int] NOT NULL,
	[CVU] [int] NOT NULL,
	[email] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[nombre_usuario] ASC,
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[compra-venta_Divisas]  WITH CHECK ADD  CONSTRAINT [FK_compra-venta_Divisas_Depositos] FOREIGN KEY([id_deposito])
REFERENCES [dbo].[Depositos] ([id_deposito])
GO
ALTER TABLE [dbo].[compra-venta_Divisas] CHECK CONSTRAINT [FK_compra-venta_Divisas_Depositos]
GO
ALTER TABLE [dbo].[compra-venta_Divisas]  WITH CHECK ADD  CONSTRAINT [FK_compra-venta_Divisas_Extracciones] FOREIGN KEY([id_extraccion])
REFERENCES [dbo].[Extracciones] ([id_extraccion])
GO
ALTER TABLE [dbo].[compra-venta_Divisas] CHECK CONSTRAINT [FK_compra-venta_Divisas_Extracciones]
GO
ALTER TABLE [dbo].[compra-venta_Divisas]  WITH CHECK ADD  CONSTRAINT [FK_compra-venta_Divisas_tipo_moneda] FOREIGN KEY([id_moneda])
REFERENCES [dbo].[tipo_moneda] ([id_moneda])
GO
ALTER TABLE [dbo].[compra-venta_Divisas] CHECK CONSTRAINT [FK_compra-venta_Divisas_tipo_moneda]
GO
ALTER TABLE [dbo].[compra-venta_Divisas]  WITH CHECK ADD  CONSTRAINT [FK_compra-venta_Divisas_Tipos_dep-extr] FOREIGN KEY([id_tipo])
REFERENCES [dbo].[Tipos_dep-extr] ([id_tipo])
GO
ALTER TABLE [dbo].[compra-venta_Divisas] CHECK CONSTRAINT [FK_compra-venta_Divisas_Tipos_dep-extr]
GO
ALTER TABLE [dbo].[Contactos]  WITH CHECK ADD  CONSTRAINT [FK_Contactos_Usuarios] FOREIGN KEY([nombre_usuario], [email])
REFERENCES [dbo].[Usuarios] ([nombre_usuario], [email])
GO
ALTER TABLE [dbo].[Contactos] CHECK CONSTRAINT [FK_Contactos_Usuarios]
GO
ALTER TABLE [dbo].[Cuentas]  WITH CHECK ADD  CONSTRAINT [FK_Cuentas_tipo_moneda] FOREIGN KEY([id_moneda])
REFERENCES [dbo].[tipo_moneda] ([id_moneda])
GO
ALTER TABLE [dbo].[Cuentas] CHECK CONSTRAINT [FK_Cuentas_tipo_moneda]
GO
ALTER TABLE [dbo].[Depositos]  WITH CHECK ADD  CONSTRAINT [FK_Depositos_Tipos_dep-extr] FOREIGN KEY([id_tipo])
REFERENCES [dbo].[Tipos_dep-extr] ([id_tipo])
GO
ALTER TABLE [dbo].[Depositos] CHECK CONSTRAINT [FK_Depositos_Tipos_dep-extr]
GO
ALTER TABLE [dbo].[Extracciones]  WITH CHECK ADD  CONSTRAINT [FK_Extracciones_Tipos_dep-extr] FOREIGN KEY([id_tipo])
REFERENCES [dbo].[Tipos_dep-extr] ([id_tipo])
GO
ALTER TABLE [dbo].[Extracciones] CHECK CONSTRAINT [FK_Extracciones_Tipos_dep-extr]
GO
ALTER TABLE [dbo].[Inversiones]  WITH CHECK ADD  CONSTRAINT [FK_Inversiones_Elecciones] FOREIGN KEY([accion_al_vto])
REFERENCES [dbo].[Elecciones] ([accion_al_vto])
GO
ALTER TABLE [dbo].[Inversiones] CHECK CONSTRAINT [FK_Inversiones_Elecciones]
GO
ALTER TABLE [dbo].[Inversiones]  WITH CHECK ADD  CONSTRAINT [FK_Inversiones_Rendimientos] FOREIGN KEY([tipo_Inversion], [id_tasa])
REFERENCES [dbo].[Rendimientos] ([tipo_Inversion], [id_tasa])
GO
ALTER TABLE [dbo].[Inversiones] CHECK CONSTRAINT [FK_Inversiones_Rendimientos]
GO
ALTER TABLE [dbo].[Operaciones]  WITH CHECK ADD  CONSTRAINT [FK_Operaciones_Cuentas] FOREIGN KEY([CVU])
REFERENCES [dbo].[Cuentas] ([CVU])
GO
ALTER TABLE [dbo].[Operaciones] CHECK CONSTRAINT [FK_Operaciones_Cuentas]
GO
ALTER TABLE [dbo].[Operaciones]  WITH CHECK ADD  CONSTRAINT [FK_Operaciones_Depositos] FOREIGN KEY([id_deposito])
REFERENCES [dbo].[Depositos] ([id_deposito])
GO
ALTER TABLE [dbo].[Operaciones] CHECK CONSTRAINT [FK_Operaciones_Depositos]
GO
ALTER TABLE [dbo].[Operaciones]  WITH CHECK ADD  CONSTRAINT [FK_Operaciones_Extracciones] FOREIGN KEY([id_extraccion])
REFERENCES [dbo].[Extracciones] ([id_extraccion])
GO
ALTER TABLE [dbo].[Operaciones] CHECK CONSTRAINT [FK_Operaciones_Extracciones]
GO
ALTER TABLE [dbo].[Operaciones]  WITH CHECK ADD  CONSTRAINT [FK_Operaciones_Inversiones] FOREIGN KEY([id_inversion])
REFERENCES [dbo].[Inversiones] ([id_Inversion])
GO
ALTER TABLE [dbo].[Operaciones] CHECK CONSTRAINT [FK_Operaciones_Inversiones]
GO
ALTER TABLE [dbo].[Operaciones]  WITH CHECK ADD  CONSTRAINT [FK_Operaciones_Pagos] FOREIGN KEY([id_pago])
REFERENCES [dbo].[Pagos] ([id_pago])
GO
ALTER TABLE [dbo].[Operaciones] CHECK CONSTRAINT [FK_Operaciones_Pagos]
GO
ALTER TABLE [dbo].[Operaciones]  WITH CHECK ADD  CONSTRAINT [FK_Operaciones_Transferencias] FOREIGN KEY([id_transferencia])
REFERENCES [dbo].[Transferencias] ([id_transferencia])
GO
ALTER TABLE [dbo].[Operaciones] CHECK CONSTRAINT [FK_Operaciones_Transferencias]
GO
ALTER TABLE [dbo].[Pagos]  WITH CHECK ADD  CONSTRAINT [FK_Pagos_Empresas] FOREIGN KEY([id_empresa])
REFERENCES [dbo].[Empresas] ([id_empresa])
GO
ALTER TABLE [dbo].[Pagos] CHECK CONSTRAINT [FK_Pagos_Empresas]
GO
ALTER TABLE [dbo].[Pagos]  WITH CHECK ADD  CONSTRAINT [FK_Pagos_formaDePago] FOREIGN KEY([id_formaPago])
REFERENCES [dbo].[formaDePago] ([id_formaPago])
GO
ALTER TABLE [dbo].[Pagos] CHECK CONSTRAINT [FK_Pagos_formaDePago]
GO
ALTER TABLE [dbo].[Personas]  WITH CHECK ADD  CONSTRAINT [FK_Personas_domicilios] FOREIGN KEY([id_domicilio])
REFERENCES [dbo].[domicilios] ([id_domicilio])
GO
ALTER TABLE [dbo].[Personas] CHECK CONSTRAINT [FK_Personas_domicilios]
GO
ALTER TABLE [dbo].[Personas]  WITH CHECK ADD  CONSTRAINT [FK_Personas_Tarjetas] FOREIGN KEY([nro_tarjeta])
REFERENCES [dbo].[Tarjetas] ([nro_tarjeta])
GO
ALTER TABLE [dbo].[Personas] CHECK CONSTRAINT [FK_Personas_Tarjetas]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Cuentas] FOREIGN KEY([CVU])
REFERENCES [dbo].[Cuentas] ([CVU])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Cuentas]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Personas] FOREIGN KEY([tipo_documento], [nro_documento])
REFERENCES [dbo].[Personas] ([tipo_documento], [nro_documento])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Personas]
GO
