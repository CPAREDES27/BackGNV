using Application.Dto.PostAttention;
using Application.Dto.UploadDocuments.PostAttention;
using Application.Services.Interfaces;
using Application.Services.Util.SecurityDirectory;
using AutoMapper;
//using AutoMapper.Configuration;
using Domain.MainModule.Entities.PostAttention;
using Domain.MainModule.Settings;
using Infrastructure.Data.Context;
using Infrastructure.MainModule.Interfaces;
using Microsoft.Data.SqlClient;
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
    public class PostAttentionRepository : IPostAttentionService
    {
        private readonly DBGNVContext context;
        private readonly IConfiguration _configuration;
        private readonly IMapper mapper;
        private readonly PaginationOptions paginationOptions;
        private readonly IMasterRepository masterRepository;

        public PostAttentionRepository(DBGNVContext context, IConfiguration configuration, IMasterRepository masterRepository)
        {
            this.context = context;
            _configuration = configuration;
            this.masterRepository = masterRepository;
        }

        public async Task<TotalPostAttentionEntity> ListPostAttention(ListPostAttentionDTO request)
        {
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("[SP_ListCargaPostAtencion]", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@NumeroPagina", SqlDbType.Int).Value = request.NumeroPagina;
                    sql.Parameters.Add("@NumeroRegistros", SqlDbType.Int).Value = request.NumeroRegistros;
                    sql.Parameters.Add("@NumeroExpediente", SqlDbType.VarChar).Value = request.NumeroExpediente;
                    sql.Parameters.Add("@IdUsuario", SqlDbType.VarChar).Value = request.IdProveedor;
                    sql.CommandTimeout = 0;
                    SqlDataReader lect = sql.ExecuteReader();
                    TotalPostAttentionEntity response = new TotalPostAttentionEntity();




                    var totalRegistros = 0;
                    while (lect.Read())
                    {
                        if (totalRegistros == 0)
                        {
                            totalRegistros = Convert.ToInt32(lect["TotalRegistros"]);
                        }
                        var entidad = new ListPostAttention()
                        {
                            idpostatencion = lect.IsDBNull(lect.GetOrdinal("idpostatencion")) ? default(int) : lect.GetInt32(lect.GetOrdinal("idpostatencion")),
                            NumExpediente = lect.IsDBNull(lect.GetOrdinal("NumExpediente")) ? default(string) : lect.GetString(lect.GetOrdinal("NumExpediente")),
                            NombreCompleto = lect.IsDBNull(lect.GetOrdinal("NombreCompleto")) ? default(string) : lect.GetString(lect.GetOrdinal("NombreCompleto")),
                            NumDocumento = lect.IsDBNull(lect.GetOrdinal("NumDocumento")) ? default(string) : lect.GetString(lect.GetOrdinal("NumDocumento")),
                            NumPlaca = lect.IsDBNull(lect.GetOrdinal("NumPlaca")) ? default(string) : lect.GetString(lect.GetOrdinal("NumPlaca")),
                            Descripcion = lect.IsDBNull(lect.GetOrdinal("Descripcion")) ? default(string) : lect.GetString(lect.GetOrdinal("Descripcion")),
                            observacion = lect.IsDBNull(lect.GetOrdinal("observacion")) ? default(string) : lect.GetString(lect.GetOrdinal("observacion")),
                            Email = lect.IsDBNull(lect.GetOrdinal("Email")) ? default(string) : lect.GetString(lect.GetOrdinal("Email")),
                            idestado = lect.IsDBNull(lect.GetOrdinal("idestado")) ? default(int) : lect.GetInt32(lect.GetOrdinal("idestado")),
                            Estado = lect.IsDBNull(lect.GetOrdinal("Estado")) ? default(string) : lect.GetString(lect.GetOrdinal("Estado")),
                            fecharegistro = lect.IsDBNull(lect.GetOrdinal("fecharegistro")) ? default(DateTime) : lect.GetDateTime(lect.GetOrdinal("fecharegistro")),
                            usuarioregistro = lect.IsDBNull(lect.GetOrdinal("usuarioregistro")) ? default(string) : lect.GetString(lect.GetOrdinal("usuarioregistro")),
                            IdEstadoPreevaluacion = lect.IsDBNull(lect.GetOrdinal("IdEstadoPreevaluacion")) ? default(int) : lect.GetInt32(lect.GetOrdinal("IdEstadoPreevaluacion")),
                            IdEstadoEvalCrediticia = lect.IsDBNull(lect.GetOrdinal("IdEstadoEvalCrediticia")) ? default(int) : lect.GetInt32(lect.GetOrdinal("IdEstadoEvalCrediticia")),
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

        public async Task<bool> UploadAsync(UploadDocumentsPostAttentionDTO uploadDocumentsDto, int idPostAttention)
        {
            try
            {
                var result = await masterRepository.GetCredentialsUrl(DirectoryConst.PublicPostAttentionfile);

                if (result != null)
                {
                    DateTime dateTimeCreate = DateTime.Now;
                    //Se crea la carpeta de un cliente para n archivos

                    var tipoProceso = uploadDocumentsDto.Archivos.Select(x => x.ProcessType).FirstOrDefault();
                    if (tipoProceso == null)
                    {
                        tipoProceso = "PA";
                    }
                    //Actualiza estado cabecera
                    await UpdatePostAtencionAsync(uploadDocumentsDto.IdPostAtencion, uploadDocumentsDto.Observacion, uploadDocumentsDto.IdEstadoPostAtencion, uploadDocumentsDto.IdUsuario, uploadDocumentsDto.FechaDespacho);


                    var fileDirectoryClient = tipoProceso + "_" + uploadDocumentsDto.IdPostAtencion + "_" + $"{DateTime.Now:ddMMyyyy_HHmmssffff}";
                    //Crea la ruta de la carpeta
                    var lastFileName = result.Valor + fileDirectoryClient;
                    //Se crea la carpeta
                    Directory.CreateDirectory(lastFileName);

                    //Recorre la lista de Archivos para la creacion del documento
                    foreach (var _uploadDocumentsDto in uploadDocumentsDto.Archivos)
                    {

                        await using var stream = new FileStream($"{lastFileName}\\{_uploadDocumentsDto.FileName}", FileMode.Create, FileAccess.Write);

                        var fileByte = Convert.FromBase64String(_uploadDocumentsDto.FileBase64.Substring(_uploadDocumentsDto.FileBase64.LastIndexOf(',') + 1));
                        stream.Write(fileByte);
                        //Registro de las rutas de archivos, el proceso y el idSfCliente en la tabla
                        await RegisterFilePathAsync($"{lastFileName}" + @"\" + _uploadDocumentsDto.FileName, _uploadDocumentsDto.ProcessType, idPostAttention, _uploadDocumentsDto.NombreDocumento, _uploadDocumentsDto.IdEstado);

                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<bool> RegisterFilePathAsync(string root, string processType, int idpostatencion, string nombreDocumento, int idEstado)
        {
            bool result = false;
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_Insert_UploadDocument_PostAtencion", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@root", SqlDbType.VarChar).Value = root;
                    sql.Parameters.Add("@processType", SqlDbType.VarChar).Value = processType;
                    sql.Parameters.Add("@idPostAtencion", SqlDbType.Int).Value = idpostatencion;
                    sql.Parameters.Add("@nombreDocumento", SqlDbType.VarChar).Value = nombreDocumento;
                    sql.Parameters.Add("@idEstado", SqlDbType.Int).Value = idEstado;
                    sql.CommandTimeout = 0;
                    SqlDataReader lect = sql.ExecuteReader();
                    lect.Close();
                    connection.Close();
                    connection.Dispose();
                    result = true;
                    return result;
                }
            }
        }

        public async Task<bool> UpdatePostAtencionAsync(int idPostAtencion,string Observciones, int idEstado,int idusuario,DateTime fechadespacho)
        {
            bool result = false;
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_UpdateCargaPostAtencion", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@idPostAtencion", SqlDbType.Int).Value = idPostAtencion;
                    sql.Parameters.Add("@Observacion", SqlDbType.VarChar).Value = Observciones;
                    sql.Parameters.Add("@idEstado", SqlDbType.Int).Value = idEstado;
                    sql.Parameters.Add("@usuarioModifica", SqlDbType.Int).Value = idusuario;
                    sql.Parameters.Add("@FechaDespacho", SqlDbType.DateTime).Value = fechadespacho;
                    sql.CommandTimeout = 0;
                    SqlDataReader lect = sql.ExecuteReader();
                    lect.Close();
                    connection.Close();
                    connection.Dispose();
                    result = true;
                    return result;
                }
            }
        }

        public async Task<ListPostAttention> GetPostAttentionById(int idPostAttention)
        {
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_ListCargaPostAtencionxId", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@IdPostAtencion", SqlDbType.Int).Value = idPostAttention;
                    sql.CommandTimeout = 0;
                    SqlDataReader lect = sql.ExecuteReader();
                    ListPostAttention evclient = null;

                    string usuarioreg;

                    while (lect.Read())
                    {
                        evclient = new ListPostAttention()
                        {
                            
                            idpostatencion = lect.IsDBNull(lect.GetOrdinal("idpostatencion")) ? default(int) : lect.GetInt32(lect.GetOrdinal("idpostatencion")),
                            NumExpediente = lect.IsDBNull(lect.GetOrdinal("NumExpediente")) ? default(string) : lect.GetString(lect.GetOrdinal("NumExpediente")),
                            NombreCompleto = lect.IsDBNull(lect.GetOrdinal("NombreCompleto")) ? default(string) : lect.GetString(lect.GetOrdinal("NombreCompleto")),
                            NumDocumento = lect.IsDBNull(lect.GetOrdinal("NumDocumento")) ? default(string) : lect.GetString(lect.GetOrdinal("NumDocumento")),
                            NumPlaca = lect.IsDBNull(lect.GetOrdinal("NumPlaca")) ? default(string) : lect.GetString(lect.GetOrdinal("NumPlaca")),
                            Descripcion = lect.IsDBNull(lect.GetOrdinal("Descripcion")) ? default(string) : lect.GetString(lect.GetOrdinal("Descripcion")),
                            observacion = lect.IsDBNull(lect.GetOrdinal("observacion")) ? default(string) : lect.GetString(lect.GetOrdinal("observacion")),
                            Email = lect.IsDBNull(lect.GetOrdinal("Email")) ? default(string) : lect.GetString(lect.GetOrdinal("Email")),
                            idestado = lect.IsDBNull(lect.GetOrdinal("idestado")) ? default(int) : lect.GetInt32(lect.GetOrdinal("idestado")),
                            Estado = lect.IsDBNull(lect.GetOrdinal("Estado")) ? default(string) : lect.GetString(lect.GetOrdinal("Estado")),
                            fecharegistro = lect.IsDBNull(lect.GetOrdinal("fecharegistro")) ? default(DateTime) : lect.GetDateTime(lect.GetOrdinal("fecharegistro")),
                            usuarioregistro = lect.IsDBNull(lect.GetOrdinal("usuarioregistro")) ? default(string) : lect.GetString(lect.GetOrdinal("usuarioregistro")),
                            Apellidos = lect.IsDBNull(lect.GetOrdinal("Apellido")) ? default(string) : lect.GetString(lect.GetOrdinal("Apellido")),
                            telefono = lect.IsDBNull(lect.GetOrdinal("TelefonoFijo")) ? default(string) : lect.GetString(lect.GetOrdinal("TelefonoFijo")),
                            celular = lect.IsDBNull(lect.GetOrdinal("Celular")) ? default(string) : lect.GetString(lect.GetOrdinal("Celular")),
                            fechaNacimiento = lect.IsDBNull(lect.GetOrdinal("FechaNacimiento")) ? default(DateTime) : lect.GetDateTime(lect.GetOrdinal("FechaNacimiento")),
                            PrecioProducto= lect.IsDBNull(lect.GetOrdinal("PrecioProducto")) ? default(decimal) : lect.GetDecimal(lect.GetOrdinal("PrecioProducto")),
                            MarcaProducto = lect.IsDBNull(lect.GetOrdinal("MarcaProducto")) ? default(string) : lect.GetString(lect.GetOrdinal("MarcaProducto")),
                            NombreProveedor = lect.IsDBNull(lect.GetOrdinal("NombreProveedor")) ? default(string) : lect.GetString(lect.GetOrdinal("NombreProveedor")),
                            fechaDespacho= lect.IsDBNull(lect.GetOrdinal("FechaDespacho")) ? default(DateTime) : lect.GetDateTime(lect.GetOrdinal("FechaDespacho")),
                            IdDepartamento = lect.IsDBNull(lect.GetOrdinal("IdDepartamento")) ? default(string) : lect.GetString(lect.GetOrdinal("IdDepartamento")),
                            Departamento = lect.IsDBNull(lect.GetOrdinal("Departamento")) ? default(string) : lect.GetString(lect.GetOrdinal("Departamento")),
                            IdProvincia = lect.IsDBNull(lect.GetOrdinal("IdProvinicia")) ? default(string) : lect.GetString(lect.GetOrdinal("IdProvinicia")),
                            Provincia = lect.IsDBNull(lect.GetOrdinal("Provincia")) ? default(string) : lect.GetString(lect.GetOrdinal("Provincia")),
                            IdDistrito = lect.IsDBNull(lect.GetOrdinal("IdDistrito")) ? default(string) : lect.GetString(lect.GetOrdinal("IdDistrito")),
                            Distrito = lect.IsDBNull(lect.GetOrdinal("Distrito")) ? default(string) : lect.GetString(lect.GetOrdinal("Distrito")),
                            IdPreevaluacion = lect.IsDBNull(lect.GetOrdinal("IdPreevaluacion")) ? default(int) : lect.GetInt32(lect.GetOrdinal("IdPreevaluacion")),
                            IdTipoProducto = lect.IsDBNull(lect.GetOrdinal("IdTipoProducto")) ? default(int) : lect.GetInt32(lect.GetOrdinal("IdTipoProducto")),
                            DireccionResidencia = lect.IsDBNull(lect.GetOrdinal("DireccionResidencia")) ? default(string) : lect.GetString(lect.GetOrdinal("DireccionResidencia")),
                        };
                    }

                    lect.Close();
                    connection.Close();
                    connection.Dispose();
                    return evclient;
                }
            }
        }
    }
}
