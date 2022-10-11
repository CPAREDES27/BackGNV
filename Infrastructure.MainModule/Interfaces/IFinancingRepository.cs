using Domain.MainModule.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.MainModule.Interfaces
{
    public interface IFinancingRepository
    {
        Task<List<PreEvaluationEntity>> GetListPreevaluacion();
    }
}
