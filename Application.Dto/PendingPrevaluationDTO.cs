namespace Application.Dto
{
    public class PendingPrevaluationDTO
    {
		public int IdPreevaluacion { get; set; }
		public string Apellido { get; set; }
		public string Nombre { get; set; } 
		public string NumDocumento { get; set; }
		public string NumPlaca { get; set; }
		public string Celular { get; set; }
		public string Email { get; set; }
		public string NombreAsesorReferido { get; set; } 
		public string Producto { get; set; }
		public decimal Precio { get; set; }
		public string Proveedor { get; set; }
		public int IdTipoDocumento { get; set; }
		public string CorreoProveedor { get; set; }
		public int? IdUsuario { get; set; }
		public int IdProducto { get; set; }
		public string EmailAsesor { get; set; }
		public int IdEstadoPreevaluacion { get; set; }
		public int IdTipoProducto { get; set; }

 	}
}
