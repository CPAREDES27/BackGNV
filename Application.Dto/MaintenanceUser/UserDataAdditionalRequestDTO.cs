using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.MaintenanceUser
{
	public class UserDataAdditionalRequestDTO
	{
		public int IdPreevaluacion { get; set; }
		public int IdUsuario { get; set; }
		public string ModeloAuto { get; set; }
		public string MarcaAuto { get; set; }
		public DateTime FechaFabricacion { get; set; }
		public string DireccionEntrega {get; set;}
		public DateTime FechaNacimiento { get; set; }
		public string Observacion { get; set; }
		public int IdUsuarioRegistro { get; set; }
		public int IdTaller { get; set; }
		//NEW
		public string  NomCliente { get; set; }
		public string ApeCliente { get; set; }
		public string TelefonoFijo { get; set; }
		public string TelefonoMovil { get; set; }
		public string DireccionResidencia { get; set; }
		public string IdDepartamento { get; set; }
		public string IdProvincia { get; set; }
		public string IdDistrito { get; set; }
	}
}
