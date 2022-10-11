using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainModule.Entities.EvaluacionCrediticia
{
    public class ListCargaPostAtencionEntity
    {
        public int IdPostAtencion { get; set; }
        public string NumeroExpediente { get; set; }
        public string NombreCompleto { get; set; }
        public string NumPlaca { get; set; }
        public string NombreProducto { get; set; }
        public int IdEstado { get; set; }

    }
}
