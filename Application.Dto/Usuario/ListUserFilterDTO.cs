using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Usuario
{
    public  class ListUserFilterDTO
    {
        public int NumeroPagina { get; set; }
        public int NumeroRegistros { get; set; }
        public int RolId { get; set; }
        public string NumDocumento { get; set; }
    }
}
