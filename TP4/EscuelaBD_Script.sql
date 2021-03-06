USE [EscuelaBD]
GO
/****** Object:  Table [dbo].[Alumnos]    Script Date: 20/6/2022 01:41:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alumnos](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[Direccion] [text] NULL,
	[FechaDeNacimiento] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Profesor]    Script Date: 20/6/2022 01:41:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profesor](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[Direccion] [text] NULL,
	[FechaDeNacimiento] [datetime] NULL,
	[Salario] [varchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tienda]    Script Date: 20/6/2022 01:41:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tienda](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Fabricante] [varchar](50) NOT NULL,
	[Articulo] [varchar](50) NOT NULL,
	[Precio] [varchar](50) NOT NULL,
	[Comprador] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsuarioDirector]    Script Date: 20/6/2022 01:41:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioDirector](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](40) NOT NULL,
	[Contraseña] [varbinary](max) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 20/6/2022 01:41:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Contraseña] [varbinary](max) NOT NULL,
	[Compra] [varchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsuariosProfesor]    Script Date: 20/6/2022 01:41:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuariosProfesor](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](40) NOT NULL,
	[Contraseña] [varbinary](max) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Alumnos] ON 

INSERT [dbo].[Alumnos] ([Id], [Nombre], [Apellido], [Direccion], [FechaDeNacimiento]) VALUES (1, N'Ariana', N'Bautista', N'9 de Julio', CAST(N'1999-12-11T00:00:00.000' AS DateTime))
INSERT [dbo].[Alumnos] ([Id], [Nombre], [Apellido], [Direccion], [FechaDeNacimiento]) VALUES (2, N'Encina', N'Alfredo', N'27 de Febrero', CAST(N'2000-10-21T00:00:00.000' AS DateTime))
INSERT [dbo].[Alumnos] ([Id], [Nombre], [Apellido], [Direccion], [FechaDeNacimiento]) VALUES (3, N'Juan', N'Miguel', N'Acassuso', CAST(N'2002-08-31T00:00:00.000' AS DateTime))
INSERT [dbo].[Alumnos] ([Id], [Nombre], [Apellido], [Direccion], [FechaDeNacimiento]) VALUES (4, N'Gregorio', N'Bermúdez', N'Avellaneda', CAST(N'2001-02-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Alumnos] ([Id], [Nombre], [Apellido], [Direccion], [FechaDeNacimiento]) VALUES (5, N'Antonio', N'Bermúdez', N'Arana', CAST(N'1998-12-12T00:00:00.000' AS DateTime))
INSERT [dbo].[Alumnos] ([Id], [Nombre], [Apellido], [Direccion], [FechaDeNacimiento]) VALUES (6, N'Manrique', N'Salvador', N'Melian', CAST(N'2003-09-18T00:00:00.000' AS DateTime))
INSERT [dbo].[Alumnos] ([Id], [Nombre], [Apellido], [Direccion], [FechaDeNacimiento]) VALUES (7, N'Antonio', N'Bernal', N'Acevedo', CAST(N'2000-12-04T00:00:00.000' AS DateTime))
INSERT [dbo].[Alumnos] ([Id], [Nombre], [Apellido], [Direccion], [FechaDeNacimiento]) VALUES (8, N'Rosales', N'Gigliola', N'Achala', CAST(N'1999-06-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Alumnos] ([Id], [Nombre], [Apellido], [Direccion], [FechaDeNacimiento]) VALUES (9, N'Noel', N'Blanco', N'Lastra', CAST(N'2002-07-15T00:00:00.000' AS DateTime))
INSERT [dbo].[Alumnos] ([Id], [Nombre], [Apellido], [Direccion], [FechaDeNacimiento]) VALUES (10, N'Velasco', N'Humberto', N'Avellaneda', CAST(N'2004-01-12T00:00:00.000' AS DateTime))
INSERT [dbo].[Alumnos] ([Id], [Nombre], [Apellido], [Direccion], [FechaDeNacimiento]) VALUES (11, N'Alejandro', N'Bolaños', N'Monroe', CAST(N'2001-07-18T00:00:00.000' AS DateTime))
INSERT [dbo].[Alumnos] ([Id], [Nombre], [Apellido], [Direccion], [FechaDeNacimiento]) VALUES (12, N'Sánchez', N'César', N'Derqui', CAST(N'1997-03-27T00:00:00.000' AS DateTime))
INSERT [dbo].[Alumnos] ([Id], [Nombre], [Apellido], [Direccion], [FechaDeNacimiento]) VALUES (13, N'Moisés', N'Briseño', N'Gaona', CAST(N'2001-08-31T00:00:00.000' AS DateTime))
INSERT [dbo].[Alumnos] ([Id], [Nombre], [Apellido], [Direccion], [FechaDeNacimiento]) VALUES (14, N'Abel', N'Buenfil', N'Achira', CAST(N'2003-07-02T00:00:00.000' AS DateTime))
INSERT [dbo].[Alumnos] ([Id], [Nombre], [Apellido], [Direccion], [FechaDeNacimiento]) VALUES (15, N'Iván', N'Burguete', N'Achupallas', CAST(N'2005-12-11T00:00:00.000' AS DateTime))
INSERT [dbo].[Alumnos] ([Id], [Nombre], [Apellido], [Direccion], [FechaDeNacimiento]) VALUES (16, N'García', N'Miguel', N'Aconcagua', CAST(N'2004-09-05T00:00:00.000' AS DateTime))
INSERT [dbo].[Alumnos] ([Id], [Nombre], [Apellido], [Direccion], [FechaDeNacimiento]) VALUES (17, N'Ángel', N'Bustamante', N'Chiclana', CAST(N'2000-01-19T00:00:00.000' AS DateTime))
INSERT [dbo].[Alumnos] ([Id], [Nombre], [Apellido], [Direccion], [FechaDeNacimiento]) VALUES (18, N'Rosario', N'Alemán', N'Cobo', CAST(N'1998-11-09T00:00:00.000' AS DateTime))
INSERT [dbo].[Alumnos] ([Id], [Nombre], [Apellido], [Direccion], [FechaDeNacimiento]) VALUES (19, N'Eduardo', N'Díaz', N'España', CAST(N'2002-10-07T00:00:00.000' AS DateTime))
INSERT [dbo].[Alumnos] ([Id], [Nombre], [Apellido], [Direccion], [FechaDeNacimiento]) VALUES (20, N'Vicente', N'Domínguez', N'Forest', CAST(N'2004-11-09T00:00:00.000' AS DateTime))
INSERT [dbo].[Alumnos] ([Id], [Nombre], [Apellido], [Direccion], [FechaDeNacimiento]) VALUES (21, N'Gabriel', N'Domínguez', N'Independencia', CAST(N'2005-01-01T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Alumnos] OFF
GO
SET IDENTITY_INSERT [dbo].[Profesor] ON 

INSERT [dbo].[Profesor] ([Id], [Nombre], [Apellido], [Direccion], [FechaDeNacimiento], [Salario]) VALUES (1, N'Samuel', N'Jackson', N'Avellaneda', CAST(N'1989-12-12T00:00:00.000' AS DateTime), N'40000')
INSERT [dbo].[Profesor] ([Id], [Nombre], [Apellido], [Direccion], [FechaDeNacimiento], [Salario]) VALUES (2, N'Hector', N'Fernandez', N'Avellaneda', CAST(N'1990-02-22T00:00:00.000' AS DateTime), N'45000')
SET IDENTITY_INSERT [dbo].[Profesor] OFF
GO
SET IDENTITY_INSERT [dbo].[Tienda] ON 

INSERT [dbo].[Tienda] ([Id], [Fabricante], [Articulo], [Precio], [Comprador]) VALUES (1, N'Coca Cola', N'Coca', N'200.00', N'usuario')
INSERT [dbo].[Tienda] ([Id], [Fabricante], [Articulo], [Precio], [Comprador]) VALUES (2, N'Bon o Bon', N'Chocolate', N'350.00', N'')
INSERT [dbo].[Tienda] ([Id], [Fabricante], [Articulo], [Precio], [Comprador]) VALUES (3, N'Fizz Fizz', N'Acido', N'15.00', N'')
INSERT [dbo].[Tienda] ([Id], [Fabricante], [Articulo], [Precio], [Comprador]) VALUES (4, N'Tita', N'Chocolate', N'650.00', N'')
INSERT [dbo].[Tienda] ([Id], [Fabricante], [Articulo], [Precio], [Comprador]) VALUES (5, N'Sprite', N'Lima Limon', N'120.00', N'')
INSERT [dbo].[Tienda] ([Id], [Fabricante], [Articulo], [Precio], [Comprador]) VALUES (6, N'Manaos', N'Naranja', N'150.00', N'')
INSERT [dbo].[Tienda] ([Id], [Fabricante], [Articulo], [Precio], [Comprador]) VALUES (7, N'Futbolito', N'Mani', N'20.00', N'')
INSERT [dbo].[Tienda] ([Id], [Fabricante], [Articulo], [Precio], [Comprador]) VALUES (8, N'Mogul', N'Fruta', N'400.00', N'')
SET IDENTITY_INSERT [dbo].[Tienda] OFF
GO
SET IDENTITY_INSERT [dbo].[UsuarioDirector] ON 

INSERT [dbo].[UsuarioDirector] ([Id], [Nombre], [Contraseña]) VALUES (1, N'director', 0x020067C85023FD2C79B7579711C72E0FEEEB1AAA0123DDA95806B44C8A5DCA3D9E7CF3964B821BECBAA4EFBF378FC8F3B8A7C1361DFB9B84FC2E41E710DBC842EE38AE597708)
SET IDENTITY_INSERT [dbo].[UsuarioDirector] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([Id], [Nombre], [Contraseña], [Compra]) VALUES (1, N'usuario', 0x0200765AC8A9DB886838C4EF3DF751BDEC1727EE7C79BF3C58FCA6F3EB7622EB75B89F5B9268D550D92EB41500F6CC57680D0EFB4A8D3C0803CF7D013D053765A68FBFE06333, NULL)
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
SET IDENTITY_INSERT [dbo].[UsuariosProfesor] ON 

INSERT [dbo].[UsuariosProfesor] ([Id], [Nombre], [Contraseña]) VALUES (1, N'profesor', 0x02009A8D78F25BF87EA00CDB2350DB19066604E7D18B67576F37D7A2D94B78651D40D1654214C1E55661F30ED5052C3F659BDB7AC4495FCA23F6D771CFFF3D2B9C55675966FC)
SET IDENTITY_INSERT [dbo].[UsuariosProfesor] OFF
GO
