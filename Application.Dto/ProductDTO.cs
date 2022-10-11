namespace Application.Dto
{
    public class ProductDTO : BaseFilterDTO
    {
        public int IdProducto { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string Imagen { get; set; }
        public int NumOrden { get; set; }
        public int Activo { get; set; }
        public string NombreProveedor { get; set; }
        public string CodigoProducto { get; set; }
    }
}
