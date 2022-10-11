using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class RespuestaRegisterDto
    {
        public string Correo { get; set; }
        public string NumeroDocumento { get; set; }
        public string Mensaje { get; set; }

        public string Response { get; set; }
    }
}
