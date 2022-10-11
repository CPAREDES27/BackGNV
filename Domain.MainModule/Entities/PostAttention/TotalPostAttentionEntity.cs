using System.Collections.Generic;

namespace Domain.MainModule.Entities.PostAttention
{
    public class TotalPostAttentionEntity
    {
        public TotalPostAttentionEntity()
        {
            Data = new List<ListPostAttention>();
            Meta = new PostAttentionPagEntity();
        }

        public List<ListPostAttention> Data { get; set; }
        public PostAttentionPagEntity Meta { get; set; }
    }
}
