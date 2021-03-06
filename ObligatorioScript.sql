USE [master]
GO
/****** Object:  Database [Obligatorio]    Script Date: 25/3/2016 14:23:47 ******/
CREATE DATABASE [Obligatorio]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Obligatorio', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Obligatorio.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Obligatorio_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Obligatorio_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
USE [Obligatorio]
GO
/****** Object:  Table [dbo].[prueba]    Script Date: 25/3/2016 14:23:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[prueba](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[prueba] ON 

INSERT [dbo].[prueba] ([id], [nombre]) VALUES (1, N'Juan')
INSERT [dbo].[prueba] ([id], [nombre]) VALUES (2, N'William')
SET IDENTITY_INSERT [dbo].[prueba] OFF
USE [master]
GO
ALTER DATABASE [Obligatorio] SET  READ_WRITE 
GO
