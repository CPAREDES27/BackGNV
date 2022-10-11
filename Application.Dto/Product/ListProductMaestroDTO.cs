using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Product
{
    public class ListProductMaestroDTO
    {
        public IList<ProductTiposDTO> ListTipoProducto { get; set; }
        public IList<ProductMarcaDTO> ListMarcaProducto { get; set; }
        public IList<ProductProveedorDTO> ListProveedorProducto { get; set; }
    }
}
