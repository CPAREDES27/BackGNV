using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.MainModule.Entities
{
    public class SfCargaDocumentoEntity
    {
        [Key]
        public int IdCargaDocumentos { get; set; }

        public int IdSfCliente { get; set; }

        public string RootArchivo { get; set; }

        public string TipoFlujoDocumento { get; set; }

    }
}
