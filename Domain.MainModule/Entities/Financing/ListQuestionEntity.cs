using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainModule.Entities.Financing
{
    public class ListQuestionEntity
    {
        public int IdPregunta { get; set; }
        public string Pregunta { get; set; }
        public string TextAyuda { get; set; }
        public string TipoDato { get; set; }
    }
}
