using Application.Dto;
using Domain.MainModule.Entities;
using Domain.MainModule.Entities.EvaluacionCliente;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Manager.Interfaces
{
    public interface IEvaluationClientManager
    {

        Task<EvaluationClientResponseEntity> ListAsync(EvaluationClientDTO request);

        Task<ListEvaluationClient> GetEvaluationClientById(int idEvalCliente);

        Task<EvaluationClientFileResponseEntity> GetEvaluationClientFileById(int idEvalCliente,string nombreDocumento);

        Task<int> UpdateStatusFileEvaluationClient(EvaluationClientFileRequestDTO productDTO);
        Task<ListEvaluationClient> RegistrarEvaluacionCliente(RegistrarEvaluacionClienteDTO regEvaluacionClienteDto);

    }
}
