using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainModule.Entities.ReportDashboard
{
    public class ListReportGraficoDatos
    {
        public string name { get; set; }
        public decimal value { get; set; }

        public IList<ListReportGraficoExtra> extra { get; set; }
    }
}
