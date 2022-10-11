using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Manager.Interfaces;
using AutoMapper;
using Domain.MainModule;
using Infrastructure.MainModule.Interfaces;
using Domain.MainModule.Entities;
using Application.Services.Util;
using Application.Dto;
using Domain.MainModule.Entities.EvaluacionCliente;

namespace Presentation.Services.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EvaluationClientController : ControllerBase
    {
        private readonly IEvaluationClientManager evalclientManager;
        private readonly IMapper mapper;
        private readonly IUriService uriService;

        public EvaluationClientController(
            IEvaluationClientManager evalclientManager,
            IMapper mapper,
            IUriService uriService)
        {
            this.evalclientManager = evalclientManager;
            this.mapper = mapper;
            this.uriService = uriService;
        }

        [HttpPost("ListEvaluationclient")]
        public async Task<IActionResult> ListEvaluationclient(EvaluationClientDTO request)
        {
            var  resultProductEntity = await evalclientManager.ListAsync(request);
            if (resultProductEntity == null)
            {
                return Ok(new { valid = false, message = Constants.InvalidListEvluationClient });
            }
            return Ok(resultProductEntity);
        }

        [HttpGet("GetEvaluationclientById")]
        public async Task<IActionResult> GetProductById(int idevalCliente)
        {
            ListEvaluationClient resultProduct = await evalclientManager.GetEvaluationClientById(idevalCliente);

            if (resultProduct == null)
            {
                return Ok(new { valid = false, message = Constants.InvalidIdEvluationClient });
            }

            return Ok(resultProduct);
        }

        [HttpGet("GetEvaluationclientFileById")]
        public async Task<IActionResult> GetEvaluationclientFileById(int idevalCliente,string nombreDocumento)
        {
            EvaluationClientFileResponseEntity resultProduct = await evalclientManager.GetEvaluationClientFileById(idevalCliente, nombreDocumento);

            if (resultProduct == null)
            {
                return Ok(new { valid = false, message = Constants.InvalidListFileEvluationClient });
            }

            return Ok(resultProduct);
        }

        [HttpPost("UpdateStatusFileEvaluationClient")]
        public async Task<IActionResult> UpdateStatusProduct([FromBody] EvaluationClientFileRequestDTO fileDTO)
        {
            try
            {
                int resultado = await evalclientManager.UpdateStatusFileEvaluationClient(fileDTO);

                if (resultado <= 0)
                {
                    return Ok(new { valid = false, message = Constants.ResponseUpdateFileEvluationClientError });
                }

                return Ok(new { valid = true, message = Constants.InvalidFileEvluationClient });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost("RegistrarEvaluacionCliente")]
        public async Task<IActionResult> RegistrarEvaluacionCliente([FromBody] RegistrarEvaluacionClienteDTO regEvaluacionClienteDto)
        {
            try
            {
                ListEvaluationClient evaluacionclienteEntity = await evalclientManager.RegistrarEvaluacionCliente(regEvaluacionClienteDto);
                if (evaluacionclienteEntity.IdEvCliente < 0)
                {
                    return Ok(new { valid = false, message = Constants.InvalidRegisterEvaluacionCliente });
                }
                return Ok(new { valid = true, message = Constants.ResponseRegisterEvaluacionCliente });
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
