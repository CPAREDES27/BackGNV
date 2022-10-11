using Domain.MainModule.Entities.ReportDashboard;
using System;
using System.Threading.Tasks;

namespace Application.Manager.Interfaces
{
    public interface IReportDashboardManager
    {
        Task<ListAsesorCabeceraDashboard> GetTotalesAsesorById(int IdAsesor, DateTime FechaInicio, DateTime FechaFin);
        Task<ListAsesorDetalleDashboard> GetListDetalleAsesorById(int IdAsesor, DateTime FechaInicio, DateTime FechaFin);

        Task<ListCabeceraDashboard> GetDashboarGeneral(DateTime FechaInicio, DateTime FechaFin);

        Task<ListAsesorDetalleDashboard> DashboarGeneralDetalle(int IdAsesor, DateTime FechaInicio, DateTime FechaFin);

        Task<ListReporteSAP> GetListaReporteSAP(int IdUsuario, DateTime FechaInicio, DateTime FechaFin);

        Task<ListReportGrafico> GetListaReporteGrafico(int IdUsuario, DateTime FechaInicio, DateTime FechaFin);

        
    }
}
