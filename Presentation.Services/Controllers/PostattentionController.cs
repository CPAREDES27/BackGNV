using Application.Dto.PostAttention;
using Application.Dto.UploadDocuments.PostAttention;
using Application.Manager.Interfaces;
using Application.Services.Util;
using AutoMapper;
using Domain.MainModule.Entities.PostAttention;
using Infrastructure.MainModule.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Services.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostattentionController : Controller
    {
        private readonly IPostattentionManager postattentionManager;
        private readonly IMapper mapper;
        private readonly IUriService uriService;
        public PostattentionController(
            IPostattentionManager postattentionManager,
            IMapper mapper,
            IUriService uriService)
        {
            this.postattentionManager = postattentionManager;
            this.mapper = mapper;
            this.uriService = uriService;
        }


        [HttpPost("ListPostAttention")]
        public async Task<IActionResult> ListPostAttention(ListPostAttentionDTO request)
        {
            if (ModelState.IsValid)
            {
                var resultado = await postattentionManager.ListPostAttention(request);
                if (resultado == null)
                {
                    return Ok(new { valid = false, message = Constants.ReponseNoExistpostAttention });
                }
                return Ok(resultado);
            }
            else
                return BadRequest(new { valid = false, message = "Revise parametros." });

        }
        
        [HttpGet("GetPostAttentionById")]
        public async Task<IActionResult> GetPostAttentionById(int idPostAttention)
        {
            ListPostAttention resultPostAttentionId = await postattentionManager.GetPostAttentionById(idPostAttention);

            if (resultPostAttentionId == null)
            {
                return Ok(new { valid = false, message = Constants.InvalidIdPostAttention });
            }

            return Ok(resultPostAttentionId);
        }


        [HttpPost("UploadDocumentPostAttention")]
        public async Task<IActionResult> UploadDocument([FromBody] UploadDocumentsPostAttentionDTO uploadDocumentsDto)
        {
            var resultUploadDocumentsDto = await postattentionManager.UploadDocumentAsync(uploadDocumentsDto);

            if (resultUploadDocumentsDto == false)
            {
                return BadRequest(new { valid = false, message = FinancingRequestConst.InvalidUploadDocuments });
            }

            return Ok(new { valid = true, message = FinancingRequestConst.SuccessUploadDocuments });
        }


    }
}
