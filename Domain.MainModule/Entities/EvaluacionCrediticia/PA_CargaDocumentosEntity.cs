using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainModule.Entities.EvaluacionCrediticia
{
    public class PA_CargaDocumentosEntity
    {
        public int IdPaCargaDocumentos { get; set; }
        public int IdPostAtencion { get; set; }
        public string RootArchivo { get; set; }
        public string TipoProcesoDocumento { get; set; }
        public string NombreDocumento { get; set; }
        public int IdEstado { get; set; }
    }
}
