using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.MainModule.Entities
{
    public class UsuarioTempEntity
    {
        [Key]
        public int IdUsuario { get; set; }
        public string UsuarioEmail { get; set; }
        public string Contrasena { get; set; }
        public string NomCliente { get; set; }
        public string ApeCliente { get; set; }
        public string Ruc { get; set; }
        public string RazonSocial { get; set; }
        public int IdTipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public int RolId { get; set; }

        public DateTime? FechaNacimiento { get; set; }
        public int? EstadoCivil { get; set; }

        public string TelefonoFijo { get; set; }
        public string TelefonoMovil { get; set; }
        public int? IdTipoCalle { get; set; }
        public string DireccionResidencia { get; set; }
        public int? NumeroIntDpto { get; set; }
        public string ManzanaLote { get; set; }
        public string Referencia { get; set; }
        public string IdDepartamento { get; set; }
        public string IdProvincia { get; set; }
        public string IdDistrito { get; set; }
        public bool? Activo { get; set; }
        public int? UsuarioRegistra { get; set; }
        public DateTime? FecRegistro { get; set; }
        public int? UsuarioModifica { get; set; }
        public DateTime? FechaModifica { get; set; }
        public bool? TermPoliticasPrivacidad { get; set; }
        public bool? TermFinesComerciales { get; set; }
        public string TipoDocumento { get; set; }
        public string DescRol { get; set; }
    }
}
