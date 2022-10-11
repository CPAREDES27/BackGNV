using Application.Dto.CentralFile;
using System.Collections.Generic;

namespace Application.Dto.UploadDocuments.RequestFinancing
{
    /// <summary>
    /// Obtener la carga de documentos del cliente "Solicitud de financiamiento"
    /// </summary>
    public class UploadDocumentsDTO
    {
        /// <summary>
        /// Obtener el ID cliente del solicitante del financiamiento
        /// </summary>
        public int IdCliente { get; set; }


        /// <summary>
        /// Lista de archivos
        /// </summary>
        public List<Archivo> Archivos { get; set; }
        

    }
}
