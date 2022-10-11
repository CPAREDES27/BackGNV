using System.Collections.Generic;

namespace Application.Dto
{
    public class ListPrevaluationPagDTO
    {
        public int TotalReg { get; set; }
        public List<PreEvaluationDTO> PreEvaluationDto { get; set; }
    }
}
