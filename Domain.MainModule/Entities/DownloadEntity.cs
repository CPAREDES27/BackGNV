using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainModule.Entities
{
    public class DownloadEntity
    {
       public string Descripcion { get; set; }
       public string Valor { get; set; }
        public int Id { get; set; }
        public int IdRegla { get; set; }
        public string RootArchivo { get; set; }
        public string TipoProcesoDocumento { get; set; }
        public string NombreDocumento { get; set; }
        public int IdEstado { get; set; }

    }
}
