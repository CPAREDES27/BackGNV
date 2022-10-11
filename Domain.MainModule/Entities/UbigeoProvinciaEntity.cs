using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.MainModule.Entities
{
    public class UbigeoProvinciaEntity
    { 
        [Key]
        public string IdProvinicia { get; set; }
        public string Provincia { get; set; }
        public string IdDepartamento { get; set; }
         
    }
}
