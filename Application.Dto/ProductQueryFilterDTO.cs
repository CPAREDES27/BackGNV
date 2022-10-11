namespace Application.Dto
{
    public class ProductQueryFilterDTO
    {
        public int? IdProducto { get; set; }
        public string Descripcion { get; set; }
        public decimal? Precio { get; set; }
        public string Imagen { get; set; }
        public int? NumOrden { get; set; }
        public bool? Activo { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
