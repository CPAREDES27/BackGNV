using Application.Dto.PostAttention;
using Application.Dto.UploadDocuments.PostAttention;
using Domain.MainModule.Entities.PostAttention;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IPostAttentionService
    {
        Task<TotalPostAttentionEntity> ListPostAttention(ListPostAttentionDTO request);

        Task<ListPostAttention> GetPostAttentionById(int idPostAttention);

        Task<bool> UploadAsync(UploadDocumentsPostAttentionDTO uploadDocumentsDto, int idPostAttention);
    }
}
