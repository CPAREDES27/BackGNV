using System.ComponentModel.DataAnnotations;

namespace Domain.MainModule.Entities
{
    public class RkCargaDocumentoEntity
    {
        [Key]
        public int IdCargaDocumentos { get; set; }
        public int? IdReglanockout { get; set; }
        public string RootArchivo { get; set; }
        public string TipoProcesoDocumento { get; set; }
    }
}
