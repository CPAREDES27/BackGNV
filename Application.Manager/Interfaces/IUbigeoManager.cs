using Application.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Manager.Interfaces
{
    public interface IUbigeoManager
    {
        Task<List<DepartmentDTO>> ListAsync();

        Task<List<ProvinceDTO>> ListProvinceAsync(string idDepartment);

        Task<List<DistrictDTO>> ListDistrictAsync(string idProvince); 
    }
}
