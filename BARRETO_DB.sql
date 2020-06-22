USE [BARRETO_DB]
GO
/****** Object:  Table [dbo].[USUARIO]    Script Date: 22/06/2020 06:58:00 p.m. ******/
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
/****** Object:  View [dbo].[usuarioListarView]    Script Date: 22/06/2020 06:58:01 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[usuarioListarView] as
select * from dbo.USUARIO
GO
/****** Object:  Table [dbo].[ARCHIVO_ADJUNTO]    Script Date: 22/06/2020 06:58:01 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ARCHIVO_ADJUNTO](
	[id_solicitud] [int] NOT NULL,
	[descripcion_archivo] [varchar](150) NOT NULL,
	[ubicacion_archivo] [varchar](150) NOT NULL,
	[fecha_upload] [smalldatetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ARTICULO]    Script Date: 22/06/2020 06:58:01 p.m. ******/
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
/****** Object:  Table [dbo].[CAI]    Script Date: 22/06/2020 06:58:01 p.m. ******/
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
/****** Object:  Table [dbo].[EMPRESA]    Script Date: 22/06/2020 06:58:01 p.m. ******/
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
/****** Object:  Table [dbo].[SOLICITUD_CABECERA]    Script Date: 22/06/2020 06:58:01 p.m. ******/
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
/****** Object:  Table [dbo].[SOLICITUD_DETALLE]    Script Date: 22/06/2020 06:58:01 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SOLICITUD_DETALLE](
	[id_solicitud] [int] IDENTITY(1,1) NOT NULL,
	[id_articulo] [int] NOT NULL,
	[cantidad] [int] NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ARTICULO] ON 

INSERT [dbo].[ARTICULO] ([id_articulo], [codigo_articulo], [descripcion_articulo], [habilitado_articulo]) VALUES (1, N'prueba1', N'prueba1', 1)
INSERT [dbo].[ARTICULO] ([id_articulo], [codigo_articulo], [descripcion_articulo], [habilitado_articulo]) VALUES (2, N'prueba 2', N'prueba dos', 1)
INSERT [dbo].[ARTICULO] ([id_articulo], [codigo_articulo], [descripcion_articulo], [habilitado_articulo]) VALUES (3, N'prueba 3', N'prueba modificacion', 0)
SET IDENTITY_INSERT [dbo].[ARTICULO] OFF
SET IDENTITY_INSERT [dbo].[CAI] ON 

INSERT [dbo].[CAI] ([id_cai], [nro_cai], [punto_venta], [fecha_inicio], [fecha_fin]) VALUES (1, 123456, 204, CAST(N'2020-06-01T00:00:00' AS SmallDateTime), CAST(N'2020-10-30T00:00:00' AS SmallDateTime))
INSERT [dbo].[CAI] ([id_cai], [nro_cai], [punto_venta], [fecha_inicio], [fecha_fin]) VALUES (2, 876543, 200, CAST(N'2019-12-01T00:00:00' AS SmallDateTime), CAST(N'2021-01-08T00:00:00' AS SmallDateTime))
SET IDENTITY_INSERT [dbo].[CAI] OFF
SET IDENTITY_INSERT [dbo].[EMPRESA] ON 

INSERT [dbo].[EMPRESA] ([id_empresa], [cuit], [razon_social], [numero_sap_empresa], [direccion_legal], [direccion_entrega], [telefono], [email], [tipo_empresa], [habilitado_empresa]) VALUES (1, N'33999000709', N'MUNICIPALIDAD DE SAN ISIDRO', 94617927, N'9 DE JULIO 526', N'9 DE JULIO 123', N'1234', N'cuentasapagar@sg.com.ar', 0, 1)
INSERT [dbo].[EMPRESA] ([id_empresa], [cuit], [razon_social], [numero_sap_empresa], [direccion_legal], [direccion_entrega], [telefono], [email], [tipo_empresa], [habilitado_empresa]) VALUES (2, N'12345', N'prueba modificando', 12345, N'prueba direccion legal 234', N'prueba dir entrega 654', N'1234', N'wer@rew.com', 1, 1)
INSERT [dbo].[EMPRESA] ([id_empresa], [cuit], [razon_social], [numero_sap_empresa], [direccion_legal], [direccion_entrega], [telefono], [email], [tipo_empresa], [habilitado_empresa]) VALUES (3, N'87654', N'prueba 2', 7654, N'fdflsdjk dfsdf', N'erwerer oererei', N'1234567', N'123@co.co', 1, 0)
INSERT [dbo].[EMPRESA] ([id_empresa], [cuit], [razon_social], [numero_sap_empresa], [direccion_legal], [direccion_entrega], [telefono], [email], [tipo_empresa], [habilitado_empresa]) VALUES (4, N'12345', N'prueba 1', 12345, N'prueba direccion legal 234', N'prueba dir entrega 654', N'1234', N'wer@rew.com', 0, 0)
SET IDENTITY_INSERT [dbo].[EMPRESA] OFF
SET IDENTITY_INSERT [dbo].[USUARIO] ON 

INSERT [dbo].[USUARIO] ([id_usuario], [nombre], [usuario_code1], [email], [password], [usuario_tipo], [usuario_habilitado]) VALUES (1, N'Soporte full', N'ejemplo 1', N'wer@rew.com', N'pepito', 2, 1)
INSERT [dbo].[USUARIO] ([id_usuario], [nombre], [usuario_code1], [email], [password], [usuario_tipo], [usuario_habilitado]) VALUES (2, N'Ejemplo Aprobador', N'123456', N'wer@rew.com', N'12345', 1, 1)
INSERT [dbo].[USUARIO] ([id_usuario], [nombre], [usuario_code1], [email], [password], [usuario_tipo], [usuario_habilitado]) VALUES (3, N'Ejemplo Usuario', N'8765yt', N'wer@rew.com', N'12345', 0, 1)
SET IDENTITY_INSERT [dbo].[USUARIO] OFF
/****** Object:  StoredProcedure [dbo].[spAltaUsuario]    Script Date: 22/06/2020 06:58:01 p.m. ******/
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
