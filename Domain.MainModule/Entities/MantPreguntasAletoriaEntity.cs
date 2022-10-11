using System.ComponentModel.DataAnnotations;

namespace Domain.MainModule.Entities
{
    public class MantPreguntasAletoriaEntity
    {
        [Key]
        public int Id { get; set; }
        public string Pregunta { get; set; }
        public string Respuesta { get; set; }
        public string TipoDato { get; set; }
        public bool Activo { get; set; }
    }
}
