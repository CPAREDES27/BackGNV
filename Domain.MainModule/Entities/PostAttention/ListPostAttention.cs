using System;

namespace Domain.MainModule.Entities.PostAttention
{
    public class ListPostAttention
    {

       public int idpostatencion { get; set; }
       public string NumExpediente { get; set; }
       public string NombreCompleto { get; set; }
        public string Apellidos { get; set; }
       public string NumDocumento { get; set; }
       public string NumPlaca { get; set; }
       public string Descripcion { get; set; }
       public string observacion { get; set; }
       public string Email { get; set; }
       public int idestado { get; set; }
       public string Estado { get; set; }
       public DateTime fecharegistro { get; set; }
       public string usuarioregistro { get; set; }
        public string telefono { get; set; }
        public string celular { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public int IdEstadoPreevaluacion { get; set; }

        public decimal PrecioProducto { get; set; }
        public string MarcaProducto { get; set; }
        public string NombreProveedor { get; set; }

        public DateTime? fechaDespacho { get; set; }
        public string IdDepartamento { get; set; }
        public string Departamento { get; set; }
        public string IdProvincia { get; set; }
        public string Provincia { get; set; }
        public string IdDistrito { get; set; }
        public string Distrito { get; set; }
        public int IdPreevaluacion { get; set; }
        public int IdTipoProducto { get; set; }

        public int IdEstadoEvalCrediticia { get; set; }

        public string DireccionResidencia { get; set; }

    }
}
