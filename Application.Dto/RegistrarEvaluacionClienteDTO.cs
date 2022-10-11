using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class RegistrarEvaluacionClienteDTO
    {
        public int IdReglaNockout { get; set; }
        public string NumExpediente { get; set; }
        public int IdEstado { get; set; }
        public int UsuarioRegistro { get; set; }
        public string Observacion { get; set; }
        
    }
}
