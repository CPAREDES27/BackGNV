using Application.Dto;
using Application.Dto.CustomEntities;
using Application.Dto.Download;
using Application.Dto.Financing;
using Application.Dto.RandomQuestions;
using Application.Dto.Survey;
using Application.Dto.UploadDocuments.KnockoutRules;
using Application.Services.Interfaces;
using Domain.MainModule.Entities;
using Domain.MainModule.Entities.Financing;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services.Implementation
{
    public class FinancingService : IFinancingService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FinancingService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
         
        public async Task<List<PendingPrevaluationDTO>> GetListPreevaluacionKnockout(int id)
        {
            return await _unitOfWork.financingRepository.GetListPreevaluacionKnockout(id);
        }
        public async Task<RespuestaRegisterDto> RegisterClientPreevaluation(RegisterClientPreevaluationDTO request)
        {
            return await _unitOfWork.financingRepository.RegisterClientPreevaluation(request);
        }
        public async Task<PreEvaluationEntity> AddPreevaluation(PreEvaluationEntity preevaluacionEntity)
        {
            return await _unitOfWork.financingRepository.AddPreevaluation(preevaluacionEntity);
        }
        public async Task<int> RegisterReglasNockout(RegisterReglasNockoutDTO request)
        {
            return await _unitOfWork.financingRepository.RegisterReglasNockout(request);
        }
        public async Task<RegistroReglasKnockoutEntity> AddReglaKnockout(RegistroReglasKnockoutEntity reglaKnockoutEntity)
        {
            return await _unitOfWork.financingRepository.AddReglaKnockout(reglaKnockoutEntity);
        }
        public async Task<TotalListPreevaluationEntity> GetListPreevaluation(FilterPreevaluationDTO request)
        {
            return await _unitOfWork.financingRepository.GetListPreevaluation(request);
        }
        public PagedList<PreEvaluationTempEntity> GetPrevaluation(PrevaluationQueryFilterDTO prevaluationQueryFilterDTO)
        {
            return _unitOfWork.financingRepository.GetPrevaluation(prevaluationQueryFilterDTO);
        }

        public int UpdateIdPrevaluation(int idPrevaluation, int idEstadoKnockoutRules)
        {
            return _unitOfWork.financingRepository.UpdateIdPrevaluation(idPrevaluation, idEstadoKnockoutRules);
        }
        public async Task<List<MantenPreguntasAleatoriasEntity>> ListMantPreguntasAleatorias()
        {
            return await _unitOfWork.financingRepository.ListMantPreguntasAleatorias();
        }
        public async Task<List<MantPreguntasAletoriaEntity>> GetList()
        {
            return await _unitOfWork.financingRepository.GetList();
        }
        public async Task<List<ListUsuarioEntity>> ListBusineesAdvisor()
        {
            return await _unitOfWork.financingRepository.ListBusineesAdvisor();
        }
        public async Task<List<UsuarioEntity>> ListBaAsync()
        {
            return await _unitOfWork.financingRepository.ListBaAsync();
        }

        public async Task<bool> UploadAsync(UploadDocumentSupportDTO uploadDocumentSupportDto, int idKnockoutRules)
        {
            return await _unitOfWork.financingRepository.UploadAsync(uploadDocumentSupportDto, idKnockoutRules);
        }

        public async Task<DownloadEntity> GetDownload(DownloadDTO download)
        {
            return await _unitOfWork.financingRepository.GetDownload(download);

        }

        public async Task<List<DownloadEntity>> GetDownload_RK_SF(string nombre_tabla, int id)
        {
            return await _unitOfWork.financingRepository.GetDownload_RK_SF(nombre_tabla,id);
        }

        public async Task<int> InsertRandonQuestions(InsertRandonQuestionsDTO request)
        {
            return await _unitOfWork.financingRepository.InsertRandonQuestions(request);
        }
        public async Task<int> InsertRandonQuestions_Detalle(RandonQuestionDetalle request)
        {
            return await _unitOfWork.financingRepository.InsertRandonQuestions_Detalle(request);
        }
        public async Task<MantPreguntasAleatoriasEntity> AddRandomQuestions(MantPreguntasAleatoriasEntity mantPreguntasAleatoriaEntity)
        {
            return await _unitOfWork.financingRepository.AddRandomQuestions(mantPreguntasAleatoriaEntity);
        }

        public async Task<bool> AddRandomQuestionsDetails(int IdPregunta, string Descripcion, bool Activo)
        {
            return await _unitOfWork.financingRepository.AddRandomQuestionsDetails(IdPregunta, Descripcion, Activo);
        }

       
        public async Task<List<ListQuestionEntity>> ListarManPreguntas()
        {
            return await _unitOfWork.financingRepository.ListarManPreguntas();
        }
        public async Task<List<ListQuestionDetalleEntity>> ListMantPreguntasDetalle(int idpregunta)
        {
            return await _unitOfWork.financingRepository.ListMantPreguntasDetalle(idpregunta);
        }
        public async Task<List<ResponseRandomQuestionsDTO>> GetList2()
        {
            return await _unitOfWork.financingRepository.GetList2();
        }
        public async Task<int> DeleteRandonQuestions(InsertRandonQuestionsDTO request)
        {
            return await _unitOfWork.financingRepository.DeleteRandonQuestions(request);
        }
        public async Task<int> DeleteRandonQuestions_Detalle(RandonQuestionDetalle request)
        {
            return await _unitOfWork.financingRepository.DeleteRandonQuestions_Detalle(request);
        }
        public async Task<JsonResultEntity> UpdateAsync(RandomQuestionsRequestDTO requestDTO)
        {
            return await _unitOfWork.financingRepository.UpdateAsync(requestDTO);
        }

        public async Task<JsonResultEntity> DeleteAsync(RequestQuestionDTO requestDTO)
        {
            return await _unitOfWork.financingRepository.DeleteAsync(requestDTO);
        }

        public async Task<JsonResultEntity> AddAsync(List<SurveyDTO> surveyDTO)
        {
            return await _unitOfWork.financingRepository.AddAsync(surveyDTO);
        }
        public async Task<List<ListQuestionEntity>> ListarManPreguntasxId(int idPregunta)
        {
            return await _unitOfWork.financingRepository.ListarManPreguntasxId(idPregunta);
        }
        public async Task<List<ListQuestionDetalleEntity>> ListMantPreguntasDetallexId(int idpregunta)
        {
            return await _unitOfWork.financingRepository.ListMantPreguntasDetallexId(idpregunta);
        }
        public async Task<List<ResponseRandomQuestionsDTO>> ListRamdonIdAsync(int idPregunta)
        {
            return await _unitOfWork.financingRepository.ListRamdonIdAsync(idPregunta);
        }
        public async Task<List<PreevaluacionTip_DocDTO>> GetPreevaluacion_TipDoc(int IdTipoDocumento, string NumDocumento)
        {
            return await _unitOfWork.financingRepository.GetPreevaluacion_TipDoc(IdTipoDocumento, NumDocumento);
        }
        public List<PreEvaluationTempEntity> GetPrevaluationTipDocEst(PrevaluationFilterTipDocEstDTO prevaluationQueryFilterDTO)
        {
            return _unitOfWork.financingRepository.GetPrevaluationTipDocEst(prevaluationQueryFilterDTO);
        }
        public async Task<List<EstadoNivelEstudiosClienteEntity>> GetEstadoNivelEstudiosCliente()
        {
        
            return await _unitOfWork.financingRepository.GetEstadoNivelEstudiosCliente();
        }
        public async Task<List<EstadoCivilClienteEntity>> GetEstadoCivilCliente()
        {

            return await _unitOfWork.financingRepository.GetEstadoCivilCliente();
        }
        public async Task<List<EstadoVehicularEntity>> GetEstadoVehicular()
        {

            return await _unitOfWork.financingRepository.GetEstadoVehicular();
        }
        public async Task<List<EstadoTipoFinanciamientoEntity>> GetEstadoTipoFinanciamiento()
        {

            return await _unitOfWork.financingRepository.GetEstadoTipoFinanciamiento();
        }
        public async Task<List<TipoCalleEntity>> GetTipoCalle()
        {

            return await _unitOfWork.financingRepository.GetTipoCalle();
        }
        public async Task<List<TipoCreditoFinanciamientoEntity>> GetTipoCreditoFinanciamiento()
        {

            return await _unitOfWork.financingRepository.GetTipoCreditoFinanciamiento();
        }

        public async Task<int> UpdateRegistroReglasKnockout(UpdateRegistroReglasNockoutDTO reglasNockoutDTO)
        {
            return await _unitOfWork.financingRepository.UpdateRegistroReglasKnockout(reglasNockoutDTO);
        }

        public async Task<ResponseRKByIdPrevaluationDTO> ListExistRKByIdPrevaluation(int IdPreevaluacion)
        {
            return await _unitOfWork.financingRepository.ListExistRKByIdPrevaluation(IdPreevaluacion);
        }

        public async Task<ResponseExistPreevaluationDTO> ExistByIdPrevaluation(int IdPreevaluacion)
        {
            return await _unitOfWork.financingRepository.ExistByIdPrevaluation(IdPreevaluacion);
        }

        public async Task<bool> UpdateAsesorPrevaluation(int IdPreevaluacion, int IdAsesor)
        {
            return await _unitOfWork.financingRepository.UpdateAsesorPrevaluation(IdPreevaluacion, IdAsesor);
        }

        public async Task<ResponseIdFinanciamientoDTO> GetListIdFinancing(int IdPreevaluacion)
        {
            return await _unitOfWork.financingRepository.GetListIdFinancing(IdPreevaluacion);
        }
    }
}
