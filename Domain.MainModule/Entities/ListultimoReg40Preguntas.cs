using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainModule.Entities
{
    public class ListultimoReg40Preguntas
    {
       public int  IdSfCliente { get; set; }
       public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string NumeroDocumento { get; set; }
        public string FechaNacimiento { get; set; }
        public int EstadoCivil { get; set; }
        public string CorreoElectronico { get; set; }
        public string Celular { get; set; }
        public int IdNivelEstudios { get; set; }
        public string Direccion { get; set; }
        public string Distrito { get; set; }
        public string ReferenciaDomicilio { get; set; }
        public string MzLt { get; set; }
        public int NumeroInterior { get; set; }
    }
}
