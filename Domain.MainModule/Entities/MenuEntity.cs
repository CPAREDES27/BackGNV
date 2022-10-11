using Domain.MainModule.Core;
using System.ComponentModel.DataAnnotations;

namespace Domain.MainModule.Entities
{
    public class MenuEntity : BaseEntity
    {
        [Key]
        public int IdMenu { get; set; }
        public int? IdPadre { get; set; }
        public int? IdOpcion { get; set; }
        public string DescMenu { get; set; }
        public string Url { get; set; }
        public int? Orden { get; set; }
        public bool Activo { get; set; }
        public string UrlImagen { get; set; }
    }
}
