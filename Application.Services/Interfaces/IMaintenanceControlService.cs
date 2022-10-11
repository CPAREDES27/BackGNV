using Application.Dto.MaintenanceControl;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IMaintenanceControlService
    {
        Task<List<MaintenanceControlDTO>> ListAsync(int keyOption);
        Task<List<StateTypeDTO>> ListStateTypeAsync(string tipoTabla);
    }
}
