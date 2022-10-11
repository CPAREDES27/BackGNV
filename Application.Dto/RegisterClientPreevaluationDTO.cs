using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class RegisterClientPreevaluationDTO
    {
		public string Apellido { get; set; }
		public string Nombre { get; set; }
		public int IdTipoDocumento { get; set; }
		public string NumDocumento { get; set; }
		public string NumPlaca { get; set; }
		public string Email { get; set; }
		public string Celular { get; set; }
		public bool TermCondiciones { get; set; }
		public bool FinComerciales { get; set; }
		public int IdEstado { get; set; }
		public string NombreAsesorReferido { get; set; }
		public int IdProducto { get; set; }
		public bool? FlagUser { get; set; }
		public int? IdAsesor { get; set; }

		public string FechaNacimiento { get; set; }

		public string DireccionSentinel { get; set; }

		public int? IdActUsuario { get; set; }
		public string Contrasena { get; set; }
	}
}
