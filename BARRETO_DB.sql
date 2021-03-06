USE [master]
GO
/****** Object:  Database [BARRETO_DB]    Script Date: 02/07/2020 07:53:07 p.m. ******/
CREATE DATABASE [BARRETO_DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BARRETO_DB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\BARRETO_DB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BARRETO_DB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\BARRETO_DB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BARRETO_DB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BARRETO_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BARRETO_DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BARRETO_DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BARRETO_DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BARRETO_DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BARRETO_DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [BARRETO_DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BARRETO_DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BARRETO_DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BARRETO_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BARRETO_DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BARRETO_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BARRETO_DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BARRETO_DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BARRETO_DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BARRETO_DB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BARRETO_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BARRETO_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BARRETO_DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BARRETO_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BARRETO_DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BARRETO_DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BARRETO_DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BARRETO_DB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BARRETO_DB] SET  MULTI_USER 
GO
ALTER DATABASE [BARRETO_DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BARRETO_DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BARRETO_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BARRETO_DB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BARRETO_DB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BARRETO_DB] SET QUERY_STORE = OFF
GO
USE [BARRETO_DB]
GO
/****** Object:  Table [dbo].[USUARIO]    Script Date: 02/07/2020 07:53:07 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USUARIO](
	[id_usuario] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](150) NOT NULL,
	[usuario_code1] [varchar](150) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[password] [varchar](150) NOT NULL,
	[usuario_tipo] [int] NOT NULL,
	[usuario_habilitado] [int] NOT NULL,
 CONSTRAINT [PK_USUARIO] PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[usuarioListarView]    Script Date: 02/07/2020 07:53:07 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[usuarioListarView] as
select * from dbo.USUARIO
GO
/****** Object:  Table [dbo].[ARCHIVO_ADJUNTO]    Script Date: 02/07/2020 07:53:07 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ARCHIVO_ADJUNTO](
	[id_solicitud] [int] NOT NULL,
	[descripcion_archivo] [varchar](150) NOT NULL,
	[fecha_upload] [smalldatetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ARTICULO]    Script Date: 02/07/2020 07:53:07 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ARTICULO](
	[id_articulo] [int] IDENTITY(1,1) NOT NULL,
	[codigo_articulo] [varchar](50) NOT NULL,
	[descripcion_articulo] [varchar](150) NOT NULL,
	[habilitado_articulo] [int] NOT NULL,
 CONSTRAINT [PK_ARTICULO] PRIMARY KEY CLUSTERED 
(
	[id_articulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CAI]    Script Date: 02/07/2020 07:53:07 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CAI](
	[id_cai] [int] IDENTITY(1,1) NOT NULL,
	[nro_cai] [bigint] NOT NULL,
	[punto_venta] [int] NOT NULL,
	[fecha_inicio] [smalldatetime] NOT NULL,
	[fecha_fin] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_CAI] PRIMARY KEY CLUSTERED 
(
	[id_cai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EMPRESA]    Script Date: 02/07/2020 07:53:07 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EMPRESA](
	[id_empresa] [int] IDENTITY(1,1) NOT NULL,
	[cuit] [varchar](50) NOT NULL,
	[razon_social] [varchar](50) NOT NULL,
	[numero_sap_empresa] [int] NOT NULL,
	[direccion_legal] [varchar](150) NULL,
	[direccion_entrega] [varchar](150) NOT NULL,
	[telefono] [varchar](50) NULL,
	[email] [varchar](50) NOT NULL,
	[tipo_empresa] [int] NOT NULL,
	[habilitado_empresa] [int] NOT NULL,
 CONSTRAINT [PK_EMPRESA] PRIMARY KEY CLUSTERED 
(
	[id_empresa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MATRIZ_APROBACION]    Script Date: 02/07/2020 07:53:07 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MATRIZ_APROBACION](
	[id_matriz] [int] IDENTITY(1,1) NOT NULL,
	[id_usuario_solicitante] [int] NOT NULL,
	[id_usuario_aprobador] [int] NOT NULL,
 CONSTRAINT [PK_MATRIZ_APROBACION] PRIMARY KEY CLUSTERED 
(
	[id_matriz] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[REMITO]    Script Date: 02/07/2020 07:53:07 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[REMITO](
	[id_remito] [int] IDENTITY(1,1) NOT NULL,
	[id_solicitud] [int] NOT NULL,
	[numero_remito] [int] NOT NULL,
 CONSTRAINT [PK_REMITO] PRIMARY KEY CLUSTERED 
(
	[id_remito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[REMITO_TIPO]    Script Date: 02/07/2020 07:53:07 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[REMITO_TIPO](
	[id_tipo_remito] [int] IDENTITY(1,1) NOT NULL,
	[descripcion_remito] [varchar](150) NOT NULL,
 CONSTRAINT [PK_REMITO_TIPO] PRIMARY KEY CLUSTERED 
(
	[id_tipo_remito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SOLICITUD_CABECERA]    Script Date: 02/07/2020 07:53:07 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SOLICITUD_CABECERA](
	[id_solicitud] [int] IDENTITY(1,1) NOT NULL,
	[id_usuario_solicitante] [int] NOT NULL,
	[id_usuario_aprobador] [int] NOT NULL,
	[punto_venta] [int] NOT NULL,
	[cantidad_items] [int] NOT NULL,
	[cantidad_bultos] [int] NOT NULL,
	[fecha_solicitud] [smalldatetime] NOT NULL,
	[id_cliente] [int] NOT NULL,
	[id_transportista] [int] NOT NULL,
	[id_tipo_remito] [int] NOT NULL,
	[observacion_solicitud] [varchar](300) NOT NULL,
	[estado_solicitud] [int] NOT NULL,
 CONSTRAINT [PK_SOLICITUD_CABECERA] PRIMARY KEY CLUSTERED 
(
	[id_solicitud] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SOLICITUD_DETALLE]    Script Date: 02/07/2020 07:53:07 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SOLICITUD_DETALLE](
	[id_solicitud] [int] NOT NULL,
	[id_articulo] [int] NOT NULL,
	[cantidad] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UNIDAD_NEGOCIO]    Script Date: 02/07/2020 07:53:07 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UNIDAD_NEGOCIO](
	[id_unidad_negocio] [int] NOT NULL,
	[nombre_unidad_negocio] [varchar](150) NOT NULL,
	[habilitado_unidad_negocio] [int] NOT NULL,
 CONSTRAINT [PK_UNIDAD_NEGOCIO] PRIMARY KEY CLUSTERED 
(
	[id_unidad_negocio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UNIDAD_NEGOCIO_EMPRESA]    Script Date: 02/07/2020 07:53:07 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UNIDAD_NEGOCIO_EMPRESA](
	[id_empresa] [int] NOT NULL,
	[id_unidad_negocio] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UNIDAD_NEGOCIO_USUARIO]    Script Date: 02/07/2020 07:53:07 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UNIDAD_NEGOCIO_USUARIO](
	[id_usuario] [int] NOT NULL,
	[id_unidad_negocio] [int] NOT NULL
) ON [PRIMARY]
GO
INSERT [dbo].[ARCHIVO_ADJUNTO] ([id_solicitud], [descripcion_archivo], [fecha_upload]) VALUES (1, N'20201home.png', CAST(N'2020-06-28T21:06:00' AS SmallDateTime))
INSERT [dbo].[ARCHIVO_ADJUNTO] ([id_solicitud], [descripcion_archivo], [fecha_upload]) VALUES (2, N'20202Cart.png', CAST(N'2020-07-01T17:22:00' AS SmallDateTime))
INSERT [dbo].[ARCHIVO_ADJUNTO] ([id_solicitud], [descripcion_archivo], [fecha_upload]) VALUES (3, N'20203main.css', CAST(N'2020-07-02T13:24:00' AS SmallDateTime))
SET IDENTITY_INSERT [dbo].[ARTICULO] ON 

INSERT [dbo].[ARTICULO] ([id_articulo], [codigo_articulo], [descripcion_articulo], [habilitado_articulo]) VALUES (1, N'prueba1', N'prueba1', 1)
INSERT [dbo].[ARTICULO] ([id_articulo], [codigo_articulo], [descripcion_articulo], [habilitado_articulo]) VALUES (2, N'prueba 2', N'prueba dos', 1)
INSERT [dbo].[ARTICULO] ([id_articulo], [codigo_articulo], [descripcion_articulo], [habilitado_articulo]) VALUES (3, N'prueba 3', N'prueba modificacion', 0)
INSERT [dbo].[ARTICULO] ([id_articulo], [codigo_articulo], [descripcion_articulo], [habilitado_articulo]) VALUES (4, N'prueba3', N'prueba online', 1)
INSERT [dbo].[ARTICULO] ([id_articulo], [codigo_articulo], [descripcion_articulo], [habilitado_articulo]) VALUES (5, N'pruebaOnline', N'Prueba de Scrap', 1)
SET IDENTITY_INSERT [dbo].[ARTICULO] OFF
SET IDENTITY_INSERT [dbo].[CAI] ON 

INSERT [dbo].[CAI] ([id_cai], [nro_cai], [punto_venta], [fecha_inicio], [fecha_fin]) VALUES (1, 123456, 204, CAST(N'2020-06-01T00:00:00' AS SmallDateTime), CAST(N'2019-10-30T00:00:00' AS SmallDateTime))
INSERT [dbo].[CAI] ([id_cai], [nro_cai], [punto_venta], [fecha_inicio], [fecha_fin]) VALUES (2, 876543, 200, CAST(N'2019-12-01T00:00:00' AS SmallDateTime), CAST(N'2020-01-08T00:00:00' AS SmallDateTime))
SET IDENTITY_INSERT [dbo].[CAI] OFF
SET IDENTITY_INSERT [dbo].[EMPRESA] ON 

INSERT [dbo].[EMPRESA] ([id_empresa], [cuit], [razon_social], [numero_sap_empresa], [direccion_legal], [direccion_entrega], [telefono], [email], [tipo_empresa], [habilitado_empresa]) VALUES (1, N'33999000709', N'MUNICIPALIDAD DE SAN ISIDRO', 94617927, N'9 DE JULIO 526', N'9 DE JULIO 123', N'1234', N'cuentasapagar@sg.com.ar', 0, 1)
INSERT [dbo].[EMPRESA] ([id_empresa], [cuit], [razon_social], [numero_sap_empresa], [direccion_legal], [direccion_entrega], [telefono], [email], [tipo_empresa], [habilitado_empresa]) VALUES (2, N'12345', N'Prueba Transportista 1', 12345, N'prueba direccion legal 234', N'prueba dir entrega 654', N'1234', N'wer@rew.com', 1, 1)
INSERT [dbo].[EMPRESA] ([id_empresa], [cuit], [razon_social], [numero_sap_empresa], [direccion_legal], [direccion_entrega], [telefono], [email], [tipo_empresa], [habilitado_empresa]) VALUES (3, N'87654', N'prueba 2', 7654, N'fdflsdjk dfsdf', N'erwerer oererei', N'1234567', N'123@co.co', 1, 1)
INSERT [dbo].[EMPRESA] ([id_empresa], [cuit], [razon_social], [numero_sap_empresa], [direccion_legal], [direccion_entrega], [telefono], [email], [tipo_empresa], [habilitado_empresa]) VALUES (4, N'12345', N'prueba 1', 12345, N'prueba direccion legal 234', N'prueba dir entrega 654', N'1234', N'wer@rew.com', 0, 1)
INSERT [dbo].[EMPRESA] ([id_empresa], [cuit], [razon_social], [numero_sap_empresa], [direccion_legal], [direccion_entrega], [telefono], [email], [tipo_empresa], [habilitado_empresa]) VALUES (5, N'0', N'Vacio', 1, N'.', N'.', N'0', N'vacio@vacio.com', 1, 0)
SET IDENTITY_INSERT [dbo].[EMPRESA] OFF
SET IDENTITY_INSERT [dbo].[MATRIZ_APROBACION] ON 

INSERT [dbo].[MATRIZ_APROBACION] ([id_matriz], [id_usuario_solicitante], [id_usuario_aprobador]) VALUES (3, 3, 2)
INSERT [dbo].[MATRIZ_APROBACION] ([id_matriz], [id_usuario_solicitante], [id_usuario_aprobador]) VALUES (5, 2, 1)
INSERT [dbo].[MATRIZ_APROBACION] ([id_matriz], [id_usuario_solicitante], [id_usuario_aprobador]) VALUES (7, 1, 2)
SET IDENTITY_INSERT [dbo].[MATRIZ_APROBACION] OFF
SET IDENTITY_INSERT [dbo].[REMITO] ON 

INSERT [dbo].[REMITO] ([id_remito], [id_solicitud], [numero_remito]) VALUES (1, 1, 1)
INSERT [dbo].[REMITO] ([id_remito], [id_solicitud], [numero_remito]) VALUES (2, 2, 2)
SET IDENTITY_INSERT [dbo].[REMITO] OFF
SET IDENTITY_INSERT [dbo].[REMITO_TIPO] ON 

INSERT [dbo].[REMITO_TIPO] ([id_tipo_remito], [descripcion_remito]) VALUES (1, N'Comodato')
INSERT [dbo].[REMITO_TIPO] ([id_tipo_remito], [descripcion_remito]) VALUES (2, N'De Salida')
SET IDENTITY_INSERT [dbo].[REMITO_TIPO] OFF
SET IDENTITY_INSERT [dbo].[SOLICITUD_CABECERA] ON 

INSERT [dbo].[SOLICITUD_CABECERA] ([id_solicitud], [id_usuario_solicitante], [id_usuario_aprobador], [punto_venta], [cantidad_items], [cantidad_bultos], [fecha_solicitud], [id_cliente], [id_transportista], [id_tipo_remito], [observacion_solicitud], [estado_solicitud]) VALUES (1, 1, 2, 204, 5, 5, CAST(N'2020-06-28T21:06:00' AS SmallDateTime), 1, 2, 1, N'hgfds', 1)
INSERT [dbo].[SOLICITUD_CABECERA] ([id_solicitud], [id_usuario_solicitante], [id_usuario_aprobador], [punto_venta], [cantidad_items], [cantidad_bultos], [fecha_solicitud], [id_cliente], [id_transportista], [id_tipo_remito], [observacion_solicitud], [estado_solicitud]) VALUES (2, 1, 2, 204, 8, 8, CAST(N'2020-07-01T17:22:00' AS SmallDateTime), 1, 2, 2, N'Observaciones', 1)
INSERT [dbo].[SOLICITUD_CABECERA] ([id_solicitud], [id_usuario_solicitante], [id_usuario_aprobador], [punto_venta], [cantidad_items], [cantidad_bultos], [fecha_solicitud], [id_cliente], [id_transportista], [id_tipo_remito], [observacion_solicitud], [estado_solicitud]) VALUES (3, 1, 2, 204, 34, 34, CAST(N'2020-07-02T13:24:00' AS SmallDateTime), 4, 3, 2, N'Observaciones Rechazo', 3)
SET IDENTITY_INSERT [dbo].[SOLICITUD_CABECERA] OFF
INSERT [dbo].[SOLICITUD_DETALLE] ([id_solicitud], [id_articulo], [cantidad]) VALUES (1, 1, 5)
INSERT [dbo].[SOLICITUD_DETALLE] ([id_solicitud], [id_articulo], [cantidad]) VALUES (2, 4, 8)
INSERT [dbo].[SOLICITUD_DETALLE] ([id_solicitud], [id_articulo], [cantidad]) VALUES (3, 2, 34)
SET IDENTITY_INSERT [dbo].[USUARIO] ON 

INSERT [dbo].[USUARIO] ([id_usuario], [nombre], [usuario_code1], [email], [password], [usuario_tipo], [usuario_habilitado]) VALUES (1, N'Soporte full', N'ejemplo 1', N'administrador@remitos.com', N'administrador', 2, 1)
INSERT [dbo].[USUARIO] ([id_usuario], [nombre], [usuario_code1], [email], [password], [usuario_tipo], [usuario_habilitado]) VALUES (2, N'Ejemplo Aprobador', N'123456', N'aprobador@remitos.com', N'aprobador', 1, 1)
INSERT [dbo].[USUARIO] ([id_usuario], [nombre], [usuario_code1], [email], [password], [usuario_tipo], [usuario_habilitado]) VALUES (3, N'Ejemplo Usuario', N'8765ytPrueba', N'usuario@remitos.com', N'usuario', 0, 1)
INSERT [dbo].[USUARIO] ([id_usuario], [nombre], [usuario_code1], [email], [password], [usuario_tipo], [usuario_habilitado]) VALUES (4, N'Ejemplo para bloquear', N'ejemploBloqueado', N'bloquear@remitos.com', N'bloquear', 0, 0)
SET IDENTITY_INSERT [dbo].[USUARIO] OFF
/****** Object:  StoredProcedure [dbo].[spAltaUsuario]    Script Date: 02/07/2020 07:53:07 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spAltaUsuario]
@nombre varchar(150),
@usuario_code1 varchar(50),
@email varchar(50),
@password varchar(150),
@usuario_tipo int
as
insert into USUARIO values (@nombre, @usuario_code1, @email, @password, @usuario_tipo, 1)
GO
USE [master]
GO
ALTER DATABASE [BARRETO_DB] SET  READ_WRITE 
GO
