use master
go
create database BARRETO_DB
go
use BARRETO_DB
go
USE [BARRETO_DB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

USE [BARRETO_DB]
GO

/****** Object:  Table [dbo].[EMPRESA]    Script Date: 15/06/2020 12:55:07 a.m. ******/
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

insert into EMPRESA(cuit, razon_social, numero_sap_empresa, direccion_legal, direccion_entrega, telefono, email, tipo_empresa, habilitado_empresa) values ('33999000709', 'MUNICIPALIDAD DE SAN ISIDRO', 94617927, '9 DE JULIO 526', '9 DE JULIO 526', 1234, 'cuentasapagar@sg.com.ar', 0, 1)
insert into EMPRESA(cuit, razon_social, numero_sap_empresa, direccion_legal, direccion_entrega, telefono, email, tipo_empresa, habilitado_empresa) values ('30663079502', 'HOSPITAL AERONAUTICO BUENOS AIRES', 94617929, 'VENTURA DE LA VEGA 3697', 'VENTURA DE LA VEGA 3697, 1234, 'cuentasapagar@sg.com.ar', 0, 1)
insert into EMPRESA(cuit, razon_social, numero_sap_empresa, direccion_legal, direccion_entrega, telefono, email, tipo_empresa, habilitado_empresa) values ('30663434191', 'SILVER CROSS AMERICA INC SA', 94617971, 'ACUNA DE FIGUEROA 1240', 'ACUNA DE FIGUEROA 1240, 1234, 'cuentasapagar@sg.com.ar', 0, 1)

select * from EMPRESA