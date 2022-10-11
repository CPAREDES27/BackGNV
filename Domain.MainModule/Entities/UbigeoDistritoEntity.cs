using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.MainModule.Entities
{
    public class UbigeoDistritoEntity
    {
        [Key]
        public string IdDistrito { get; set; }
        public string Distrito { get; set; }
        public string IdProvinicia { get; set; }
        public string IdDepartamento { get; set; }
         
    }
}
