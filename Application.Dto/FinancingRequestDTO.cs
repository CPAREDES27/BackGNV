using System;
using System.ComponentModel.DataAnnotations;

namespace Application.Dto
{
    public class FinancingRequestDTO
    {
        public int IdCliente { get; set; }

        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        public string NumeroDocumento { get; set; }

        public string CodUbigeo { get; set; }

        public DateTime FechaEmision { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public int EstadoCivil { get; set; }

        public string CorreoElectronico { get; set; }

        public string Celular { get; set; }

        public int IdNivelEstudios { get; set; }

        public string Ocupacion { get; set; }

        public string TipoContrato { get; set; }

        public string TiempoEmpleoCliente { get; set; }

        public string TipoCalle { get; set; }

        public string Direccion { get; set; }

        public int NumeroInterior { get; set; }

        public string MzLt { get; set; }

        public string Distrito { get; set; }

        public string ReferenciaDomicilio { get; set; }

        public string TipoVivienda { get; set; }

        public int TiempoAnoVivienda { get; set; }

        public int TiempoMesesVivienda { get; set; }

        public bool IsGasNatural { get; set; }

        public string NumeroPlaca { get; set; }

        public string MarcaAuto { get; set; }

        public string ModeloAuto { get; set; }

        public string FechaFabricacion { get; set; }

        public string NumeroTarjetaPropiedad { get; set; }

        public string TipoCilindroMotor { get; set; }

        public bool TipoUsoVehicular { get; set; }

        public int EstadoVehiculo { get; set; }

        public string IngresoMensual { get; set; }

        public int NumeroHijos { get; set; }

        public string NombreEstablecimiento { get; set; }

        public int TipoFinanciamiento { get; set; }

        public int TipoCredito { get; set; }

        public string PlazoCuotasFinanciamiento { get; set; }

        public int MontoFinanciamiento { get; set; }

        public string Observaciones { get; set; }

        public int IdTaller { get; set; }

        public string ClaseVehiculo { get; set; }

        public string NumeroAsientos { get; set; }

        public string NumeroMotor { get; set; }

        public string NumeroSerie { get; set; }

        public int NumeroScore { get; set; }
        public int? IdPreevaluacion { get; set; }

        public bool? FlagContratoFinanciamiento { get; set; }
        public bool? FlagFormatoConformidad { get; set; }
        public bool? FlagDNI { get; set; }
        public string DigitoVerificadorDNI {get; set;}

        public bool? FlagpoliticasCondiciones { get; set; }
        public string MesAnio { get; set; }
        public Int64 IdSfClientetemp { get; set; }
    }
}
