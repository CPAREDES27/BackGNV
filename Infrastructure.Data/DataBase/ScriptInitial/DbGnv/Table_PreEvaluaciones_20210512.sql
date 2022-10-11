
CREATE TABLE [dbo].[Preevaluaciones](
	[IdPreevaluacion] [int] IDENTITY(1,1) NOT NULL,
	[Apellido] [varchar](80) NULL,
	[Nombre] [varchar](80) NULL,
	[IdTipoDocumento] [int] NOT NULL,
	[NumDocumento] [varchar](30) NOT NULL,
	[NumPlaca] [varchar](30) NOT NULL,
	[Email] [varchar](130) NOT NULL,
	[Celular] [varchar](30) NOT NULL,
	[TermCondiciones] [bit] NOT NULL,
	[FinComerciales] [bit] NOT NULL,
	[IdEstado] [int] NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
	[UsuarioModifica] [int] NULL,
	[FechaModifica] [datetime] NULL
)

ALTER TABLE [dbo].[Preevaluacion]
ADD CONSTRAINT [PK_Preevaluacion]
PRIMARY KEY ([IdPreevaluacion])
GO