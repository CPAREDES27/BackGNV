using Application.Dto;
using Application.Manager.Interfaces;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.MainModule.Entities;
using Domain.MainModule.Entities.EvaluacionCliente;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Manager.Implementation
{
    public class EvaluationClientManager : IEvaluationClientManager
    {
        private readonly IEvaluationClientService evaluationclientService;
        private readonly IMapper mapper;

        public EvaluationClientManager(IEvaluationClientService evaluationclientService, IMapper mapper)
        {
            this.evaluationclientService = evaluationclientService;
            this.mapper = mapper;
        }

        public async Task<ListEvaluationClient> GetEvaluationClientById(int idEvalCliente)
        {
            return await evaluationclientService.GetEvaluationClientById(idEvalCliente);
        }

        public async Task<EvaluationClientFileResponseEntity> GetEvaluationClientFileById(int idEvalCliente, string nombreDocumento)
        {
            return await evaluationclientService.GetEvaluationClientFileById(idEvalCliente, nombreDocumento);
        }

        public async Task<EvaluationClientResponseEntity> ListAsync(EvaluationClientDTO request)
        {
            var evaluationclient = await evaluationclientService.GetListAsync(request);
            return evaluationclient;
        }

        public async Task<int> UpdateStatusFileEvaluationClient(EvaluationClientFileRequestDTO fileDTO)
        {
            try
            {
                int resultado = await evaluationclientService.UpdateStatusFileEvaluationClient(fileDTO);
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ListEvaluationClient> RegistrarEvaluacionCliente(RegistrarEvaluacionClienteDTO regEvaluacionClienteDto)
        {
            try
            {
                ListEvaluationClient _evaluacionClienteResponseEntity = await evaluationclientService.RegistrarEvaluacionCliente(regEvaluacionClienteDto);
               
                return _evaluacionClienteResponseEntity;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
