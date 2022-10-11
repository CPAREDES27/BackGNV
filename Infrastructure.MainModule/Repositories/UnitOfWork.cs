using Application.Services.Implementation;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.MainModule.Settings;
using Infrastructure.Data.Context;
using Infrastructure.MainModule.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.MainModule.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DBGNVContext context;
        private readonly IOptions<PaginationOptions> _paginationOptions;
        private readonly IRolOptionsRepository _optionsRepository;
        private readonly ISecurityRepository _securityRepository;
        private readonly IFinancingService _financingRepository;
        private readonly IUserService _userRepository;
        private readonly IFinancingRequestService _financingRequestRepository;
        private readonly IWorkshopService _workshopRepository;
        private readonly IConfiguration configuration;
        private readonly IMasterRepository masterRepository;
        private readonly IMaintenanceControlService _maintenanceControlServices;
        private readonly IMapper mapper;
        private readonly IUbigeoService _ubigeoService;
        private readonly IProductService _productService;
        private readonly ISecurityService _securityService;
        private readonly IEvaluationClientService _evaluationClientService;
        private readonly IEvaluacionCrediticiaService _evaluacionCrediticiaService;
        private readonly IPostAttentionService _postAttentionService;
        private readonly IReportDashboardService _reportDashboardService;
        private readonly ISentinelService _sentinelService;
        
       
        public UnitOfWork(DBGNVContext context, 
            IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        public ISecurityService SecurityRepository => _securityService ?? new SecurityRepository(context, configuration);

        public IRolOptionsRepository optionsRepository => _optionsRepository ?? new RolOptionsRepository(context);
         
        public IFinancingService financingRepository => _financingRepository ?? new FinancingRepository(context, _paginationOptions, masterRepository, configuration, mapper);

        public IUserService userRepository => _userRepository ?? new UserRepository(context, configuration, _paginationOptions);

        public IFinancingRequestService financingRequestRepository => _financingRequestRepository ?? new FinancingRequestRepository(context, configuration, masterRepository);

        public IWorkshopService workshopRepository => _workshopRepository ?? new WorkshopRepository(context);

        public IMaintenanceControlService maintenanceControlServices => _maintenanceControlServices ?? new MaintenanceControlRepository(context, configuration);

        public IUbigeoService ubigeoRepository => _ubigeoService ?? new UbigeoRepository(context, configuration);
        public IProductService productRepository => _productService ?? new ProductRespository(context, configuration, masterRepository);

        public IEvaluationClientService evaluationClientRepository => _evaluationClientService ?? new EvaluationClientRepository(context, configuration);
        public IEvaluacionCrediticiaService evaluationCrediticiaRepository => _evaluacionCrediticiaService ?? new EvaluacionCrediticiaRepository(context, configuration, masterRepository, _sentinelService);

        public IPostAttentionService postAttentionRepository => _postAttentionService ?? new PostAttentionRepository(context, configuration, masterRepository);

        public IReportDashboardService reportDashboardRepository => _reportDashboardService ?? new ReportDashboardRepository(context,configuration);

        public ISentinelService sentinelRepository => _sentinelService ?? new SentinelRepository(context, _paginationOptions, masterRepository, configuration, mapper);

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }
         

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

       
    }
}
