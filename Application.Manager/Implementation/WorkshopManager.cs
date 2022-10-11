using Application.Dto;
using Application.Manager.Interfaces;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.MainModule.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Manager.Implementation
{
    public class WorkshopManager : IWorkshopManager
    {
        private readonly IWorkshopService _workshopService;
        private readonly IMapper mapper;

        public WorkshopManager(
             IWorkshopService workshopService,
             IMapper mapper
            )
        {
            this._workshopService = workshopService; 
            this.mapper = mapper;
        }

     



        //public async Task<List<WorkshopResponseDTO>> GetList()
        //{
        //    List<WorkshopResponseDTO> listFinancingRequest = new List<WorkshopResponseDTO>();

        //    listFinancingRequest = _workshopService.GetList().Result.Select(x => new WorkshopResponseDTO()
        //    {
        //        IdTaller = x.IdTaller,
        //        Nombre = x.Nombre,
        //        Direccion = x.Direccion,
        //        Activo = x.Activo,
        //        FecRegistro = x.FecRegistro,
        //        UsuarioModifica = x.UsuarioModifica,
        //        FechaModifica = x.FechaModifica
        //    }).ToList();

        //    return listFinancingRequest;
        //}
    }
}
