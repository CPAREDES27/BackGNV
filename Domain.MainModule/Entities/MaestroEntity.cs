using System.ComponentModel.DataAnnotations;

namespace Domain.MainModule.Entities
{
    public class MaestroEntity
    {
        [Key]
        public int IdMaestro { get; set; }
        public string Descripcion { get; set; }
        public string Valor { get; set; }
        public string Clave { get; set; }

        public bool Activo { get; set; }

    }
}
