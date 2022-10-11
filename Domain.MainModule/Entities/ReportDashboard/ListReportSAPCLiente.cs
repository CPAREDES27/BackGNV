using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainModule.Entities.ReportDashboard
{
    public class ListReportSAPCLiente
    {
      public int  Idcliente { get; set; }
      public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string TipoDocumento { get; set; }
        public string NumDocumento { get; set; }
        //public string Ruc { get; set; }
        public string RazonSocial { get; set; }
        public string Email { get; set; }
        public string TelefonoFijo { get; set; }
        public string TelefonoMovil { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string DireccionResidencia { get; set; }
        public int NumeroIntDpto { get; set; }
        public string ManzanaLote { get; set; }
        public string Departamento { get; set; }
        public string Provincia { get; set; }
        public string Distrito { get; set; }
    }
}
