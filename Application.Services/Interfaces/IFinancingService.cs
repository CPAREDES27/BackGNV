using Application.Dto;
using Application.Dto.CustomEntities;
using Application.Dto.Download;
using Application.Dto.Financing;
using Application.Dto.RandomQuestions;
using Application.Dto.Survey;
using Application.Dto.UploadDocuments.KnockoutRules;
using Domain.MainModule.Entities;
using Domain.MainModule.Entities.Financing;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IFinancingService
    {
        Task<List<PendingPrevaluationDTO>> GetListPreevaluacionKnockout(int id);

        Task<RespuestaRegisterDto> RegisterClientPreevaluation(RegisterClientPreevaluationDTO request);
        Task<PreEvaluationEntity> AddPreevaluation(PreEvaluationEntity preevaluacionEntity);
        Task<int> RegisterReglasNockout(RegisterReglasNockoutDTO request);
        Task<RegistroReglasKnockoutEntity> AddReglaKnockout(RegistroReglasKnockoutEntity reglaKnockoutEntity);
        Task<TotalListPreevaluationEntity> GetListPreevaluation(FilterPreevaluationDTO request);
        PagedList<PreEvaluationTempEntity> GetPrevaluation(PrevaluationQueryFilterDTO prevaluationQueryFilterDTO);
       
        public int UpdateIdPrevaluation(int idPrevaluation, int idEstadoKnockoutRules);
        Task<List<MantenPreguntasAleatoriasEntity>> ListMantPreguntasAleatorias();
        Task<List<MantPreguntasAletoriaEntity>> GetList();
        Task<List<ListUsuarioEntity>> ListBusineesAdvisor();
        Task<List<UsuarioEntity>> ListBaAsync();

        Task<bool> UploadAsync(UploadDocumentSupportDTO uploadDocumentSupportDto, int idKnockoutRules);

        Task<DownloadEntity> GetDownload(DownloadDTO download);
        Task<List<DownloadEntity>> GetDownload_RK_SF(string nombre_tabla, int id);
        Task<int> InsertRandonQuestions(InsertRandonQuestionsDTO request);
        Task<int> InsertRandonQuestions_Detalle(RandonQuestionDetalle request);
        Task<MantPreguntasAleatoriasEntity> AddRandomQuestions(MantPreguntasAleatoriasEntity mantPreguntasAleatoriaEntity);
        
        Task<bool> AddRandomQuestionsDetails(int IdPregunta, string Descripcion, bool Activo);
        Task<List<ListQuestionEntity>> ListarManPreguntas();
        Task<List<ListQuestionDetalleEntity>> ListMantPreguntasDetalle(int idpregunta);
        Task<List<ResponseRandomQuestionsDTO>> GetList2();
        Task<int> DeleteRandonQuestions(InsertRandonQuestionsDTO request);
        Task<int> DeleteRandonQuestions_Detalle(RandonQuestionDetalle request);
        Task<JsonResultEntity> UpdateAsync(RandomQuestionsRequestDTO requestDTO);

        Task<JsonResultEntity> DeleteAsync(RequestQuestionDTO requestDTO);

        Task<JsonResultEntity> AddAsync(List<SurveyDTO> surveyDTO);
        Task<List<ListQuestionEntity>> ListarManPreguntasxId(int idPregunta);
        Task<List<ListQuestionDetalleEntity>> ListMantPreguntasDetallexId(int idpregunta);
        Task<List<ResponseRandomQuestionsDTO>> ListRamdonIdAsync(int idPregunta);
        Task<List<PreevaluacionTip_DocDTO>> GetPreevaluacion_TipDoc(int IdTipoDocumento, string NumDocumento);
        List<PreEvaluationTempEntity> GetPrevaluationTipDocEst(PrevaluationFilterTipDocEstDTO prevaluationQueryFilterDTO);

        Task<List<EstadoNivelEstudiosClienteEntity>> GetEstadoNivelEstudiosCliente(); 
        Task<List<EstadoCivilClienteEntity>> GetEstadoCivilCliente();

        Task<List<EstadoVehicularEntity>> GetEstadoVehicular();
        Task<List<EstadoTipoFinanciamientoEntity>> GetEstadoTipoFinanciamiento();
        Task<List<TipoCalleEntity>> GetTipoCalle();
        Task<List<TipoCreditoFinanciamientoEntity>> GetTipoCreditoFinanciamiento();
        Task<int> UpdateRegistroReglasKnockout(UpdateRegistroReglasNockoutDTO reglasNockoutDTO);
        Task<ResponseRKByIdPrevaluationDTO> ListExistRKByIdPrevaluation(int IdPreevaluacion);

        Task<ResponseExistPreevaluationDTO> ExistByIdPrevaluation(int IdPreevaluacion);
        Task<bool> UpdateAsesorPrevaluation(int IdPreevaluacion, int IdAsesor);

        Task<ResponseIdFinanciamientoDTO> GetListIdFinancing(int IdPreevaluacion);
        
    }
}
