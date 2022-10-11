using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainModule.Entities.ReportDashboard
{
    public class ListCabeceraDashboard
    {
        public int Productos_vendidos { get; set; }
        public int CantidadTotal_Financiamiento { get; set; }
        public decimal Porcentaje_Ventas { get; set; }
        //public int Financiamientos_Aprobados { get; set; }
        public decimal MontoTotal_Financiado { get; set; }


    }
}
