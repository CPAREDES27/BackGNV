using Application.Services.Interfaces;
using Domain.MainModule.Entities;
using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.MainModule.Repositories
{
    public class WorkshopRepository : IWorkshopService
    {
        private readonly DBGNVContext _context;

        public WorkshopRepository(DBGNVContext context)
        {
            this._context = context;
        }

     
    }
}
