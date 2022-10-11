using Application.Dto;
using Application.Dto.BusinessAdvisors;
using Application.Dto.CustomEntities;
using Application.Dto.Download;
using Application.Dto.Financing;
using Application.Dto.RandomQuestions;
using Application.Dto.Survey;
using Application.Dto.UploadDocuments.KnockoutRules;
using Domain.MainModule.Entities;
using Domain.MainModule.Entities.Financing;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Manager.Interfaces
{
    public interface IFinancingManager
    {
        Task<List<PendingPrevaluationDTO>> GetListPreevaluacionKnockout(int id);
        Task<RespuestaRegisterDto> RegisterClientPreevaluation(RegisterClientPreevaluationDTO request);

        Task<int> RegisterReglasNockout(RegisterReglasNockoutDTO request);
        Task<RegisterPreEvaluationDTO> AddPreevaluation(PreEvaluationDTO preEvaluationDTO);
        
        Task<RegisterReglaKnockoutDTO> AddReglaKnockout(ReglaKnockoutDTO reglaKnockoutDTO);
        Task<TotalListPreevaluationEntity> GetListPreevaluation(FilterPreevaluationDTO request);
        PagedList<PreEvaluationTempEntity> ListPagePrevaluation(PrevaluationQueryFilterDTO prevaluationQueryFilterDTO);
        Task<List<MantenPreguntasAleatoriasEntity>> ListMantPreguntasAleatorias();
        Task<bool> UpdateAsesorPrevaluation(int IdPreevaluacion, int IdAsesor);
        Task<List<RandomQuestionsDTO>> ListAsync();
        Task<List<ResponseRandomQuestionsDTO>> ListQuestion_Cab_Det();
        Task<List<ResponseRandomQuestionsDTO>> List2Async();
        Task<List<ResponseRandomQuestionsDTO>> ListRamdonIdAsync(int idPregunta);
        Task<int> InsertRandonQuestions(InsertRandonQuestionsDTO request);
        Task<bool> AddRandomQuestions(RandomQuestionsRequestDTO randomQuestionsRequestDTO);
        Task<int> DeleteRandonQuestions(InsertRandonQuestionsDTO request);
        Task<JsonResultEntity> UpdateAsync(RandomQuestionsRequestDTO requestDTO);

        Task<JsonResultEntity> DeleteAsync(RequestQuestionDTO requestQuestionDto);
        Task<List<ListUsuarioEntity>> ListBusineesAdvisor();
        Task<List<BusinessAdvisorsDTO>> ListBaAsync();

        Task<bool> UploadAsync(UploadDocumentSupportDTO uploadDocumentSupportDTO);

        Task<DownloadEntity> GetDownload(DownloadDTO download);
        Task<List<DownloadEntity>> GetDownload_RK_SF(string nombre_tabla, int id);

        Task<JsonResultEntity> AddAsync(List<SurveyDTO> surveyDTO);
        Task<List<PreevaluacionTip_DocDTO>> GetPreevaluacion_TipDoc(int IdTipoDocumento, string NumDocumento);
        List<PreEvaluationTempEntity> ListPagePrevaluationTipDocEst(PrevaluationFilterTipDocEstDTO prevaluationQueryFilterDTO);
        Task<List<EstadoNivelEstudiosClienteEntity>> GetEstadoNivelEstudiosCliente();
        Task<List<EstadoCivilClienteEntity>> GetEstadoCivilCliente();
        Task<List<EstadoVehicularEntity>> GetEstadoVehicular();
        Task<List<EstadoTipoFinanciamientoEntity>> GetEstadoTipoFinanciamiento();
        Task<List<TipoCalleEntity>> GetTipoCalle();
        Task<List<TipoCreditoFinanciamientoEntity>> GetTipoCreditoFinanciamiento();
        Task<int> UpdateRegistroReglasKnockout(UpdateRegistroReglasNockoutDTO reglasNockoutDTO);
        Task<ResponseRKByIdPrevaluationDTO> ListExistRKByIdPrevaluation(int IdPreevaluacion);

        Task<ResponseExistPreevaluationDTO> ExistByIdPrevaluation(int IdPreevaluacion);

        Task<ResponseIdFinanciamientoDTO> GetListIdFinancing(int IdPreevaluacion);
        

    }
}
