using Application.Dto;
using Application.Dto.BusinessAdvisors;
using Application.Dto.CustomEntities;
using Application.Dto.Financing;
using Application.Dto.RandomQuestions;
using Application.Dto.Survey;
using Application.Dto.UploadDocuments.KnockoutRules;
using Application.Manager.Interfaces;
using Application.Services.Util;
using Application.Services.Util.Directonary;
using AutoMapper;
using Domain.MainModule.Entities;
using Infrastructure.MainModule.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Presentation.Services.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FinancingController : ControllerBase
    {
        private readonly IFinancingManager financingManager;
        private readonly IMapper mapper;
        private readonly IUriService uriService; 
        public FinancingController(
            IFinancingManager financing,
            IMapper mapper,
            IUriService uriService
            )
        {
            this.financingManager = financing;
            this.mapper = mapper;
            this.uriService = uriService;
        } 

        [HttpGet("GetIdPendingPrevaluation")]
        public async Task<IActionResult> GetIdPendingPrevaluation(int id)
        {
            List<PendingPrevaluationDTO> pendingPrevaluationDTO = await financingManager.GetListPreevaluacionKnockout(id);
            if (pendingPrevaluationDTO == null)
            {
                return BadRequest(new { valid = false, messaje = Constants.ResponseInvalidCodPrevaluation });
            }
            return Ok(pendingPrevaluationDTO);
        }


        [HttpPost("RegisterClientPreevaluation_homo")]
        public async Task<IActionResult> RegisterClientPreevaluation(RegisterClientPreevaluationDTO request)
        {
            if (request.Contrasena == "")
            {
                request.Contrasena = "";
            }
            else
            {
                request.Contrasena = CryptoHelper.EncryptAES(request.Contrasena);
            }
            

            try
            {
                RespuestaRegisterDto respuesta = new RespuestaRegisterDto();
                respuesta = await financingManager.RegisterClientPreevaluation(request);


                if (respuesta.Response == "0")
                {
                    return BadRequest(new { valid = false, message = Constants.ReponseInvalidPrevaluationRegister });
                }
                else if (respuesta.Mensaje == "Documento" || respuesta.Mensaje == "Correo")
                {
                    return Ok(new { valid = true, message = Constants.ReponseUsuarioRegistradoEnBD, correo = respuesta.Correo, NumeroDocumento = respuesta.NumeroDocumento, Error=respuesta.Mensaje });
                }
                else
                {
                    return Ok(new { valid = true, message = Constants.ReponsePreevaluacionRegistro });
                }

                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpPost("RegisterClientPrevaluation")]
        public async Task<IActionResult> RegisterClientPrevaluation([FromBody] PreEvaluationDTO preEvaluationDTO)
        {
            RegisterPreEvaluationDTO registerPreEvaluationDTO = await financingManager.AddPreevaluation(preEvaluationDTO);
            if (registerPreEvaluationDTO.IdPreevaluacion < 0)
            {
                return BadRequest(new { valid = false, messaje = Constants.ReponseInvalidPrevaluationRegister });
            }
            return Ok(new { valid = true, message = Constants.ReponsePreevaluacionRegistro });
        }
        
        [HttpPost("RegisterKnockoutRules_homo")]
        public async Task<IActionResult> RegisterReglasNockout(RegisterReglasNockoutDTO request)
        {
            try
            {
                int resultado = await financingManager.RegisterReglasNockout(request);

                if (resultado <= 0)
                {
                    return BadRequest(new { valid = false, message = Constants.ResponseRegisterKnockoutRules });
                }
                 
                return Ok(new { valid = true, message = Constants.ResponseRegisterKnockoutRulesTrue, IdReglanockout = resultado });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("UpdateAsesorPrevaluation")]
        public async Task<IActionResult> UpdateAsesorPrevaluation(int IdPreevaluacion, int IdAsesor)
        {
            var updatePreEvaluationDTO = await financingManager.UpdateAsesorPrevaluation(IdPreevaluacion, IdAsesor);
            if (updatePreEvaluationDTO == false)
            {
                return BadRequest(new { valid = false, messaje = Constants.ReponseInvalidPreevaluacionAsesorUpdate });
            }
            return Ok(new { valid = true, message = Constants.ReponsePreevaluacionAsesorUpdate });
        }

        [HttpPost("RegisterKnockoutRules")]
        public async Task<IActionResult> RegisterKnockoutRules([FromBody] ReglaKnockoutDTO reglaKnockoutRequest)
        {
            RegisterReglaKnockoutDTO registerReglaKnockoutDTO = await financingManager.AddReglaKnockout(reglaKnockoutRequest);
            if (registerReglaKnockoutDTO.IdReglanockout < 0)
            {
                return BadRequest(new { valid = false, messaje = Constants.ResponseRegisterKnockoutRules });
            }
            return Ok(new { valid = true, message = Constants.ResponseRegisterKnockoutRulesTrue, IdReglanockout = registerReglaKnockoutDTO.IdReglanockout });
        }
       

        [HttpPost("AllPrevaluationPag_homo")]
        public IActionResult GetListPreevaluation(FilterPreevaluationDTO request)
        {
            var resultado = financingManager.GetListPreevaluation(request);
            if (resultado == null)
            {
                return BadRequest(new { valid = false, messaje = Constants.InvalidListGetPreevaluacion });
            }
            return Ok(resultado.Result);
        }


        [HttpGet("AllPrevaluationPag")]
        public IActionResult AllPrevaluationPag([FromQuery] PrevaluationQueryFilterDTO prevaluationQueryFilterDTO)
        {
            var resultPrevaluation = financingManager.ListPagePrevaluation(prevaluationQueryFilterDTO);
            var resultPrevaluationDtos = mapper.Map<List<PreEvaluationDTO>>(resultPrevaluation);

            var metaData = new MetaData
            {
                TotalCount = resultPrevaluation.TotalCount,
                PageSize = resultPrevaluation.PageSize,
                CurrentPage = resultPrevaluation.CurrentPage,
                TotalPages = resultPrevaluation.TotalPages,
                HasNextPage = resultPrevaluation.HasNextPage,
                HasPreviousPage = resultPrevaluation.HasPreviousPage,
                NextPageUrl = uriService.GetPostPaginationUri(prevaluationQueryFilterDTO, Url.RouteUrl(RouteData.Values)).ToString(),
                PreviousPageUrl = uriService.GetPostPaginationUri(prevaluationQueryFilterDTO, Url.RouteUrl(RouteData.Values)).ToString()
            };

            var response = new ApiResponse<List<PreEvaluationDTO>>(resultPrevaluationDtos)
            {
                Meta = metaData
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metaData));
            return Ok(response);
        }
        


        [HttpGet("PrevaluationTipDocEst_homo")]
        public IActionResult GetPreevaluacion_TipDoc(int IdTipoDocumento, string NumDocumento)
        {
            var resultado =  financingManager.GetPreevaluacion_TipDoc( IdTipoDocumento,  NumDocumento);
            if (resultado == null)
            {
                return BadRequest(new { valid = false, messaje = Constants.InvalidGetPreevaluacionTipDoc });
            }
            return Ok(resultado.Result);
        }


        [HttpGet("PrevaluationTipDocEst")]
        public IActionResult PrevaluationTipDocEst([FromQuery] PrevaluationFilterTipDocEstDTO prevaluationQueryFilterDTO)
        {
            var resultPrevaluation = financingManager.ListPagePrevaluationTipDocEst(prevaluationQueryFilterDTO);
            var resultPrevaluationDtos = mapper.Map<List<PreEvaluationDTO>>(resultPrevaluation);
            
            return Ok(resultPrevaluationDtos);
        }
        
        [HttpGet("ListRandomQuestions_homo")]
        public async Task<IActionResult> ListMantPreguntasAleatorias()
        {
            var resultado = await financingManager.ListMantPreguntasAleatorias();
            if (resultado.Count < 0)
            {
                return BadRequest(new { valid = false, messaje = Constants.InvalidListRandomQuestions });
            }
            return Ok(resultado);
        }
        [HttpGet("ListRandomQuestions")]
        public async Task<IActionResult> ListRandomQuestions()
        {
            List<RandomQuestionsDTO> randonQuestionsDto = await financingManager.ListAsync();
            if (randonQuestionsDto.Count < 0)
            {
                return BadRequest(new { valid = false, messaje = Constants.InvalidListRandomQuestions });
            }
            return Ok(randonQuestionsDto);
        }

        
        [HttpGet("ListRandomQuestions2_homo")]
        public async Task<IActionResult> ListQuestion_Cab_Det()
        {
            List<ResponseRandomQuestionsDTO> randonQuestionsDto = await financingManager.ListQuestion_Cab_Det();
            if (randonQuestionsDto.Count < 0)
            {
                return BadRequest(new { valid = false, message = Constants.InvalidListRandomQuestions });
            }
            return Ok(randonQuestionsDto);
        }


        #region "Preguntas Aleatorias"
        /// <summary>
        /// Listar Preguntas Aleatorias
        /// </summary>
        /// <returns></returns>
        [HttpGet("ListRandomQuestions2")]
        public async Task<IActionResult> ListRandomQuestions2()
        {
            List<ResponseRandomQuestionsDTO> randonQuestionsDto = await financingManager.List2Async();
            if (randonQuestionsDto.Count < 0)
            {
                return BadRequest(new { valid = false, message = Constants.InvalidListRandomQuestions });
            }
            return Ok(randonQuestionsDto);
        }
       
        [HttpGet("ListRandomQuestionsId_homo")]
        public async Task<IActionResult> ListQuestion_Cab_DetxId(int idPregunta)
        {
            List<ResponseRandomQuestionsDTO> randonQuestionsDto = await financingManager.ListRamdonIdAsync(idPregunta);
            if (randonQuestionsDto.Count < 0)
            {
                return BadRequest(new { valid = false, message = Constants.InvalidListRandomQuestions });
            }
            return Ok(randonQuestionsDto);
        }

        [HttpGet("ListRandomQuestionsId")]
        public async Task<IActionResult> ListRandomQuestionsId(int idPregunta)
        {
            List<ResponseRandomQuestionsDTO> randonQuestionsDto = await financingManager.ListRamdonIdAsync(idPregunta);
            if (randonQuestionsDto.Count < 0)
            {
                return BadRequest(new { valid = false, message = Constants.InvalidListRandomQuestions });
            }
            return Ok(randonQuestionsDto);
        }

        [HttpPost("RegisterRandomQuestions_homo")]
        public async Task<IActionResult> InsertRandonQuestions(InsertRandonQuestionsDTO request)
        {
            var registerRandomQuestions = await financingManager.InsertRandonQuestions(request);
            if (registerRandomQuestions <= 0)
            {
                return BadRequest(new { valid = false, message = Constants.ResponseRegisterKnockoutRules });
            }
            return Ok(new { valid = true, message = Constants.ResponseRegisterRandomQuestions });
        }
        /// <summary>
        /// Registrar preguntas aleatorias para el mantenimiento
        /// </summary>
        /// <param name="randomQuestionsRequest"></param>
        /// <returns></returns>
        [HttpPost("RegisterRandomQuestions")]
        public async Task<IActionResult> RegisterRandomQuestions([FromBody] RandomQuestionsRequestDTO randomQuestionsRequest)
        {
            var registerRandomQuestionsRequestDTO = await financingManager.AddRandomQuestions(randomQuestionsRequest);
            if (registerRandomQuestionsRequestDTO == false)
            {
                return BadRequest(new { valid = false, message = Constants.ResponseRegisterKnockoutRules });
            }
            return Ok(new { valid = true, message = Constants.ResponseRegisterRandomQuestions });
        }


        [HttpPost("UpdateRandomQuestions_homo")]
        public async Task<IActionResult> DeleteRandonQuestions(InsertRandonQuestionsDTO request)
        {
            var updateRandonQuestions = await financingManager.DeleteRandonQuestions(request);
            if (updateRandonQuestions <= 0)
            {
                return BadRequest(new { valid = false, message = Constants.InvalidDeleteRandonQuestions});
            }
            return Ok(new { valid = true, message = Constants.ReponseDeleteRandonQuestions });
        }



        [HttpPost("UpdateRandomQuestions")]
        public async Task<IActionResult> UpdateRandomQuestions([FromBody] RandomQuestionsRequestDTO requestDTO)
        {
            JsonResultEntity registerRandomQuestionsRequestDTO = await financingManager.UpdateAsync(requestDTO);
            if (registerRandomQuestionsRequestDTO.Value < 0)
            {
                return BadRequest(new { valid = false, message = registerRandomQuestionsRequestDTO.Message });
            }
            return Ok(new { valid = true, message = registerRandomQuestionsRequestDTO.Message });
        }

       
        [HttpPost("DeleteRandomQuestions")]
        public async Task<IActionResult> DeleteRandomQuestions([FromBody] RequestQuestionDTO requestQuestionDto)
        {
            JsonResultEntity jsonResult = await financingManager.DeleteAsync(requestQuestionDto);
            if (jsonResult.Value < 0)
            {
                return BadRequest(new { valid = false, message = jsonResult.Message });
            }
            return Ok(new { valid = true, message = jsonResult.Message });
        }

        /// <summary>
        /// Registrar las respuestas de preguntas de la Solicitud de financiamiento
        /// </summary>
        /// <returns></returns>
        [HttpPost("RecordSurveyResponse")]
        public async Task<IActionResult> RecordSurveyResponse([FromBody] List<SurveyDTO> surveyDTO)
        {
            JsonResultEntity jsonResult = await financingManager.AddAsync(surveyDTO);
            if (jsonResult.Value < 0)
            {
                return BadRequest(new { valid = false, message = jsonResult.Message });
            }
            return Ok(new { valid = true, message = jsonResult.Message });


        }

        #endregion
        
        [HttpGet("ListBusinessAdvisors_homo")]
        public async Task<IActionResult> ListBusineesAdvisor()
        {
            var listaUsuario  = await financingManager.ListBaAsync();
            if (listaUsuario.Count < 0)
            {
                return BadRequest(new { valid = false, message = Constants.InvalidListBusinessAdvisors });
            }
            return Ok(listaUsuario);
        }


        [HttpGet("ListBusinessAdvisors")]
        public async Task<IActionResult> ListBusinessAdvisors()
        {
            List<BusinessAdvisorsDTO> businessAdvisorsDto = await financingManager.ListBaAsync();
            if (businessAdvisorsDto.Count < 0)
            {
                return BadRequest(new { valid = false, message = Constants.InvalidListBusinessAdvisors });
            }
            return Ok(businessAdvisorsDto);
        }

        [HttpPost("UploadDocumentSupport")]
        public async Task<IActionResult> UploadDocumentSupport([FromBody] UploadDocumentSupportDTO uploadDocumentSupportDTO)
        {
            var resultUploadDocumentSupport = await financingManager.UploadAsync(uploadDocumentSupportDTO);
            if (resultUploadDocumentSupport == false)
            {
                return BadRequest(new { valid = false, message = FinancingRequestConst.InvalidUploadDocuments });
            }
            return Ok(new { valid = true, message = FinancingRequestConst.SuccessUploadDocuments });
        }

        [HttpPost("GetDownloadMaestro")]
        public async Task<IActionResult> GetDownload(DownloadDTO download)
        {
            DownloadEntity resultDownload = await financingManager.GetDownload(download);

            if (resultDownload == null)
            {
                return Ok(new { valid = false, message = Constants.InvalidGetDownload });
            }

            return Ok(resultDownload);
        }
        [HttpGet("GetDownloadRK_SF")]
        public async Task<IActionResult> GetDownload_RK_SF(string nombre_tabla, int id)
        {
           List<DownloadEntity> resultDownload_RK_SF = await financingManager.GetDownload_RK_SF(nombre_tabla,id);

            if (resultDownload_RK_SF.Count <= 0)
            {
                return Ok(new { valid = false, message = Constants.InvalidGetDownload });
            }

            return Ok(resultDownload_RK_SF);
        }


        [HttpGet("GetEstadoNivelEstudiosCliente")]
        public async Task<IActionResult> GetEstadoNivelEstudiosCliente()
        {
            List<EstadoNivelEstudiosClienteEntity> resultEstadoNivelEstudiosCliente = await financingManager.GetEstadoNivelEstudiosCliente();

            if (resultEstadoNivelEstudiosCliente == null)
            {
                return BadRequest(new { valid = false, message = Constants.InvalidListEstadoNivelEstudiosCliente });
            }
            
            return Ok(resultEstadoNivelEstudiosCliente);
        }

        [HttpGet("GetEstadoCivilCliente")]
        public async Task<IActionResult> GetEstadoCivilCliente()
        {
            List<EstadoCivilClienteEntity> resultEstadoNivelEstudiosCliente = await financingManager.GetEstadoCivilCliente();

            if (resultEstadoNivelEstudiosCliente == null)
            {
                return BadRequest(new { valid = false, message = Constants.InvalidListEstadoCivilCliente });
            }
            

                return Ok(resultEstadoNivelEstudiosCliente);
        }

        [HttpGet("GetEstadoVehicular")]
        public async Task<IActionResult> GetEstadoVehicular()
        {
            List<EstadoVehicularEntity> resultEstadoNivelEstudiosCliente = await financingManager.GetEstadoVehicular();

            if (resultEstadoNivelEstudiosCliente == null)
            {
                return BadRequest(new { valid = false, message = Constants.InvalidListEstadoVehicular });
            }


            return Ok(resultEstadoNivelEstudiosCliente);
        }

        [HttpGet("GetEstadoTipoFinanciamiento")]
        public async Task<IActionResult> GetEstadoTipoFinanciamiento()
        {
            List<EstadoTipoFinanciamientoEntity> resultEstadoNivelEstudiosCliente = await financingManager.GetEstadoTipoFinanciamiento();

            if (resultEstadoNivelEstudiosCliente == null)
            {
                return Ok(new { valid = false, message = Constants.InvalidListEstadoTipoFinanciamiento });
            }


            return Ok(resultEstadoNivelEstudiosCliente);
        }

        [HttpGet("GetTipoCalle")]
        public async Task<IActionResult> GetTipoCalle()
        {
            List<TipoCalleEntity> resultEstadoNivelEstudiosCliente = await financingManager.GetTipoCalle();

            if (resultEstadoNivelEstudiosCliente == null)
            {
                return BadRequest(new { valid = false, message = Constants.InvalidListTipoCalle });
            }


            return Ok(resultEstadoNivelEstudiosCliente);
        }

        [HttpGet("GetTipoCreditoFinanciamiento")]
        public async Task<IActionResult> GetTipoCreditoFinanciamiento()
        {
            List<TipoCreditoFinanciamientoEntity> resultEstadoNivelEstudiosCliente = await financingManager.GetTipoCreditoFinanciamiento();

            if (resultEstadoNivelEstudiosCliente == null)
            {
                return BadRequest(new { valid = false, message = Constants.InvalidListTipoCreditoFinanciamiento });
            }


            return Ok(resultEstadoNivelEstudiosCliente);
        }
        [HttpPost("UpdateRegistroReglasKnockout")]
        public async Task<IActionResult> UpdateRegistroReglasKnockout(UpdateRegistroReglasNockoutDTO reglasNockoutDTO)
        {
            try
            {
                int resultado = await financingManager.UpdateRegistroReglasKnockout(reglasNockoutDTO);

                if (resultado <= 0)
                {
                    return BadRequest(new { valid = false, message = Constants.InvalidUpdateReglasNockout });
                }

                return Ok(new { valid = true, message = Constants.ResponseUpdateReglasNockout });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetExistRKByIdPrevaluation")]
        public async Task<IActionResult> GetExistRKByIdPrevaluation(int IdPreevaluacion)
        {
            ResponseRKByIdPrevaluationDTO randonQuestionsDto = await financingManager.ListExistRKByIdPrevaluation(IdPreevaluacion);
            
            if (randonQuestionsDto == null)
            {
                return Ok(new { valid = false, message = Constants.ReponseNoExitPrevaluation });
            }
            return Ok(randonQuestionsDto);
        }

        [HttpGet("GetFinancingByIdPreevaluacion")]
        public async Task<IActionResult> GetFinancingByIdPreevaluacion(int IdPreevaluacion)
        {
            ResponseExistPreevaluationDTO randonQuestionsDto = await financingManager.ExistByIdPrevaluation(IdPreevaluacion);
            if (randonQuestionsDto == null)
            {
                return Ok(new { valid = false, message = Constants.ReponseNoExitPrevaluation40 });
            }
            return Ok(randonQuestionsDto);
        }

        [HttpGet("GetListIdFinancing")]
        public async Task<IActionResult> GetListIdFinancing(int IdPreevaluacion)
        {
            ResponseIdFinanciamientoDTO IdLstDTO = await financingManager.GetListIdFinancing(IdPreevaluacion);
            if (IdLstDTO == null)
            {
                return Ok(new { valid = false, message = Constants.InvalidReportDashBoard });
            }
            return Ok(IdLstDTO);
        }


    }
}
