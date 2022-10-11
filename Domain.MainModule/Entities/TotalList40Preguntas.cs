using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainModule.Entities
{
    public class TotalList40Preguntas
    {
        public TotalList40Preguntas()
        {
            Data = new List<List40Preguntas>();
            Meta = new List40PreguntasPaginado();
        }

        public List<List40Preguntas> Data { get; set; }
        public List40PreguntasPaginado Meta { get; set; }

    }
}
