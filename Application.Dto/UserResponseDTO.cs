using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class UserResponseDTO
    {
		public int IdUsuario { get; set; }
		public int IdTipoUsuario { get; set; }
		public string NombreTipoUsuario { get; set; }
		public int IdPerfil { get; set; }
		public string NombrePerfil { get; set; }
		public string NomCliente { get; set; }
		public string ApeCliente { get; set; }
		public string RazonSocial { get; set; }
		public string NumeroDocumento { get; set; }
		public string CodigoUbigeo { get; set; }
		public DateTime FechaEmision { get; set; }
		public string FechaEmisionString { get; set; }
		public DateTime FechaNacimiento { get; set; }
		public string FechaNacimientoString { get; set; }
		public string EstadoCivil { get; set; }
		public string NombreEstadoCivil { get; set; }
		public int IdPais { get; set; }
		public string NombrePais { get; set; }
		public string TelefonoFijo { get; set; }
		public string TelefonoMovil { get; set; }
		public string Email { get; set; }
		public int? IdTipoCalle { get; set; }
		public string NombreTipoCalle { get; set; }
		public string DireccionResidencia { get; set; }
		public int NumeroIntDpto { get; set; }
		public string ManzanaLote { get; set; }
		public string Referencia { get; set; }
		public string IdDepartamento { get; set; }
		public string NombreDepartamento { get; set; }
		public string IdProvincia { get; set; }
		public string NombreProvincia { get; set; }
		public string IdDistrito { get; set; }
		public string UsuarioEmail { get; set; }
		public string Contrasena { get; set; }
		public string NombreDistrito { get; set; }
		public string Ruc { get; set; }
		public int? RolId { get; set; }
		public bool Activo { get; set; }
		public DateTime FechaRegistro { get; set; }
		public int? UsuarioModifica { get; set; }
		public DateTime? FechaModifica { get; set; }
	}
}
