using System;

namespace Domain.MainModule.Entities.EvaluacionCliente
{
    public class ListEvaluationClient
    {
		public int IdEvCliente { get; set; }
		public string NumExpediente { get; set; }
		public string Nombre { get; set; }
		public string Apellido { get; set; }
		public string NumDocumento { get; set; }
		public DateTime FechaNacimiento { get; set; }
		public string TelefonoFijo { get; set; }
		public string TelefonoMovil { get; set; }
		public string UsuarioEmail { get; set; }
		public string NumPlaca { get; set; }
		public string Estado { get; set; }
		public int IdEstado { get; set; }
		public string Producto { get; set; }
		public decimal Precio { get; set; }
		public string Proveedor { get; set; }
		public int IdReglanockout { get; set; }
		public int IdEstadoPreevaluacion { get; set; }
		public string CorreoProveedor { get; set; }
		public int IdPreevaluacion { get; set; }
		public int IdCliente { get; set; }
		//New
		public string Ruc { get; set; }
		public string RazonSocial { get; set; }
		public string IdDepartamento { get; set; }
		public string Departamento { get; set; }
		public string IdProvincia { get; set; }
		public string Provincia { get; set; }
		public string IdDistrito { get; set; }
		public string Distrito { get; set; }
		public string DireccionResidencia { get; set; }
		public string ModeloAuto { get; set; }
		public string MarcaAuto { get; set; }
	}
}
