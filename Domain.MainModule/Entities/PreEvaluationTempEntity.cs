using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.MainModule.Entities
{
    public  class PreEvaluationTempEntity
    {
		[Key]
		public int IdPreevaluacion { get; set; }
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
		public DateTime FechaRegistro { get; set; }
		public int? UsuarioModifica { get; set; }
		public DateTime? FechaModifica { get; set; }
		public string NombreAsesorReferido { get; set; }
		public int IdProducto { get; set; }
		public bool? FlagUser { get; set; }
		public int? IdAsesor { get; set; }
		//response
		public string Producto { get; set; }
		public decimal? Precio { get; set; }
		public string Proveedor { get; set; }
		public int IdTipoProducto { get; set; }
		public string TipoDescripcion { get; set; }
		public int IdProveedorProducto { get; set; }
		public int IdEstadoPreevaluacion { get; set; }
	}
}
