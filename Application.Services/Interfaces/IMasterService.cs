using Domain.MainModule.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IMasterService
    {
        Task<List<MaestroEntity>> GetMaestro(string clave);
    }
}
