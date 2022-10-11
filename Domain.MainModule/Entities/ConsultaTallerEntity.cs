using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainModule.Entities
{
    public class ConsultaTallerEntity
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int Activo { get; set; }
        public int IdProveedor { get; set; }
        public int IdTaller { get; set; }

    }
}
