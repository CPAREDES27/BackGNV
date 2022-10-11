using Application.Services.Interfaces;
using Domain.MainModule.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services.Implementation
{
    public class UbigeoService : IUbigeoService
    {
        private readonly IUnitOfWork unitOfWork;

        public UbigeoService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<List<UbigeoDepartamentoEntity>> GetListAsync()
        {
            return await unitOfWork.ubigeoRepository.GetListAsync();
        }

        public async Task<List<UbigeoProvinciaEntity>> ListProvinceAsync(string idDepartment)
        {
            return await unitOfWork.ubigeoRepository.ListProvinceAsync(idDepartment);
        }

        public async Task<List<UbigeoDistritoEntity>> ListDistrictAsync(string idDepartment)
        {
            return await unitOfWork.ubigeoRepository.ListDistrictAsync(idDepartment);
        } 
    }
}
