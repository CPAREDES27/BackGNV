using Application.Dto;
using Application.Dto.UploadDocuments.RequestFinancing;
using Application.Manager.Interfaces;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.MainModule.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Manager.Implementation
{
    public class FinancingRequestManager : IFinancingRequestManager
    {
        private readonly IFinancingRequestService financingRequestService;
        private readonly IMapper mapper;
        private int idSfClient;
        public FinancingRequestManager(
             IFinancingRequestService financingRequestService,
             IMapper mapper
            )
        {
            this.financingRequestService = financingRequestService;
            this.mapper = mapper;
        }

        public async Task<CustomerFinancingDTO> CustomerFinancingRecord(FinancingRequestDTO financingRequestDTO)
        {
            RegistroSolicitudFinanciamientoEntity registroSolicitudFinanciamientoEntity = mapper.Map<RegistroSolicitudFinanciamientoEntity>(financingRequestDTO);
            RegistroSolicitudFinanciamientoEntity _registroSolicitudFinanciamiento = await financingRequestService.AddCustomerFinancingAsync(registroSolicitudFinanciamientoEntity); 
            CustomerFinancingDTO customerFinancingDTO = mapper.Map<CustomerFinancingDTO>(_registroSolicitudFinanciamiento);
            var result = await UpdateServiceCenterAsync(_registroSolicitudFinanciamiento.IdSfCliente, financingRequestDTO.IdTaller);
            idSfClient = _registroSolicitudFinanciamiento.IdSfCliente;
            return customerFinancingDTO;
        }

        public async Task<bool> CustomerFinancingRecordTemp(FinancingRequestTempDTO financingRequest)
        {
            RegistroSolicitudFinanciamientoEntity registroSolicitudFinanciamientoEntity = mapper.Map<RegistroSolicitudFinanciamientoEntity>(financingRequest);

            var registertemp = await financingRequestService.AddCustomerFinancingAsyncTemp(registroSolicitudFinanciamientoEntity);
            return registertemp;
        }

        public async Task<LineaCreditoEntity> LineaCredito(int NumScore, string ValorCR)
        {
            var lineacredito = await financingRequestService.LineaCredito(NumScore, ValorCR);
            return lineacredito;
        }

        public async Task<TotalList40Preguntas> List40Preguntas(int IdtipoDocumento, string NumDocumento, int NumPag, int NumReg)
        {
            var list40 = await financingRequestService.List40Preguntas(IdtipoDocumento, NumDocumento, NumPag, NumReg);
            return list40;
        }

        public async Task<List<ListLineaTiempoEntity>> ListLineaTiempo(string Clave, int Id)
        {
            var listLineatiempo = await financingRequestService.ListLineaTiempo(Clave, Id);
            return listLineatiempo;
        }

        public async Task<List<ListPendienteSolicitudId>> ListPendienteSolicitidById(Int64 IdSfCliente)
        {
            var ListById = await financingRequestService.ListPendienteSolicitidById(IdSfCliente);
            return ListById;
        }

        public async Task<TotalListPendienteSolicitud> ListPendienteTempSolicitud(int IdTipoDocumento, string Numdocumento, int NumPag, int NumReg)
        {
            var listTemporalSolicitud = await financingRequestService.ListPendienteTempSolicitud(IdTipoDocumento, Numdocumento, NumPag, NumReg);
            return listTemporalSolicitud;
        }

        public async Task<List<ConsultaTallerEntity>> ListServiceCenterAsync(string nombre, int idProveedor)
        {
            var listaServiceCenter = await financingRequestService.ListServiceCenterAsync(nombre, idProveedor);
            return listaServiceCenter;
        }

        public async Task<ListultimoReg40Preguntas> ListultimoRegistro40Preguntas(int IdUsuario)
        {
            var lisUltimoRegistro40 = await financingRequestService.ListultimoRegistro40Preguntas(IdUsuario);
            return lisUltimoRegistro40;
        }

        public async Task<ListUltimoRegPreevaluacion> ListultimoRegistroPreevalucion(int IdUsuario)
        {
            var listUtlimoRegistro = await financingRequestService.ListultimoRegistroPreevalucion(IdUsuario);
            return listUtlimoRegistro;
        }

        public async Task<List<RegistroSolicitudFinanciamientoEntity>> UpdateServiceCenterAsync(int idSfClient, int idWorkshop)
        {
            List<RegistroSolicitudFinanciamientoEntity> result = await financingRequestService.UpdateIdAsync(idSfClient, idWorkshop);
            return result;
        }

        public async Task<bool> UploadDocumentAsync(UploadDocumentsDTO uploadDocumentsDto)
        {
            var uploadDocumentsDtos = await financingRequestService.UploadAsync(uploadDocumentsDto, uploadDocumentsDto.IdCliente);
            return uploadDocumentsDtos;
        }
    }
}
