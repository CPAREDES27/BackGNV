using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainModule.Entities
{
    public class ListLineaTiempoEntity
    {
		public int IdPreevaluacion { get; set; }
		public string  FechaRegistro { get; set; }
		public string Estado { get; set; }
		public string Producto { get; set; }
		public string Observaciones { get; set; }
		public string FechaDespacho { get; set; }
		public string Eactual { get; set; }
		public int NroPaso { get; set; }
		public string DescripcionPaso { get; set; }
	}
}
