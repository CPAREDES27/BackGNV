using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainModule.Entities
{
    public class TotalListPendienteSolicitud
    {
        public TotalListPendienteSolicitud()
        {
            Data = new List<ListPendienteSolicitud>();
            Meta = new List40PreguntasPaginado();
        }

        public List<ListPendienteSolicitud> Data { get; set; }
        public List40PreguntasPaginado Meta { get; set; }
    }
}
