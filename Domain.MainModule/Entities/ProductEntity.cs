using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainModule.Entities
{
    public class ProductEntity
    {
        [Key]
        public int IdProducto { get; set; }
        public int IdTipoProducto { get; set; }
        public int IdMarcaProducto { get; set; }
        public int IdProveedorProducto { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string Imagen { get; set; }
        public int NumOrden { get; set; }
        public int IdEstado { get; set; }
        public string imagenBase64 { get; set; }
        public int UsuarioRegistro { get; set; }

        public string CodigoProducto { get; set; }
        
    }
}
