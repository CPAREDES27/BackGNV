using Application.Dto.UploadDocuments.RequestFinancing;
using Domain.MainModule.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IFinancingRequestService
    {
        Task<RegistroSolicitudFinanciamientoEntity> AddCustomerFinancingAsync(RegistroSolicitudFinanciamientoEntity reglaKnockoutEntity);

        Task<List<ConsultaTallerEntity>> ListServiceCenterAsync(string nombre, int idProveedor);

        Task<List<RegistroSolicitudFinanciamientoEntity>> UpdateIdAsync(int idSfClient, int idWorkshop);

        Task<bool> UploadAsync(UploadDocumentsDTO uploadDocumentsDto, int idSfClient);

        Task<bool> AddCustomerFinancingAsyncTemp(RegistroSolicitudFinanciamientoEntity reglaKnockoutEntity);

        Task<TotalListPendienteSolicitud> ListPendienteTempSolicitud(int IdTipoDocumento, string Numdocumento, int NumPag, int NumReg);

        Task<List<ListPendienteSolicitudId>> ListPendienteSolicitidById(long IdSfCliente);

        Task<TotalList40Preguntas> List40Preguntas(int IdtipoDocumento, string NumDocumento, int NumPag, int NumReg);

        Task<List<ListLineaTiempoEntity>> ListLineaTiempo(string Clave, int Id);
        Task<ListUltimoRegPreevaluacion> ListultimoRegistroPreevalucion(int IdUsuario);

        Task<ListultimoReg40Preguntas> ListultimoRegistro40Preguntas(int IdUsuario);

        Task<LineaCreditoEntity> LineaCredito(int NumScore, string ValorCR);

    }
}
