using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.EvaluacionCrediticia
{
    public class EvaluacionCrediticiaDTO
    {
        public int NumeroPagina { get; set; }
        public int NumeroRegistros { get; set; }
        public string NumeroExpediente { get; set; }
        public int EstadoFinanciamiento { get; set; }
    }
}
