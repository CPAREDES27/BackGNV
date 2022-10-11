CREATE TABLE [dbo].[Usuarios](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[NomCliente] [varchar](50) NULL,
	[ApeCliente] [varchar](50) NULL,
	[RazonSocial] [varchar](300) NULL,
	[NumeroDocumento] [varchar](20) NOT NULL,
	[CodigoUbigeo] [varchar](20) NOT NULL,
	[FechaEmision] [datetime] NOT NULL,
	[FechaNacimiento] [datetime] NOT NULL,
	[EstadoCivil] [char](1) NOT NULL,
	[IdPais] [int] NOT NULL,
	[TelefonoFijo] [varchar](20) NOT NULL,
	[TelefonoMovil] [varchar](20) NOT NULL,
	[IdTipoCalle] [int] NULL,
	[DireccionResidencia] [varchar](300) NULL,
	[NumeroIntDpto] [int] NULL,
	[ManzanaLote] [varchar](5) NULL,
	[Referencia] [varchar](200) NULL,
	[IdDepartamento] [int] NOT NULL,
	[IdProvincia] [int] NOT NULL,
	[IdDistrito] [int] NOT NULL,
	[UsuarioEmail] [varchar](300) NOT NULL,
	[Contrasena] [varchar](50) NULL,
	[Ruc] [varchar](20) NULL,
	[RolId] [int] NULL,
	[Activo] [bit] NULL,
	[FecRegistro] [datetime] NULL,
	[UsuarioModifica] [int] NULL,
	[FechaModifica] [datetime] NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]