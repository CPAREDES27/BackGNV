using Infrastructure.Data.Context;
using Infrastructure.MainModule.Services.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Infrastructure.MainModule.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            //MSSQL
            services.AddDbContext<DBGNVContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("CnnGnvSqlServer"))
            );

            return services;
        }

        public static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<PasswordOptions>(options => configuration.GetSection("PasswordOptions").Bind(options));

            return services;
        }


        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(doc =>
            {
                doc.SwaggerDoc("v1", new OpenApiInfo { Title = "GNV", Version = "v1" });
            
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
                //doc.IncludeXmlComments(xmlPath);
            });

            return services;
        }


    }
}
