using Application.Services.Util;
using Domain.MainModule.Entities;
using Infrastructure.Data.Context;
using Infrastructure.MainModule.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Infrastructure.MainModule.Repositories
{
    public class MasterRepository : IMasterRepository
    { 
        private readonly DBGNVContext context;

        public MasterRepository(DBGNVContext context)
        { 
            this.context = context;
        }

        public async Task<MaestroEntity> GetCredentialsUrl(string rootKey)
        { 
            try
            {
                var query = await context.Maestro.FirstOrDefaultAsync(p => p.Clave.Equals(rootKey) && p.Clave.StartsWith(rootKey) && p.Activo == true);
                return query;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
