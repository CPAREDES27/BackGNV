using System;
using System.Collections.Generic;

#nullable disable

namespace Infrastucture.BaseData.Context
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public string UsuarioEmail { get; set; }
        public string Contrasena { get; set; }
        public string NomCliente { get; set; }
        public string ApeCliente { get; set; }
        public string RazonSocial { get; set; }
        public string Ruc { get; set; }
        public int? RolId { get; set; }
        public bool? Activo { get; set; }
        public DateTime? FecRegistro { get; set; }
        public DateTime? FechaCaducidad { get; set; }
        public int? IntentosFallidos { get; set; }
    }
}
