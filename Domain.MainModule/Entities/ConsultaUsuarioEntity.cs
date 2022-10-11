using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainModule.Entities
{
    public class ConsultaUsuarioEntity
    {
        public string NomCliente { get; set; }
        public string ApeCliente { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int EstadoCivil { get; set; }
        public string UsuarioEmail { get; set; }
        public string TelefonoMovil { get; set; }
    }
}
