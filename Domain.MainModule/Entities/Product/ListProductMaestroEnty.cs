using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainModule.Entities.Product
{
    public  class ListProductMaestroEnty
    {

       public IList<ProductTipo> ListTipoProducto { get; set; }
       public IList<ProductMarca> ListMarcaProducto { get; set; }
       public IList<ProductProveedor> ListProveedorProducto { get; set; }

    }
}
