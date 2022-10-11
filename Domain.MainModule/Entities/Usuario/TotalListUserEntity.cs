using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainModule.Entities.Usuario
{
    public class TotalListUserEntity
    {
        public TotalListUserEntity()
        {
            Data = new List<ListUserEntity>();
            Meta = new ListUserPaginadoEntity();
        }

        public List<ListUserEntity> Data { get; set; }
        public ListUserPaginadoEntity Meta { get; set; }
    }
}

