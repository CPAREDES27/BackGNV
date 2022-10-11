using Application.Services.Interfaces;
using Domain.MainModule.Entities.ReportDashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implementation
{
    public class ReportDashboardService : IReportDashboardService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReportDashboardService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<ListAsesorDetalleDashboard> DashboarGeneralDetalle(int IdAsesor, DateTime FechaInicio, DateTime FechaFin)
        {
            return await _unitOfWork.reportDashboardRepository.DashboarGeneralDetalle(IdAsesor, FechaInicio, FechaFin);
        }

        public async Task<ListCabeceraDashboard> GetDashboarGeneral(DateTime FechaInicio, DateTime FechaFin)
        {
            return await _unitOfWork.reportDashboardRepository.GetDashboarGeneral(FechaInicio, FechaFin);
        }

        public async Task<ListReportGrafico> GetListaReporteGrafico(int IdUsuario, DateTime FechaInicio, DateTime FechaFin)
        {
            return await _unitOfWork.reportDashboardRepository.GetListaReporteGrafico(IdUsuario, FechaInicio, FechaFin);
        }

        public async Task<ListReporteSAP> GetListaReporteSAP(int IdUsuario, DateTime FechaInicio, DateTime FechaFin)
        {
            return await _unitOfWork.reportDashboardRepository.GetListaReporteSAP(IdUsuario, FechaInicio, FechaFin);
        }

        public async Task<ListAsesorDetalleDashboard> GetListAsesorDetalleDashboard(int IdAsesor, DateTime FechaInicio, DateTime FechaFin)
        {
            return await _unitOfWork.reportDashboardRepository.GetListAsesorDetalleDashboard(IdAsesor, FechaInicio, FechaFin);
        }

        public async Task<ListAsesorCabeceraDashboard> GetTotalesAsesorById(int IdAsesor, DateTime FechaInicio, DateTime FechaFin)
        {
            return await _unitOfWork.reportDashboardRepository.GetTotalesAsesorById(IdAsesor, FechaInicio, FechaFin);
        }
    }
}
