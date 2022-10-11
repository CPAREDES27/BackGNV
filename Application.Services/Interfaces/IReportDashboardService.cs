using Domain.MainModule.Entities.ReportDashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IReportDashboardService
    {
        Task<ListAsesorCabeceraDashboard> GetTotalesAsesorById(int IdAsesor, DateTime FechaInicio, DateTime FechaFin);
        Task<ListAsesorDetalleDashboard> GetListAsesorDetalleDashboard(int IdAsesor, DateTime FechaInicio, DateTime FechaFin);
        Task<ListCabeceraDashboard> GetDashboarGeneral(DateTime FechaInicio, DateTime FechaFin);

        Task<ListAsesorDetalleDashboard> DashboarGeneralDetalle(int IdAsesor, DateTime FechaInicio, DateTime FechaFin);

        Task<ListReporteSAP> GetListaReporteSAP(int IdUsuario, DateTime FechaInicio, DateTime FechaFin);

        Task<ListReportGrafico> GetListaReporteGrafico(int IdUsuario, DateTime FechaInicio, DateTime FechaFin);

        


    }
}
