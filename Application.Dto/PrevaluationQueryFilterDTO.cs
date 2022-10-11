namespace Application.Dto
{
    public class PrevaluationQueryFilterDTO
    {
		public int? IdPreevaluacion { get; set; }
        public int? IdTipoDocumento { get; set; }
        public string Nombre { get; set; }
		public string Apellido { get; set; } 
		public string NumDocumento { get; set; }
		public string NumPlaca { get; set; } 
		public int? IdEstado { get; set; } 
		public int PageSize { get; set; } 
		public int PageNumber { get; set; }
		public int? IdAsesor { get; set; }
	}
}
