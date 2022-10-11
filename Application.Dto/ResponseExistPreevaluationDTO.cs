using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class ResponseExistPreevaluationDTO
    {
        public bool valid { get; set; }
        public string message { get; set; }
        public int IdPreevaluacion { get; set; }
    }
}
