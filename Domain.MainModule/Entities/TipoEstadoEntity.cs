using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.MainModule.Entities
{
    public class TipoEstadoEntity
    {
        [Key]
        public int IdEstado { get; set; }
        public string Estado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool? Activo { get; set; }
    }
}
