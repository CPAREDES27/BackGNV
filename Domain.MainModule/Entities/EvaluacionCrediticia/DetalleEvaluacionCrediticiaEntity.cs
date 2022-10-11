using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainModule.Entities.EvaluacionCrediticia
{
    public class DetalleEvaluacionCrediticiaEntity
    {
        public int IdEvCliente { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string NumDocumento { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string TelefonoFijo { get; set; }
        public string TelefonoMovil { get; set; }
        public string UsuarioEmail { get; set; }
        public string NombreProducto { get; set; }
        public string PrecioProducto { get; set; }
        public string NombreProveedor { get; set; }
        public string NombreCompleto { get; set; }
        public string NumeroExpediente { get; set; }
        public string NumPlaca { get; set; }
        public string TipoProducto { get; set; }
        public int IdPreevaluacion { get; set; }
        public int NumeroScrore { get; set; }
        public string Observaciones { get; set; }
        public int IdEstado { get; set; }
        public string NumExpediente { get; set; }
        //new
        public DateTime FechaDespacho { get; set; }
        public int InformacionCR { get; set; }
        public decimal LineaCredito { get; set; }

        public int IngresoMensual { get; set; }

        public string Calificativo { get; set; }
        public bool CalNorFlag { get; set; }
        public bool CalCppFlag { get; set; }
        public bool CalDefFlag { get; set; }
        public bool CalDudandPerFlag { get; set; }
        public bool CalSinCalFlag { get; set; }

        public bool DeudaMas6Entidades { get; set; }
        public string ReporteDeudaSBS { get; set; }
        public bool InfoCR { get; set; }
        public bool DeudasMas6vecesIngreso { get; set; }
    }
}
