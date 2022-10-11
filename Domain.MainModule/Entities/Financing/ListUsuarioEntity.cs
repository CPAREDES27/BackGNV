using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainModule.Entities.Financing
{
    public class ListUsuarioEntity
    {
        public int IdUsuario { get; set; }
        public string NomCliente { get; set; }
        public string ApeCliente { get; set; }
        public string UsuarioEmail { get; set; }
    }
}
