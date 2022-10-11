using Application.Dto.CentralFile;
using System.Collections.Generic;

namespace Application.Dto.UploadDocuments.KnockoutRules
{
    public class UploadDocumentSupportDTO
    {
        public string NumDocument { get; set; }
        /// <summary>
        /// Lista de archivos como sustento de la prevaluacion
        /// </summary>
        public List<Archivo> Archivos { get; set; }
    }
}
