using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainModule.Entities.EvaluacionCrediticia
{
    public class DetallePostAtencionEntity
    {
        public int IdPostAtencion { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string NumDocumento { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string TelefonoFijo { get; set; }
        public string TelefonoMovil { get; set; }
        public string UsuarioEmail { get; set; }

    }
}
