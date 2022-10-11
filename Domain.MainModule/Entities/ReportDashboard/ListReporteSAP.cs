using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainModule.Entities.ReportDashboard
{
    public class ListReporteSAP
    {
        public IList<ListReportSAPCLiente> ListCiente { get; set; }
        public IList<ListReportSAPVenta> ListVenta { get; set; }
    }
}
