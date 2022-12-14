USE [DBGNV]
GO

CREATE TABLE dbo.ReglaKnockout
(
	IdReglanockout int identity(1,1),
	IdPreevaluacion int not null,
	FechaVencimientoRevisioAnual datetime not null,
	FechaVencimientoCilindro datetime not null,
	IndicadorCreditoActivo bit not null,
	IndicadorParaConsumir bit not null,
	IndicadorAntiguedadMenos10Anios bit not null,
	RutaAntiguedadMenos10Anios varchar(500) null,
	IndicadorTitular20A65Anios bit not null,
	RutaTitular20A65Anios varchar(500) null,
	IndicadorDniRegistradoEnReniec bit not null,
	RutaDniRegistradoEnReniec varchar(500) null,
	IndicadorDniTitularContrato bit not null,
	RutaDniTitularContrato varchar(500) null,
	IndicadorLicenciaConducirVigente bit not null,
	RutaLicenciaConducirVigente varchar(500) null,
	IndicadorTitularPropietarioVehiculo bit not null,
	RutaTitularPropietarioVehiculo varchar(500) null,
	IndicadorSoatVigente bit not null,
	RutaSoatVigente varchar(500) null,
	IndicadorVehiculoNoMultasPendientePago bit not null,
	RutaVehiculoNoMultasPendientePago varchar(500) null,
	IndicadorTitularNoMultasPendientePago bit not null,
	RutaTitularNoMultasPendientePago varchar(500) null,
	IndicadorVehiculoNoOrdenCaptura bit not null,
	RutaVehiculoNoOrdenCaptura varchar(500) null,
	IndicadorEstadoPreevaluacion bit not null,
	FechaRegistro datetime not null,
	UsuarioModifica int null,
	FechaModifica datetime null
)
GO

ALTER TABLE dbo.ReglaKnockout
ADD CONSTRAINT PK_ReglaKnockout
PRIMARY KEY (IdReglanockout)
GO

ALTER TABLE dbo.ReglaKnockout
ADD CONSTRAINT FK_ReglaKnockout_Preevaluacion
FOREIGN KEY (IdPreevaluacion)
REFERENCES dbo.Preevaluacion
GO