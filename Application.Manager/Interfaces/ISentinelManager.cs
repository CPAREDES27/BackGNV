using Application.Dto;
using Application.Dto.BusinessAdvisors;
using Application.Dto.CustomEntities;
using Application.Dto.Download;
using Application.Dto.Financing;
using Application.Dto.RandomQuestions;
using Application.Dto.Sentinel;
using Application.Dto.Survey;
using Application.Dto.UploadDocuments.KnockoutRules;
using Domain.MainModule.Entities;
using Domain.MainModule.Entities.Financing;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Application.Manager.Interfaces
{
    public interface ISentinelManager
    {
        Task<Ws1EncriptacionSalidaDTO> ObtenerUsuarioEncriptado(Ws1EncriptacionEntradaDTO request);
        Task<Ws1EncriptacionSalidaClaveDTO> ObtenerClaveEncriptado(Ws1EncriptacionEntradaDTO request);

        Task<ws2SalidaDTO> ObtenerDatosWs2(ws2EntradaDTO request);

        Task<ObtenerDatosUsuarioDTO> ObtenerDatosUsuario(ObtenerEntradaSolicitudDTO request);
    }
}
