using Application.Services.Interfaces;
using Domain.MainModule.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services.Implementation
{
    public class WorkshopService : IWorkshopService
    {
        private readonly IUnitOfWork _unitOfWork;

        public WorkshopService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

      
    }
}
