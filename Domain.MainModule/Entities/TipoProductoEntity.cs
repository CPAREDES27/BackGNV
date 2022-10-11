using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainModule.Entities
{
    public class TipoProductoEntity
    {
        [Key]
        public int IdTipoProducto { get; set; }
        public string TipoDescripcion { get; set; }

    }
}
