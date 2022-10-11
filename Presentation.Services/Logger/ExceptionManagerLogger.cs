using Domain.MainModule.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;

namespace Presentation.Services.Logger
{
    public static class ExceptionManagerLogger
    {
        public static void ExceptionManager(
           this IApplicationBuilder app,
           ILogger<Startup> logger)
        {

            app.UseExceptionHandler(err =>
            {
                err.Run(async context =>
                {
                    context.Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        string codigo = Guid.NewGuid().ToString();
                        logger.LogError($"Error inesperado: {codigo} - {contextFeature.Error}");

                        ErrorDetailsEntity ed = new ErrorDetailsEntity
                        {
                            InternalCode = codigo,
                            Message = "Error interno en la aplicacion",
                            StatusCode = context.Response.StatusCode
                        };

                        await context.Response.WriteAsync(ed.ToString());
                    }

                });

            });

        }
    }
}
