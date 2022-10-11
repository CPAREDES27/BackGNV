using Application.Dto;
using Domain.MainModule.Entities;
using Domain.MainModule.Entities.EvaluacionCliente;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IEvaluationClientService
    {
        Task<EvaluationClientResponseEntity> GetListAsync(EvaluationClientDTO request);

        Task<ListEvaluationClient> GetEvaluationClientById(int idEvalCliente);
        Task<EvaluationClientFileResponseEntity> GetEvaluationClientFileById(int idEvalCliente, string nombreDocumento);

        Task<int> UpdateStatusFileEvaluationClient(EvaluationClientFileRequestDTO fileDTO);
        Task<ListEvaluationClient> RegistrarEvaluacionCliente(RegistrarEvaluacionClienteDTO regEvaluacionClienteDto);

    }
}
