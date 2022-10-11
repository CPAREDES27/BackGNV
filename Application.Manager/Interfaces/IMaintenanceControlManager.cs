using Application.Dto.MaintenanceControl;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Manager.Interfaces
{
    public interface IMaintenanceControlManager
    {
        Task<List<MaintenanceControlDTO>> ListAsync(int keyOption);
        Task<List<StateTypeDTO>> ListStateTypeAsync(string tipoTabla);

    }
}
