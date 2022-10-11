using Domain.MainModule.Entities;
using System.Threading.Tasks;

namespace Infrastructure.MainModule.Interfaces
{
    public interface IMasterRepository
    {
        Task<MaestroEntity> GetCredentialsUrl(string rootKey);
    }
}
