using Application.Services.Implementation;
using System;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        //ISecurityRepository SecurityRepository { get; }
        ISecurityService SecurityRepository { get; }

        IRolOptionsRepository optionsRepository { get; }
       
        IFinancingService financingRepository { get; }
       
        IUserService userRepository { get; }
       
        IFinancingRequestService financingRequestRepository { get; }
        
        IWorkshopService workshopRepository { get; }

        IMaintenanceControlService maintenanceControlServices { get; }

        IUbigeoService ubigeoRepository { get; }

        IProductService productRepository { get; }

        IEvaluationClientService evaluationClientRepository { get; }

        ISentinelService sentinelRepository { get; }

        public void SaveChanges();
       
        Task SaveChangesAsync();
        IEvaluacionCrediticiaService evaluationCrediticiaRepository { get; }
        IPostAttentionService postAttentionRepository { get; }

        IReportDashboardService reportDashboardRepository { get; }

    }
}
