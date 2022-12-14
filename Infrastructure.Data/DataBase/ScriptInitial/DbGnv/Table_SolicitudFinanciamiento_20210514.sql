CREATE TABLE dbo.SolicitudFinanciamiento
(
	IdSolicitudFinanciamiento int IDENTITY(1,1) NOT NULL,
	--1
	Nombres varchar(50) NOT NULL,
	Apellidos varchar(50) NOT NULL,
	NumeroDocumento varchar(20) NOT NULL,
	CodigoUbigeo varchar(20) NOT NULL,
	FechaEmision datetime NOT NULL,
	FechaNacimiento datetime NOT NULL,
	EstadoCivil char(1) NOT NULL,
	IdPais int NOT NULL,
	Email varchar(150) NOT NULL,
	Celular varchar(20) NOT NULL,
	IdNivelEstudio int NOT NULL,
	--2
	Ocupacion varchar(15) NOT NULL,
	Contrato varchar(15) NOT NULL,
	MesesTiempoEmpleo int NULL,
	--3
	TipoCalle varchar(15) NOT NULL,
	TipoCalleOtros varchar(50) NULL,
	Direccion varchar(300) NULL,
	NumeroIntDpto int NULL,
	ManzanaLote varchar(5) NULL,
	--IdDepartamento int NOT NULL,
	--IdProvincia int NOT NULL,
	NombreDistrito varchar(50) NULL,
	Referencia varchar(200) NULL,
	TipoVivienda varchar(15) NOT NULL,
	AnioEnVivienda int NULL,
	MesesContratoVencer int NULL,
	TieneGasNatural bit NOT NULL,
	--4
	Placa varchar(15) NOT NULL,
	IdMarca int NOT NULL,
	IdModelo int NOT NULL,
	AnioFabricacion int NOT NULL,
	NumeroTarjetaPropiedad varchar(20) NOT NULL,
	IdTipoCilindrada int NOT NULL,
	UsoVehiculo	varchar(15) NOT NULL,
	EstadoVehiculo varchar(15) NOT NULL,
	IngresoMensual numeric(18,2) NULL,
	NumeroHijos int null,
	--5
	NombreEstablecimiento varchar(200) NOT NULL,
	TipoFinanciamiento varchar(15) NOT NULL,
	TipoFinanciamientoOtros varchar(70) NULL,
	TipoCredito varchar(15) NOT NULL,
	PlazoFinanciamiento int NOT NULL,
	MontoFinanciar numeric(18,2) NOT NULL,
	Observaciones varchar(300) NULL,
	--6
	IdTaller int NOT NULL,
	--7
	RutaFormularioUnicoDatos varchar(300) NOT NULL,
	RutaContratoFinanciamiento varchar(300) NOT NULL,
	RutaFormatoConformidad varchar(300) NOT NULL,
	--8
	RutaDocumentoIdentidad varchar(300) NOT NULL,
	RutaHud varchar(300) NOT NULL,
	RutaTarjetaPropiedad varchar(300) NOT NULL,
	RutaPermisoTaxiUltimaBoletaPago varchar(300) NOT NULL,
	RutaLicenciaConducir varchar(300) NOT NULL,
	RutaReciboServicioPublico varchar(300) NOT NULL,
	RutaRevisionTecnica varchar(300) NULL,
	RutaSoatVigente varchar(300) NOT NULL,
	RutaContratoFinanciamiento2 varchar(300) NOT NULL,
	RutaFormatoConformidad2 varchar(300) NOT NULL,
	Activo bit NULL,
	FecRegistro datetime NULL,
	UsuarioModifica int NULL,
	FechaModifica datetime NULL
)
GO

ALTER TABLE dbo.SolicitudFinanciamiento
ADD CONSTRAINT PK_SolicitudFinanciamiento
PRIMARY KEY (IdSolicitudFinanciamiento)
GO