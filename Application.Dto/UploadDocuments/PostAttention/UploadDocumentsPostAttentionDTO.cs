using Application.Dto.CentralFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.UploadDocuments.PostAttention
{
    public class UploadDocumentsPostAttentionDTO
    {
        public int IdPostAtencion { get; set; }
        public int IdEstadoPostAtencion { get; set; }
        public string Observacion { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaDespacho { get; set; }
        public List<Archivo> Archivos { get; set; }
        
    }
}
