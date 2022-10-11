using Application.Manager.Implementation;
using Application.Manager.Interfaces;
using Application.Services.Implementation;
using Application.Services.Interfaces;
using Infrastructure.Data.Context;
using Infrastructure.MainModule.Interfaces;
using Infrastructure.MainModule.Repositories;
using Infrastructure.MainModule.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Application.IoC
{
    public static class IocContainer
    { 
        public static IServiceCollection AddDependencyInjectionInterfaces(this IServiceCollection services)
        {
            services.AddScoped<DbContext, DBGNVContext>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddDependencyInjectionsAppService();
            services.AddDependencyInjectionsAppManager();
            services.AddIDependencynjectionsRepository();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IUriService>(provider =>
            {
                var accesor = provider.GetRequiredService<IHttpContextAccessor>();
                var request = accesor.HttpContext.Request;
                var absoluteUri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
                return new UriService(absoluteUri);
            });

            return services;
        }

        public static void AddDependencyInjectionsAppService(this IServiceCollection service)
        { 
            service.AddTransient<ISecurityService, SecurityService>();
            service.AddTransient<IPasswordService, PasswordService>();
            service.AddTransient<IFinancingService, FinancingService>();
            service.AddTransient<IUserService, UserService>();
            service.AddTransient<IFinancingRequestService, FinancingRequestService>();
            service.AddTransient<IWorkshopService, WorkshopService>();
            service.AddTransient<IMaintenanceControlService, MaintenanceControlService>();
            service.AddTransient<IUbigeoService, UbigeoService>();
            service.AddTransient<IProductService, ProductService>();
            service.AddTransient<IEmailService, EmailService>();
            service.AddTransient<IEvaluationClientService, EvaluationClientService>();
            service.AddTransient<IEvaluacionCrediticiaService, EvaluacionCrediticiaService>();
            service.AddTransient<IPostAttentionService, PostAttentionService>();
            service.AddTransient<IReportDashboardService, ReportDashboardService>();
            service.AddTransient<ISentinelService, SentinelService>();

        }

        public static void AddDependencyInjectionsAppManager(this IServiceCollection service)
        {
            service.AddTransient<ISecurityManager, SecurityManager>();
            service.AddTransient<IFinancingManager, FinancingManager>();
            service.AddTransient<IUserManager, UserManager>();
            service.AddTransient<IFinancingRequestManager, FinancingRequestManager>();
            service.AddTransient<IWorkshopManager, WorkshopManager>();
            service.AddTransient<IMaintenanceControlManager, MaintenanceControlManager>();
            service.AddTransient<IUbigeoManager, UbigeoManager>();
            service.AddTransient<IProductManager, ProductManager>();
            service.AddTransient<IEmailManager, EmailManager>();
            service.AddTransient<IEvaluationClientManager, EvaluationClientManager>();
            service.AddTransient<IEvaluacionCrediticiaManager, EvaluacionCrediticiaManager>();
            service.AddTransient<IPostattentionManager, PostAttentionManager>();
            service.AddTransient<IReportDashboardManager, ReportDashboardManager>();
            service.AddTransient<ISentinelManager, SentinelManager>();
        }

        public static void AddIDependencynjectionsRepository(this IServiceCollection service)
        {
            service.AddScoped<ISecurityService, SecurityRepository>();
            service.AddScoped<IRolOptionsRepository, RolOptionsRepository>();
            service.AddScoped<IFinancingService, FinancingRepository>();
            service.AddScoped<IUserService, UserRepository>();
            service.AddScoped<IFinancingRequestService, FinancingRequestRepository>();
            service.AddScoped<IWorkshopService, WorkshopRepository>();
            service.AddScoped<IMasterRepository, MasterRepository>();
            service.AddScoped<IMaintenanceControlService, MaintenanceControlRepository>();
            service.AddScoped<IUbigeoService, UbigeoRepository>();
            service.AddScoped<IProductService, ProductRespository>();
            service.AddScoped<IEvaluationClientService, EvaluationClientRepository>();
            service.AddScoped<IEvaluacionCrediticiaService, EvaluacionCrediticiaRepository>();
            service.AddScoped<IPostAttentionService, PostAttentionRepository>();
            service.AddScoped<IReportDashboardService, ReportDashboardRepository>();
            service.AddScoped<ISentinelService, SentinelRepository>();

        }
    }
}
