using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.MainModule.Entities
{
    public partial class EstadoCivilClienteEntity
    {
        [Key]
        public int Id { get; set; }
        public string Estado { get; set; }
        public bool? Flag { get; set; }
    }
}
