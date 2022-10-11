namespace Application.Dto.MaintenanceUser
{
    public class UserPageResponseDTO
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
        //public int TotalPag { get; set; }
    }
}
