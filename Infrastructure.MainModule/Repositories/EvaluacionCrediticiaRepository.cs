using Application.Dto.EvaluacionCrediticia;
using Application.Dto.Sentinel;
using Application.Services.Interfaces;
using Application.Services.Util.SecurityDirectory;
using AutoMapper;
using Domain.MainModule.Entities;
using Domain.MainModule.Entities.EvaluacionCrediticia;
using Domain.MainModule.Settings;
using Infrastructure.Data.Context;
using Infrastructure.MainModule.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.MainModule.Repositories
{
    public class EvaluacionCrediticiaRepository : IEvaluacionCrediticiaService
    {
        private readonly DBGNVContext context;
        private readonly IConfiguration _configuration;
        private readonly IMapper mapper;
        private readonly PaginationOptions paginationOptions;
        private readonly IMasterRepository _masterRepository;
        private readonly ISentinelService _sentinelRepository;
       

        public EvaluacionCrediticiaRepository(DBGNVContext context, IConfiguration configuration, IMasterRepository masterRepository, ISentinelService sentinelRepository)
        {
            this.context = context;
            _configuration = configuration;
            this._masterRepository = masterRepository;
            _sentinelRepository = sentinelRepository;
        }

        public async Task<TotalEvaluacionCrediticialEntity> GetEvaluacionCrediticia(EvaluacionCrediticiaDTO request)
        {
            
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("[SP_GetEvaluacionCrediticia]", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@NumeroPagina", SqlDbType.VarChar).Value = request.NumeroPagina;
                    sql.Parameters.Add("@NumeroRegistros", SqlDbType.VarChar).Value = request.NumeroRegistros;
                    sql.Parameters.Add("@NumeroExpediente", SqlDbType.VarChar).Value = request.NumeroExpediente;
                    sql.Parameters.Add("@EstadoFinanciamiento", SqlDbType.VarChar).Value = request.EstadoFinanciamiento;
                    sql.CommandTimeout = 0;
                    SqlDataReader lect = sql.ExecuteReader();
                    TotalEvaluacionCrediticialEntity response = new TotalEvaluacionCrediticialEntity();




                    var totalRegistros = 0;
                    while (lect.Read())
                    {
                        if (totalRegistros == 0)
                        {
                            totalRegistros = Convert.ToInt32(lect["TotalRegistros"]);
                        }
                        var entidad = new ListEvaluacionCrediticia()
                        {
                            IdEvCliente = Convert.ToInt32(lect["IdEvCliente"]),
                            NumeroExpediente = Convert.ToString(lect["NumExpediente"]),
                            NombresApellidos = Convert.ToString(lect["NombreCompleto"]),
                            Placa = Convert.ToString(lect["NumPlaca"]),
                            EstadoFinanciamiento = Convert.ToInt32(lect["IdEstado"]),
                            TipoDocumento = Convert.ToString(lect["TipoDocumento"]),
                            NumDocumento = Convert.ToString(lect["NumDocumento"]),
                            IdEstadoRK = Convert.ToInt32(lect["IdEstadoRK"]),
                            precioProducto = Convert.ToDecimal(lect["Precio"])

                        };
                        response.Data.Add(entidad);
                    };
                    var totalPaginaInt = 0;
                    var totalPaginaDec = 0;
                    totalPaginaInt = (totalRegistros / request.NumeroRegistros);
                    totalPaginaDec = (totalRegistros % request.NumeroRegistros);
                    if (totalPaginaDec > 0)
                    {
                        totalPaginaInt = totalPaginaInt + 1;
                    }
                    response.Meta.TotalCount = totalRegistros;
                    response.Meta.PageSize = request.NumeroRegistros;
                    response.Meta.CurrentPage = request.NumeroPagina;
                    response.Meta.TotalPages = totalPaginaInt;


                    lect.Close();
                    connection.Close();
                    connection.Dispose();
                    return response;

                }
            }
        }

        public string devolverDoc(int? id)
        {

            if (id == 1)
            {
                return "D";
            }
            else if (id == 2) { return "4"; }
            else if (id == 3) { return "5"; }
            else if (id == 4) return "R";
            else { return ""; }
        }
        public async Task<DetalleEvaluacionCrediticiaEntity> GetDetalleEvaluacionCrediticia(int idEvalCliente, string tipoDocumento, string documento)
        {
           
                await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
                {
                    connection.Open();
                    await using (var sql = new SqlCommand("Sp_GetDetalleEvaluacionCrediticia", connection))
                    {
                        sql.CommandType = CommandType.StoredProcedure;
                        sql.Parameters.Add("@idEvaluacionCliente", SqlDbType.Int).Value = idEvalCliente;
                        sql.CommandTimeout = 0;
                        SqlDataReader lect = sql.ExecuteReader();
                        DetalleEvaluacionCrediticiaEntity response = null;


                        var tipodoc = tipoDocumento;
                        var Documento = documento;
                        ObtenerEntradaSolicitudDTO entrada = new ObtenerEntradaSolicitudDTO();

                        entrada.tipoDocumento = tipodoc;
                        entrada.numeroDocumento = Documento;

                        ObtenerDatosUsuarioDTO datos = await _sentinelRepository.ObtenerDatosUsuario(entrada);

                        while (lect.Read())
                        {
                            response = new DetalleEvaluacionCrediticiaEntity()
                            {

                                IdEvCliente = Convert.ToInt32(lect["IdEvCliente"]),
                                Nombres = Convert.ToString(lect["Nombre"]),
                                Apellidos = Convert.ToString(lect["Apellido"]),
                                NumDocumento = Convert.ToString(lect["NumDocumento"]),
                                FechaNacimiento = Convert.ToDateTime(lect["FechaNacimiento"]),
                                TelefonoFijo = Convert.ToString(lect["TelefonoFijo"]),
                                TelefonoMovil = Convert.ToString(lect["TelefonoMovil"]),
                                UsuarioEmail = Convert.ToString(lect["UsuarioEmail"]),
                                NombreProducto = Convert.ToString(lect["NombreProducto"]),
                                PrecioProducto = Convert.ToString(lect["PrecioProducto"]),
                                NombreProveedor = Convert.ToString(lect["NombreProveedor"]),
                                IdPreevaluacion = Convert.ToInt32(lect["IdPreevaluacion"]),
                                NumeroScrore = Convert.ToInt32(lect["NumeroScore"]),
                                Observaciones = Convert.ToString(lect["Observaciones"]),
                                IdEstado = Convert.ToInt32(lect["IdEstado"]),
                                NumExpediente = Convert.ToString(lect["NumExpediente"]),
                                FechaDespacho = Convert.ToDateTime(lect["FechaDespacho"]),
                                InformacionCR = Convert.ToInt32(lect["InformacionCR"]),
                                LineaCredito = Convert.ToDecimal(lect["LineaCredito"]),
                                IngresoMensual = Convert.ToInt32(lect["IngresoMensual"]),
                                Calificativo = datos.Calificativo,
                                CalNorFlag = datos.CalNorFlag,
                                CalCppFlag = datos.CalCppFlag,
                                CalDefFlag = datos.CalDefFlag,
                                CalSinCalFlag = datos.CalSinCalFlag,
                                CalDudandPerFlag = datos.CalDudandPerFlag,
                                DeudaMas6Entidades = datos.DeudaMas6Entidades,
                                ReporteDeudaSBS = datos.ReporteDeudaSBS,
                                InfoCR = datos.InfoCR
                            };

                        }

                    try
                    {
                        if (response == null)
                        {
                            throw new Exception("Error");
                        }
                        else
                        {
                            if (datos.DeudaTotal > response.IngresoMensual * 6)
                            { response.DeudasMas6vecesIngreso = true; }
                            else { response.DeudasMas6vecesIngreso = false; }
                        }
                        
                    }
                    catch(Exception ex)
                    {

                    }
                        

                        lect.Close();
                        connection.Close();
                        connection.Dispose();
                        return response;
                    }
                }
          
           
        }

        public async Task<List<GetDetallesArchivosEntity>> GetDetalleArchivos(int idPreevaluacion)
        {
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_GetDetalleArchivos", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@IdPreevaluacion", SqlDbType.Int).Value = idPreevaluacion;
                    SqlDataReader lect = sql.ExecuteReader();
                    var response = new List<GetDetallesArchivosEntity>();
                    GetDetallesArchivosEntity jsonResult;

                    while (lect.Read())
                    {
                        jsonResult = new GetDetallesArchivosEntity()
                        {
                            IdPreevaluacion = Convert.ToInt32(lect["IdPreevaluacion"]),
                            IdRegla = Convert.ToInt32(lect["IdRegla"]),
                            RootArchivo = Convert.ToString(lect["RootArchivo"]),
                            TipoProcesoDucumento = Convert.ToString(lect["TipoProcesoDucumento"]),
                            NombreDocumento = Convert.ToString(lect["NombreDocumento"]),
                            IdEstado = Convert.ToInt32(lect["IdEstado"]),
                            IdCargaDocumento = Convert.ToInt32(lect["IdCargaDocumentos"])
                        };

                        response.Add(jsonResult);
                    }

                    lect.Close();
                    connection.Close();
                    connection.Dispose();
                    return response;
                }
            }
        }

        public async Task<TotalEvaluacionCrediticialEntity> ListarEvaluacionCrediticia(ListaEvaluacionCrediticiaDTO request)
        {
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("[Sp_ListarEvaluacionCrediticia]", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@NumeroPagina", SqlDbType.VarChar).Value = request.NumeroPagina;
                    sql.Parameters.Add("@NumeroRegistros", SqlDbType.VarChar).Value = request.NumeroRegistros;
                    sql.Parameters.Add("@NumeroExpediente", SqlDbType.VarChar).Value = request.NumeroExpediente;
                    sql.CommandTimeout = 0;
                    SqlDataReader lect = sql.ExecuteReader();
                    TotalEvaluacionCrediticialEntity response = new TotalEvaluacionCrediticialEntity();




                    var totalRegistros = 0;
                    while (lect.Read())
                    {
                        if (totalRegistros == 0)
                        {
                            totalRegistros = Convert.ToInt32(lect["TotalRegistros"]);
                        }
                        var entidad = new ListEvaluacionCrediticia()
                        {
                            NumeroExpediente = Convert.ToString(lect["NumExpediente"]),
                            NombresApellidos = Convert.ToString(lect["NombreCompleto"]),
                            Placa = Convert.ToString(lect["NumPlaca"]),
                            NumDocumento = Convert.ToString(lect["NumDocumento"]),
                            TipoProducto = Convert.ToString(lect["TipoProducto"]),
                            EstadoFinanciamiento = Convert.ToInt32(lect["EstadoFinanciamiento"]),
                            FechaRegistro = Convert.ToDateTime(lect["FechaRegistro"])

                        };
                        response.Data.Add(entidad);
                    };
                    var totalPaginaInt = 0;
                    var totalPaginaDec = 0;
                    totalPaginaInt = (totalRegistros / request.NumeroRegistros);
                    totalPaginaDec = (totalRegistros % request.NumeroRegistros);
                    if (totalPaginaDec > 0)
                    {
                        totalPaginaInt = totalPaginaInt + 1;
                    }
                    response.Meta.TotalCount = totalRegistros;
                    response.Meta.PageSize = request.NumeroRegistros;
                    response.Meta.CurrentPage = request.NumeroPagina;
                    response.Meta.TotalPages = totalPaginaInt;


                    lect.Close();
                    connection.Close();
                    connection.Dispose();
                    return response;

                }
            }
        }

        public async Task<int> RegisterEvaluacionCrediticia(RegisterEvaluacionCrediticiaDTO request)
        {
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_InsertEvaluacionCrediticia", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;

                    sql.Parameters.Add("@idEvCliente", SqlDbType.Int).Value = request.IdEvCliente;
                    sql.Parameters.Add("@entidadSBS", SqlDbType.Int).Value = request.EntidadSBS;
                    sql.Parameters.Add("@valorDeuda", SqlDbType.Int).Value = request.ValorDeuda;
                    sql.Parameters.Add("@reporteSBS", SqlDbType.Int).Value = request.ReporteSBS;
                    sql.Parameters.Add("@idEstado", SqlDbType.Int).Value = request.IdEstado;
                    sql.Parameters.Add("@usuarioRegistro", SqlDbType.Int).Value = request.UsuarioRegistro;
                    sql.Parameters.Add("@observaciones", SqlDbType.VarChar).Value = request.Observaciones;
                    sql.Parameters.Add("@InformacionCR", SqlDbType.Int).Value = request.InformacionCR;
                    sql.Parameters.Add("@LineaCredito", SqlDbType.Int).Value = request.LineaCredito;
                    sql.CommandTimeout = 0;
                    SqlDataReader lect = sql.ExecuteReader();
                    int idEvCrediticia = 0;

                    while (lect.Read())
                    {

                        idEvCrediticia = Convert.ToInt32(lect["IdEvCredicitia"]);


                    };

                    connection.Close();
                    connection.Dispose();
                    return idEvCrediticia;
                }
            }
        }
        public async Task<TotalCargaPostAtencionEntity> ListarPostAtencion(ListaEvaluacionCrediticiaDTO request)
        {
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_ListarPostAtencion", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@NumeroPagina", SqlDbType.Int).Value = request.NumeroPagina;
                    sql.Parameters.Add("@NumeroRegistros", SqlDbType.Int).Value = request.NumeroRegistros;
                    sql.Parameters.Add("@NumeroExpediente", SqlDbType.VarChar).Value = request.NumeroExpediente;
                    sql.CommandTimeout = 0;
                    SqlDataReader lect = sql.ExecuteReader();
                    TotalCargaPostAtencionEntity response = new TotalCargaPostAtencionEntity();




                    var totalRegistros = 0;
                    while (lect.Read())
                    {
                        if (totalRegistros == 0)
                        {
                            totalRegistros = Convert.ToInt32(lect["TotalRegistros"]);
                        }
                        var entidad = new ListCargaPostAtencionEntity()
                        {
                            IdPostAtencion = Convert.ToInt32(lect["IdPostAtencion"]),
                            NumeroExpediente = Convert.ToString(lect["NumeroExpediente"]),
                            NombreCompleto = Convert.ToString(lect["NombreCompleto"]),
                            NumPlaca = Convert.ToString(lect["NumPlaca"]),
                            NombreProducto = Convert.ToString(lect["NombreProducto"]),
                            IdEstado = Convert.ToInt32(lect["IdEstado"]),

                        };
                        response.Data.Add(entidad);
                    };
                    var totalPaginaInt = 0;
                    var totalPaginaDec = 0;
                    totalPaginaInt = (totalRegistros / request.NumeroRegistros);
                    totalPaginaDec = (totalRegistros % request.NumeroRegistros);
                    if (totalPaginaDec > 0)
                    {
                        totalPaginaInt = totalPaginaInt + 1;
                    }
                    response.Meta.TotalCount = totalRegistros;
                    response.Meta.PageSize = request.NumeroRegistros;
                    response.Meta.CurrentPage = request.NumeroPagina;
                    response.Meta.TotalPages = totalPaginaInt;


                    lect.Close();
                    connection.Close();
                    connection.Dispose();
                    return response;

                }
            }
        }

        public async Task<DetallePostAtencionEntity> DetallePostAtencion(int idPostAtencion)
        {
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_DetallePostAtencion", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@idPostAtencion", SqlDbType.Int).Value = idPostAtencion;
                    sql.CommandTimeout = 0;
                    SqlDataReader lect = sql.ExecuteReader();
                    DetallePostAtencionEntity response = null;

                    while (lect.Read())
                    {
                        response = new DetallePostAtencionEntity()
                        {
                            IdPostAtencion = Convert.ToInt32(lect["IdPostAtencion"]),
                            Nombre = Convert.ToString(lect["Nombre"]),
                            Apellidos = Convert.ToString(lect["Apellidos"]),
                            NumDocumento = Convert.ToString(lect["NumDocumento"]),
                            FechaNacimiento = Convert.ToDateTime(lect["FechaNacimiento"]),
                            TelefonoFijo = Convert.ToString(lect["TelefonoFijo"]),
                            TelefonoMovil = Convert.ToString(lect["TelefonoMovil"]),
                            UsuarioEmail = Convert.ToString(lect["UsuarioEmail"]),

                        };
                    }

                    lect.Close();
                    connection.Close();
                    connection.Dispose();
                    return response;
                }
            }
        }

        public async Task<PA_CargaDocumentosEntity> CargaDocumentos_PA(int idPostAtencion, string nombreDocumento)
        {
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_CargaDocumentos_PA", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@idPostAtencion", SqlDbType.Int).Value = idPostAtencion;
                    sql.Parameters.Add("@nombreDocumento", SqlDbType.VarChar).Value = nombreDocumento;
                    sql.CommandTimeout = 0;
                    SqlDataReader lect = sql.ExecuteReader();
                    PA_CargaDocumentosEntity response = null;

                    while (lect.Read())
                    {
                        response = new PA_CargaDocumentosEntity()
                        {
                            IdPaCargaDocumentos = Convert.ToInt32(lect["IdPaCargaDocumentos"]),
                            IdPostAtencion = Convert.ToInt32(lect["IdPostAtencion"]),
                            RootArchivo = Convert.ToString(lect["RootArchivo"]),
                            TipoProcesoDocumento = Convert.ToString(lect["TipoProcesoDocumento"]),
                            NombreDocumento = Convert.ToString(lect["NombreDocumento"]),
                            IdEstado = Convert.ToInt32(lect["IdEstado"])
                        };
                    }

                    lect.Close();
                    connection.Close();
                    connection.Dispose();
                    return response;
                }
            }
        }
        public async Task<int> UpdatePA_CargaDocumentos(UpdateCargaDocumentosPADTO request)
        {
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_UpdatePA_CargaDocumentos", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;

                    sql.Parameters.Add("@idPACargaDocumentos", SqlDbType.Int).Value = request.IdPaCargaDocumentos;
                    sql.Parameters.Add("@idEstado", SqlDbType.Int).Value = request.IdEstado;

                    sql.CommandTimeout = 0;

                    int resultado = await sql.ExecuteNonQueryAsync();

                    connection.Close();
                    connection.Dispose();
                    return resultado;
                }
            }
        }

        public async Task<List<CargaIndividualMasivoEntity>> ObtenerCargaOnBaseIndividual(CargaOnBaseIndividualDTO request)
        {
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_CargaOnBase_Individual", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;

                    sql.Parameters.Add("@idPostAtencion", SqlDbType.Int).Value = request.IdPostAtencion;
                    sql.Parameters.Add("@idEstado", SqlDbType.Int).Value = request.IdEstado;
                    sql.CommandTimeout = 0;
                    SqlDataReader lect = sql.ExecuteReader();
                    List<CargaIndividualMasivoEntity> response = new List<CargaIndividualMasivoEntity>();

                    while (lect.Read())
                    {
                        response.Add(new CargaIndividualMasivoEntity()
                        {
                            IdPostAtencion = Convert.ToInt32(lect["IdPostAtencion"]),
                            NombreDocumento = Convert.ToString(lect["NombreDocumento"]),
                            NumExpediente = Convert.ToString(lect["NumExpediente"]),
                            FechaAprobacionServicio= Convert.ToDateTime(lect["FechaAprobacionServicio"]),
                            TipoDocumento = Convert.ToString(lect["TipoDocumento"]),
                            NumeroDocumento = Convert.ToString(lect["NumeroDocumento"]),
                            NombreCompleto = Convert.ToString(lect["NombreCompleto"]),
                            Estado = Convert.ToString(lect["Estado"]),
                            CorreoElectronico = Convert.ToString(lect["CorreoElectronico"]),
                            NumPlaca = Convert.ToString(lect["NumeroPlaca"]),
                            FechaDespacho = Convert.ToDateTime(lect["FechaDespacho"]),
                            DescripcionProducto = Convert.ToString(lect["Descripcion"]),
                            RutaArchivo = Convert.ToString(lect["RutaArchivo"]),
                            Observacion = Convert.ToString(lect["Observacion"]),
                            Correlativo = Convert.ToString(lect["Correlativo"])

                        });
                    }

                    lect.Close();
                    connection.Close();
                    connection.Dispose();
                    return response;
                }
            }
        }

        public async Task<List<CargaIndividualMasivoEntity>> ObtenerCargaOnBaseMasivo()
        {
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_CargaOnBase_Masivo", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.CommandTimeout = 0;
                    SqlDataReader lect = sql.ExecuteReader();
                    List<CargaIndividualMasivoEntity> response = new List<CargaIndividualMasivoEntity>();

                    while (lect.Read())
                    {
                        response.Add(new CargaIndividualMasivoEntity()
                        {
                            IdPostAtencion = Convert.ToInt32(lect["IdPostAtencion"]),
                            NombreDocumento = Convert.ToString(lect["NombreDocumento"]),
                            NumExpediente = Convert.ToString(lect["NumExpediente"]),
                            NumeroDocumento = Convert.ToString(lect["NumeroDocumento"]),
                            NombreCompleto = Convert.ToString(lect["NombreCompleto"]),
                            //IdEstado = Convert.ToInt32(lect["IdEstado"]),
                            CorreoElectronico = Convert.ToString(lect["CorreoElectronico"]),
                            RutaArchivo = Convert.ToString(lect["RutaArchivo"]),
                            Observacion = Convert.ToString(lect["Observacion"]),
                            Correlativo = Convert.ToString(lect["Correlativo"])
                        });
                    }

                    lect.Close();
                    connection.Close();
                    connection.Dispose();
                    return response;
                }
            }
        }

        public async Task<int> InsertarIndividual(List<CargaIndividualMasivoEntity> listaCargaIndividualMasivo)
        {
            int resultado = 0;
            int correlativo = 0;
            string NumExpediente = null;
            if (listaCargaIndividualMasivo.Count == 0)
            {
                resultado = 1;
                return resultado;
            }

            var resultPathLoadOnBase = await _masterRepository.GetCredentialsUrl(DirectoryConst.PublicPathBaseLoadOnBase);

            //Rutas
            string sourcePath = @"\\SLIMAPP4DEV\Interfaces\qa\Financiamientos_GNV\root_SustentoPostAtencion\PA_27_19082021_1114131548";  //Origen
            string targetPath = @"\\SLIMAPP4DEV\Interfaces\qa\Financiamientos_GNV\OnBaseCarga";   //Destino
            string[] shortcuts1 = {
            "FormatoConformidad.docx","9-titularMultas.docx"};

            if (resultPathLoadOnBase != null)
            {
                foreach (var item in listaCargaIndividualMasivo)
                {
                    //--Se crea la carpeta de un cliente para n archivos
                    var fileDirectoryExpediente = resultPathLoadOnBase.Valor; //+ "\\" + item.NumExpediente;
                    var nombreCorrelativo = item.NumExpediente + '_' + item.Correlativo;
                    //--Se crea la carpeta
                    //Directory.CreateDirectory(fileDirectoryExpediente);

                    if (NumExpediente != item.NumExpediente)
                    {
                        correlativo = 0;
                    }
                    NumExpediente = item.NumExpediente;
                    correlativo++;
                    item.Correlativo = correlativo < 10 ? "0" + correlativo.ToString() : correlativo.ToString();
                    string text = string.Empty;
                    text += "\"" + item.NombreDocumento + "\",";
                    text += "\"" + item.NumExpediente + "\",";
                    text += "\"" + item.FechaAprobacionServicio.ToString("dd/MM/yyyy") + "\",";
                    text += "\"" + item.TipoDocumento + "\",";
                    text += "\"" + item.NumeroDocumento + "\",";
                    text += "\"" + item.NombreCompleto + "\",";
                    text += "\"" + item.Estado + "\",";
                    text += "\"" + item.CorreoElectronico + "\",";
                    text += "\"" + item.NumPlaca + "\",";
                    text += "\"" + item.FechaDespacho.ToString("dd/MM/yyyy") + "\",";
                    text += "\"" + item.DescripcionProducto + "\",";
                    text += "\"" + item.RutaArchivo + "\"";

                    //if (File.Exists(Path.Combine(fileDirectoryExpediente, item.NumExpediente + ".txt")))
                    //{
                    //    File.AppendAllText(Path.Combine(fileDirectoryExpediente, item.NumExpediente + ".txt"), "\n" + text + Environment.NewLine);
                    //}
                    //else
                    //{
                    //    File.WriteAllText(Path.Combine(fileDirectoryExpediente, item.NumExpediente + ".txt"), text);
                    //}

                    string[] valores = item.RutaArchivo.Split("\\");
                    string nombreArchivo = Path.GetFileName(@valores[0] + "\\" + valores[1] + "\\" + item.NumExpediente + "_" + item.Correlativo + ".jpg");

                    //--File.SetAttributes(item.RutaArchivo, File.GetAttributes(item.RutaArchivo) & ~FileAttributes.ReadOnly);

                    //File.Move(item.RutaArchivo, Path.Combine(fileDirectoryExpediente, nombreArchivo), true);


                    //New Tony
                    //Obtiene Nombre de archivo
                    //string path = @"\\SLIMAPP4DEV\Interfaces\qa\Financiamientos_GNV\root_SustentoPostAtencion\PA_27_19082021_1114131548\FormatoConformidad.docx";
                    string path = item.RutaArchivo;
                    string filename = null;
                    filename = Path.GetFileName(path);

                    string[] shortcuts = { filename };

                    for (int i = 0; i < shortcuts.Length; i++)
                    {
                        if (shortcuts[i] != null)
                        {
                            File.Copy(Path.Combine(sourcePath, shortcuts[i]), Path.Combine(targetPath, shortcuts[i]), true);
                            //Console.WriteLine(shortcuts[i] + " was moved to desktop!");
                        }
                        else
                        {
                            //Console.WriteLine("Shortcut " + shortcuts[i] + " Not found!");
                        }
                    }

                    //await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
                    //{
                    //    connection.Open();
                    //    await using (var sql = new SqlCommand("Sp_Insert_CargaOnBase", connection))
                    //    {
                    //        sql.CommandType = CommandType.StoredProcedure;
                    //        sql.Parameters.Add("@idPostAtencion", SqlDbType.Int).Value = item.IdPostAtencion;
                    //        sql.Parameters.Add("@numExpediente", SqlDbType.VarChar).Value = item.NumExpediente;
                    //        sql.Parameters.Add("@rootArchivo", SqlDbType.VarChar).Value = item.RutaArchivo;
                    //        sql.Parameters.Add("@observaciones", SqlDbType.VarChar).Value = item.Observacion;
                    //        sql.Parameters.Add("@idEstado", SqlDbType.Int).Value = item.IdEstado;
                    //        sql.Parameters.Add("@fechaCarga", SqlDbType.DateTime).Value = DateTime.Now;
                    //        sql.Parameters.Add("@idUsuario", SqlDbType.Int).Value = 4;
                    //        sql.CommandTimeout = 0;
                    //        SqlDataReader lect = sql.ExecuteReader();
                    //        lect.Close();
                    //        connection.Close();
                    //        connection.Dispose();
                    //    }
                    //}
                }

                resultado = 1;
            }
            else
            {
                //No Existe Ruta para almacenar Expedientes
                resultado = -1;
            }

            return resultado;
        }

        public async Task<int> InsertarMasivo(List<CargaIndividualMasivoEntity> listaCargaIndividualMasivo)
        {
            int resultado = 0;
            int correlativo = 0;
            string NumExpediente = null;

            if (listaCargaIndividualMasivo.Count == 0)
            {
                resultado = 1;
                return resultado;
            }

            var resultPathLoadOnBase = await _masterRepository.GetCredentialsUrl(DirectoryConst.PublicPathBaseLoadOnBase);

            if (resultPathLoadOnBase != null)
            {
                foreach (var item in listaCargaIndividualMasivo)
                {
                    //Se crea la carpeta de un cliente para n archivos
                    var fileDirectoryExpediente = resultPathLoadOnBase.Valor + "\\" + item.NumExpediente;
                    //Se crea la carpeta
                    Directory.CreateDirectory(fileDirectoryExpediente);
                    if (NumExpediente != item.NumExpediente)
                    {
                        correlativo = 0;
                    }
                    NumExpediente = item.NumExpediente;
                    correlativo++;
                    item.Correlativo = correlativo < 10 ? "0" + correlativo.ToString() : correlativo.ToString();
                    string text = string.Empty;
                    text += "\"" + item.NombreDocumento + "\",";
                    text += "\"" + item.NumExpediente + "\",";
                    text += "\"" + DateTime.Now.ToString("dd/MM/yyyy") + "\",";
                    text += "\"" + item.NumeroDocumento + "\",";
                    text += "\"" + item.NombreCompleto + "\",";
                    text += "\"Completado\",";
                    text += "\"" + item.CorreoElectronico + "\",";
                    text += "\"" + item.RutaArchivo + "\"";

                    if (File.Exists(Path.Combine(fileDirectoryExpediente, item.NumExpediente + ".txt")))
                    {
                        File.AppendAllText(Path.Combine(fileDirectoryExpediente, item.NumExpediente + ".txt"), "\n" + text);
                    }
                    else
                    {
                        File.WriteAllText(Path.Combine(fileDirectoryExpediente, item.NumExpediente + ".txt"), text);
                    }

                    string[] valores = item.RutaArchivo.Split("\\");
                    string nombreArchivo = Path.GetFileName(@valores[0] + "\\" + valores[1] + "\\" + item.NumExpediente + "_" + item.Correlativo + ".jpg");
                    File.Move(item.RutaArchivo, Path.Combine(fileDirectoryExpediente, nombreArchivo), true);

                    await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
                    {
                        connection.Open();
                        await using (var sql = new SqlCommand("Sp_Insert_CargaOnBase", connection))
                        {
                            sql.CommandType = CommandType.StoredProcedure;
                            sql.Parameters.Add("@idPostAtencion", SqlDbType.Int).Value = item.IdPostAtencion;
                            sql.Parameters.Add("@numExpediente", SqlDbType.VarChar).Value = item.NumExpediente;
                            sql.Parameters.Add("@rootArchivo", SqlDbType.VarChar).Value = item.RutaArchivo;
                            sql.Parameters.Add("@observaciones", SqlDbType.VarChar).Value = item.Observacion;
                            //sql.Parameters.Add("@idEstado", SqlDbType.Int).Value = item.IdEstado;
                            sql.Parameters.Add("@fechaCarga", SqlDbType.DateTime).Value = DateTime.Now;
                            sql.Parameters.Add("@idUsuario", SqlDbType.Int).Value = 4;
                            sql.CommandTimeout = 0;
                            SqlDataReader lect = sql.ExecuteReader();
                            lect.Close();
                            connection.Close();
                            connection.Dispose();
                        }
                    }
                }

                resultado = 1;
            }
            else
            {
                //No Existe Ruta para almacenar Expedientes
                resultado = -1;
            }

            return resultado;
        }
        public async Task<ConsultaSolicitudEntity> ConsultaFormatoSolicitud(int idPrevaluacion)
        {
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_ConsultaFormatoSolicitud", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@idPreevaluacion", SqlDbType.Int).Value = idPrevaluacion;

                    sql.CommandTimeout = 0;
                    SqlDataReader lect = sql.ExecuteReader();
                    var resultado = new ConsultaSolicitudEntity();


                    while (lect.Read())
                    {

                        resultado.Resultado = Convert.ToInt32(lect["Resultado"]);
                        resultado.IdSfCliente = Convert.ToInt32(lect["IdSfCliente"]);
                    };

                    lect.Close();
                    connection.Close();
                    connection.Dispose();
                    return resultado;
                }
            }
        }
        public async Task<int> UpdateEstadoPreevaluacion(int idPreevaluacion, int idEstado)
        {
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_UpdateEstadoPreevaluacion", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;

                    sql.Parameters.Add("@idPreevaluacion", SqlDbType.Int).Value = idPreevaluacion;
                    sql.Parameters.Add("@idEstado", SqlDbType.Int).Value = idEstado;

                    sql.CommandTimeout = 0;

                    int resultado = await sql.ExecuteNonQueryAsync();

                    connection.Close();
                    connection.Dispose();
                    return resultado;
                }
            }
        }
    }
}
