using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.MainModule.Entities
{
    public class TipoCreditoFinanciamientoEntity
    {
        [Key]
        public int Id { get; set; }
        public string TipoCredito { get; set; }
        public bool? Flag { get; set; }
    }
}
