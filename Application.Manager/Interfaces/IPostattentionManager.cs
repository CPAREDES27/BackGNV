using Application.Dto.PostAttention;
using Application.Dto.UploadDocuments.PostAttention;
using Domain.MainModule.Entities.PostAttention;
using System.Threading.Tasks;

namespace Application.Manager.Interfaces
{
    public  interface IPostattentionManager
    {
        Task<TotalPostAttentionEntity> ListPostAttention(ListPostAttentionDTO request);

        Task<ListPostAttention> GetPostAttentionById(int idPostAttention);

        Task<bool> UploadDocumentAsync(UploadDocumentsPostAttentionDTO uploadDocumentsDto);
    }
}
