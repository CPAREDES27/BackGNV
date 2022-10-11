using Application.Dto;
using Application.Dto.CustomEntities;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.MainModule;
using Domain.MainModule.Entities;
using Domain.MainModule.Entities.EvaluacionCliente;
using Domain.MainModule.Settings;
using Infrastructure.Data.Context;
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
    public class EvaluationClientRepository : IEvaluationClientService
    {
        private readonly DBGNVContext context;
        private readonly IConfiguration _configuration;
        private readonly IMapper mapper;
        private readonly PaginationOptions paginationOptions;

        public EvaluationClientRepository(DBGNVContext context, IConfiguration configuration)
        {
            this.context = context;
            _configuration = configuration;
        }
       
        public async Task<ListEvaluationClient> GetEvaluationClientById(int idEvalCliente)
        {
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_ListEvaluacionClientexId", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@idEvCliente", SqlDbType.Int).Value = idEvalCliente;
                    sql.CommandTimeout = 0;
                    SqlDataReader lect = sql.ExecuteReader();
                    ListEvaluationClient evclient = null;

                    while (lect.Read())
                    {
                        evclient = new ListEvaluationClient()
                        {
                            //
                            IdEvCliente = lect.IsDBNull(lect.GetOrdinal("IdEvCliente")) ? default(int) : lect.GetInt32(lect.GetOrdinal("idEvCliente")),
                            NumExpediente = lect.IsDBNull(lect.GetOrdinal("NumExpediente")) ? default(string) : lect.GetString(lect.GetOrdinal("NumExpediente")),
                            Nombre = lect.IsDBNull(lect.GetOrdinal("Nombre")) ? default(string) : lect.GetString(lect.GetOrdinal("Nombre")),
                            Apellido = lect.IsDBNull(lect.GetOrdinal("Apellido")) ? default(string) : lect.GetString(lect.GetOrdinal("Apellido")),
                            NumDocumento= lect.IsDBNull(lect.GetOrdinal("NumDocumento")) ? default(string) : lect.GetString(lect.GetOrdinal("NumDocumento")),
                            FechaNacimiento= lect.IsDBNull(lect.GetOrdinal("FechaNacimiento")) ? default(DateTime) : lect.GetDateTime(lect.GetOrdinal("FechaNacimiento")),
                            TelefonoFijo= lect.IsDBNull(lect.GetOrdinal("TelefonoFijo")) ? default(string) : lect.GetString(lect.GetOrdinal("TelefonoFijo")),
                            TelefonoMovil= lect.IsDBNull(lect.GetOrdinal("TelefonoMovil")) ? default(string) : lect.GetString(lect.GetOrdinal("TelefonoMovil")),
                            UsuarioEmail= lect.IsDBNull(lect.GetOrdinal("UsuarioEmail")) ? default(string) : lect.GetString(lect.GetOrdinal("UsuarioEmail")),
                            NumPlaca= lect.IsDBNull(lect.GetOrdinal("NumPlaca")) ? default(string) : lect.GetString(lect.GetOrdinal("NumPlaca")),
                            Estado= lect.IsDBNull(lect.GetOrdinal("Estado")) ? default(string) : lect.GetString(lect.GetOrdinal("Estado")),
                            IdEstado = lect.IsDBNull(lect.GetOrdinal("IdEstado")) ? default(int) : lect.GetInt32(lect.GetOrdinal("IdEstado")),
                            Producto = lect.IsDBNull(lect.GetOrdinal("Descripcion")) ? default(string) : lect.GetString(lect.GetOrdinal("Descripcion")),
                            Precio = lect.IsDBNull(lect.GetOrdinal("Precio")) ? default(decimal) : lect.GetDecimal(lect.GetOrdinal("Precio")),
                            Proveedor = lect.IsDBNull(lect.GetOrdinal("RazonSocial")) ? default(string) : lect.GetString(lect.GetOrdinal("RazonSocial")),
                            IdReglanockout = lect.IsDBNull(lect.GetOrdinal("IdReglanockout")) ? default(int) : lect.GetInt32(lect.GetOrdinal("IdReglanockout")),
                            CorreoProveedor = lect.IsDBNull(lect.GetOrdinal("CorreoProveedor")) ? default(string) : lect.GetString(lect.GetOrdinal("CorreoProveedor")),
                            IdPreevaluacion = lect.IsDBNull(lect.GetOrdinal("IdPreevaluacion")) ? default(int) : lect.GetInt32(lect.GetOrdinal("IdPreevaluacion")),
                            IdCliente = lect.IsDBNull(lect.GetOrdinal("IdCliente")) ? default(int) : lect.GetInt32(lect.GetOrdinal("IdCliente")),

                            Ruc = lect.IsDBNull(lect.GetOrdinal("Ruc")) ? default(string) : lect.GetString(lect.GetOrdinal("Ruc")),
                            RazonSocial = lect.IsDBNull(lect.GetOrdinal("RazonSocial")) ? default(string) : lect.GetString(lect.GetOrdinal("RazonSocial")),
                            IdDepartamento = lect.IsDBNull(lect.GetOrdinal("IdDepartamento")) ? default(string) : lect.GetString(lect.GetOrdinal("IdDepartamento")),
                            Departamento = lect.IsDBNull(lect.GetOrdinal("Departamento")) ? default(string) : lect.GetString(lect.GetOrdinal("Departamento")),
                            IdProvincia = lect.IsDBNull(lect.GetOrdinal("IdProvincia")) ? default(string) : lect.GetString(lect.GetOrdinal("IdProvincia")),
                            Provincia = lect.IsDBNull(lect.GetOrdinal("Provincia")) ? default(string) : lect.GetString(lect.GetOrdinal("Provincia")),
                            IdDistrito = lect.IsDBNull(lect.GetOrdinal("IdDistrito")) ? default(string) : lect.GetString(lect.GetOrdinal("IdDistrito")),
                            Distrito = lect.IsDBNull(lect.GetOrdinal("Distrito")) ? default(string) : lect.GetString(lect.GetOrdinal("Distrito")),
                            DireccionResidencia = lect.IsDBNull(lect.GetOrdinal("DireccionResidencia")) ? default(string) : lect.GetString(lect.GetOrdinal("DireccionResidencia")),
                            ModeloAuto= lect.IsDBNull(lect.GetOrdinal("ModeloAuto")) ? default(string) : lect.GetString(lect.GetOrdinal("ModeloAuto")),
                            MarcaAuto = lect.IsDBNull(lect.GetOrdinal("MarcaAuto")) ? default(string) : lect.GetString(lect.GetOrdinal("MarcaAuto")),
                        };
                    }

                    lect.Close();
                    connection.Close();
                    connection.Dispose();
                    return evclient;
                }
            }
        }

        public async Task<EvaluationClientFileResponseEntity> GetEvaluationClientFileById(int idEvalCliente, string nombreDocumento)
        {
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_ListEvaluacionClienteFilexId", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@idEvCliente", SqlDbType.Int).Value = idEvalCliente;
                    sql.Parameters.Add("@nombreDocumento", SqlDbType.VarChar).Value = nombreDocumento;
                    sql.CommandTimeout = 0;
                    SqlDataReader lect = sql.ExecuteReader();
                    EvaluationClientFileResponseEntity evfileclient = null;

                    while (lect.Read())
                    {
                        evfileclient = new EvaluationClientFileResponseEntity()
                        {
                            idCargaDocumento = Convert.ToInt32(lect["IdCargaDocumentos"]),
                            rutaDocumento = Convert.ToString(lect["RootArchivo"]),
                            nombreDocumento = Convert.ToString(lect["NombreDocumento"]),
                            estadoDocumento = Convert.ToString(lect["Estado"]),

                        };
                    }

                    lect.Close();
                    connection.Close();
                    connection.Dispose();
                    return evfileclient;
                }
            }
        }

        public async Task<EvaluationClientResponseEntity> GetListAsync(EvaluationClientDTO request)
        {
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_ListEvaluacionCliente", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@NumeroPagina", SqlDbType.Int).Value = request.NumeroPagina;
                    sql.Parameters.Add("@NumeroRegistros", SqlDbType.Int).Value = request.NumeroRegistros;
                    sql.Parameters.Add("@NumeroExpediente", SqlDbType.VarChar).Value = request.NumeroExpediente;
                    sql.Parameters.Add("@IdEstado", SqlDbType.VarChar).Value = request.IdEstado;
                    sql.CommandTimeout = 0;
                    SqlDataReader lect = sql.ExecuteReader();
                    EvaluationClientResponseEntity dataSql = new EvaluationClientResponseEntity();
                    //EvaluationClientResponseEntity jsonResult;

                    var totalRegistros = 0;

                    while (lect.Read())
                    {
                        if (totalRegistros == 0)
                        {
                            totalRegistros = Convert.ToInt32(lect["TotalRegistros"]);
                        }

                        var jsonResult = new ListEvaluationClient()
                        {
                            IdEvCliente = lect.IsDBNull(lect.GetOrdinal("idEvCliente")) ? default(int) : lect.GetInt32(lect.GetOrdinal("idEvCliente")),
                            NumExpediente = lect.IsDBNull(lect.GetOrdinal("NumExpediente")) ? default(string) : lect.GetString(lect.GetOrdinal("NumExpediente")),
                            Nombre = lect.IsDBNull(lect.GetOrdinal("Nombres")) ? default(string) : lect.GetString(lect.GetOrdinal("Nombres")),
                            NumDocumento = lect.IsDBNull(lect.GetOrdinal("NumDocumento")) ? default(string) : lect.GetString(lect.GetOrdinal("NumDocumento")),
                            NumPlaca = lect.IsDBNull(lect.GetOrdinal("NumPlaca")) ? default(string) : lect.GetString(lect.GetOrdinal("NumPlaca")),
                            Estado = lect.IsDBNull(lect.GetOrdinal("Estado")) ? default(string) : lect.GetString(lect.GetOrdinal("Estado")),
                            IdEstado = lect.IsDBNull(lect.GetOrdinal("IdEstado")) ? default(int) : lect.GetInt32(lect.GetOrdinal("IdEstado")),
                            IdReglanockout = lect.IsDBNull(lect.GetOrdinal("IdReglanockout")) ? default(int) : lect.GetInt32(lect.GetOrdinal("IdReglanockout")),
                            IdEstadoPreevaluacion = lect.IsDBNull(lect.GetOrdinal("IdEstadoPrevaluacion")) ? default(int) : lect.GetInt32(lect.GetOrdinal("IdEstadoPrevaluacion")),
                        };

                        dataSql.Data.Add(jsonResult);
                    };

                    var totalPaginaInt = 0;
                    var totalPaginaDec = 0;
                    totalPaginaInt = (totalRegistros / request.NumeroRegistros);
                    totalPaginaDec = (totalRegistros % request.NumeroRegistros);
                    if (totalPaginaDec > 0)
                    {
                        totalPaginaInt = totalPaginaInt + 1;
                    }
                    dataSql.Meta.TotalCount = totalRegistros;
                    dataSql.Meta.PageSize = request.NumeroRegistros;
                    dataSql.Meta.CurrentPage = request.NumeroPagina;
                    dataSql.Meta.TotalPages = totalPaginaInt;
                    lect.Close();
                    connection.Close();
                    connection.Dispose();
                    return dataSql;

                }
            }
        }

        public async Task<int> UpdateStatusFileEvaluationClient(EvaluationClientFileRequestDTO fileDTO)
        {
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_UpdateRKCargaDocumentos", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;

                    sql.Parameters.Add("@IdCargaDocumento", SqlDbType.Int).Value = fileDTO.idCargaDocumento;
                    sql.Parameters.Add("@IdEstado", SqlDbType.Int).Value = fileDTO.idEstado;
                    sql.Parameters.Add("@processType", SqlDbType.VarChar).Value = fileDTO.processType;
                    sql.CommandTimeout = 0;

                    int resultado = await sql.ExecuteNonQueryAsync();

                    connection.Close();
                    connection.Dispose();
                    return resultado;
                }
            }
        }
        public async Task<ListEvaluationClient> RegistrarEvaluacionCliente(RegistrarEvaluacionClienteDTO regEvaluacionClienteDto)
        {
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_RegistrarEvaluacionCliente", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;

                    sql.Parameters.Add("@idReglaKnockout", SqlDbType.Int).Value = regEvaluacionClienteDto.IdReglaNockout;
                    sql.Parameters.Add("@numExpediente", SqlDbType.VarChar).Value = regEvaluacionClienteDto.NumExpediente;
                    sql.Parameters.Add("@idEstado", SqlDbType.Int).Value = regEvaluacionClienteDto.IdEstado;
                    sql.Parameters.Add("@usuarioRegistro", SqlDbType.Int).Value = regEvaluacionClienteDto.UsuarioRegistro;
                    sql.Parameters.Add("@Observacion", SqlDbType.NVarChar).Value = regEvaluacionClienteDto.Observacion;
                    
                    sql.CommandTimeout = 0;

                    SqlDataReader lect = sql.ExecuteReader();
                    ListEvaluationClient response = new ListEvaluationClient();

                    while (lect.Read())
                    {
                        response.IdEvCliente = Convert.ToInt32(lect[0]);
                    }

                    lect.Close();
                    connection.Close();
                    connection.Dispose();
                    return response;
                }
            }
        }

    }
}
