using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class ResponseRKByIdPrevaluationDTO
    {
		public bool valid { get; set; }
		public string message { get; set; }
		public int IdReglanockout { get; set; }
		public DateTime FechaVencimientoRevisioAnual { get; set; }
		public DateTime FechaVencimientoCilindro { get; set; }
		public bool IndicadorCreditoActivo { get; set; }
		public bool IndicadorParaConsumir { get; set; }
		public bool IndicadorAntiguedadMenos10Anios { get; set; }
		public bool IndicadorTitular20A65Anios { get; set; }
		public bool IndicadorDniRegistradoEnReniec { get; set; }
		public bool IndicadorDniTitularContrato { get; set; }
		public bool IndicadorLicenciaConducirVigente { get; set; }
		public bool IndicadorTitularPropietarioVehiculo { get; set; }
		public bool IndicadorSoatVigente { get; set; }
		public bool IndicadorVehiculoNoMultasPendientePago { get; set; }
		public bool IndicadorTitularNoMultasPendientePago { get; set; }
		public bool IndicadorVehiculoNoOrdenCaptura { get; set; }
		public bool IndicadorEstadoPreevaluacion { get; set; }
		public int IdEstadoPrevaluacion { get; set; }
		public string EstadoPrevaluacion { get; set; }
		public DateTime? FechaVencimientoSOAT { get; set; }
		public bool IndicadorVehiculoFuncionaGNV { get; set; }
		public string fileVehiculoGNV { get; set; }
		public string fileLicenciaVigente { get; set; }
		public string filePropietarioVehiculo { get; set; }
		public string fileSoatVigente { get; set; }
		public string fileMultastransito { get; set; }
		public string fileOrdenCaptura { get; set; }

	}
}
