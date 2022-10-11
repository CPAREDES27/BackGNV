using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainModule.Entities.EvaluacionCrediticia
{
    public class TotalEvaluacionCrediticialEntity
    {
        public TotalEvaluacionCrediticialEntity() {
            Data = new List<ListEvaluacionCrediticia>();
            Meta = new EvaluacionCrediticiaPaginadoEntity();
        }
           
        public List<ListEvaluacionCrediticia> Data { get; set; }
        public EvaluacionCrediticiaPaginadoEntity Meta { get; set; }

    }
}
