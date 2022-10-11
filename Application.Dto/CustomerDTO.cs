namespace Application.Dto
{
    public class CustomerDTO
    {
        public int IdUsuario { get; set; }
        public string NomCliente { get; set; }
        public string ApeCliente { get; set; }
        public string Ruc { get; set; }
        public string RazonSocial { get; set; }
        public string UsuarioEmail { get; set; }
        public string TelefonoFijo { get; set; }
        public string TelefonoMovil { get; set; }
        public int IdTipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Contrasena { get; set; } 
        public int RolId { get; set; }
        public bool TermPoliticasPrivacidad { get; set; }
        public bool TermFinesComerciales { get; set; }
    }
}
