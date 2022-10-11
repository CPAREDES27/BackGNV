using Application.Dto.EvaluacionCrediticia;
using Domain.MainModule.Entities.EvaluacionCrediticia;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IEvaluacionCrediticiaService 
    {
        Task<TotalEvaluacionCrediticialEntity> GetEvaluacionCrediticia(EvaluacionCrediticiaDTO request);
        Task<DetalleEvaluacionCrediticiaEntity> GetDetalleEvaluacionCrediticia(int idEvalCliente, string tipoDocumento, string documento);
        Task<List<GetDetallesArchivosEntity>> GetDetalleArchivos(int idPreevaluacion);
        Task<TotalEvaluacionCrediticialEntity> ListarEvaluacionCrediticia(ListaEvaluacionCrediticiaDTO request);
        Task<int> RegisterEvaluacionCrediticia(RegisterEvaluacionCrediticiaDTO request);
        Task<TotalCargaPostAtencionEntity> ListarPostAtencion(ListaEvaluacionCrediticiaDTO request);
        Task<DetallePostAtencionEntity> DetallePostAtencion(int idPostAtencion);
       Task<PA_CargaDocumentosEntity> CargaDocumentos_PA(int idPostAtencion, string nombreDocumento);
        Task<int> UpdatePA_CargaDocumentos(UpdateCargaDocumentosPADTO request);

        Task<List<CargaIndividualMasivoEntity>> ObtenerCargaOnBaseIndividual(CargaOnBaseIndividualDTO request);
        Task<List<CargaIndividualMasivoEntity>> ObtenerCargaOnBaseMasivo();

        Task<int> InsertarIndividual(List<CargaIndividualMasivoEntity> listaCargaIndividualMasivo);
        Task<int> InsertarMasivo(List<CargaIndividualMasivoEntity> listaCargaIndividualMasivo);
        Task<ConsultaSolicitudEntity> ConsultaFormatoSolicitud(int idPrevaluacion);
        Task<int> UpdateEstadoPreevaluacion(int idPreevaluacion, int idEstado);
    }
}
