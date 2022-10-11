using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainModule.Entities
{
    public class ListPendienteSolicitud
    {
        public long idsfcliente { get; set; }
        public int idcliente { get; set; }
        public string Nombres { get; set; } 
        public string Apellidos { get; set; }
        public int IdPreevaluacion { get; set; }
        public string Producto { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
