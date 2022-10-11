using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainModule.Entities.ReportDashboard
{
    public class ListReportSAPVenta
    {
       public int IdCliente { get; set; }
       public int IdPreevaluacion { get; set; }
        public string Cliente { get; set; }
        public string TipoDocumento { get; set; }
        public string NumDocumento { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string NumPlaca { get; set; }
        public string ProductoFinanciar { get; set; }
        public decimal Precio { get; set; }
        public string ProveedorProducto { get; set; }
        public string RUC { get; set; }
        public string EmailProveedor { get; set; }
        public DateTime? FechaSolicitud { get; set; }
        public DateTime? FechaAprobacion { get; set; }
        public DateTime? FechaEntregaProducto { get; set; }
        public string Observacion { get; set; }
        public int NumeroScore { get; set; }
        public string NumeroPlaca { get; set; }
        public string MarcaAuto { get; set; }
        public string ModeloAuto { get; set; }
        public string FechaFabricacion { get; set; }
        public int MontoFinanciamiento { get; set; }
    }
}
