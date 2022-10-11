using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Application.Dto.Sentinel
{
   public class ObtenerDatosUsuarioDTO
    {
        public ObtenerDatosUsuarioDTO(string json)
        {
            JObject nombre = JObject.Parse(json);
            JToken token = nombre["Resultado"];


            Documento = (string)token[("Documento")];
            RazonSocial = (string)token[("RazonSocial")];
            FechaNacimiento = (string)token[("FechaNacimiento")];
            CodigoWs = (string)token[("CodigoWS")];
            DireccionFiscal = (string)token[("DireccionFiscal")];
            Calificativo = (string)token[("Calificativo")];
            DeudaTotal = (decimal)token[("DeudaTotal")];

            if( (int)token[("NroBancos")] >6)
            { DeudaMas6Entidades = true; } else { DeudaMas6Entidades = false; }
        }
        public string? Documento { get; set; }
        public string? RazonSocial { get; set; }
        public string? FechaNacimiento { get; set; } 
        public string? Apellidos { get; set; }
        public string? Nombres { get; set; }
        public string? Email { get; set; }
        public string? Celular { get; set; }
        public string Mensaje { get; set; }
        public string CodigoWs { get; set; }
        public string DireccionFiscal { get; set; }
        public string Direccion { get; set; }
        public string Distrito { get; set; }
        public string Provincia { get; set; }
        public string Departamento { get; set; }
        public string Calificativo { get; set; }
        public bool CalNorFlag { get; set; }
        public bool CalCppFlag { get; set; }
        public bool CalDefFlag { get; set; }
        public bool CalDudandPerFlag { get; set; }

        public bool CalSinCalFlag { get; set; }
        public bool DeudaMas6Entidades { get; set; }

        public string ReporteDeudaSBS { get; set; }
        public bool InfoCR { get; set; }

        public decimal? DeudaTotal { get; set; }
       
        public void metodoSepararNombre()
        {
           if( this.CodigoWs =="3")
            {
                this.Apellidos = "";
                this.Nombres = "";
                this.Direccion = "";
                this.Provincia = "";
                this.Departamento = "";
                this.Mensaje = "Documento Inválido (No Existe)";
            }
            else
            {
                string[] nombrecompleto = RazonSocial.Split(" ");
                this.Apellidos = nombrecompleto[0].ToString() + " " + nombrecompleto[1].ToString();
              
                    
                try
                {
                    this.Nombres = nombrecompleto[2].ToString() + " " + nombrecompleto[3].ToString();

                }
                catch (Exception ex)
                {
                    this.Nombres = nombrecompleto[2].ToString();
                }
                    
              

                if (this.DireccionFiscal == "")
                {
                    this.Direccion = "";
                    this.Distrito = "";
                    this.Provincia = "";
                    this.Departamento = "";
                }
                else
                {
                    string[] direccionfiscal = DireccionFiscal.Split(" - ");
                    this.Direccion = direccionfiscal[0].ToString().Trim();
                    this.Distrito = direccionfiscal[1].ToString().Trim();
                    this.Provincia = direccionfiscal[2].ToString().Trim();
                    this.Departamento = direccionfiscal[3].ToString().Trim();
                }
                

                this.Mensaje = "Todo Ok";
            }
            
        }

        public void metodoCalificativo()
        {
            int CalNor, CalCpp, CalDef, CalDud, CalPer, CalSinCalifi;

            if (this.CodigoWs == "3")
            {
                CalNor = 0; CalCpp = 0; CalDef = 0; CalDud = 0; CalPer = 0;
            }
            else
            {
                string[] calificativo = Calificativo.Split("%");

                string calNor = calificativo[0].ToString().Trim();
                string[] Nor = calNor.Split(" ");
                string nCalNor = Nor[1].ToString().Trim();
                if (nCalNor == "") { CalNor = 0; this.CalNorFlag = false; } else { CalNor = Convert.ToInt32(nCalNor); this.CalNorFlag = true; }

                string calCpp = calificativo[1].ToString().Trim();
                string[] Cpp = calCpp.Split(" ");
                string nCalCpp = Cpp[1].ToString().Trim();
                if (nCalCpp == "") { CalCpp = 0; this.CalCppFlag = false; } else { CalCpp = Convert.ToInt32(nCalCpp); this.CalCppFlag = true; }


                string calDef = calificativo[2].ToString().Trim();
                string[] Def = calDef.Split(" ");
                string nCalDef = Def[1].ToString().Trim();
                if (nCalDef == "") { CalDef = 0; this.CalDefFlag = false; } else { CalDef = Convert.ToInt32(nCalDef); this.CalDefFlag = true; }

                string calDud = calificativo[3].ToString().Trim();
                string[] Dud = calDud.Split(" ");
                string nCalDud = Dud[1].ToString().Trim();
                if (nCalDud == "") { CalDud = 0; } else { CalDud = Convert.ToInt32(nCalDud); }


                string calPer = calificativo[4].ToString().Trim();
                string[] Per = calPer.Split(" ");
                string nCalPer = Per[1].ToString().Trim();
                if (nCalPer == "") { CalPer = 0; } else { CalPer = Convert.ToInt32(nCalPer); }

                if (CalDud + CalPer > 0)
                {
                    this.CalDudandPerFlag = true;
                }
                else
                {
                    this.CalDudandPerFlag = false;
                }

                //if (this.CalNorFlag == true) { this.ReporteDeudaSBS = "Normal"; }
                //else if (this.CalCppFlag == true) { this.ReporteDeudaSBS = "Con Problemas Potenciales"; }
                //else if (this.CalDefFlag == true) { this.ReporteDeudaSBS = "Deficiente"; }
                //else if (this.CalDudandPerFlag == true) { this.ReporteDeudaSBS = "Dudoso y Pérdida"; }
                //else { this.ReporteDeudaSBS = "Sin Calificación"; }

                CalSinCalifi = CalNor + CalCpp + CalDef + CalDud + CalPer;

                if ( CalNor> CalCpp || CalNor > CalDef || CalNor>CalDud || CalNor> CalPer) { this.ReporteDeudaSBS = "Normal"; }
                else if (CalCpp > CalNor || CalCpp > CalDef || CalCpp > CalDud || CalCpp > CalPer || CalSinCalifi ==0) { this.ReporteDeudaSBS = "Sin Calificación y Con Problemas Potenciales"; }
                else if (CalDef > CalNor || CalDef > CalCpp || CalDef > CalDud || CalDef > CalPer) { this.ReporteDeudaSBS = "Deficiente"; }
                else if (CalDud > CalNor || CalDud > CalCpp || CalDud > CalDef || CalDud > CalPer ||
                    CalPer > CalNor || CalPer > CalCpp || CalPer > CalDef || CalPer > CalDud) { this.ReporteDeudaSBS = "Dudoso y Pérdida"; }



                    if ( CalSinCalifi == 0){ this.CalSinCalFlag = true; } else { this.CalSinCalFlag = false; }

                if (this.DeudaMas6Entidades == true || this.CalNorFlag == false) { this.InfoCR = true; } else { this.InfoCR = false; }
               
                
            }
        }



    }
}
