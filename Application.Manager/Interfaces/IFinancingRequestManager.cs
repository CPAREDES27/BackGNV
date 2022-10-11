using Application.Dto;
using Application.Dto.UploadDocuments.RequestFinancing;
using Domain.MainModule.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Manager.Interfaces
{

    public interface IFinancingRequestManager
    {
        Task<CustomerFinancingDTO> CustomerFinancingRecord(FinancingRequestDTO financingRequest);

        Task<List<ConsultaTallerEntity>> ListServiceCenterAsync(string nombre, int idProveedor);

        Task<bool> UploadDocumentAsync(UploadDocumentsDTO uploadDocumentsDto);

        //Registro Temporal 40 preguntas
        Task<bool> CustomerFinancingRecordTemp(FinancingRequestTempDTO financingRequest);

        Task<TotalListPendienteSolicitud> ListPendienteTempSolicitud(int IdTipoDocumento, string Numdocumento, int NumPag, int NumReg);

        Task<List<ListPendienteSolicitudId>> ListPendienteSolicitidById(Int64 IdSfCliente);

        Task<TotalList40Preguntas> List40Preguntas(int IdtipoDocumento, string NumDocumento, int NumPag, int NumReg);

        Task<List<ListLineaTiempoEntity>> ListLineaTiempo(string Clave, int Id);

        Task<ListUltimoRegPreevaluacion> ListultimoRegistroPreevalucion(int IdUsuario);

        Task<ListultimoReg40Preguntas> ListultimoRegistro40Preguntas(int IdUsuario);

        Task<LineaCreditoEntity> LineaCredito(int NumScore, string ValorCR);

        //


    }
}
