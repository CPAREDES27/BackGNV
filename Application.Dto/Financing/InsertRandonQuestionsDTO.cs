using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Financing
{
    public class InsertRandonQuestionsDTO
    {
        public int IdPregunta { get; set; }
        public string Pregunta { get; set; }
        public string TextAyuda { get; set; }
        public string TipoDato { get; set; }
        public bool ActivoCabecera { get; set; }
        public List<RandonQuestionDetalle> detailsQuestions { get; set; }
        
    }

    public class RandonQuestionDetalle
    {
        public int IdPregunta { get; set; }
        public int IdDetalle { get; set; }
        public bool ActivoDetalle { get; set; }
        public string DescripcionDetalle { get; set; }
    }
}
