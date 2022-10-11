

using System.ComponentModel.DataAnnotations;

namespace Domain.MainModule.Entities
{
    public  class MantPreguntasAleatoriasEntity
    {
        [Key]
        public int IdPregunta { get; set; }
        public string Pregunta { get; set; }
        public string TextAyuda { get; set; }
        public string TipoDato { get; set; }
        public bool? Activo { get; set; }
    }
}
