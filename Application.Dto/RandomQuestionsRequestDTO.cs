using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class RandomQuestionsRequestDTO
    {
        public int IdPregunta { get; set; }
        public string Pregunta { get; set; }
        public string TextAyuda { get; set; }
        public string TipoDato { get; set; }
        public bool Activo { get; set; }

        public List<RandomQuestionsDetailsRequestDTO> DetailsQuestions { get; set; }
    }
}
