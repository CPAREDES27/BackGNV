using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainModule.Entities
{
    public class EvaluationClientFileResponseEntity
    {
        public int idCargaDocumento { get; set; }
        public string rutaDocumento { get; set; }
        public string nombreDocumento { get; set; }
        public string estadoDocumento { get; set; }
    }
}
