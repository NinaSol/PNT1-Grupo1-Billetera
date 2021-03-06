USE [master]
GO
/****** Object:  User [##MS_PolicyEventProcessingLogin##]    Script Date: 23/11/2021 13:59:14 ******/
CREATE USER [##MS_PolicyEventProcessingLogin##] FOR LOGIN [##MS_PolicyEventProcessingLogin##] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [##MS_AgentSigningCertificate##]    Script Date: 23/11/2021 13:59:14 ******/
CREATE USER [##MS_AgentSigningCertificate##] FOR LOGIN [##MS_AgentSigningCertificate##]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 23/11/2021 13:59:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movimientos]    Script Date: 23/11/2021 13:59:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movimientos](
	[Id] [uniqueidentifier] NOT NULL,
	[Monto] [float] NOT NULL,
	[Descripcion] [nvarchar](180) NULL,
	[Fecha] [datetime2](7) NOT NULL,
	[TipoMovimiento] [int] NOT NULL,
	[UsuarioId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Movimientos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 23/11/2021 13:59:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Id] [uniqueidentifier] NOT NULL,
	[Nombre] [nvarchar](180) NULL,
	[Contrasenia] [nvarchar](8) NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211117224104_Bille1', N'3.1.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211123021703_pnt', N'3.1.3')
GO
INSERT [dbo].[Movimientos] ([Id], [Monto], [Descripcion], [Fecha], [TipoMovimiento], [UsuarioId]) VALUES (N'b1b50145-a86f-46fb-b05a-04ece3ffcc01', 15000, N'freelance', CAST(N'2021-11-22T00:00:00.0000000' AS DateTime2), 0, N'bb1f963b-c69c-42a5-be43-07990877519e')
INSERT [dbo].[Movimientos] ([Id], [Monto], [Descripcion], [Fecha], [TipoMovimiento], [UsuarioId]) VALUES (N'08e505a4-efbb-4a87-bb78-53bedf5da99c', 250000, N'salario', CAST(N'2021-11-22T00:00:00.0000000' AS DateTime2), 0, N'0583eae6-3014-494a-aea6-efb467c8a385')
INSERT [dbo].[Movimientos] ([Id], [Monto], [Descripcion], [Fecha], [TipoMovimiento], [UsuarioId]) VALUES (N'3d35d2a8-d89a-4f46-9dbd-a4050b50ce44', 5000, N'gastos varios', CAST(N'2021-11-22T00:00:00.0000000' AS DateTime2), 1, N'bb1f963b-c69c-42a5-be43-07990877519e')
INSERT [dbo].[Movimientos] ([Id], [Monto], [Descripcion], [Fecha], [TipoMovimiento], [UsuarioId]) VALUES (N'c3972f56-e1ab-4e99-8616-a76eb2b40662', 35000, N'alquiler', CAST(N'2021-11-22T00:00:00.0000000' AS DateTime2), 1, N'0583eae6-3014-494a-aea6-efb467c8a385')
INSERT [dbo].[Movimientos] ([Id], [Monto], [Descripcion], [Fecha], [TipoMovimiento], [UsuarioId]) VALUES (N'0701cf6d-2186-458d-b0f0-b288683107d9', 3500, N'cobro', CAST(N'2021-11-23T00:00:00.0000000' AS DateTime2), 0, N'9769e4af-5ab0-4c39-aef3-cfdab5025ee8')
INSERT [dbo].[Movimientos] ([Id], [Monto], [Descripcion], [Fecha], [TipoMovimiento], [UsuarioId]) VALUES (N'0bcf723f-b0be-4796-9238-d9cf0a384a7f', 10500, N'supermercado', CAST(N'2021-11-23T00:00:00.0000000' AS DateTime2), 1, N'9769e4af-5ab0-4c39-aef3-cfdab5025ee8')
INSERT [dbo].[Movimientos] ([Id], [Monto], [Descripcion], [Fecha], [TipoMovimiento], [UsuarioId]) VALUES (N'b06eed74-190c-484d-8c5a-e2a6d17fae51', 57000, N'sueldo', CAST(N'2021-11-23T00:00:00.0000000' AS DateTime2), 0, N'9769e4af-5ab0-4c39-aef3-cfdab5025ee8')
GO
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Contrasenia]) VALUES (N'bb1f963b-c69c-42a5-be43-07990877519e', N'fran', N'1234')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Contrasenia]) VALUES (N'9769e4af-5ab0-4c39-aef3-cfdab5025ee8', N'nina', N'0147')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Contrasenia]) VALUES (N'0583eae6-3014-494a-aea6-efb467c8a385', N'giuliano', N'4321')
GO
/****** Object:  Index [IX_Movimientos_UsuarioId]    Script Date: 23/11/2021 13:59:14 ******/
CREATE NONCLUSTERED INDEX [IX_Movimientos_UsuarioId] ON [dbo].[Movimientos]
(
	[UsuarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Movimientos]  WITH CHECK ADD  CONSTRAINT [FK_Movimientos_Usuarios_UsuarioId] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuarios] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Movimientos] CHECK CONSTRAINT [FK_Movimientos_Usuarios_UsuarioId]
GO
