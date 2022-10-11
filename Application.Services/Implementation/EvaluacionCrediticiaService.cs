using Application.Dto.EvaluacionCrediticia;
using Application.Services.Interfaces;
using Domain.MainModule.Entities.EvaluacionCrediticia;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implementation
{
    public class EvaluacionCrediticiaService: IEvaluacionCrediticiaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EvaluacionCrediticiaService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<TotalEvaluacionCrediticialEntity> GetEvaluacionCrediticia(EvaluacionCrediticiaDTO request)
        {
            return await _unitOfWork.evaluationCrediticiaRepository.GetEvaluacionCrediticia(request);
        }
        public async Task<DetalleEvaluacionCrediticiaEntity> GetDetalleEvaluacionCrediticia(int idEvalCliente, string tipoDocumento, string documento)
        {
            return await _unitOfWork.evaluationCrediticiaRepository.GetDetalleEvaluacionCrediticia(idEvalCliente, tipoDocumento,documento);
        }
        public async Task<List<GetDetallesArchivosEntity>> GetDetalleArchivos(int idPreevaluacion)
        {
            return await _unitOfWork.evaluationCrediticiaRepository.GetDetalleArchivos(idPreevaluacion);
        }
        public async Task<TotalEvaluacionCrediticialEntity> ListarEvaluacionCrediticia(ListaEvaluacionCrediticiaDTO request)
        {
            return await _unitOfWork.evaluationCrediticiaRepository.ListarEvaluacionCrediticia(request);
        }
        public async Task<int> RegisterEvaluacionCrediticia(RegisterEvaluacionCrediticiaDTO request)
        {
            return await _unitOfWork.evaluationCrediticiaRepository.RegisterEvaluacionCrediticia(request);
        }
        public async Task<TotalCargaPostAtencionEntity> ListarPostAtencion(ListaEvaluacionCrediticiaDTO request)
        {
            return await _unitOfWork.evaluationCrediticiaRepository.ListarPostAtencion(request);
        }
        public async Task<DetallePostAtencionEntity> DetallePostAtencion(int idPostAtencion)
        {
            return await _unitOfWork.evaluationCrediticiaRepository.DetallePostAtencion(idPostAtencion);
        }
        public async Task<PA_CargaDocumentosEntity> CargaDocumentos_PA(int idPostAtencion, string nombreDocumento)
        {
            return await _unitOfWork.evaluationCrediticiaRepository.CargaDocumentos_PA(idPostAtencion, nombreDocumento);
        }
        public async Task<int> UpdatePA_CargaDocumentos(UpdateCargaDocumentosPADTO request)
        {
            return await _unitOfWork.evaluationCrediticiaRepository.UpdatePA_CargaDocumentos(request);
        }

        public async Task<List<CargaIndividualMasivoEntity>> ObtenerCargaOnBaseIndividual(CargaOnBaseIndividualDTO request)
        {
            return await _unitOfWork.evaluationCrediticiaRepository.ObtenerCargaOnBaseIndividual(request);
        }

        public async Task<List<CargaIndividualMasivoEntity>> ObtenerCargaOnBaseMasivo()
        {
            return await _unitOfWork.evaluationCrediticiaRepository.ObtenerCargaOnBaseMasivo();
        }

        public async Task<int> InsertarIndividual(List<CargaIndividualMasivoEntity> listaCargaIndividualMasivo)
        {
            return await _unitOfWork.evaluationCrediticiaRepository.InsertarIndividual(listaCargaIndividualMasivo);
        }

        public async Task<int> InsertarMasivo(List<CargaIndividualMasivoEntity> listaCargaIndividualMasivo)
        {
            return await _unitOfWork.evaluationCrediticiaRepository.InsertarMasivo(listaCargaIndividualMasivo);
        }
        public async Task<ConsultaSolicitudEntity> ConsultaFormatoSolicitud(int idPrevaluacion)
        {
            return await _unitOfWork.evaluationCrediticiaRepository.ConsultaFormatoSolicitud(idPrevaluacion);
        }
        public async Task<int> UpdateEstadoPreevaluacion(int idPreevaluacion, int idEstado)
        {
            return await _unitOfWork.evaluationCrediticiaRepository.UpdateEstadoPreevaluacion(idPreevaluacion, idEstado);
        }
    }
}
