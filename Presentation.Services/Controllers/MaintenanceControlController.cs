using Application.Dto.MaintenanceControl;
using Application.Manager.Interfaces;
using Application.Services.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaintenanceControlController : ControllerBase
    {
        private readonly IMaintenanceControlManager maintenanceControlManager;

        public MaintenanceControlController(IMaintenanceControlManager maintenanceControlManager)
        {
            this.maintenanceControlManager = maintenanceControlManager;
        }

        [HttpGet("ListMaintenanceOption")]
        public async Task<IActionResult> ListMaintenanceOption(int keyOption)
        {
            List<MaintenanceControlDTO> maintenanceControlDTOs = await maintenanceControlManager.ListAsync(keyOption); 
            if (maintenanceControlDTOs.Count < 0)
            {
                return BadRequest(new { valid = false, message = Constants.InvalidListMaintenanceControl });
            } 
            return Ok(maintenanceControlDTOs); 
        }

        [HttpGet("ListStateType")]
        public async Task<IActionResult> ListStateType(string tipoTabla)
        {
            List<StateTypeDTO> result = await maintenanceControlManager.ListStateTypeAsync(tipoTabla);
            if (result.Count < 0)
            {
                return BadRequest(new { valid = false, message = Constants.InvalidListStateMaintenanceControl });
            }
            return Ok(result);
        }

    }
}
