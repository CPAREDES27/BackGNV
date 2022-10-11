using System.ComponentModel.DataAnnotations;

namespace Domain.MainModule.Entities
{
    public class EstadoTipoFinanciamientoEntity
    {
        [Key]
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool? Activo { get; set; }
        public string TipoCredito { get; set; }
    }
}
