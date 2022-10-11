using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.MainModule.Entities
{
    public class TallerEntity
    {
        [Key]
        public int IdTaller { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public bool Activo { get; set; }
    
    }
}
