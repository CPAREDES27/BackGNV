using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Product
{
    public class ProductFilterDTO
    {
        public int? IdProducto { get; set; }
        public string Descripcion { get; set; }
        public decimal? Precio { get; set; }
        public string Imagen { get; set; }
        public int? NumOrden { get; set; }
        public int NumeroPagina { get; set; }
        public int NumeroRegistros { get; set; }
        public int idProveedor { get; set; }
    }
}
