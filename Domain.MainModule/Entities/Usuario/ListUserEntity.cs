using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainModule.Entities.Usuario
{
    public class ListUserEntity
    {
        public int IdUsuario { get; set; }
        public string UsuarioEmail { get; set; }
        public string NomCliente { get; set; }
        public string ApeCliente { get; set; }
        public int RolId { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Ruc { get; set; }
        public string RazonSocial { get; set; }
        public string DescRol { get; set; }
        public string TelefonoMovil { get; set; }
        //New
        public bool IdEstado { get; set; }
        public string Estado { get; set; }
    }
}
