using Application.Dto.MaintenanceControl;
using Application.Manager.Interfaces;
using Application.Services.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Manager.Implementation
{
    public class MaintenanceControlManager : IMaintenanceControlManager
    {
        private readonly IMapper mapper;
        private readonly IMaintenanceControlService maintenanceControlServices;

        public MaintenanceControlManager(IMapper mapper, 
            IMaintenanceControlService maintenanceControlServices)
        {
            this.mapper = mapper;
            this.maintenanceControlServices = maintenanceControlServices;
        }

        public async Task<List<MaintenanceControlDTO>> ListAsync(int keyOption)
        {
            List<MaintenanceControlDTO> maintenanceControlDTOs = await maintenanceControlServices.ListAsync(keyOption);
            return maintenanceControlDTOs;
        }

        public async Task<List<StateTypeDTO>> ListStateTypeAsync(string tipoTabla)
        {
            List<StateTypeDTO> evaluationclient = await maintenanceControlServices.ListStateTypeAsync(tipoTabla);
            return evaluationclient;
        }
    }
}
