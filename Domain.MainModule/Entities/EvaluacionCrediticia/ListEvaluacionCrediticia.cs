using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainModule.Entities.EvaluacionCrediticia
{
    public class ListEvaluacionCrediticia
    {
        public int IdEvCliente { get; set; }
        public string NumeroExpediente { get; set; }
        public string NombresApellidos { get; set; }
        public string NumDocumento { get; set; }
        public string Placa { get; set; }
        public int EstadoFinanciamiento { get; set; }
        public string TipoDocumento { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string TipoProducto { get; set; }
        public int IdEstadoRK { get; set; }

        public decimal precioProducto { get; set; }

    }
}
