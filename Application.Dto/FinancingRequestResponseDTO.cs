using System;

namespace Application.Dto
{
    public class FinancingRequestResponseDTO
    {
        public int IdSolicitudFinanciamiento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string NumeroDocumento { get; set; }
        public string CodigoUbigeo { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string EstadoCivil { get; set; }
        public int IdPais { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public int IdNivelEstudio { get; set; }
        public string Ocupacion { get; set; }
        public string Contrato { get; set; }
        public int? MesesTiempoEmpleo { get; set; }
        public string TipoCalle { get; set; }
        public string TipoCalleOtros { get; set; }
        public string Direccion { get; set; }
        public int? NumeroIntDpto { get; set; }
        public string ManzanaLote { get; set; }
        public string NombreDistrito { get; set; }
        public string Referencia { get; set; }
        public string TipoVivienda { get; set; }
        public int AnioEnVivienda { get; set; }
        public int MesesContratoVencer { get; set; }
        public bool TieneGasNatural { get; set; }
        public string Placa { get; set; }
        public int IdMarca { get; set; }
        public int IdModelo { get; set; }
        public int AnioFabricacion { get; set; }
        public string NumeroTarjetaPropiedad { get; set; }
        public int IdTipoCilindrada { get; set; }
        public string UsoVehiculo { get; set; }
        public string EstadoVehiculo { get; set; }
        public decimal IngresoMensual { get; set; }
        public int NumeroHijos { get; set; }
        public string NombreEstablecimiento { get; set; }
        public string TipoFinanciamiento { get; set; }
        public string TipoFinanciamientoOtros { get; set; }
        public string TipoCredito { get; set; }
        public int PlazoFinanciamiento { get; set; }
        public decimal MontoFinanciar { get; set; }
        public string Observaciones { get; set; }
        public int IdTaller { get; set; }
        public string RutaFormularioUnicoDatos { get; set; }
        public string RutaContratoFinanciamiento { get; set; }
        public string RutaFormatoConformidad { get; set; }
        public string RutaDocumentoIdentidad { get; set; }
        public string RutaHud { get; set; }
        public string RutaTarjetaPropiedad { get; set; }
        public string RutaPermisoTaxiUltimaBoletaPago { get; set; }
        public string RutaLicenciaConducir { get; set; }
        public string RutaReciboServicioPublico { get; set; }
        public string RutaRevisionTecnica { get; set; }
        public string RutaSoatVigente { get; set; }
        public string RutaContratoFinanciamiento2 { get; set; }
        public string RutaFormatoConformidad2 { get; set; }
        public bool Activo { get; set; }
        public DateTime FecRegistro { get; set; }
        public int? UsuarioModifica { get; set; }
        public DateTime? FechaModifica { get; set; }
    }
}
