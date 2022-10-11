using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Security
{
    public class RolMenuHijoDTO
    {
        public int IdMenuPadre { get; set; }
        public int IdMenuHijo { get; set; }
        public int IdOpcion { get; set; }
        public string DescMenu { get; set; }
        public string Url { get; set; }
        public bool Activo { get; set; }
    }
}
