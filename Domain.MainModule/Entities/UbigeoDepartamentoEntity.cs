using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.MainModule.Entities
{
    public class UbigeoDepartamentoEntity
    { 

        [Key]
        public string IdDepartamento { get; set; }
        public string Departamento { get; set; } 
        public bool Flag { get; set; }
    }
}
