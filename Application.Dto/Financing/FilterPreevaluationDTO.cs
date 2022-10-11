using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Financing
{
    public class FilterPreevaluationDTO
    {
        public int IdPreevaluacion { get; set; }
        public int IdTipoDocumento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NumDocumento { get; set; }
        public string NumPlaca { get; set; }
        public int IdEstado { get; set; }
        public int NumeroPagina { get; set; }
        public int NumeroRegistros { get; set; }
        public int IdAsesor { get; set; }

    }
    }
