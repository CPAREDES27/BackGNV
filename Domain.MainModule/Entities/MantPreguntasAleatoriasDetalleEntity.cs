
using System.ComponentModel.DataAnnotations;

namespace Domain.MainModule.Entities
{
    public class MantPreguntasAleatoriasDetalleEntity
    {
        [Key]
        public int IdDetalle { get; set; }
        public int IdPregunta { get; set; }
        public string Descripcion { get; set; }
        public bool? Activo { get; set; }
    }
}
