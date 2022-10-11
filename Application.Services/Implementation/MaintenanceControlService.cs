using Application.Dto.MaintenanceControl;
using Application.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services.Implementation
{
    public class MaintenanceControlService : IMaintenanceControlService
    {
        private readonly IUnitOfWork unitOfWork;

        public MaintenanceControlService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<List<MaintenanceControlDTO>> ListAsync(int keyOption)
        {
            return await unitOfWork.maintenanceControlServices.ListAsync(keyOption);
        }

        public async Task<List<StateTypeDTO>> ListStateTypeAsync(string tipoTabla)
        {
            return await unitOfWork.maintenanceControlServices.ListStateTypeAsync(tipoTabla);
        }
    }
}
