using Application.Dto.EvaluacionCrediticia;
using Application.Manager.Interfaces;
using Application.Services.Util;
using AutoMapper;
using Domain.MainModule.Entities.EvaluacionCrediticia;
using Infrastructure.MainModule.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Services.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EvaluacionCrediticiaController : ControllerBase
    {
        private readonly IEvaluacionCrediticiaManager evalcrediticiaManager;
        private readonly IMapper mapper;
        private readonly IUriService uriService;

        public EvaluacionCrediticiaController(
            IEvaluacionCrediticiaManager evalcrediticiaManager,
            IMapper mapper,
            IUriService uriService)
        {
            this.evalcrediticiaManager = evalcrediticiaManager;
            this.mapper = mapper;
            this.uriService = uriService;
        }

        [HttpPost("ListEvaluationclient")]
        public async Task<IActionResult> ListEvaluationclient(EvaluacionCrediticiaDTO request)
        {
            var resultado = await evalcrediticiaManager.GetEvaluacionCrediticia(request);
            if (resultado == null)
            {
                return Ok(new { valid = false, messaje = Constants.InvalidGetEvaluacionCrediticia });
            }
            return Ok(resultado);
        }

        [HttpGet("GetDetalleEvaluacionCrediticia")]
        public async Task<IActionResult> GetDetalleEvaluacionCrediticia(int idEvalCliente, string tipoDocumento, string documento)
        {
            var resultado = await evalcrediticiaManager.GetDetalleEvaluacionCrediticia(idEvalCliente, tipoDocumento, documento);
            if (resultado == null)
            {
                return Ok(new { valid = false, message = Constants.InvalidGetEvaluacionCrediticia });
            }
            return Ok(resultado);
        }

        [HttpGet("GetDetalleArchivos")]
        public async Task<IActionResult> GetDetalleArchivos(int idPreevaluacion)
        {
            var resultado = await evalcrediticiaManager.GetDetalleArchivos(idPreevaluacion);
            if (resultado.Count <= 0)
            {
                return Ok(new { valid = false, message = Constants.InvalidGetEvaluacionCrediticia });
            }
            return Ok(resultado);
        }

        [HttpPost("ListarEvaluacionCrediticia")]
        public async Task<IActionResult> ListarEvaluacionCrediticia(ListaEvaluacionCrediticiaDTO request)
        {
            var resultado = await evalcrediticiaManager.ListarEvaluacionCrediticia(request);
            if (resultado == null)
            {
                return Ok(new { valid = false, message = Constants.InvalidGetEvaluacionCrediticia });
            }
            return Ok(resultado);

        }

        [HttpPost("RegisterEvaluacionCrediticia")]
        public async Task<IActionResult> RegisterEvaluacionCrediticia(RegisterEvaluacionCrediticiaDTO request)
        {
            var resultado = await evalcrediticiaManager.RegisterEvaluacionCrediticia(request);
            if (resultado <= 0)
            {
                return Ok(new { valid = false, message = Constants.InvalidRegisterEvaluacionCrediticia });
            }
            return Ok(new { valid = true, message = Constants.ReponseRegisterEvaluacionCrediticia, IdEvCrediticia= resultado });

        }
      
        [HttpPost("ListarPostAtencion")]
        public async Task<IActionResult> ListarPostAtencion(ListaEvaluacionCrediticiaDTO request)
        {
            var resultado = await evalcrediticiaManager.ListarPostAtencion(request);
            if (resultado == null)
            {
                return Ok(new { valid = false, message = Constants.InvalidCargaPostAtencion });
            }
            return Ok(resultado);

        }
       
        [HttpGet("DetallePostAtencion")]
        public async Task<IActionResult> DetallePostAtencion(int idPostAtencion)
        {
            var resultado = await evalcrediticiaManager.DetallePostAtencion(idPostAtencion);
            if (resultado == null)
            {
                return Ok(new { valid = false, message = Constants.InvalidDetallePostAtencion });
            }
            return Ok(resultado);
        }
      
        [HttpGet("CargaDocumentos_PA")]
        public async Task<IActionResult> CargaDocumentos_PA(int idPostAtencion, string nombreDocumento)
        {
            var resultado = await evalcrediticiaManager.CargaDocumentos_PA(idPostAtencion, nombreDocumento);
            if (resultado == null)
            {
                return Ok(new { valid = false, message = Constants.InvalidPA_CargaDocumentos });
            }
            return Ok(resultado);
        }
        
        [HttpPost("UpdatePA_CargaDocumentos")]
        public async Task<IActionResult> UpdatePA_CargaDocumentos(UpdateCargaDocumentosPADTO request)
        {
            var resultado = await evalcrediticiaManager.UpdatePA_CargaDocumentos(request);
            if (resultado <= 0)
            {
                return Ok(new { valid = false, message = Constants.InvalidUpdateCargaDocumentosPA });
            }
            return Ok(new { valid = true, message = Constants.ReponseUpdateCargaDocumentosPA });

        }

        [HttpPost("InsertarIndividual")]
        public async Task<IActionResult> InsertarIndividual(CargaOnBaseIndividualDTO request)
        {
            var resultado = await evalcrediticiaManager.InsertarIndividual(request);

            if (resultado == 0)
            {
                return Ok(new { valid = false, message = Constants.InvalidRegisterCargaOnBase });
            }
            else if (resultado == -1)
            {
                return Ok(new { valid = false, message = Constants.InvalidPathCargaOnBase });
            }
            else
            {
                return Ok(new { valid = true, message = Constants.ReponseRegisterCargaOnBase });
            }
        }

        [HttpPost("InsertarMasivo")]
        public async Task<IActionResult> InsertarMasivo()
        {
            var resultado = await evalcrediticiaManager.InsertarMasivo();

            if (resultado == 0)
            {
                return Ok(new { valid = false, message = Constants.InvalidRegisterCargaOnBase });
            }
            else if (resultado == -1)
            {
                return Ok(new { valid = false, message = Constants.InvalidPathCargaOnBase });
            }
            else
            {
                return Ok(new { valid = true, message = Constants.ReponseRegisterCargaOnBase });
            }
        }
       
        [HttpGet("ConsultaFormatoSolicitud")]
        public async Task<IActionResult> ConsultaFormatoSolicitud(int idPrevaluacion)
        {
            var resultado = await evalcrediticiaManager.ConsultaFormatoSolicitud(idPrevaluacion);
            if (resultado.Resultado <= 0)
            {
                return Ok(new { valid = false, message = Constants.InvalidConsultaFormatoConformidad , IdSfCliente = resultado.IdSfCliente });
            }
            return Ok(new { valid = true, message = Constants.ReponseConsultaFormatoConformidad , IdSfCliente = resultado.IdSfCliente });

        }
        [HttpGet("UpdateEstadoPreevaluacion")]
        public async Task<IActionResult> UpdateEstadoPreevaluacion(int idPreevaluacion, int idEstado)
        {
            var resultado = await evalcrediticiaManager.UpdateEstadoPreevaluacion(idPreevaluacion, idEstado);
            if (resultado <= 0)
            {
                return Ok(new { valid = false, message = Constants.InvalidUpdateEstadoPreevaluacion });
            }
            return Ok(new { valid = true, message = Constants.ReponseUpdateEstadoPreevaluacion});

        }
    }
}
