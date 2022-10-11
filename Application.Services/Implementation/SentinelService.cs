using Application.Dto;
using Application.Dto.CustomEntities;
using Application.Dto.Download;
using Application.Dto.Financing;
using Application.Dto.RandomQuestions;
using Application.Dto.Sentinel;
using Application.Dto.Survey;
using Application.Dto.UploadDocuments.KnockoutRules;
using Application.Services.Interfaces;
using Domain.MainModule.Entities;
using Domain.MainModule.Entities.Financing;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Application.Services.Implementation
{
    public class SentinelService : ISentinelService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SentinelService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Ws1EncriptacionSalidaClaveDTO> ObtenerClaveEncriptado(Ws1EncriptacionEntradaDTO request)
        {
            return await _unitOfWork.sentinelRepository.ObtenerClaveEncriptado(request);
        }

        public async Task<ObtenerDatosUsuarioDTO> ObtenerDatosUsuario(ObtenerEntradaSolicitudDTO request)
        {
            return await _unitOfWork.sentinelRepository.ObtenerDatosUsuario(request);
        }

        public async Task<ws2SalidaDTO> ObtenerDatosWs2(ws2EntradaDTO request)
        {
            return await _unitOfWork.sentinelRepository.ObtenerDatosWs2(request);
        }

        public async Task<Ws1EncriptacionSalidaDTO> ObtenerUsuarioEncriptado(Ws1EncriptacionEntradaDTO request)
        {
            return await _unitOfWork.sentinelRepository.ObtenerUsuarioEncriptado(request);
        }
    }
}
