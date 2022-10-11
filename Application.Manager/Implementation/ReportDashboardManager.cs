using Application.Manager.Interfaces;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.MainModule.Entities.ReportDashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Manager.Implementation
{
    public class ReportDashboardManager : IReportDashboardManager
    {
        private readonly IReportDashboardService reportDashboardService;
        private readonly IMapper mapper;

        public ReportDashboardManager(IReportDashboardService reportDashboardService, IMapper mapper)
        {
            this.reportDashboardService = reportDashboardService;
            this.mapper = mapper;
        }

        public async Task<ListAsesorDetalleDashboard> DashboarGeneralDetalle(int IdAsesor, DateTime FechaInicio, DateTime FechaFin)
        {
            return await reportDashboardService.DashboarGeneralDetalle(IdAsesor, FechaInicio, FechaFin);
        }

        public async Task<ListCabeceraDashboard> GetDashboarGeneral(DateTime FechaInicio, DateTime FechaFin)
        {
            return await reportDashboardService.GetDashboarGeneral(FechaInicio, FechaFin);
        }

        public async Task<ListReportGrafico> GetListaReporteGrafico(int IdUsuario, DateTime FechaInicio, DateTime FechaFin)
        {
           return await reportDashboardService.GetListaReporteGrafico(IdUsuario, FechaInicio, FechaFin);
        }

        public async Task<ListReporteSAP> GetListaReporteSAP(int IdUsuario, DateTime FechaInicio, DateTime FechaFin)
        {
            return await reportDashboardService.GetListaReporteSAP(IdUsuario, FechaInicio, FechaFin);
        }

        public async Task<ListAsesorDetalleDashboard> GetListDetalleAsesorById(int IdAsesor, DateTime FechaInicio, DateTime FechaFin)
        {
            return await reportDashboardService.GetListAsesorDetalleDashboard(IdAsesor, FechaInicio, FechaFin);
        }

        public async Task<ListAsesorCabeceraDashboard> GetTotalesAsesorById(int IdAsesor, DateTime FechaInicio, DateTime FechaFin)
        {
            return await reportDashboardService.GetTotalesAsesorById(IdAsesor, FechaInicio, FechaFin);
        }



    }
}
