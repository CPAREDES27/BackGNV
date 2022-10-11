using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainModule.Entities.EvaluacionCrediticia
{
    public class GetDetallesArchivosEntity
    {
        public int IdPreevaluacion { get; set; }
        public int IdRegla { get; set; }
        public string RootArchivo { get; set; }
        public string TipoProcesoDucumento { get; set; }
        public string NombreDocumento { get; set; }
        public int IdEstado { get; set; }
        public int IdCargaDocumento { get; set; }
    }
}
