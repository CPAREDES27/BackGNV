using Domain.MainModule.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IUbigeoService
    {
        Task<List<UbigeoDepartamentoEntity>> GetListAsync();

        Task<List<UbigeoProvinciaEntity>> ListProvinceAsync(string idDepartment);

        Task<List<UbigeoDistritoEntity>> ListDistrictAsync(string idProvince);
    }
}
