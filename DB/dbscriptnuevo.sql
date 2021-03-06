USE [master]
GO
/****** Object:  Database [dev_pw]    Script Date: 14/09/2021 16:27:14 ******/
CREATE DATABASE [dev_pw]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dev_pw', FILENAME = N'E:\Programas\MSSQL15.MSSQLSERVER\MSSQL\DATA\dev_pw.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'dev_pw_log', FILENAME = N'E:\Programas\MSSQL15.MSSQLSERVER\MSSQL\DATA\dev_pw_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [dev_pw] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dev_pw].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dev_pw] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dev_pw] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dev_pw] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dev_pw] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dev_pw] SET ARITHABORT OFF 
GO
ALTER DATABASE [dev_pw] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dev_pw] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dev_pw] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dev_pw] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dev_pw] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dev_pw] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dev_pw] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dev_pw] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dev_pw] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dev_pw] SET  DISABLE_BROKER 
GO
ALTER DATABASE [dev_pw] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dev_pw] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dev_pw] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dev_pw] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dev_pw] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dev_pw] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dev_pw] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dev_pw] SET RECOVERY FULL 
GO
ALTER DATABASE [dev_pw] SET  MULTI_USER 
GO
ALTER DATABASE [dev_pw] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dev_pw] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dev_pw] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dev_pw] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [dev_pw] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [dev_pw] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'dev_pw', N'ON'
GO
ALTER DATABASE [dev_pw] SET QUERY_STORE = OFF
GO
USE [dev_pw]
GO
/****** Object:  Table [dbo].[Contactos]    Script Date: 14/09/2021 16:27:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contactos](
	[id_contacto] [int] NOT NULL,
	[id_usuario] [int] NULL,
	[id_usuario_agendado] [int] NULL,
 CONSTRAINT [PK_Contactos] PRIMARY KEY CLUSTERED 
(
	[id_contacto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cuentas]    Script Date: 14/09/2021 16:27:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cuentas](
	[id_cuenta] [int] IDENTITY(1,1) NOT NULL,
	[id_usuario] [int] NULL,
	[tipo_cuenta] [varchar](50) NULL,
	[CVU] [varchar](50) NULL,
	[alias] [varchar](50) NULL,
	[saldo] [varchar](50) NULL,
 CONSTRAINT [PK_Cuentas] PRIMARY KEY CLUSTERED 
(
	[id_cuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Operaciones]    Script Date: 14/09/2021 16:27:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Operaciones](
	[id_operacion] [int] IDENTITY(1,1) NOT NULL,
	[id_cuenta] [int] NULL,
	[id_tipo_operacion] [int] NULL,
	[destinatario] [int] NULL,
	[monto] [varchar](50) NULL,
	[fecha_operacion] [varchar](50) NULL,
 CONSTRAINT [PK_Operaciones] PRIMARY KEY CLUSTERED 
(
	[id_operacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipo_operacion]    Script Date: 14/09/2021 16:27:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipo_operacion](
	[id_tipo_operacion] [int] IDENTITY(1,1) NOT NULL,
	[nombre_operacion] [varchar](50) NULL,
 CONSTRAINT [PK_Tipo_operacion] PRIMARY KEY CLUSTERED 
(
	[id_tipo_operacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 14/09/2021 16:27:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[id_usuario] [int] IDENTITY(1,1) NOT NULL,
	[nombre_usuario] [varchar](50) NULL,
	[nombre] [varchar](50) NULL,
	[apelldio] [varchar](50) NULL,
	[dni] [int] NULL,
	[telefono] [varchar](50) NULL,
	[email] [varchar](50) NULL,
	[calle] [varchar](50) NULL,
	[ciudad] [varchar](50) NULL,
	[provincia] [varchar](50) NULL,
	[pais] [varchar](50) NULL,
	[password] [varchar](50) NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Contactos]  WITH CHECK ADD  CONSTRAINT [FK_Contactos_Usuario] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[Usuario] ([id_usuario])
GO
ALTER TABLE [dbo].[Contactos] CHECK CONSTRAINT [FK_Contactos_Usuario]
GO
ALTER TABLE [dbo].[Operaciones]  WITH CHECK ADD  CONSTRAINT [FK_Operaciones_Cuentas] FOREIGN KEY([id_cuenta])
REFERENCES [dbo].[Cuentas] ([id_cuenta])
GO
ALTER TABLE [dbo].[Operaciones] CHECK CONSTRAINT [FK_Operaciones_Cuentas]
GO
ALTER TABLE [dbo].[Operaciones]  WITH CHECK ADD  CONSTRAINT [FK_Operaciones_Tipo_operacion] FOREIGN KEY([id_operacion])
REFERENCES [dbo].[Tipo_operacion] ([id_tipo_operacion])
GO
ALTER TABLE [dbo].[Operaciones] CHECK CONSTRAINT [FK_Operaciones_Tipo_operacion]
GO
USE [master]
GO
ALTER DATABASE [dev_pw] SET  READ_WRITE 
GO
