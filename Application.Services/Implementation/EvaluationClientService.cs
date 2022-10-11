using Application.Dto;
using Application.Dto.CustomEntities;
using Application.Services.Interfaces;
using Domain.MainModule;
using Domain.MainModule.Entities;
using Domain.MainModule.Entities.EvaluacionCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implementation
{
    public class EvaluationClientService : IEvaluationClientService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EvaluationClientService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
       
        public async Task<ListEvaluationClient> GetEvaluationClientById(int idEvalCliente)
        {
            return await _unitOfWork.evaluationClientRepository.GetEvaluationClientById(idEvalCliente);
        }

        public async Task<EvaluationClientFileResponseEntity> GetEvaluationClientFileById(int idEvalCliente, string nombreDocumento)
        {
            return await _unitOfWork.evaluationClientRepository.GetEvaluationClientFileById(idEvalCliente, nombreDocumento);
        }

        public async Task<EvaluationClientResponseEntity> GetListAsync(EvaluationClientDTO request)
        {
            return await _unitOfWork.evaluationClientRepository.GetListAsync(request);
        }

        public async Task<int> UpdateStatusFileEvaluationClient(EvaluationClientFileRequestDTO fileDTO)
        {
            return await _unitOfWork.evaluationClientRepository.UpdateStatusFileEvaluationClient(fileDTO);
        }

        public async Task<ListEvaluationClient> RegistrarEvaluacionCliente(RegistrarEvaluacionClienteDTO regEvaluacionClienteDto)
        {
            try
            {
                return await _unitOfWork.evaluationClientRepository.RegistrarEvaluacionCliente(regEvaluacionClienteDto);
               
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
