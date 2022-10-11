using Domain.MainModule.Entities.EvaluacionCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainModule.Entities
{
    public class EvaluationClientResponseEntity
    {

		public EvaluationClientResponseEntity()
		{
			Data = new List<ListEvaluationClient>();
			Meta = new EvaluationClientPagEntity();
		}

		public List<ListEvaluationClient> Data { get; set; }
		public EvaluationClientPagEntity Meta { get; set; }
	}
}
