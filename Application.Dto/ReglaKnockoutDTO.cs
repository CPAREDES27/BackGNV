using System;

namespace Application.Dto
{
    public class ReglaKnockoutDTO
    {
		public int IdPreevaluacion { get; set; }

		public DateTime? FechaVencimientoRevisioAnual { get; set; }

		public DateTime? FechaVencimientoCilindro { get; set; }

		public bool? IndicadorCreditoActivo { get; set; }

		public bool? IndicadorParaConsumir { get; set; }

		public bool? IndicadorAntiguedadMenos10Anios { get; set; } 

        public bool? IndicadorTitular20A65Anios { get; set; } 

		public bool? IndicadorDniRegistradoEnReniec { get; set; }
		 
		public bool? IndicadorDniTitularContrato { get; set; }
		 
		public bool? IndicadorLicenciaConducirVigente { get; set; }
		 
		public bool? IndicadorTitularPropietarioVehiculo { get; set; }
		 
		public bool? IndicadorSoatVigente { get; set; }
	 
		public bool? IndicadorVehiculoNoMultasPendientePago { get; set; }
		 
		public bool? IndicadorTitularNoMultasPendientePago { get; set; }
		 
		public bool? IndicadorVehiculoNoOrdenCaptura { get; set; }
		 
		public bool? IndicadorEstadoPreevaluacion { get; set; }

		public DateTime FechaRegistro { get; set; } 

        public int IdEstadoPrevaluacion { get; set; }
    }
}
