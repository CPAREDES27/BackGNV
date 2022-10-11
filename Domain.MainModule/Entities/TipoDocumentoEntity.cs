using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.MainModule.Entities
{
    public class TipoDocumentoEntity
    {
        [Key]
        public int IdTipoDocumento { get; set; }
        public string TipoDocumento { get; set; }

        public bool Activo { get; set; }
    }
}
