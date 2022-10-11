using Application.Dto.UploadDocuments.RequestFinancing;
using Application.Services.Interfaces;
using Domain.MainModule.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services.Implementation
{
    public class FinancingRequestService : IFinancingRequestService
    {
        private readonly IUnitOfWork _unitOfWork;

        public async Task<RegistroSolicitudFinanciamientoEntity> AddCustomerFinancingAsync(RegistroSolicitudFinanciamientoEntity registroSolicitudFinanciamientoEntity)
        {
            return await _unitOfWork.financingRequestRepository.AddCustomerFinancingAsync(registroSolicitudFinanciamientoEntity);
        }

        public async Task<bool> AddCustomerFinancingAsyncTemp(RegistroSolicitudFinanciamientoEntity reglaKnockoutEntity)
        {
            return await _unitOfWork.financingRequestRepository.AddCustomerFinancingAsyncTemp(reglaKnockoutEntity);
        }

        public async Task<LineaCreditoEntity> LineaCredito(int NumScore, string ValorCR)
        {
            return await _unitOfWork.financingRequestRepository.LineaCredito(NumScore, ValorCR);
        }

        public async Task<TotalList40Preguntas> List40Preguntas(int IdtipoDocumento, string NumDocumento, int NumPag, int NumReg)
        {
            return await _unitOfWork.financingRequestRepository.List40Preguntas(IdtipoDocumento, NumDocumento, NumPag, NumReg);
        }

        public async Task<List<ListLineaTiempoEntity>> ListLineaTiempo(string Clave, int Id)
        {
            return await _unitOfWork.financingRequestRepository.ListLineaTiempo(Clave, Id);
        }

        public async Task<List<ListPendienteSolicitudId>> ListPendienteSolicitidById(Int64 IdSfCliente)
        {
            return await _unitOfWork.financingRequestRepository.ListPendienteSolicitidById(IdSfCliente);
        }

        public async Task<TotalListPendienteSolicitud> ListPendienteTempSolicitud(int IdTipoDocumento, string Numdocumento, int NumPag, int NumReg)
        {
            return await _unitOfWork.financingRequestRepository.ListPendienteTempSolicitud(IdTipoDocumento, Numdocumento, NumPag, NumReg);
        }

        public async Task<List<ConsultaTallerEntity>> ListServiceCenterAsync(string nombre, int idProveedor)
        {
            return await _unitOfWork.financingRequestRepository.ListServiceCenterAsync(nombre, idProveedor);
        }

        public async Task<ListultimoReg40Preguntas> ListultimoRegistro40Preguntas(int IdUsuario)
        {
            return await _unitOfWork.financingRequestRepository.ListultimoRegistro40Preguntas(IdUsuario);
        }

        public async Task<ListUltimoRegPreevaluacion> ListultimoRegistroPreevalucion(int IdUsuario)
        {
            return await _unitOfWork.financingRequestRepository.ListultimoRegistroPreevalucion(IdUsuario);
        }

        public async Task<List<RegistroSolicitudFinanciamientoEntity>> UpdateIdAsync(int idSfClient, int idWorkshop)
        {
            return await _unitOfWork.financingRequestRepository.UpdateIdAsync(idSfClient, idWorkshop);
        }

        public async Task<bool> UploadAsync(UploadDocumentsDTO uploadDocumentsDto, int idSfClient)
        {
            return await _unitOfWork.financingRequestRepository.UploadAsync(uploadDocumentsDto, idSfClient);
        }
    }
}
