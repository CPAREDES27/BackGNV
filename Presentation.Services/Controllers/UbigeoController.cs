using Application.Dto;
using Application.Manager.Interfaces;
using Application.Services.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Presentation.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UbigeoController : ControllerBase
    {
        private readonly IUbigeoManager ubigeoManager;

        public UbigeoController(IUbigeoManager ubigeoManager)
        {
            this.ubigeoManager = ubigeoManager;
        }

        [HttpGet("ListDepartment")]
        public async Task<IActionResult> ListDepartment()
        { 
            List<DepartmentDTO> resultDepartmentDto = await ubigeoManager.ListAsync();
            if (resultDepartmentDto.Count < 0)
            {
                return BadRequest(new { valid = false, message = Constants.InvalidListDepartment });
            }
            return Ok(resultDepartmentDto);
        }

        [HttpGet("ListProvince")]
        public async Task<IActionResult> ListProvince(string idDepartment)
        {
            List<ProvinceDTO> resultDistrictDto = await ubigeoManager.ListProvinceAsync(idDepartment);
            if (resultDistrictDto.Count < 0)
            {
                return BadRequest(new { valid = false, message = Constants.InvalidListDepartment });
            }
            return Ok(resultDistrictDto);
        }

        [HttpGet("ListDistrict")]
        public async Task<IActionResult> ListDistrict(string idProvince)
        {
            List<DistrictDTO> resultDistrictDto = await ubigeoManager.ListDistrictAsync(idProvince);
            if (resultDistrictDto.Count < 0)
            {
                return BadRequest(new { valid = false, message = Constants.InvalidListDepartment });
            }
            return Ok(resultDistrictDto);
        }
    }
}
