using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainModule.Entities.Product
{
    public class TotalListProductEntity
    {
        public TotalListProductEntity()
        {
            Data = new List<ListProductEntity>();
            Meta = new ListProductPaginadoEntity();
        }

        public List<ListProductEntity> Data { get; set; }
        public ListProductPaginadoEntity Meta { get; set; }
    }
}
