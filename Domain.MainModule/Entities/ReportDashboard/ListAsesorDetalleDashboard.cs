using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainModule.Entities.ReportDashboard
{
    public class ListAsesorDetalleDashboard
    {
        public List<ListDashboardFinanciamientos> listaFinanciamientos { get; set; }
        public List<ListDashboardFinanciamientosAprobados> listaFinanciamientosAprobados { get; set; }
    }
}
