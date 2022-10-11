using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Sentinel
{
    public class Ws1EncriptacionSalidaDTO
    {
        public Ws1EncriptacionSalidaDTO(string json)
        {
            JObject nombre = JObject.Parse(json);
            JToken token = nombre;
            UsuarioEncriptado = (string)token[("encriptado")];
            UsuarioCoderror = (string)token[("coderror")];
        }
        public string UsuarioEncriptado { get; set; }
        public string UsuarioCoderror { get; set; }


    }
}
