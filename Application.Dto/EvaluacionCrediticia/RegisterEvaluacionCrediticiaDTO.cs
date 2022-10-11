using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.EvaluacionCrediticia
{
    public class RegisterEvaluacionCrediticiaDTO
    {
        public int IdEvCliente { get; set; }
        public int EntidadSBS { get; set; }
        public int ValorDeuda { get; set; }
        public int ReporteSBS { get; set; }
        public int IdEstado { get; set; }
        public int UsuarioRegistro { get; set; }
        public string Observaciones { get; set; }
        public int InformacionCR { get; set; }
        public decimal LineaCredito { get; set; }
    }
}
