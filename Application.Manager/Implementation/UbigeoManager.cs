using Application.Dto;
using Application.Manager.Interfaces;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.MainModule.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Manager.Implementation
{
    public class UbigeoManager : IUbigeoManager
    {
        private readonly IUbigeoService ubigeoService;
        private readonly IMapper mapper;

        public UbigeoManager(IUbigeoService ubigeoService,
                             IMapper mapper)
        {
            this.ubigeoService = ubigeoService;
            this.mapper = mapper;
        }
        public async Task<List<DepartmentDTO>> ListAsync()
        {
            List<UbigeoDepartamentoEntity> department = await ubigeoService.GetListAsync();
            List<DepartmentDTO> result = mapper.Map<List<DepartmentDTO>>(department);
            return result;
        }

        public async Task<List<ProvinceDTO>> ListProvinceAsync(string idDepartment)
        {
            List<UbigeoProvinciaEntity> provinciaEntities = await ubigeoService.ListProvinceAsync(idDepartment);
            List<ProvinceDTO> provinces = mapper.Map<List<ProvinceDTO>>(provinciaEntities);
            return provinces;
        }

        public async Task<List<DistrictDTO>> ListDistrictAsync(string idProvince)
        {
            List<UbigeoDistritoEntity> distritoEntities = await ubigeoService.ListDistrictAsync(idProvince);
            List<DistrictDTO> districts = mapper.Map<List<DistrictDTO>>(distritoEntities);
            return districts;
        } 
    }
}
