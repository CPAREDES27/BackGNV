using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainModule.Entities.EvaluacionCrediticia
{
    public class TotalCargaPostAtencionEntity
    {
        public TotalCargaPostAtencionEntity()
        {
            Data = new List<ListCargaPostAtencionEntity>();
            Meta = new EvaluacionCrediticiaPaginadoEntity();
        }

        public List<ListCargaPostAtencionEntity> Data { get; set; }
        public EvaluacionCrediticiaPaginadoEntity Meta { get; set; }
    }
}
