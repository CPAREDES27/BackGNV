using Application.Dto.PostAttention;
using Application.Dto.UploadDocuments.PostAttention;
using Application.Services.Interfaces;
using Domain.MainModule.Entities.PostAttention;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implementation
{
    public class PostAttentionService : IPostAttentionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PostAttentionService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<ListPostAttention> GetPostAttentionById(int idPostAttention)
        {
            return await _unitOfWork.postAttentionRepository.GetPostAttentionById(idPostAttention);
        }

        public async Task<TotalPostAttentionEntity> ListPostAttention(ListPostAttentionDTO request)
        {
            return await _unitOfWork.postAttentionRepository.ListPostAttention(request);
        }

        public async Task<bool> UploadAsync(UploadDocumentsPostAttentionDTO uploadDocumentsDto, int idPostAttention)
        {
            return await _unitOfWork.postAttentionRepository.UploadAsync(uploadDocumentsDto, idPostAttention);
        }
    }
}
