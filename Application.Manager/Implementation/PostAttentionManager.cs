using Application.Dto.PostAttention;
using Application.Dto.UploadDocuments.PostAttention;
using Application.Manager.Interfaces;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.MainModule.Entities.PostAttention;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Manager.Implementation
{
    public  class PostAttentionManager: IPostattentionManager
    {
        private readonly IPostAttentionService postattenionService;
        private readonly IMapper mapper;

        public PostAttentionManager(IPostAttentionService postAttentionService, IMapper mapper)
        {
            this.postattenionService = postAttentionService;
            this.mapper = mapper;
        }

        public async Task<ListPostAttention> GetPostAttentionById(int idPostAttention)
        {
            return await postattenionService.GetPostAttentionById(idPostAttention);
        }

        public async Task<TotalPostAttentionEntity> ListPostAttention(ListPostAttentionDTO request)
        {
            var responseListPostAttention = await postattenionService.ListPostAttention(request);
            return responseListPostAttention;
        }

        public async Task<bool> UploadDocumentAsync(UploadDocumentsPostAttentionDTO uploadDocumentsDto)
        {
            var uploadDocumentsDtos = await postattenionService.UploadAsync(uploadDocumentsDto, uploadDocumentsDto.IdPostAtencion);
            return uploadDocumentsDtos;
        }
    }
}
