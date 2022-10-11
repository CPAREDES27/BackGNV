CREATE TABLE [dbo].[MenuHijo](
	[IdMenuHijo] [int] IDENTITY(1,1) NOT NULL,
	[IdMenuPadre] [int] NOT NULL,
	[IdOpcion] [int] NULL,
	[DescMenu] [varchar](200) NULL,
	[Url] [varchar](500) NULL,
	[Orden] [int] NULL,
	[Activo] [bit] NOT NULL,
	[UrlImagen] [nvarchar](200) NULL,
 CONSTRAINT [PK_MenuHijo] PRIMARY KEY CLUSTERED 
(
	[IdMenuHijo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



CREATE TABLE [dbo].[MenuPadre](
	[IdMenuPadre] [int] IDENTITY(1,1) NOT NULL,
	[IdOpcion] [int] NULL,
	[DescMenu] [varchar](200) NULL,
	[Url] [varchar](500) NULL,
	[Orden] [int] NULL,
	[Activo] [bit] NOT NULL,
	[UrlImagen] [nvarchar](200) NULL,
 CONSTRAINT [PK_MenuPadre] PRIMARY KEY CLUSTERED 
(
	[IdMenuPadre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]