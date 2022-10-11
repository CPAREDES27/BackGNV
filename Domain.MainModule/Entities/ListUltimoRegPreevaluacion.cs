using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainModule.Entities
{
    public class ListUltimoRegPreevaluacion
    {
       public string Apellido { get; set; }
        public string Nombre { get; set; }
        public int IdTipoDocumento { get; set; }
        public string NumDocumento { get; set; }
        public string NumPlaca { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
    }
}
