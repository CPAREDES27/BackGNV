using Application.Dto;
using Application.Dto.CustomEntities;
using Application.Dto.Download;
using Application.Dto.Financing;
using Application.Dto.RandomQuestions;
using Application.Dto.Sentinel;
using Application.Dto.Survey;
using Application.Dto.UploadDocuments.KnockoutRules;
using Application.Services.Interfaces;
using Application.Services.Util;
using Application.Services.Util.SecurityDirectory;
using AutoMapper;
using Domain.MainModule.Entities;
using Domain.MainModule.Entities.Financing;
using Domain.MainModule.Enum;
using Domain.MainModule.Settings;
using Infrastructure.Data.Context;
using Infrastructure.MainModule.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.MainModule.Repositories
{
    public class SentinelRepository : ISentinelService
    {
        private readonly DBGNVContext context;
        private readonly IMasterRepository masterRepository;
        private readonly IConfiguration configuration;
        private readonly IMapper mapper;
        private readonly PaginationOptions paginationOptions;
        private readonly IConfiguration _configuration;

        public SentinelRepository(DBGNVContext context,
            IOptions<PaginationOptions> paginationOptions,
            IMasterRepository masterRepository, IConfiguration configuration,
            IMapper mapper)
        {
            this.context = context;
            this.masterRepository = masterRepository;
            this.configuration = configuration;
            this.mapper = mapper;
            this.paginationOptions = paginationOptions.Value;
            _configuration = configuration;
        }

        public async Task<Ws1EncriptacionSalidaDTO> ObtenerUsuarioEncriptado(Ws1EncriptacionEntradaDTO request)
        {
            var keysentinel = request.keysentinel;
            var parametro = request.parametro;
            var url = _configuration["Sentinel:Ws1Encriptado"];
            var request2 = (HttpWebRequest)WebRequest.Create(url);
            request2.Method = "POST";
            //string json = $"{{\"Gx_UsuEnc\":\"RD8X17tD2ta240mGL8G0jF==\",\"Gx_PasEnc\":\"BD8526341A0284CE91EA2358B962845C\",\"Gx_Key\":\"BD8526341A0284CE91EA2358B962845C\",\"TipoDoc\":\"D\",\"NroDoc\":\"01380600\"}}";
            string json = $"{{\"keysentinel\":\""+keysentinel + "\",\"parametro\":\""+parametro+"\"}}";
            request2.ContentType = "application/json";
            request2.Accept = "application/json";

            using (var streamwriter = new StreamWriter(request2.GetRequestStream()))
            {
                streamwriter.Write(json);
                streamwriter.Flush();
                streamwriter.Close();
            }
            Ws1EncriptacionSalidaDTO req;
            try
            {
                using (WebResponse response = request2.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            //var resultadoF = JsonSerializer.Deserialize<UsuarioSentinel>(responseBody);
                            req = new Ws1EncriptacionSalidaDTO(responseBody);
                            Console.WriteLine(responseBody);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return req;
        }


        public async Task<Ws1EncriptacionSalidaClaveDTO> ObtenerClaveEncriptado(Ws1EncriptacionEntradaDTO request)
        {
            var keysentinel = request.keysentinel;
            var parametro = request.parametro;
            var url = _configuration["Sentinel:Ws1Encriptado"];
            var request2 = (HttpWebRequest)WebRequest.Create(url);
            request2.Method = "POST";
            //string json = $"{{\"Gx_UsuEnc\":\"RD8X17tD2ta240mGL8G0jF==\",\"Gx_PasEnc\":\"BD8526341A0284CE91EA2358B962845C\",\"Gx_Key\":\"BD8526341A0284CE91EA2358B962845C\",\"TipoDoc\":\"D\",\"NroDoc\":\"01380600\"}}";
            string json = $"{{\"keysentinel\":\"" + keysentinel + "\",\"parametro\":\"" + parametro + "\"}}";
            request2.ContentType = "application/json";
            request2.Accept = "application/json";

            using (var streamwriter = new StreamWriter(request2.GetRequestStream()))
            {
                streamwriter.Write(json);
                streamwriter.Flush();
                streamwriter.Close();
            }
            Ws1EncriptacionSalidaClaveDTO req;
            try
            {
                using (WebResponse response = request2.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            //var resultadoF = JsonSerializer.Deserialize<UsuarioSentinel>(responseBody);
                            req = new Ws1EncriptacionSalidaClaveDTO(responseBody);
                            Console.WriteLine(responseBody);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return req;
        }

        public async Task<ws2SalidaDTO> ObtenerDatosWs2(ws2EntradaDTO request)
        {
            
            var Gx_UsuEnc = _configuration["Sentinel:Gx_UsuEnc"];
            var Gx_PasEnc = _configuration["Sentinel:Gx_PasEnc"];
            var Gx_Key = _configuration["Sentinel:TokenKeyPublico"];
            var TipoDoc = request.TipoDoc;
            var NroDoc = request.NroDoc;

            
            var url = _configuration["Sentinel:Ws2Data"];
            var request2 = (HttpWebRequest)WebRequest.Create(url);
            request2.Method = "POST";
            //string json = $"{{\"Gx_UsuEnc\":\"RD8X17tD2ta240mGL8G0jF==\",\"Gx_PasEnc\":\"BD8526341A0284CE91EA2358B962845C\",\"Gx_Key\":\"BD8526341A0284CE91EA2358B962845C\",\"TipoDoc\":\"D\",\"NroDoc\":\"01380600\"}}";
            string json = $"{{\"Gx_UsuEnc\":\"" + Gx_UsuEnc + "\",\"Gx_PasEnc\":\"" + Gx_PasEnc + "\",\"Gx_Key\":\"" + Gx_Key + "\",\"TipoDoc\":\"" + TipoDoc + "\",\"NroDoc\":\"" + NroDoc + "\"}}";
            request2.ContentType = "application/json";
            request2.Accept = "application/json";

           await using (var streamwriter = new StreamWriter(request2.GetRequestStream()))
            {
                streamwriter.Write(json);
                streamwriter.Flush();
                streamwriter.Close();
            }
            ws2SalidaDTO req;
            try
            {
                using (WebResponse response = request2.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();

                            req = new ws2SalidaDTO(responseBody);
                            Console.WriteLine(responseBody);

                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
            req.metodoPorcentaje();
            req.metodoSepararNombre();
            return req;
        }

        public async Task<ObtenerDatosUsuarioDTO> ObtenerDatosUsuario(ObtenerEntradaSolicitudDTO request)
        {
            var Gx_UsuEnc = _configuration["Sentinel:Gx_UsuEnc"];
            var Gx_PasEnc = _configuration["Sentinel:Gx_PasEnc"];
            var Gx_Key = _configuration["Sentinel:TokenKeyPublico"];
            var TipoDoc = request.tipoDocumento;
            var NroDoc = request.numeroDocumento;


            var url = _configuration["Sentinel:Ws2Data"];
            var request2 = (HttpWebRequest)WebRequest.Create(url);
            request2.Method = "POST";
            //string json = $"{{\"Gx_UsuEnc\":\"RD8X17tD2ta240mGL8G0jF==\",\"Gx_PasEnc\":\"BD8526341A0284CE91EA2358B962845C\",\"Gx_Key\":\"BD8526341A0284CE91EA2358B962845C\",\"TipoDoc\":\"D\",\"NroDoc\":\"01380600\"}}";
            string json = $"{{\"Gx_UsuEnc\":\"" + Gx_UsuEnc + "\",\"Gx_PasEnc\":\"" + Gx_PasEnc + "\",\"Gx_Key\":\"" + Gx_Key + "\",\"TipoDoc\":\"" + TipoDoc + "\",\"NroDoc\":\"" + NroDoc + "\"}}";
            request2.ContentType = "application/json";
            request2.Accept = "application/json";

            await using (var streamwriter = new StreamWriter(request2.GetRequestStream()))
            {
                streamwriter.Write(json);
                streamwriter.Flush();
                streamwriter.Close();
            }
            ObtenerDatosUsuarioDTO req;
            try
            {
                using (WebResponse response = request2.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();

                            req = new ObtenerDatosUsuarioDTO(responseBody);
                            Console.WriteLine(responseBody);

                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            List<UsuarioEntity> Usuario;

            Usuario = await (from usu in context.Usuarios
                             where usu.NumeroDocumento == request.numeroDocumento
                       select new UsuarioEntity
                       {
                           TelefonoMovil = usu.TelefonoMovil,
                           UsuarioEmail = usu.UsuarioEmail,
                           IngresoMensual = usu.IngresoMensual ?? 0
                           
                       }).ToListAsync();

            if (Usuario.Count == 0)
            {
                req.Celular = "";
                req.Email = "";
            }
            else
            {

                req.Celular = Usuario[0].TelefonoMovil;
                req.Email = Usuario[0].UsuarioEmail;
            }
            
            req.metodoSepararNombre();
            req.metodoCalificativo();
            return req;
        }
    }
}
