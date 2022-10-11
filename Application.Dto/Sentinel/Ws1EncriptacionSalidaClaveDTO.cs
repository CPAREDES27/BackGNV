using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Sentinel
{
    public class Ws1EncriptacionSalidaClaveDTO
    {
        public Ws1EncriptacionSalidaClaveDTO(string json)
        {
            JObject nombre = JObject.Parse(json);
            JToken token = nombre;
            ClaveEncriptado = (string)token[("encriptado")];
            ClaveCoderror = (string)token[("coderror")];
        }
        public string ClaveEncriptado { get; set; }
        public string ClaveCoderror { get; set; }
    }
}
