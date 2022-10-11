using System;

namespace Application.Dto
{
    public class RegisterPreEvaluationDTO
    {
		public int IdPreevaluacion { get; set; }
		public string Nombre { get; set; }
		public string Apellido { get; set; }
		public int IdTipoDocumento { get; set; }
		public string NumDocumento { get; set; }
		public string NumPlaca { get; set; }
		public string Email { get; set; }
		public string Celular { get; set; }
		public bool TermCondiciones { get; set; }
		public bool FinComerciales { get; set; }
		public int IdEstado { get; set; }
		public DateTime FechaRegistro { get; set; }
		public string NombreAsesorReferido { get; set; }
		public int IdProducto { get; set; }
		public bool FlagUser { get; set; }
		public int IdAsesor { get; set; }
	}
}
