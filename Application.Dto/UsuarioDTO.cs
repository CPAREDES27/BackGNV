using Domain.MainModule.Enum;
using System;

namespace Application.Dto
{
    public class UsuarioDTO
    {
        public int IdUsuario { get; set; }
        public string UsuarioEmail { get; set; }
        public string NomCliente { get; set; }
        public string ApeCliente { get; set; }
        public string RazonSocial { get; set; }
        public string Ruc { get; set; }
        public int RolId { get; set; }
        public DateTime FecRegistro { get; set; }
    }
}
