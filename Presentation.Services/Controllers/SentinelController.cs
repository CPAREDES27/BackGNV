using Application.Dto;
using Application.Dto.BusinessAdvisors;
using Application.Dto.CustomEntities;
using Application.Dto.Financing;
using Application.Dto.RandomQuestions;
using Application.Dto.Sentinel;
using Application.Dto.Survey;
using Application.Dto.UploadDocuments.KnockoutRules;
using Application.Manager.Interfaces;
using Application.Services.Util;
using Application.Services.Util.Directonary;
using AutoMapper;
using Domain.MainModule.Entities;
using Infrastructure.Data.Context;
using Infrastructure.MainModule.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Presentation.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SentinelController : ControllerBase
    {
        private readonly ISentinelManager sentinelManager;
        private readonly IMapper mapper;
        private readonly IUriService uriService;
        private readonly DBGNVContext Dbcont;

        public SentinelController(
            ISentinelManager sentinel,
            IMapper mapper,
            IUriService uriService,
            DBGNVContext Dbcont
            )
        {
            this.sentinelManager = sentinel;
            this.mapper = mapper;
            this.uriService = uriService;
            this.Dbcont = Dbcont;
        }

        [HttpPost("UsuarioEncriptado")]
        public async Task<IActionResult> UsuarioEncriptado([FromBody] Ws1EncriptacionEntradaDTO ws1encriptacionentrada)
        {
            Ws1EncriptacionSalidaDTO req = await sentinelManager.ObtenerUsuarioEncriptado(ws1encriptacionentrada);
            
            return Ok(req);
        }

        [HttpPost("ClaveEncriptado")]
        public async Task<IActionResult> ClaveEncriptado([FromBody] Ws1EncriptacionEntradaDTO ws1encriptacionentrada)
        {
            Ws1EncriptacionSalidaClaveDTO req = await sentinelManager.ObtenerClaveEncriptado(ws1encriptacionentrada);

            return Ok(req);
        }

        [HttpPost("Ws2DatosPersona")]
        public async Task<IActionResult> Ws2DAtosPersona([FromBody] ws2EntradaDTO ws2EntradaDTO)
        {
            ws2SalidaDTO req = await sentinelManager.ObtenerDatosWs2(ws2EntradaDTO);

            return Ok(req);
        }
        [HttpPost("ObtenerDatosUsuario")]
        public async Task<IActionResult> ObtenerDatosUsuario([FromBody] ObtenerEntradaSolicitudDTO ObtenerDatos)
        {
            ObtenerDatosUsuarioDTO req = await sentinelManager.ObtenerDatosUsuario(ObtenerDatos);

            return Ok(req);
        }


        //[HttpGet("CualquierCosa")]
        //public async Task<ActionResult<List<TablaSentinel>>> CualquierCosa()
        //{
        //    return Ok(await Dbcont.TablaSentinel.ToListAsync());
        //}
    }
}
