using Application.Dto.EvaluacionCrediticia;
using Domain.MainModule.Entities.EvaluacionCrediticia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Manager.Interfaces
{
    public interface IEvaluacionCrediticiaManager
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

        Task<int> InsertarIndividual(CargaOnBaseIndividualDTO request);

        Task<int> InsertarMasivo();
        Task<ConsultaSolicitudEntity> ConsultaFormatoSolicitud(int idPrevaluacion);
       Task<int> UpdateEstadoPreevaluacion(int idPreevaluacion, int idEstado);
    }
}
