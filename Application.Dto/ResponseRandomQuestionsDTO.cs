using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class ResponseRandomQuestionsDTO
    {
        public int Id { get; set; }
        public string Pregunta { get; set; }
        public string textAyuda { get; set; }
        public string TipoDato { get; set; }

        public List<MenuOpciones> opciones { get; set; }
    }

    public class MenuOpciones
    {
        public int IdDetalle { get; set; }

        public string descripcion { get; set; }
    }

}
