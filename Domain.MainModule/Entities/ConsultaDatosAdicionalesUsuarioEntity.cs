using System;

namespace Domain.MainModule.Entities
{
	public class ConsultaDatosAdicionalesUsuarioEntity
	{
		public bool valid { get; set; }
		public string message {get; set; }
	  public int IdUsuario { get; set; }
	  public string NomCliente { get; set; }
		public string ApeCliente { get; set; }
		public string ModeloAuto { get; set; }
		public string MarcaAuto { get; set; }
		public DateTime FechaFabricacion { get; set; }
		public string  DireccionEntrega { get; set; }
		public DateTime FechaNacimiento { get; set; }
		public int IdTaller { get; set; }
		public string NombreTaller { get; set; }
		//NEW
		public string TelefonoFijo { get; set; }
		public string TelefonoMovil { get; set; }
		public string IdDepartamento { get; set; }
		public string Departamento { get; set; }
		public string IdProvincia { get; set; }
		public string Provincia { get; set; }
		public string IdDistrito  { get; set; }
		public string Distrito { get; set; }
		public string DireccionResidencia { get; set; }

	}
}
