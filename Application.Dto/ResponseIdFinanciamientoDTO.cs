using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class ResponseIdFinanciamientoDTO
    {
        public int IdPreevaluacion { get; set; }
        public int IdSolicitudFinanciamiento { get; set; }
        public int IdReglanockout { get; set; }
        public int IdPostAtencion { get; set; }
    }
}
