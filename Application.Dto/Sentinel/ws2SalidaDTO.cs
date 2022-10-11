using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Sentinel
{
    public class ws2SalidaDTO
    {
        public ws2SalidaDTO(string json)
        {
            JObject nombre = JObject.Parse(json);
            JToken token = nombre["Resultado"];


            Documento = (string)token[("Documento")];
            RazonSocial = (string)token[("RazonSocial")];
            FechaNacimiento = (string)token[("FechaNacimiento")];
            FechaProceso = (string)token[("FechaProceso")];
            Semaforos = (string)token[("Semaforos")];
            Nota = (string)token[("Nota")];

            NroBancos = (int)token[("NroBancos")];
            var cantbancos = (int)token[("NroBancos")];

            if (cantbancos >= 6)
            {
                CantBancos = true;
            }
            else
            {
                CantBancos = false;
            }



            DeudaTotal = (string)token[("DeudaTotal")];
            VencidoBanco = (string)token[("VencidoBanco")];

            Calificativo = (string)token[("Calificativo")];

            SemaActual = (string)token[("SemaActual")];
            SemaPrevio = (string)token[("SemaPrevio")];
            SemaPeorMejor = (string)token[("SemaPeorMejor")];
            Documento2 = (string)token[("Documento2")];
            EstDomic = (string)token[("EstDomic")];
            CondDomic = (string)token[("CondDomic")];

            DeudaTributaria = (string)token[("DeudaTributaria")];
            DeudaLaboral = (string)token[("DeudaLaboral")];
            DeudaImpaga = (string)token[("DeudaImpaga")];


            DeudaProtestos = (string)token[("DeudaProtestos")];
            DeudaSBS = (string)token[("DeudaSBS")];
            TarCtas = (string)token[("TarCtas")];

            RepNeg = (string)token[("RepNeg")];
            TipoActv = (string)token[("TipoActv")];
            FechIniActv = (string)token[("FechIniActv")];
            DireccionFiscal = (string)token[("DireccionFiscal")];
            CodigoWS = (string)token[("CodigoWS")];


        }
        public string Documento { get; set; }
        public string RazonSocial { get; set; }
        public string FechaNacimiento { get; set; }
        public string FechaProceso { get; set; }
        public string Semaforos { get; set; }
        public string Nota { get; set; }
        public int NroBancos { get; set; }
        public string DeudaTotal { get; set; }
        public string VencidoBanco { get; set; }
        public string Calificativo { get; set; }
        public string SemaActual { get; set; }
        public string SemaPrevio { get; set; }
        public string SemaPeorMejor { get; set; }
        public string Documento2 { get; set; }
        public string EstDomic { get; set; }
        public string CondDomic { get; set; }
        public string DeudaTributaria { get; set; }
        public string DeudaLaboral { get; set; }
        public string DeudaImpaga { get; set; }
        public string DeudaProtestos { get; set; }
        public string DeudaSBS { get; set; }
        public string TarCtas { get; set; }
        public string RepNeg { get; set; }
        public string TipoActv { get; set; }
        public string FechIniActv { get; set; }
        public string DireccionFiscal { get; set; }
        public string CodigoWS { get; set; }
        public string TipoCalf { get; set; }

        public bool CantBancos { get; set; }

        public string Apellidos { get; set; }
        public string Nombres { get; set; }

        public void metodoPorcentaje()
        {
            string[] Calificativo1 = Calificativo.Split("%");

            if (Calificativo1[0].ToString().Contains("100"))
            {
                this.TipoCalf = "NOR";
            }
            if (Calificativo1[1].ToString().Contains("100"))
            {
                this.TipoCalf = "CPP";
            }
            if (Calificativo1[2].ToString().Contains("100"))
            {
                this.TipoCalf = "DEF";
            }
            if (Calificativo1[3].ToString().Contains("100"))
            {
                this.TipoCalf = "DUD";
            }
            if (Calificativo1[4].ToString().Contains("100"))
            {
                this.TipoCalf = "PER";
            }


        }
        public void metodoSepararNombre()
        {
            string[] nombrecompleto = RazonSocial.Split(" ");
            this.Apellidos = nombrecompleto[0].ToString()+ " "+ nombrecompleto[1].ToString();

            this.Nombres = nombrecompleto[2].ToString()+ " "+ nombrecompleto[3].ToString();    
        }

    }
}
