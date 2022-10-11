using Application.Dto.Sentinel;
using Application.Manager.Interfaces;
using Application.Services.Interfaces;
using AutoMapper;
using Infrastructure.MainModule.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Manager.Implementation
{
    public class SentinelManager : ISentinelManager
    {

        private readonly ISentinelService sentinelService;
        private readonly IMapper mapper;
        public SentinelManager(
             ISentinelService sentinelService,
             IMapper mapper
            )
        {
            this.sentinelService = sentinelService;
            this.mapper = mapper;
        }

        public async Task<Ws1EncriptacionSalidaClaveDTO> ObtenerClaveEncriptado(Ws1EncriptacionEntradaDTO request)
        {
            Ws1EncriptacionSalidaClaveDTO req = await sentinelService.ObtenerClaveEncriptado(request);

            return req;
        }

        public async Task<ws2SalidaDTO> ObtenerDatosWs2(ws2EntradaDTO request)
        {
            ws2SalidaDTO req = await sentinelService.ObtenerDatosWs2(request);

            return req;
        }

        public async Task<Ws1EncriptacionSalidaDTO> ObtenerUsuarioEncriptado(Ws1EncriptacionEntradaDTO request)
        {
            Ws1EncriptacionSalidaDTO req = await sentinelService.ObtenerUsuarioEncriptado(request);

            return req;
        }

        public async Task<ObtenerDatosUsuarioDTO> ObtenerDatosUsuario(ObtenerEntradaSolicitudDTO request)
        {
            ObtenerDatosUsuarioDTO req = await sentinelService.ObtenerDatosUsuario(request);

            return req;
        }
    }
}
