using Application.Dto;
using Application.Dto.BusinessAdvisors;
using Application.Dto.CustomEntities;
using Application.Dto.Download;
using Application.Dto.Financing;
using Application.Dto.RandomQuestions;
using Application.Dto.Survey;
using Application.Dto.UploadDocuments.KnockoutRules;
using Application.Manager.Interfaces;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.MainModule.Entities;
using Domain.MainModule.Entities.Financing;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Manager.Implementation
{
    public class FinancingManager : IFinancingManager
    {
        private readonly IFinancingService financingService;
        private readonly IMapper mapper;
        private int idKnockoutRules;
        public FinancingManager(
             IFinancingService financingService,
             IMapper mapper 
            )
        {
            this.financingService = financingService;
            this.mapper = mapper; 
        }
        public async Task<RespuestaRegisterDto> RegisterClientPreevaluation(RegisterClientPreevaluationDTO request)
        {
            var resultado =  await financingService.RegisterClientPreevaluation(request);
            return resultado;
        }
        public async Task<RegisterPreEvaluationDTO> AddPreevaluation(PreEvaluationDTO preEvaluationDTO)
        {
            
            PreEvaluationEntity preEvaluationEntity = mapper.Map<PreEvaluationEntity>(preEvaluationDTO);
            PreEvaluationEntity preEvaluation = await financingService.AddPreevaluation(preEvaluationEntity);
            RegisterPreEvaluationDTO registerPreEvaluationDTO = mapper.Map<RegisterPreEvaluationDTO>(preEvaluation); 
            return registerPreEvaluationDTO;
        }

        public async Task<int> RegisterReglasNockout(RegisterReglasNockoutDTO request)
        {
            var resultado = await financingService.RegisterReglasNockout(request);
            return resultado;
        }
        public async Task<RegisterReglaKnockoutDTO> AddReglaKnockout(ReglaKnockoutDTO reglaKnockoutRequest)
        {
            RegistroReglasKnockoutEntity reglaKnockoutEntity = mapper.Map<RegistroReglasKnockoutEntity>(reglaKnockoutRequest);
            RegistroReglasKnockoutEntity reglaKnockout = await financingService.AddReglaKnockout(reglaKnockoutEntity); 
            //UpdatePrevaluationStatus(reglaKnockout.IdPreevaluacion, reglaKnockout.IdEstadoPrevaluacion);
            RegisterReglaKnockoutDTO registerReglaKnockoutDTO = mapper.Map<RegisterReglaKnockoutDTO>(reglaKnockout);
            idKnockoutRules = reglaKnockout.IdReglanockout;
            return registerReglaKnockoutDTO;
        }

        public int UpdatePrevaluationStatus(int idPrevaluation, int idEstadoKnockoutRules)
        {
            var _resultPrevaluation = financingService.UpdateIdPrevaluation(idPrevaluation, idEstadoKnockoutRules); 
            return _resultPrevaluation;
        }

        public async Task<List<PendingPrevaluationDTO>> GetListPreevaluacionKnockout(int id)
        {
            //PendingPrevaluationDTO preEvaluationDTO = null;
            //PreEvaluationEntity preEvaluationEntity = await financingService.GetListPreevaluacionKnockout(id);
            //if (preEvaluationEntity != null) 
            //{ preEvaluationDTO = mapper.Map<PendingPrevaluationDTO>(preEvaluationEntity); }
            //return preEvaluationDTO;

            var result = await financingService.GetListPreevaluacionKnockout(id);
            return result;

        }
        public async Task<TotalListPreevaluationEntity> GetListPreevaluation(FilterPreevaluationDTO request)
        {
            var _preEvaluationEntity =  await financingService.GetListPreevaluation(request);
            return _preEvaluationEntity;
        }
        public PagedList<PreEvaluationTempEntity> ListPagePrevaluation(PrevaluationQueryFilterDTO prevaluationQueryFilterDTO)
        {
            var _preEvaluationEntity = financingService.GetPrevaluation(prevaluationQueryFilterDTO);            
            return _preEvaluationEntity;
        }
        public async Task<List<PreevaluacionTip_DocDTO>> GetPreevaluacion_TipDoc(int IdTipoDocumento, string NumDocumento)
        {
            var _preevaluacionDto= financingService.GetPreevaluacion_TipDoc(IdTipoDocumento, NumDocumento);
            return  await _preevaluacionDto;
        }
        public List<PreEvaluationTempEntity> ListPagePrevaluationTipDocEst(PrevaluationFilterTipDocEstDTO prevaluationQueryFilterDTO)
        {
            var _preEvaluationEntity = financingService.GetPrevaluationTipDocEst(prevaluationQueryFilterDTO);
            return _preEvaluationEntity;
        }
        public async Task<List<MantenPreguntasAleatoriasEntity>> ListMantPreguntasAleatorias()
        {
            var mantenPreguntasAleatoriasEntity = await financingService.ListMantPreguntasAleatorias();
            return mantenPreguntasAleatoriasEntity;
        }
        public async Task<List<RandomQuestionsDTO>> ListAsync()
        {
            List<MantPreguntasAletoriaEntity> preguntasAletoriaEntity = await financingService.GetList();
            List<RandomQuestionsDTO> randomQuestionsDtos = mapper.Map<List<RandomQuestionsDTO>>(preguntasAletoriaEntity);
            return randomQuestionsDtos;
        }
        public async Task<List<ListUsuarioEntity>> ListBusineesAdvisor()
        {
            var listUsuarioEntity = await financingService.ListBusineesAdvisor();
            return listUsuarioEntity;
        }
        public async Task<List<BusinessAdvisorsDTO>> ListBaAsync()
        {
            List<UsuarioEntity> customer = await financingService.ListBaAsync();
            List<BusinessAdvisorsDTO> customerDto = mapper.Map<List<BusinessAdvisorsDTO>>(customer);
            return customerDto;
        }

        public async Task<bool> UploadAsync(UploadDocumentSupportDTO uploadDocumentSupportDTO)
        {
            var uploadDocumentSupport = await financingService.UploadAsync(uploadDocumentSupportDTO, idKnockoutRules);
            return uploadDocumentSupport;
        }

        public async Task<DownloadEntity> GetDownload(DownloadDTO download)
        {
            DownloadEntity downloadEntity = await financingService.GetDownload(download);
            return downloadEntity;
        }
        public async Task<List<DownloadEntity>> GetDownload_RK_SF(string nombre_tabla, int id)
        {
            List<DownloadEntity> getdowload_RK_SF_Entity = await financingService.GetDownload_RK_SF(nombre_tabla,id);
            return getdowload_RK_SF_Entity;
        }
        public async Task<int> InsertRandonQuestions(InsertRandonQuestionsDTO request)
        {

            var resultado = await financingService.InsertRandonQuestions(request);
            
            foreach (var item in request.detailsQuestions)
            {
                item.IdPregunta = resultado;
                var resultadoDetalle = await financingService.InsertRandonQuestions_Detalle(item);
                
            }
            return resultado;
        }

        public async Task<bool> AddRandomQuestions(RandomQuestionsRequestDTO randomQuestionsRequestDTO)
        {
            bool result = false;
            //Registra cabecera
            MantPreguntasAleatoriasEntity mantPreguntasAleatoriaEntity = mapper.Map<MantPreguntasAleatoriasEntity>(randomQuestionsRequestDTO);
            MantPreguntasAleatoriasEntity mantPreguntasAleatoria = await financingService.AddRandomQuestions(mantPreguntasAleatoriaEntity);
            //Registra Detalle
            if(randomQuestionsRequestDTO.DetailsQuestions.Count > 0)
            {
                foreach(var item in randomQuestionsRequestDTO.DetailsQuestions)
                {
                    var details = await financingService.AddRandomQuestionsDetails(mantPreguntasAleatoria.IdPregunta, item.Descripcion, item.Activo);
                }
            }
            if(mantPreguntasAleatoria.IdPregunta > 0)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }

        public async Task<List<ResponseRandomQuestionsDTO>> ListQuestion_Cab_Det()
        {
            var headers = await financingService.ListarManPreguntas();
            var response = new List<ResponseRandomQuestionsDTO>();
            foreach (var item in headers)
            {
                var header = new ResponseRandomQuestionsDTO();
                header.Id = item.IdPregunta;
                header.Pregunta = item.Pregunta;
                header.textAyuda = item.TextAyuda;
                header.TipoDato = item.TipoDato;
                var details = await financingService.ListMantPreguntasDetalle(item.IdPregunta);
                header.opciones = new List<MenuOpciones>();
                foreach (var detail in details)
                {
                    var detailitem = new MenuOpciones();
                    detailitem.IdDetalle = detail.IdDetalle;
                    detailitem.descripcion = detail.Descripcion;
                    header.opciones.Add(detailitem);
                }
                response.Add(header);
                
            }
            return response;
        }
        public async Task<List<ResponseRandomQuestionsDTO>> List2Async()
        {
            List<ResponseRandomQuestionsDTO> responseRandomQuestionsDTO = await financingService.GetList2();
            return responseRandomQuestionsDTO;
        }
        public async Task<int> DeleteRandonQuestions(InsertRandonQuestionsDTO request)
        {
            var result = await financingService.DeleteRandonQuestions(request);
            foreach (var item in request.detailsQuestions)
            {
                await financingService.DeleteRandonQuestions_Detalle(item);
            }
            return result;
        }
        public async Task<JsonResultEntity> UpdateAsync(RandomQuestionsRequestDTO requestDTO)
        {
            var result = await financingService.UpdateAsync(requestDTO);
            return result;
        }

        public async Task<JsonResultEntity> DeleteAsync(RequestQuestionDTO requestQuestionDto)
        {
            var result = await financingService.DeleteAsync(requestQuestionDto);
            return result;
        }

        public async Task<JsonResultEntity> AddAsync(List<SurveyDTO> surveyDTO)
        {
            
            var result = await financingService.AddAsync(surveyDTO);
            return result;
        }

        public async Task<List<ResponseRandomQuestionsDTO>> ListQuestion_Cab_DetxId(int idPregunta)
        {
            var headers = await financingService.ListarManPreguntasxId(idPregunta);
            var response = new List<ResponseRandomQuestionsDTO>();
            foreach (var item in headers)
            {
                var header = new ResponseRandomQuestionsDTO();
                header.Id = item.IdPregunta;
                header.Pregunta = item.Pregunta;
                header.textAyuda = item.TextAyuda;
                header.TipoDato = item.TipoDato;
                var details = await financingService.ListMantPreguntasDetalle(item.IdPregunta);
                header.opciones = new List<MenuOpciones>();
                foreach (var detail in details)
                {
                    var detailitem = new MenuOpciones();
                    detailitem.IdDetalle = detail.IdDetalle;
                    detailitem.descripcion = detail.Descripcion;
                    header.opciones.Add(detailitem);
                }
                response.Add(header);

            }
            return response;
        }
        public async Task<List<ResponseRandomQuestionsDTO>> ListRamdonIdAsync(int idPregunta)
        {
            List<ResponseRandomQuestionsDTO> responseRandomQuestionsDTO = await financingService.ListRamdonIdAsync(idPregunta);
            return responseRandomQuestionsDTO;
        }
        public async Task<List<EstadoNivelEstudiosClienteEntity>> GetEstadoNivelEstudiosCliente()
        {
            return await financingService.GetEstadoNivelEstudiosCliente();
        }
        public async Task<List<EstadoCivilClienteEntity>> GetEstadoCivilCliente()
        {
            return await financingService.GetEstadoCivilCliente();
        }
        public async Task<List<EstadoVehicularEntity>> GetEstadoVehicular()
        {
            return await financingService.GetEstadoVehicular();
        }
        public async Task<List<EstadoTipoFinanciamientoEntity>> GetEstadoTipoFinanciamiento()
        {
            return await financingService.GetEstadoTipoFinanciamiento();
        }
        public async Task<List<TipoCalleEntity>> GetTipoCalle()
        {
            return await financingService.GetTipoCalle();
        }
        public async Task<List<TipoCreditoFinanciamientoEntity>> GetTipoCreditoFinanciamiento()
        {
            return await financingService.GetTipoCreditoFinanciamiento();
        }
        public async Task<int> UpdateRegistroReglasKnockout(UpdateRegistroReglasNockoutDTO reglasNockoutDTO)
        {
            return await financingService.UpdateRegistroReglasKnockout(reglasNockoutDTO);
        }

        public async Task<ResponseRKByIdPrevaluationDTO> ListExistRKByIdPrevaluation(int IdPreevaluacion)
        {
            ResponseRKByIdPrevaluationDTO responseByIdPrevaluationDTO = await financingService.ListExistRKByIdPrevaluation(IdPreevaluacion);
            return responseByIdPrevaluationDTO;
        }

        public async Task<ResponseExistPreevaluationDTO> ExistByIdPrevaluation(int IdPreevaluacion)
        {
            ResponseExistPreevaluationDTO responseByIdPrevaluationDTO = await financingService.ExistByIdPrevaluation(IdPreevaluacion);
            return responseByIdPrevaluationDTO;
        }

        public async Task<bool> UpdateAsesorPrevaluation(int IdPreevaluacion, int IdAsesor)
        {
            var updateAsesor = await financingService.UpdateAsesorPrevaluation(IdPreevaluacion, IdAsesor);
            return updateAsesor;
        }

        public async Task<ResponseIdFinanciamientoDTO> GetListIdFinancing(int IdPreevaluacion)
        {
            ResponseIdFinanciamientoDTO responseDTO = await financingService.GetListIdFinancing(IdPreevaluacion);
            return responseDTO;
        }
    }
}
