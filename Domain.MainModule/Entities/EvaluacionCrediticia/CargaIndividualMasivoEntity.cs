using System;

namespace Domain.MainModule.Entities.EvaluacionCrediticia
{
    public class CargaIndividualMasivoEntity
    {
        public int IdPostAtencion { get; set; }
        public string NombreDocumento { get; set; }
        public string NumExpediente { get; set; }
        public DateTime FechaAprobacionServicio { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string NombreCompleto { get; set; }
        public string Estado { get; set; }
        public string CorreoElectronico { get; set; }
        public string NumPlaca { get; set; }
        public DateTime FechaDespacho { get; set; }
        public string DescripcionProducto { get; set; }
        public string RutaArchivo { get; set; }
        public string Observacion { get; set; }
        public string Correlativo { get; set; }
    }
}
