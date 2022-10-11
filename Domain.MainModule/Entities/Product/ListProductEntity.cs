using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainModule.Entities.Product
{
    public class ListProductEntity
    {
        public int IdProducto { get; set; }
        public string Descripcion { get; set; }
        public int IdTipoProducto { get; set; }
        public string TipoDescripcion { get; set; }
        public decimal Precio { get; set; }
        public string Imagen { get; set; }
        public int NumOrden { get; set; }
        public string ProveedorProducto { get; set; }

    }
}
