using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainModule.Entities.Financing
{
    public class TotalListPreevaluationEntity
    {
        public TotalListPreevaluationEntity()
        {
            Data = new List<ListPreevaluationEntity>();
            Meta = new ListPreevaluationPaginadoEntity();
        }

        public List<ListPreevaluationEntity> Data { get; set; }
        public ListPreevaluationPaginadoEntity Meta { get; set; }
    }
}

