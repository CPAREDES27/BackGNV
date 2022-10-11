USE DBGNV
GO

CREATE TABLE dbo.Taller
(
IdTaller int identity(1,1) NOT NULL,
Nombre varchar(150) NOT NULL,
Direccion varchar(300) NOT NULL,
Activo bit NOT NULL,
FecRegistro datetime NULL,
UsuarioModifica int NULL,
FechaModifica datetime NULL
)
GO

ALTER TABLE dbo.Taller
ADD CONSTRAINT PK_Taller
PRIMARY KEY (IdTaller)
GO