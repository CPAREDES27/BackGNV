using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class ProductRequestDTO
    {
        public int IdProducto { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string Imagen { get; set; }
        public int NumOrden { get; set; }
        public bool Activo { get; set; }
        public int IdTipoProducto { get; set; }
        public int IdMarca { get; set; }
        public int IdProveedor { get; set; }
        public string imagenBase64 { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public string CodigoProducto { get; set; }
    }
}
