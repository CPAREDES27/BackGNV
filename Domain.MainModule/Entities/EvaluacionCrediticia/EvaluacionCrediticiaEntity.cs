using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainModule.Entities.EvaluacionCrediticia
{
    public class EvaluacionCrediticiaEntity
    {
        //public List<ListEvaluacionCrediticia> listaEvaluacionCrediticia { get; set; }
        public string NumeroExpediente { get; set; }
        public string NombresApellidos { get; set; }
        //public string DNI { get; set; }
        public string Placa { get; set; }
        public int EstadoFinanciamiento { get; set; }
    }
}
