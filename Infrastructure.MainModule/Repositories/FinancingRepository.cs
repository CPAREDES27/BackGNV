using Application.Dto;
using Application.Dto.CustomEntities;
using Application.Dto.Download;
using Application.Dto.Financing;
using Application.Dto.RandomQuestions;
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
using System.Threading.Tasks;

namespace Infrastructure.MainModule.Repositories
{
    public class FinancingRepository : IFinancingService
    {
        private readonly DBGNVContext context;
        private readonly IMasterRepository masterRepository;
        private readonly IConfiguration configuration;
        private readonly IMapper mapper;
        private readonly PaginationOptions paginationOptions;
        private readonly IConfiguration _configuration;

        public FinancingRepository(DBGNVContext context, 
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

        public async Task<RespuestaRegisterDto> RegisterClientPreevaluation(RegisterClientPreevaluationDTO request)
        {
            List<UsuarioEntity> usuario;
            RespuestaRegisterDto respuesta = new RespuestaRegisterDto();
            try
            {
                usuario = await (from usu in context.Usuarios
                                 where usu.NumeroDocumento == request.NumDocumento
                                 || usu.UsuarioEmail == request.Email
                                 select new UsuarioEntity
                                 {
                                     NumeroDocumento = usu.NumeroDocumento,
                                     UsuarioEmail = usu.UsuarioEmail,
                                     NomCliente = usu.NomCliente,
                                     ApeCliente = usu.ApeCliente
                                 }).ToListAsync();

                
            }catch(Exception ex)
            {
                usuario = null;
            }

            try
            {
                if(usuario.Count==0)
                {
                    try
                    {
                        await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
                        {
                            connection.Open();
                            await using (var sql = new SqlCommand("Sp_RegistrarClientePreevaluacion", connection))
                            {
                                sql.CommandType = CommandType.StoredProcedure;

                                sql.Parameters.Add("@nombre", SqlDbType.VarChar).Value = request.Nombre;
                                sql.Parameters.Add("@apellido", SqlDbType.VarChar).Value = request.Apellido;
                                sql.Parameters.Add("@idTipoDocumento", SqlDbType.Int).Value = request.IdTipoDocumento;
                                sql.Parameters.Add("@numDocumento", SqlDbType.VarChar).Value = request.NumDocumento;
                                sql.Parameters.Add("@numPlaca", SqlDbType.VarChar).Value = request.NumPlaca;
                                sql.Parameters.Add("@email", SqlDbType.VarChar).Value = request.Email;
                                sql.Parameters.Add("@celular", SqlDbType.VarChar).Value = request.Celular;
                                sql.Parameters.Add("@termCondiciones", SqlDbType.Bit).Value = request.TermCondiciones;
                                sql.Parameters.Add("@finComerciales", SqlDbType.Bit).Value = request.FinComerciales;
                                sql.Parameters.Add("@idEstado", SqlDbType.Int).Value = request.IdEstado;
                                sql.Parameters.Add("@nombreAsesorReferido", SqlDbType.VarChar).Value = request.NombreAsesorReferido;
                                sql.Parameters.Add("@idProducto", SqlDbType.Int).Value = request.IdProducto;
                                sql.Parameters.Add("@flagUser", SqlDbType.Bit).Value = request.FlagUser;
                                sql.Parameters.Add("@idAsesor", SqlDbType.Int).Value = request.IdAsesor;
                                sql.Parameters.Add("@fechanacimiento", SqlDbType.VarChar).Value = request.FechaNacimiento;
                                sql.Parameters.Add("@direccionSentinel", SqlDbType.VarChar).Value = request.DireccionSentinel;
                                sql.Parameters.Add("@IdActUsuario", SqlDbType.Int).Value = request.IdActUsuario;
                                sql.Parameters.Add("@Contraseña", SqlDbType.VarChar).Value = request.Contrasena;
                                sql.CommandTimeout = 0;
                                //SqlDataReader lect = sql.ExecuteReader();

                                int resultado = await sql.ExecuteNonQueryAsync();

                                respuesta.Response = Convert.ToString(resultado);
                                respuesta.Mensaje = "Ok";
                                connection.Close();
                                connection.Dispose();
                                return respuesta;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        respuesta.Response = Convert.ToString(ex);
                        return respuesta;
                    }
                }
                else if (usuario[0].NumeroDocumento == request.NumDocumento && usuario[0].UsuarioEmail == request.Email && request.IdActUsuario == 0)
                {

                    try
                    {
                        await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
                        {
                            connection.Open();
                            await using (var sql = new SqlCommand("Sp_RegistrarClientePreevaluacion", connection))
                            {
                                sql.CommandType = CommandType.StoredProcedure;

                                sql.Parameters.Add("@nombre", SqlDbType.VarChar).Value = request.Nombre;
                                sql.Parameters.Add("@apellido", SqlDbType.VarChar).Value = request.Apellido;
                                sql.Parameters.Add("@idTipoDocumento", SqlDbType.Int).Value = request.IdTipoDocumento;
                                sql.Parameters.Add("@numDocumento", SqlDbType.VarChar).Value = request.NumDocumento;
                                sql.Parameters.Add("@numPlaca", SqlDbType.VarChar).Value = request.NumPlaca;
                                sql.Parameters.Add("@email", SqlDbType.VarChar).Value = request.Email;
                                sql.Parameters.Add("@celular", SqlDbType.VarChar).Value = request.Celular;
                                sql.Parameters.Add("@termCondiciones", SqlDbType.Bit).Value = request.TermCondiciones;
                                sql.Parameters.Add("@finComerciales", SqlDbType.Bit).Value = request.FinComerciales;
                                sql.Parameters.Add("@idEstado", SqlDbType.Int).Value = request.IdEstado;
                                sql.Parameters.Add("@nombreAsesorReferido", SqlDbType.VarChar).Value = request.NombreAsesorReferido;
                                sql.Parameters.Add("@idProducto", SqlDbType.Int).Value = request.IdProducto;
                                sql.Parameters.Add("@flagUser", SqlDbType.Bit).Value = request.FlagUser;
                                sql.Parameters.Add("@idAsesor", SqlDbType.Int).Value = request.IdAsesor;
                                sql.Parameters.Add("@fechanacimiento", SqlDbType.VarChar).Value = request.FechaNacimiento;
                                sql.Parameters.Add("@direccionSentinel", SqlDbType.VarChar).Value = request.DireccionSentinel;
                                sql.Parameters.Add("@IdActUsuario", SqlDbType.Int).Value = request.IdActUsuario;
                                sql.Parameters.Add("@Contraseña", SqlDbType.VarChar).Value = request.Contrasena;
                                sql.CommandTimeout = 0;
                                //SqlDataReader lect = sql.ExecuteReader();

                                int resultado = await sql.ExecuteNonQueryAsync();

                                respuesta.Response = Convert.ToString(resultado);
                                respuesta.Mensaje = "Ok";
                                connection.Close();
                                connection.Dispose();
                                return respuesta;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        respuesta.Response = Convert.ToString(ex);
                        return respuesta;
                    }

                }
                else if ((usuario[0].NumeroDocumento == request.NumDocumento || usuario[0].UsuarioEmail == request.Email) && request.IdActUsuario == 1)
                {
                    try
                    {
                        await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
                        {
                            connection.Open();
                            await using (var sql = new SqlCommand("Sp_RegistrarClientePreevaluacion", connection))
                            {
                                sql.CommandType = CommandType.StoredProcedure;

                                sql.Parameters.Add("@nombre", SqlDbType.VarChar).Value = request.Nombre;
                                sql.Parameters.Add("@apellido", SqlDbType.VarChar).Value = request.Apellido;
                                sql.Parameters.Add("@idTipoDocumento", SqlDbType.Int).Value = request.IdTipoDocumento;
                                sql.Parameters.Add("@numDocumento", SqlDbType.VarChar).Value = request.NumDocumento;
                                sql.Parameters.Add("@numPlaca", SqlDbType.VarChar).Value = request.NumPlaca;
                                sql.Parameters.Add("@email", SqlDbType.VarChar).Value = request.Email;
                                sql.Parameters.Add("@celular", SqlDbType.VarChar).Value = request.Celular;
                                sql.Parameters.Add("@termCondiciones", SqlDbType.Bit).Value = request.TermCondiciones;
                                sql.Parameters.Add("@finComerciales", SqlDbType.Bit).Value = request.FinComerciales;
                                sql.Parameters.Add("@idEstado", SqlDbType.Int).Value = request.IdEstado;
                                sql.Parameters.Add("@nombreAsesorReferido", SqlDbType.VarChar).Value = request.NombreAsesorReferido;
                                sql.Parameters.Add("@idProducto", SqlDbType.Int).Value = request.IdProducto;
                                sql.Parameters.Add("@flagUser", SqlDbType.Bit).Value = request.FlagUser;
                                sql.Parameters.Add("@idAsesor", SqlDbType.Int).Value = request.IdAsesor;
                                sql.Parameters.Add("@fechanacimiento", SqlDbType.VarChar).Value = request.FechaNacimiento;
                                sql.Parameters.Add("@direccionSentinel", SqlDbType.VarChar).Value = request.DireccionSentinel;
                                sql.Parameters.Add("@IdActUsuario", SqlDbType.Int).Value = request.IdActUsuario;
                                sql.Parameters.Add("@Contraseña", SqlDbType.VarChar).Value = request.Contrasena;
                                sql.CommandTimeout = 0;
                                //SqlDataReader lect = sql.ExecuteReader();

                                int resultado = await sql.ExecuteNonQueryAsync();

                                respuesta.Response = Convert.ToString(resultado);
                                respuesta.Mensaje = "Ok";
                                connection.Close();
                                connection.Dispose();
                                return respuesta;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        respuesta.Response = Convert.ToString(ex);
                        return respuesta;
                    }

                }
                else if (usuario[0].NumeroDocumento != request.NumDocumento)
                {
                    // var correo = usuario[0].UsuarioEmail;

                    respuesta.Correo = usuario[0].UsuarioEmail;
                    respuesta.NumeroDocumento = usuario[0].NumeroDocumento;
                    respuesta.Mensaje = "Documento";

                    return respuesta;

                }
                else if (usuario[0].UsuarioEmail != request.Email)
                {
                    // var correo = usuario[0].UsuarioEmail;

                    respuesta.Correo = usuario[0].UsuarioEmail;
                    respuesta.NumeroDocumento = usuario[0].NumeroDocumento;
                    respuesta.Mensaje = "Correo";

                    return respuesta;

                }
                else
                {
                    return respuesta;
                }
            }
            catch(Exception ex)
            {
                return respuesta;
            }
            


        }

        public async Task<PreEvaluationEntity> AddPreevaluation(PreEvaluationEntity preevaluacionEntity)
        {
            await context.Preevaluaciones.AddAsync(preevaluacionEntity);
            context.SaveChanges();
            return preevaluacionEntity;
        }

        public async Task<List<PendingPrevaluationDTO>> GetListPreevaluacionKnockout(int id)
        {
            //return await context.Preevaluaciones.FirstOrDefaultAsync(data => data.IdPreevaluacion == id);
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_ListPreevaluacionesxId", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@idPreevaluacion", SqlDbType.Int).Value = id;
                    sql.CommandTimeout = 0;
                    SqlDataReader lect = sql.ExecuteReader();

                    List<PendingPrevaluationDTO> dataSql = new List<PendingPrevaluationDTO>();

                    PendingPrevaluationDTO preevaluation = null;

                    while (lect.Read())
                    {
                        preevaluation = new PendingPrevaluationDTO()
                        {

                            IdPreevaluacion = Convert.ToInt32(lect["IdPreevaluacion"]),
                            Apellido = Convert.ToString(lect["Apellido"]),
                            Nombre = Convert.ToString(lect["Nombre"]),
                            NumDocumento = Convert.ToString(lect["NumDocumento"]),
                            NumPlaca = Convert.ToString(lect["NumPlaca"]),
                            Celular = Convert.ToString(lect["Celular"]),
                            Email = Convert.ToString(lect["Email"]),
                            NombreAsesorReferido = Convert.ToString(lect["NombreAsesorReferido"]),
                            Producto = Convert.ToString(lect["Producto"]),
                            Precio = Convert.ToDecimal(lect["Precio"]),
                            Proveedor = Convert.ToString(lect["Proveedor"]),
                            IdTipoDocumento = Convert.ToInt32(lect["IdTipoDocumento"]),
                            CorreoProveedor = Convert.ToString(lect["CorreoProveedor"]),
                            IdUsuario = lect.IsDBNull(lect.GetOrdinal("IdUsuario")) ? default(int) : lect.GetInt32(lect.GetOrdinal("IdUsuario")),
                            IdProducto = lect.IsDBNull(lect.GetOrdinal("IdProducto")) ? default(int) : lect.GetInt32(lect.GetOrdinal("IdProducto")),
                            EmailAsesor = lect.IsDBNull(lect.GetOrdinal("EmailAsesor")) ? default(string) : lect.GetString(lect.GetOrdinal("EmailAsesor")),
                            IdEstadoPreevaluacion = lect.IsDBNull(lect.GetOrdinal("IdEstado")) ? default(int) : lect.GetInt32(lect.GetOrdinal("IdEstado")),
                            IdTipoProducto = lect.IsDBNull(lect.GetOrdinal("IdTipoProducto")) ? default(int) : lect.GetInt32(lect.GetOrdinal("IdTipoProducto")),
                        };
                        dataSql.Add(preevaluation);
                    }

                    lect.Close();
                    connection.Close();
                    connection.Dispose();
                    return dataSql;
                }
            }

        }
        public async Task<int> RegisterReglasNockout(RegisterReglasNockoutDTO request)
        {
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_RegisterReglaNockout", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;

                    string fechavence1 = "";
                    string fechavence2 = "";
                    fechavence1 = request.FechaVencimientoRevisioAnual.ToString();
                    fechavence2 = request.FechaVencimientoCilindro.ToString();

                    sql.Parameters.Add("@idPreevaluacion", SqlDbType.Int).Value = request.IdPreevaluacion;
                    if (fechavence1 == "1/01/0001 00:00:00" || request.FechaVencimientoRevisioAnual == null)
                    {
                        sql.Parameters.Add("@fechaVencimientoRevisionAnual", SqlDbType.DateTime).Value = DBNull.Value;
                    }else
                    {
                        sql.Parameters.Add("@fechaVencimientoRevisionAnual", SqlDbType.DateTime).Value = request.FechaVencimientoRevisioAnual;
                    }
                    if (fechavence2 == "1/01/0001 00:00:00" || request.FechaVencimientoCilindro == null)
                    {
                        sql.Parameters.Add("@fechaVencimientoCilindro", SqlDbType.DateTime).Value = DBNull.Value;
                    }
                    else
                    {
                        sql.Parameters.Add("@fechaVencimientoCilindro", SqlDbType.DateTime).Value = request.FechaVencimientoCilindro;
                    }

                    if (request.IndicadorCreditoActivo == null)
                    {
                        sql.Parameters.Add("@indicadorCreditoActivo", SqlDbType.Bit).Value = DBNull.Value;
                    }
                    else
                    {
                        sql.Parameters.Add("@indicadorCreditoActivo", SqlDbType.Bit).Value = request.IndicadorCreditoActivo;
                    }

                    if (request.IndicadorParaConsumir == null)
                    {
                        sql.Parameters.Add("@indicadorParaConsumir", SqlDbType.Bit).Value = DBNull.Value;
                    }
                    else
                    {
                        sql.Parameters.Add("@indicadorParaConsumir", SqlDbType.Bit).Value = request.IndicadorParaConsumir;
                    }

                    if (request.IndicadorAntiguedadMenos10Anios == null)
                    {
                        sql.Parameters.Add("@indicadorAntiguedadMenos10Anios", SqlDbType.Bit).Value = DBNull.Value;
                    }
                    else
                    {
                        sql.Parameters.Add("@indicadorAntiguedadMenos10Anios", SqlDbType.Bit).Value = request.IndicadorAntiguedadMenos10Anios;
                    }

                    if (request.IndicadorTitular20A65Anios == null)
                    {
                        sql.Parameters.Add("@indicadorTitular20A65Anios", SqlDbType.Bit).Value = DBNull.Value;
                    }
                    else
                    {
                        sql.Parameters.Add("@indicadorTitular20A65Anios", SqlDbType.Bit).Value = request.IndicadorTitular20A65Anios;
                    }

                    if (request.IndicadorDniRegistradoEnReniec == null)
                    {
                        sql.Parameters.Add("@indicadorDniRegistradoEnReniec", SqlDbType.Bit).Value = DBNull.Value;
                    }
                    else
                    {
                        sql.Parameters.Add("@indicadorDniRegistradoEnReniec", SqlDbType.Bit).Value = request.IndicadorDniRegistradoEnReniec;
                    }

                    if (request.IndicadorDniTitularContrato == null)
                    {
                        sql.Parameters.Add("@indicadorDniTitularContrato", SqlDbType.Bit).Value = DBNull.Value;
                    }
                    else
                    {
                        sql.Parameters.Add("@indicadorDniTitularContrato", SqlDbType.Bit).Value = request.IndicadorDniTitularContrato;
                    }

                    if (request.IndicadorLicenciaConducirVigente == null)
                    {
                        sql.Parameters.Add("@indicadorLicenciaConducirVigente", SqlDbType.Bit).Value = DBNull.Value;
                    }
                    else
                    {
                        sql.Parameters.Add("@indicadorLicenciaConducirVigente", SqlDbType.Bit).Value = request.IndicadorLicenciaConducirVigente;
                    }

                    if (request.IndicadorTitularPropietarioVehiculo == null)
                    {
                        sql.Parameters.Add("@indicadorTitularPropietarioVehiculo", SqlDbType.Bit).Value = DBNull.Value;
                    }
                    else
                    {
                        sql.Parameters.Add("@indicadorTitularPropietarioVehiculo", SqlDbType.Bit).Value = request.IndicadorTitularPropietarioVehiculo;
                    }

                    if (request.IndicadorSoatVigente == null)
                    {
                        sql.Parameters.Add("@indicadorSoatVigente", SqlDbType.Bit).Value = DBNull.Value;
                    }
                    else
                    {
                        sql.Parameters.Add("@indicadorSoatVigente", SqlDbType.Bit).Value = request.IndicadorSoatVigente;
                    }

                    if (request.IndicadorVehiculoNoMultasPendientePago == null)
                    {
                        sql.Parameters.Add("@indicadorVehiculoNoMultasPendientePago", SqlDbType.Bit).Value = DBNull.Value;
                    }
                    else
                    {
                        sql.Parameters.Add("@indicadorVehiculoNoMultasPendientePago", SqlDbType.Bit).Value = request.IndicadorVehiculoNoMultasPendientePago;
                    }

                    if (request.IndicadorTitularNoMultasPendientePago == null)
                    {
                        sql.Parameters.Add("@indicadorTitularNoMultasPendientePago", SqlDbType.Bit).Value = DBNull.Value;
                    }
                    else
                    {
                        sql.Parameters.Add("@indicadorTitularNoMultasPendientePago", SqlDbType.Bit).Value = request.IndicadorTitularNoMultasPendientePago;
                    }

                    if (request.IndicadorVehiculoNoOrdenCaptura == null)
                    {
                        sql.Parameters.Add("@indicadorVehiculoNoOrdenCaptura", SqlDbType.Bit).Value = DBNull.Value;
                    }
                    else
                    {
                        sql.Parameters.Add("@indicadorVehiculoNoOrdenCaptura", SqlDbType.Bit).Value = request.IndicadorVehiculoNoOrdenCaptura;
                    }

                    if (request.IndicadorEstadoPreevaluacion == null)
                    {
                        sql.Parameters.Add("@indicadorEstadoPreevaluacion", SqlDbType.Bit).Value = DBNull.Value;
                    }
                    else
                    {
                        sql.Parameters.Add("@indicadorEstadoPreevaluacion", SqlDbType.Bit).Value = request.IndicadorEstadoPreevaluacion;
                    }
                   
                    sql.Parameters.Add("@idEstadoPreevaluacion", SqlDbType.Int).Value = request.IdEstadoPrevaluacion;

                    if (request.FechaVencimientoSOAT == null)
                    {
                        sql.Parameters.Add("@FechaVenceSoat", SqlDbType.DateTime).Value = DBNull.Value;
                    }
                    else
                    {
                        sql.Parameters.Add("@FechaVenceSoat", SqlDbType.DateTime).Value = request.FechaVencimientoSOAT;
                    }
                    if (request.IndicadorVehiculoFuncionaGNV == null)
                    {
                        sql.Parameters.Add("@IndicadorVehiculoFuncionaGNV", SqlDbType.Bit).Value = DBNull.Value;
                    }
                    else
                    {
                        sql.Parameters.Add("@IndicadorVehiculoFuncionaGNV", SqlDbType.Bit).Value = request.IndicadorVehiculoFuncionaGNV;
                    }

                    sql.Parameters.Add("@UsuarioRegistro", SqlDbType.Int).Value = request.IdUsuarioRegistro;

                    sql.CommandTimeout = 0;
                    SqlDataReader lect = sql.ExecuteReader();
                    int idReglaNockout = 0;

                    while (lect.Read())
                    {

                        idReglaNockout = Convert.ToInt32(lect["IdReglanockout"]);


                    };

                    connection.Close();
                    connection.Dispose();
                    return idReglaNockout;
                }
            }
        }
        public async Task<RegistroReglasKnockoutEntity> AddReglaKnockout(RegistroReglasKnockoutEntity reglaKnockoutEntity)
        {
            await context.ReglaKnockout.AddAsync(reglaKnockoutEntity);
            context.SaveChanges();
            return reglaKnockoutEntity; 
        }



        public async Task<TotalListPreevaluationEntity> GetListPreevaluation(FilterPreevaluationDTO request)
        {
            await using (var connection = new SqlConnection(configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("[Sp_GetListPreevaluation]", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@idPreevaluacion", SqlDbType.Int).Value = request.IdPreevaluacion;
                    sql.Parameters.Add("@idTipoDocumento", SqlDbType.Int).Value = request.IdTipoDocumento;
                    sql.Parameters.Add("@nombre", SqlDbType.VarChar).Value = request.Nombre;
                    sql.Parameters.Add("@apellido", SqlDbType.VarChar).Value = request.Apellido;
                    sql.Parameters.Add("@numDocumento", SqlDbType.VarChar).Value = request.NumDocumento;
                    sql.Parameters.Add("@numPlaca", SqlDbType.VarChar).Value = request.NumPlaca;
                    sql.Parameters.Add("@idEstado", SqlDbType.Int).Value = request.IdEstado;
                    sql.Parameters.Add("@NumeroPagina", SqlDbType.Int).Value = request.NumeroPagina;
                    sql.Parameters.Add("@NumeroRegistros", SqlDbType.Int).Value = request.NumeroRegistros;
                    sql.Parameters.Add("@idAsesor", SqlDbType.Int).Value = request.IdAsesor;
                    sql.CommandTimeout = 0;
                    SqlDataReader lect = sql.ExecuteReader();
                    TotalListPreevaluationEntity response = new TotalListPreevaluationEntity();




                    var totalRegistros = 0;
                    while (lect.Read())
                    {
                        if (totalRegistros == 0)
                        {
                            totalRegistros = Convert.ToInt32(lect["TotalRegistros"]);
                        }
                        var entidad = new ListPreevaluationEntity()
                        {
                            IdPreevaluacion = Convert.ToInt32(lect["IdPreevaluacion"]),
                            Apellido = Convert.ToString(lect["Apellido"]),
                            Nombre = Convert.ToString(lect["Nombre"]),
                            IdTipoDocumento = Convert.ToInt32(lect["IdTipoDocumento"]),
                            NumDocumento = Convert.ToString(lect["NumDocumento"]),
                            NumPlaca = Convert.ToString(lect["NumPlaca"]),
                            Email = Convert.ToString(lect["Email"]),
                            Celular = Convert.ToString(lect["Celular"]),
                            TermCondiciones = Convert.ToBoolean(lect["TermCondiciones"]),
                            FinComerciales = Convert.ToBoolean(lect["FinComerciales"]),
                            IdEstado = Convert.ToInt32(lect["IdEstado"]),
                            FechaRegistro = Convert.ToDateTime(lect["FechaRegistro"]),
                            NombreAsesorReferido = Convert.ToString(lect["NombreAsesorReferido"]),
                            IdProducto = Convert.ToInt32(lect["IdProducto"]),
                            FlagUser = Convert.ToBoolean(lect["FlagUser"]),
                            IdAsesor = Convert.ToInt32(lect["IdAsesor"]),
                            Producto = Convert.ToString(lect["Producto"]),
                            Precio = Convert.ToDecimal(lect["Precio"]),
                            Proveedor = Convert.ToString(lect["Proveedor"]),
                            IdEstadoPreevaluacion = Convert.ToInt32(lect["IdEstadoPreevaluacion"]),


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
        public PagedList<PreEvaluationTempEntity> GetPrevaluation(PrevaluationQueryFilterDTO prevaluationQueryFilterDTO)
        {
            prevaluationQueryFilterDTO.PageNumber = prevaluationQueryFilterDTO.PageNumber == 0 ? paginationOptions.DefaultPageNumber : prevaluationQueryFilterDTO.PageNumber;

            prevaluationQueryFilterDTO.PageSize = prevaluationQueryFilterDTO.PageSize == 0 ? paginationOptions.DefaultPageSize : prevaluationQueryFilterDTO.PageSize;

            List<PreEvaluationTempEntity> prevaluations;

            ///var prevaluations = context.Preevaluaciones.ToList();
       
                prevaluations = (from op in context.Preevaluaciones
                                 join rl in context.Productos
                                 on op.IdProducto equals rl.IdProducto
                                 //join r in context.ReglaKnockout
                                 //on op.IdPreevaluacion equals r.IdPreevaluacion
                                 //join td in context.ProveedorProducto  //on rl.IdProveedorProducto equals td.IdProveedorProducto
                                 select new PreEvaluationTempEntity
                                 {
                                     IdPreevaluacion = op.IdPreevaluacion,
                                     Apellido = op.Apellido,
                                     Nombre = op.Nombre,
                                     IdTipoDocumento = op.IdTipoDocumento,
                                     NumDocumento = op.NumDocumento,
                                     NumPlaca = op.NumPlaca,
                                     Email = op.Email,
                                     Celular = op.Celular,
                                     TermCondiciones = op.TermCondiciones,
                                     FinComerciales = op.FinComerciales,
                                     IdEstado = op.IdEstado,
                                     FechaRegistro = op.FechaRegistro,
                                     UsuarioModifica = op.UsuarioModifica,
                                     FechaModifica = op.FechaModifica,
                                     NombreAsesorReferido = op.NombreAsesorReferido,
                                     IdProducto = op.IdProducto,
                                     FlagUser = op.FlagUser,
                                     IdAsesor = op.IdAsesor,
                                     Producto = rl.Descripcion,
                                     Precio = rl.Precio,
                                     Proveedor = "Proveedor1", //td.RazonSocial,
                                     IdEstadoPreevaluacion = Convert.ToInt32((from r in context.ReglaKnockout where r.IdPreevaluacion == op.IdPreevaluacion && r.IdEstadoPrevaluacion > 0 select r.IdEstadoPrevaluacion).FirstOrDefault())
                                     
                                 }).ToList();
            prevaluations.ForEach(p =>
            {
                if( p.IdEstadoPreevaluacion <= 0)
                {
                    p.IdEstadoPreevaluacion = 6;
                }
            });


            if (prevaluationQueryFilterDTO.IdPreevaluacion != null)
            {
                prevaluations = prevaluations.Where(x => x.IdPreevaluacion == prevaluationQueryFilterDTO.IdPreevaluacion).ToList();
            }

            if (prevaluationQueryFilterDTO.IdTipoDocumento.HasValue)
            {
                prevaluations = prevaluations.Where(x => x.IdTipoDocumento == prevaluationQueryFilterDTO.IdTipoDocumento).ToList();
            }

            if (prevaluationQueryFilterDTO.Nombre != null)
            {
                prevaluations = prevaluations.Where(x => x.Nombre == prevaluationQueryFilterDTO.Nombre).ToList();
            }

            if (prevaluationQueryFilterDTO.Apellido != null)
            {
                prevaluations = prevaluations.Where(x => x.Apellido == prevaluationQueryFilterDTO.Apellido).ToList();
            }

            if (prevaluationQueryFilterDTO.NumDocumento != null)
            {
                prevaluations = prevaluations.Where(x => x.NumDocumento == prevaluationQueryFilterDTO.NumDocumento).ToList();
            }

            if (prevaluationQueryFilterDTO.NumPlaca != null)
            {
                prevaluations = prevaluations.Where(x => x.NumPlaca == prevaluationQueryFilterDTO.NumPlaca).ToList();
            }

            if (prevaluationQueryFilterDTO.IdAsesor != null)
            {
                prevaluations = prevaluations.Where(x => x.IdAsesor == prevaluationQueryFilterDTO.IdAsesor).ToList();
            }

            if (prevaluationQueryFilterDTO.IdEstado.HasValue)
            {
                prevaluations = prevaluations.Where(x => x.IdEstado == prevaluationQueryFilterDTO.IdEstado).ToList();
            }
            prevaluations = prevaluations.OrderByDescending(a => a.FechaRegistro).ToList();

            var pagedListPrevaluation = PagedList<PreEvaluationTempEntity>.Create(prevaluations, prevaluationQueryFilterDTO.PageNumber, prevaluationQueryFilterDTO.PageSize);
           
            return pagedListPrevaluation;
        }

        public async Task<List<PreevaluacionTip_DocDTO>> GetPreevaluacion_TipDoc(int IdTipoDocumento, string NumDocumento)
        {
            //return await context.Preevaluaciones.FirstOrDefaultAsync(data => data.IdPreevaluacion == id);
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_GetPreevaluacion_TipDoc", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@idTipoDocumento", SqlDbType.Int).Value = IdTipoDocumento;
                    sql.Parameters.Add("@numDocumento", SqlDbType.VarChar).Value = NumDocumento;
                    sql.CommandTimeout = 0;
                    SqlDataReader lect = sql.ExecuteReader();

                    var dataSql = new  List<PreevaluacionTip_DocDTO>();

                    PreevaluacionTip_DocDTO preevaluacionDTO = null;

                    while (lect.Read())
                    {
                        preevaluacionDTO = new PreevaluacionTip_DocDTO()
                        {

                            IdPreevaluacion = Convert.ToInt32(lect["IdPreevaluacion"]),
                            Nombre = Convert.ToString(lect["Nombre"]),
                            Apellido = Convert.ToString(lect["Apellido"]),
                            IdTipoDocumento = Convert.ToInt32(lect["IdTipoDocumento"]),
                            NumDocumento = Convert.ToString(lect["NumDocumento"]),
                            NumPlaca = Convert.ToString(lect["NumPlaca"]),
                            Email = Convert.ToString(lect["Email"]),
                            Celular = Convert.ToString(lect["Celular"]),
                            TermCondiciones = Convert.ToBoolean(lect["TermCondiciones"]),
                            FinComerciales = Convert.ToBoolean(lect["FinComerciales"]),
                            IdEstado = Convert.ToInt32(lect["IdEstado"]),
                            FechaRegistro = Convert.ToDateTime(lect["FechaRegistro"]),
                            IdProducto = Convert.ToInt32(lect["IdProducto"]),
                            FlagUser = Convert.ToBoolean(lect["FlagUser"]),
                            IdAsesor = Convert.ToInt32(lect["FlagUser"]),
                            Producto = Convert.ToString(lect["Producto"]),
                            Precio = Convert.ToDecimal(lect["Precio"]),
                            Proveedor = Convert.ToString(lect["Proveedor"]),
                            IdTipoProducto = Convert.ToInt32(lect["IdTipoProducto"]),
                            TipoDescripcion = Convert.ToString(lect["TipoDescripcion"]),
                            IdProveedorProducto = Convert.ToInt32(lect["IdProveedorProducto"]),
                            IndPropietarioVehiculo = Convert.ToInt32(lect["PropietarioVehiculo"]),

                        };
                        dataSql.Add(preevaluacionDTO);
                    }

                    lect.Close();
                    connection.Close();
                    connection.Dispose();
                    return dataSql;
                }
            }

        }

        public List<PreEvaluationTempEntity> GetPrevaluationTipDocEst(PrevaluationFilterTipDocEstDTO prevaluationQueryFilterDTO)
        {
            List<PreEvaluationTempEntity> prevaluations;

            prevaluations = (from op in context.Preevaluaciones
                             join rl in context.Productos
                             on op.IdProducto equals rl.IdProducto
                             join tp in context.TipoProducto
                             on rl.IdTipoProducto equals tp.IdTipoProducto
                             select new PreEvaluationTempEntity
                             {
                                 IdPreevaluacion = op.IdPreevaluacion,
                                 Apellido = op.Apellido,
                                 Nombre = op.Nombre,
                                 IdTipoDocumento = op.IdTipoDocumento,
                                 NumDocumento = op.NumDocumento,
                                 NumPlaca = op.NumPlaca,
                                 Email = op.Email,
                                 Celular = op.Celular,
                                 TermCondiciones = op.TermCondiciones,
                                 FinComerciales = op.FinComerciales,
                                 IdEstado = op.IdEstado,
                                 FechaRegistro = op.FechaRegistro,
                                 UsuarioModifica = op.UsuarioModifica,
                                 FechaModifica = op.FechaModifica,
                                 NombreAsesorReferido = op.NombreAsesorReferido,
                                 IdProducto = op.IdProducto,
                                 FlagUser = op.FlagUser,
                                 IdAsesor = op.IdAsesor,
                                 Producto = rl.Descripcion,
                                 Precio = rl.Precio,
                                 Proveedor = "Proveedor1", //td.RazonSocial,
                                 IdTipoProducto = tp.IdTipoProducto,
                                 TipoDescripcion = tp.TipoDescripcion,
                                 IdProveedorProducto = rl.IdProveedorProducto
                             }).ToList();

            if (prevaluationQueryFilterDTO.IdTipoDocumento.HasValue)
            {
                prevaluations = prevaluations.Where(x => x.IdTipoDocumento == prevaluationQueryFilterDTO.IdTipoDocumento).ToList();
            }

            if (prevaluationQueryFilterDTO.NumDocumento != null)
            {
                prevaluations = prevaluations.Where(x => x.NumDocumento == prevaluationQueryFilterDTO.NumDocumento).ToList();
            }

            prevaluations = prevaluations.Where(x => x.IdEstado == 3).ToList();

            return prevaluations;
        }

        public int UpdateIdPrevaluation(int idPrevaluation, int idEstadoKnockoutRules)
        {
            var _resultPrevaluation = context.Preevaluaciones.FirstOrDefault(item => item.IdPreevaluacion == idPrevaluation);
            if (_resultPrevaluation != null)
            {
                _resultPrevaluation.IdEstado = idEstadoKnockoutRules;
                context.Preevaluaciones.Update(_resultPrevaluation);
            }
            return context.SaveChanges(); 
        }

        public async Task<List<MantenPreguntasAleatoriasEntity>> ListMantPreguntasAleatorias()
        {
            
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_ListMantPreguntasAleatorias", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;                 
                    sql.CommandTimeout = 0;
                    SqlDataReader lect = sql.ExecuteReader();
                    List<MantenPreguntasAleatoriasEntity> dataSql = new List<MantenPreguntasAleatoriasEntity>();
                    MantenPreguntasAleatoriasEntity jsonResult;

                    while (lect.Read())
                    {
                        jsonResult = new MantenPreguntasAleatoriasEntity()
                        {

                            Id = Convert.ToInt32(lect["Id"]),
                            Pregunta = Convert.ToString(lect["Pregunta"]),
                            Respuesta = Convert.ToString(lect["Respuesta"]),
                            TipoDato = Convert.ToString(lect["TipoDato"])
                            

                        };
                        dataSql.Add(jsonResult);
                    }

                    lect.Close();
                    connection.Close();
                    connection.Dispose();
                    return dataSql;
                }
            }

        }
        public async Task<List<MantPreguntasAletoriaEntity>> GetList()
        {
            var listRandomQuestions = await (from op in context.Mant_PreguntasAletorias
                                             where op.Activo == true
                                             select new MantPreguntasAletoriaEntity
                                             {
                                                 Id = op.Id,
                                                 Pregunta = op.Pregunta,
                                                 Respuesta = op.Respuesta,
                                                 TipoDato = op.TipoDato
                                             }).ToListAsync();

            return listRandomQuestions;
        }

        public async Task<List<ListUsuarioEntity>> ListBusineesAdvisor()
        {

            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_ListBusineesAdvisor", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.CommandTimeout = 0;
                    SqlDataReader lect = sql.ExecuteReader();
                    List<ListUsuarioEntity> dataSql = new List<ListUsuarioEntity>();
                    ListUsuarioEntity jsonResult;

                    while (lect.Read())
                    {
                        jsonResult = new ListUsuarioEntity()
                        {

                            IdUsuario = Convert.ToInt32(lect["IdUsuario"]),
                            NomCliente = Convert.ToString(lect["NomCliente"]),
                            ApeCliente = Convert.ToString(lect["ApeCliente"]),
                            UsuarioEmail = Convert.ToString(lect["UsuarioEmail"])


                        };
                        dataSql.Add(jsonResult);
                    }

                    lect.Close();
                    connection.Close();
                    connection.Dispose();
                    return dataSql;
                }
            }

        }

        public async Task<List<UsuarioEntity>> ListBaAsync()
        {
            var listUsers = await (from usr in context.Usuarios
                                   where usr.Activo == true &&
                                   usr.RolId == Constants.AsesorVentas
                                   select new UsuarioEntity
                                   {
                                    IdUsuario = usr.IdUsuario,
                                    NomCliente = usr.NomCliente,
                                    ApeCliente = usr.ApeCliente,
                                    UsuarioEmail =usr.UsuarioEmail
                                   }).ToListAsync();

            return listUsers;
        }

        public async Task<bool> UploadAsync(UploadDocumentSupportDTO uploadDocumentSupportDto, int idKnockoutRules)
        {
            var result = await masterRepository.GetCredentialsUrl(DirectoryConst.PublicKnockoutRulesKey);

            if (result != null)
            {
                DateTime dateTimeCreate = DateTime.Now;
                //Se crea la carpeta de un cliente para n archivos
                var fileDirectoryClient = "RK" + "_" + uploadDocumentSupportDto.NumDocument + "_" + $"{DateTime.Now:ddMMyyyy_HHmmssffff}";
                //Crea la ruta de la carpeta
                var lastFileName = result.Valor + fileDirectoryClient;
                //Se crea la carpeta
                Directory.CreateDirectory(lastFileName);
                //Recorre la lista de Archivos para la creacion del documento
                foreach (var _uploadDocumentsDto in uploadDocumentSupportDto.Archivos)
                {
                    await using var stream = new FileStream($"{lastFileName}\\{_uploadDocumentsDto.FileName}", FileMode.Create, FileAccess.Write);
                    var fileByte = Convert.FromBase64String(_uploadDocumentsDto.FileBase64.Substring(_uploadDocumentsDto.FileBase64.LastIndexOf(',') + 1));
                    stream.Write(fileByte);
                    //Registro de las rutas de archivos, el proceso y el idSfCliente en la tabla
                    await RegisterFilePathAsync($"{lastFileName}{_uploadDocumentsDto.FileName}",
                                                _uploadDocumentsDto.ProcessType, idKnockoutRules);
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> RegisterFilePathAsync(string root, string processType, int idKnockoutRules)
        {
            bool result = false;
            await using (var connection = new SqlConnection(configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_Insert_UploadDocument_RulesKnockout", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@root", SqlDbType.Int).Value = root;
                    sql.Parameters.Add("@processType", SqlDbType.Int).Value = processType;
                    sql.Parameters.Add("@idKnockoutRules", SqlDbType.Int).Value = idKnockoutRules;
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

        public async Task<DownloadEntity> GetDownload(DownloadDTO download)
        {
            //return await context.Preevaluaciones.FirstOrDefaultAsync(data => data.IdPreevaluacion == id);
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_GetDownload", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@keyDocument", SqlDbType.VarChar).Value = download.KeyUser;
                    sql.CommandTimeout = 0;
                    SqlDataReader lect = sql.ExecuteReader();

                    //DownloadEntity dataSql = new DownloadEntity();

                    DownloadEntity downloadEntity = null;

                    while (lect.Read())
                    {
                        downloadEntity = new DownloadEntity()
                        {

                            Descripcion = Convert.ToString(lect["Descripcion"]),
                            Valor = Convert.ToString(lect["Valor"]),

                        };
                        //dataSql.Add(downloadEntity);
                    }

                    lect.Close();
                    connection.Close();
                    connection.Dispose();
                    return downloadEntity;
                }
            }

        }

        public async Task <List<DownloadEntity>> GetDownload_RK_SF(string nombre_tabla , int id)
        {
            //return await context.Preevaluaciones.FirstOrDefaultAsync(data => data.IdPreevaluacion == id);
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_GetDownload_SF_RK", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@NombreTabla", SqlDbType.VarChar).Value = nombre_tabla;
                    sql.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    sql.CommandTimeout = 0;
                    SqlDataReader lect = sql.ExecuteReader();
                    List<DownloadEntity> dataSql = new List<DownloadEntity>();
                    DownloadEntity jsonResult;

                    while (lect.Read())
                    {
                        jsonResult = new DownloadEntity()
                        {

                            Id = Convert.ToInt32(lect["Id"]),
                            IdRegla = Convert.ToInt32(lect["IdRegla"]),
                            RootArchivo = Convert.ToString(lect["RootArchivo"]),
                            TipoProcesoDocumento = Convert.ToString(lect["TipoProcesoDocumento"]),
                            NombreDocumento = Convert.ToString(lect["NombreDocumento"]),
                            IdEstado = Convert.ToInt32(lect["IdEstado"])

                        };
                        dataSql.Add(jsonResult);
                    }

                    lect.Close();
                    connection.Close();
                    connection.Dispose();
                    return dataSql;
                }
            }

        }

        public async Task<int> InsertRandonQuestions(InsertRandonQuestionsDTO request)
        {
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_InsertRandonQuestions", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;

                    sql.Parameters.Add("@pregunta", SqlDbType.VarChar).Value = request.Pregunta;
                    sql.Parameters.Add("@textAyuda", SqlDbType.VarChar).Value = request.TextAyuda;
                    sql.Parameters.Add("@tipoDato", SqlDbType.VarChar).Value = request.TipoDato;
                    sql.Parameters.Add("@activoCabecera", SqlDbType.Bit).Value = request.ActivoCabecera;

                    sql.CommandTimeout = 0;
                    SqlDataReader lect = sql.ExecuteReader();
                    var response = 0;

                    while (lect.Read())
                    {
                        response = Convert.ToInt32(lect["IdPregunta"]);
                        
                    }

                    connection.Close();
                    connection.Dispose();
                    return response;
                }
            }
        }

        public async Task<int> InsertRandonQuestions_Detalle (RandonQuestionDetalle request)
        {
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_InsertRandonQuestions_Detalle", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;

                    sql.Parameters.Add("@idpregunta", SqlDbType.Int).Value = request.IdPregunta;
                    sql.Parameters.Add("@activoDetalle", SqlDbType.Bit).Value = request.ActivoDetalle;
                    sql.Parameters.Add("@descripcionDetalle", SqlDbType.VarChar).Value = request.DescripcionDetalle;
                    sql.CommandTimeout = 0;

                    var resultado = await sql.ExecuteNonQueryAsync();

                    connection.Close();
                    connection.Dispose();
                    return resultado;
                }
            }
        }


        public async Task<MantPreguntasAleatoriasEntity> AddRandomQuestions(MantPreguntasAleatoriasEntity mantPreguntasAleatoriaEntity)
        {
            await context.MantPreguntasAleatorias.AddAsync(mantPreguntasAleatoriaEntity);
            context.SaveChanges();
            return mantPreguntasAleatoriaEntity;
        }

        public async Task<bool> AddRandomQuestionsDetails(int IdPregunta, string Descripcion, bool Activo)
        {
            bool result = false;
            await using (var connection = new SqlConnection(configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_Insert_Mant_PreguntasAleatoriasDetalle", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@IdPregunta", SqlDbType.Int).Value = IdPregunta;
                    sql.Parameters.Add("@Descripcion", SqlDbType.Char).Value = Descripcion;
                    sql.Parameters.Add("@Activo", SqlDbType.Bit).Value = Activo;
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

        public async Task<List<ListQuestionEntity>> ListarManPreguntas()
        {
            //return await context.Preevaluaciones.FirstOrDefaultAsync(data => data.IdPreevaluacion == id);
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_ListarManPreguntas", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.CommandTimeout = 0;
                    SqlDataReader lect = sql.ExecuteReader();
                    var dataSql = new List<ListQuestionEntity>();
                    ListQuestionEntity jsonResult;

                    while (lect.Read())
                    {
                        jsonResult = new ListQuestionEntity()
                        {

                            IdPregunta = Convert.ToInt32(lect["IdPregunta"]),
                            Pregunta = Convert.ToString(lect["Pregunta"]),
                            TextAyuda = Convert.ToString(lect["TextAyuda"]),
                            TipoDato = Convert.ToString(lect["TipoDato"])

                        };
                        dataSql.Add(jsonResult);
                    }

                    lect.Close();
                    connection.Close();
                    connection.Dispose();
                    return dataSql;
                }
            }

        }

        public async Task<List<ListQuestionDetalleEntity>> ListMantPreguntasDetalle(int idpregunta)
        {
            //return await context.Preevaluaciones.FirstOrDefaultAsync(data => data.IdPreevaluacion == id);
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_ListMantPreguntasDetalle", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@idPregunta", SqlDbType.Int).Value = idpregunta;
                    sql.CommandTimeout = 0;
                    SqlDataReader lect = sql.ExecuteReader();
                    var dataSql = new List<ListQuestionDetalleEntity>();
                    ListQuestionDetalleEntity jsonResult;

                    while (lect.Read())
                    {
                        jsonResult = new ListQuestionDetalleEntity()
                        {

                            IdDetalle = Convert.ToInt32(lect["IdDetalle"]),
                            Descripcion = Convert.ToString(lect["Descripcion"]),


                        };
                        dataSql.Add(jsonResult);
                    }

                    lect.Close();
                    connection.Close();
                    connection.Dispose();
                    return dataSql;
                }
            }

        }

        public async Task<List<ResponseRandomQuestionsDTO>> GetList2()
        {
          List<ResponseRandomQuestionsDTO> questionResponseDTO = new List<ResponseRandomQuestionsDTO>();

            var listRandomQuestions = await (from op in context.MantPreguntasAleatorias
                                             where op.Activo == true
                                             select new ResponseRandomQuestionsDTO
                                             {
                                                 Id = op.IdPregunta,
                                                 Pregunta = op.Pregunta,
                                                 textAyuda = op.TextAyuda,
                                                 TipoDato = op.TipoDato
                                             }).ToListAsync();

            listRandomQuestions.ForEach(itemPadre =>
            {
                itemPadre.opciones = (from menuHijo in context.MantPreguntasAleatoriasDetalles
                                      where menuHijo.IdPregunta == itemPadre.Id && menuHijo.Activo == true
                                      select new MenuOpciones
                                      {
                                          IdDetalle = menuHijo.IdDetalle,
                                          descripcion = menuHijo.Descripcion
                                      }).ToList();
            });
            questionResponseDTO = listRandomQuestions;
            return questionResponseDTO;
        }


        public async Task<List<ListQuestionEntity>> ListarManPreguntasxId(int idPregunta)
        {
            //return await context.Preevaluaciones.FirstOrDefaultAsync(data => data.IdPreevaluacion == id);
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_ListarManPreguntasxId", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@idPregunta", SqlDbType.Int).Value = idPregunta;
                    sql.CommandTimeout = 0;
                    SqlDataReader lect = sql.ExecuteReader();
                    var dataSql = new List<ListQuestionEntity>();
                    ListQuestionEntity jsonResult;

                    while (lect.Read())
                    {
                        jsonResult = new ListQuestionEntity()
                        {

                            IdPregunta = Convert.ToInt32(lect["IdPregunta"]),
                            Pregunta = Convert.ToString(lect["Pregunta"]),
                            TextAyuda = Convert.ToString(lect["TextAyuda"]),
                            TipoDato = Convert.ToString(lect["TipoDato"])

                        };
                        dataSql.Add(jsonResult);
                    }

                    lect.Close();
                    connection.Close();
                    connection.Dispose();
                    return dataSql;
                }
            }

        }

        public async Task<List<ListQuestionDetalleEntity>> ListMantPreguntasDetallexId(int idpregunta)
        {
            //return await context.Preevaluaciones.FirstOrDefaultAsync(data => data.IdPreevaluacion == id);
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_ListMantPreguntasDetallexId", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@idPregunta", SqlDbType.Int).Value = idpregunta;
                    sql.CommandTimeout = 0;
                    SqlDataReader lect = sql.ExecuteReader();
                    var dataSql = new List<ListQuestionDetalleEntity>();
                    ListQuestionDetalleEntity jsonResult;

                    while (lect.Read())
                    {
                        jsonResult = new ListQuestionDetalleEntity()
                        {

                            IdDetalle = Convert.ToInt32(lect["IdDetalle"]),
                            Descripcion = Convert.ToString(lect["Descripcion"]),


                        };
                        dataSql.Add(jsonResult);
                    }

                    lect.Close();
                    connection.Close();
                    connection.Dispose();
                    return dataSql;
                }
            }

        }

        public async Task<List<ResponseRandomQuestionsDTO>> ListRamdonIdAsync(int idPregunta)
        {
            List<ResponseRandomQuestionsDTO> questionResponseDTO = new List<ResponseRandomQuestionsDTO>();

            var listRandomQuestions = await (from op in context.MantPreguntasAleatorias
                                             where op.Activo == true && op.IdPregunta == idPregunta
                                             select new ResponseRandomQuestionsDTO
                                             {
                                                 Id = op.IdPregunta,
                                                 Pregunta = op.Pregunta,
                                                 textAyuda = op.TextAyuda,
                                                 TipoDato = op.TipoDato
                                             }).ToListAsync();

            listRandomQuestions.ForEach(itemPadre =>
            {
                itemPadre.opciones = (from menuHijo in context.MantPreguntasAleatoriasDetalles
                                      where menuHijo.IdPregunta == itemPadre.Id && menuHijo.Activo == true
                                      select new MenuOpciones
                                      {
                                          IdDetalle = menuHijo.IdDetalle,
                                          descripcion = menuHijo.Descripcion
                                      }).ToList();
            });
            questionResponseDTO = listRandomQuestions;
            return questionResponseDTO;
        }

        public async Task<int> DeleteRandonQuestions(InsertRandonQuestionsDTO request)
        {
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_DeleteRandonQuestions", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;

                    sql.Parameters.Add("@idPregunta", SqlDbType.Int).Value = request.IdPregunta;
                    sql.Parameters.Add("@pregunta", SqlDbType.VarChar).Value = request.Pregunta;
                    sql.Parameters.Add("@textAyuda", SqlDbType.VarChar).Value = request.TextAyuda;
                    sql.Parameters.Add("@tipoDato", SqlDbType.VarChar).Value = request.TipoDato;
                    sql.Parameters.Add("@activo", SqlDbType.Bit).Value = request.ActivoCabecera;
                    sql.CommandTimeout = 0;
                    //SqlDataReader lect = sql.ExecuteReader();

                    int resultado = await sql.ExecuteNonQueryAsync();

                    connection.Close();
                    connection.Dispose();
                    return resultado;
                }
            }
        }

        public async Task<int> DeleteRandonQuestions_Detalle(RandonQuestionDetalle request)
        {
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_DeleteRandonQuestions_Detalle", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;

                    sql.Parameters.Add("@idPregunta", SqlDbType.Int).Value = request.IdPregunta;
                    sql.Parameters.Add("@idDetalle", SqlDbType.Int).Value = request.IdDetalle;
                    sql.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = request.DescripcionDetalle;
                    sql.Parameters.Add("@activo", SqlDbType.Bit).Value = request.ActivoDetalle;
                    sql.CommandTimeout = 0;
                    //SqlDataReader lect = sql.ExecuteReader();

                    int resultado = await sql.ExecuteNonQueryAsync();

                    connection.Close();
                    connection.Dispose();
                    return resultado;
                }
            }
        }


        public async Task<JsonResultEntity> UpdateAsync(RandomQuestionsRequestDTO requestDTO)
        {
            JsonResultEntity result = new JsonResultEntity();
            MantPreguntasAleatoriasEntity mantPreguntasAleatoriaEntity = mapper.Map<MantPreguntasAleatoriasEntity>(requestDTO);
            result = await UpdateQuestionAsync(mantPreguntasAleatoriaEntity);
            foreach (var str in requestDTO.DetailsQuestions)
            {
                result = await UpdateQuestionDetailAsync(
                    str.IdDetalle, str.IdPregunta, str.Descripcion, str.Activo);
            }
            return result;
        }

        #region ResponseQuestionMaintenance
        public async Task<JsonResultEntity> UpdateQuestionAsync(MantPreguntasAleatoriasEntity mantPreguntasAleatoriaEntity)
        {
            await using (var connection = new SqlConnection(configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_Update_RandonQuestion_Maintenance", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@IdPregunta", SqlDbType.Int).Value = mantPreguntasAleatoriaEntity.IdPregunta;
                    sql.Parameters.Add("@Pregunta", SqlDbType.VarChar).Value = mantPreguntasAleatoriaEntity.Pregunta;
                    sql.Parameters.Add("@TextAyuda", SqlDbType.VarChar).Value = mantPreguntasAleatoriaEntity.TextAyuda;
                    sql.Parameters.Add("@TipoDato", SqlDbType.VarChar).Value = mantPreguntasAleatoriaEntity.TipoDato;
                    sql.CommandTimeout = 0;

                    SqlDataReader lect = sql.ExecuteReader();
                    JsonResultEntity jsonResult = new JsonResultEntity();

                    while (lect.Read())
                    {
                        jsonResult.Value = Convert.ToInt32(lect["Value"]);
                        jsonResult.Message = Convert.ToString(lect["Message"]);
                    }

                    lect.Close();
                    connection.Close();
                    connection.Dispose();
                    return jsonResult;
                }
            }
        }

        public async Task<JsonResultEntity> UpdateQuestionDetailAsync(int n_id_detail, int n_id_question, string vc_description, bool b_i_flag)
        {
            await using (var connection = new SqlConnection(configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open(); 
                await using (var sql = new SqlCommand("Sp_Update_RandonQuestionDetail_Maintenance", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@n_id_detail", SqlDbType.Int).Value = n_id_detail;
                    sql.Parameters.Add("@n_id_question", SqlDbType.Int).Value = n_id_question;
                    sql.Parameters.Add("@vc_description", SqlDbType.VarChar).Value = vc_description;
                    sql.Parameters.Add("@b_i_flag", SqlDbType.Bit).Value = b_i_flag;
                    sql.CommandTimeout = 0;
                    SqlDataReader lect = sql.ExecuteReader();
                    JsonResultEntity jsonResult = new JsonResultEntity();

                    while (lect.Read())
                    {
                        jsonResult.Value = Convert.ToInt32(lect["Value"]);
                        jsonResult.Message = Convert.ToString(lect["Message"]);
                    }

                    lect.Close();
                    connection.Close();
                    connection.Dispose();
                    return jsonResult;
                }
            }
            
        }

        public async Task<JsonResultEntity> DeleteAsync(RequestQuestionDTO requestDTO)
        {
            MantPreguntasAleatoriasEntity mantPreguntasAleatoriaEntity = mapper.Map<MantPreguntasAleatoriasEntity>(requestDTO);
            JsonResultEntity data = new JsonResultEntity();
            var n_result = context.MantPreguntasAleatorias.FirstOrDefault(item => item.IdPregunta == mantPreguntasAleatoriaEntity.IdPregunta);
             
            if (n_result != null)
            {
                n_result.Activo = false; 
                context.MantPreguntasAleatorias.Update(n_result); 
                data = await DeleteIdQuestionDetail(requestDTO.IdPregunta); 
                data.Value = 1;
                data.Message = "La pregunta fue dado de baja.";
            }
            context.SaveChanges();

           
            return data;
        }

        public async Task<JsonResultEntity> DeleteIdQuestionDetail(int idQuestion)
        {
            await using (var connection = new SqlConnection(configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_Delete_RandonQuestionDetail_Maintenance", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@idQuestion", SqlDbType.Int).Value = idQuestion; 
                    sql.CommandTimeout = 0;
                    SqlDataReader lect = sql.ExecuteReader();
                    JsonResultEntity jsonResult = new JsonResultEntity();

                    while (lect.Read())
                    {
                        jsonResult.Value = Convert.ToInt32(lect["Value"]);
                        jsonResult.Message = Convert.ToString(lect["Message"]);
                    }

                    lect.Close();
                    connection.Close();
                    connection.Dispose();
                    return jsonResult;
                }
            }
        }

        //public async Task<JsonResultEntity> Add1Async(SurveyDTO surveyDTO)
        //{
        //    MantAnswerEntity mantAnswerEntity = mapper.Map<MantAnswerEntity>(surveyDTO);
        //    await using (var connection = new SqlConnection(configuration["ConnectionStrings:CnnGnvSqlServer"]))
        //    {
        //        connection.Open();
        //        await using (var sql = new SqlCommand("Sp_Add_Survey", connection))
        //        {
        //            sql.CommandType = CommandType.StoredProcedure;
        //            sql.Parameters.Add("@idQuestion", SqlDbType.Int).Value = mantAnswerEntity.IdQuestion;
        //            sql.Parameters.Add("@IdFinancing", SqlDbType.Int).Value = mantAnswerEntity.IdFinancing;
        //            sql.Parameters.Add("@Answer", SqlDbType.VarChar).Value = mantAnswerEntity.Answer;
        //            sql.CommandTimeout = 0;
        //            SqlDataReader lect = sql.ExecuteReader();
        //            JsonResultEntity jsonResult = new JsonResultEntity();

        //            while (lect.Read())
        //            {
        //                jsonResult.Value = Convert.ToInt32(lect["Value"]);
        //                jsonResult.Message = Convert.ToString(lect["Message"]);
        //            }

        //            lect.Close();
        //            connection.Close();
        //            connection.Dispose();
        //            return jsonResult;
        //        }
        //    }
        //}

        public async Task<JsonResultEntity> AddAsync(List<SurveyDTO> entities)
        {
            using (var connection = new SqlConnection(configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    using (var command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.Transaction = transaction;
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "Sp_Add_Survey";
                        command.Parameters.Add("@idQuestion", SqlDbType.Int);
                        command.Parameters.Add("@IdFinancing", SqlDbType.Int);
                        command.Parameters.Add("@Answer", SqlDbType.VarChar);
                        try
                        {
                            JsonResultEntity jsonResult = new JsonResultEntity();

                            SqlDataReader rdr; //= command.ExecuteReader(CommandBehavior.CloseConnection);

                            foreach (var item in entities)
                            {
                                command.Parameters["@idQuestion"].Value = item.IdPregunta;
                                command.Parameters["@IdFinancing"].Value = item.IdFinanciamiento;
                                command.Parameters["@Answer"].Value = item.Respuesta;
                                command.ExecuteNonQuery();

                                //while (rdr.Read())
                                //{
                                jsonResult.Value = 1; //Convert.ToInt32(rdr["Value"]);
                                jsonResult.Message = "La encuesta se ha registrado correctamente"; //Convert.ToString(rdr["Message"]);

                                //}


                            }
                            transaction.Commit();

                            connection.Close();
                            connection.Dispose();
                            return jsonResult;


                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            connection.Close();
                            throw;
                        }
                    }
                }
            }
        }
        #endregion

        public async Task<List<EstadoNivelEstudiosClienteEntity>> GetEstadoNivelEstudiosCliente()
        {
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_GetEstadoNivelEstudiosCliente", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    //sql.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = descripcion;
                    sql.CommandTimeout = 0;
                    SqlDataReader lect = sql.ExecuteReader();
                    List<EstadoNivelEstudiosClienteEntity> dataSql = new List<EstadoNivelEstudiosClienteEntity>();
                    EstadoNivelEstudiosClienteEntity jsonResult;

                    while (lect.Read())
                    {
                        jsonResult = new EstadoNivelEstudiosClienteEntity()
                        {
                            Id = Convert.ToInt32(lect["Id"]),
                            Estado = Convert.ToString(lect["Estado"])
                        };

                        dataSql.Add(jsonResult);
                    }

                    lect.Close();
                    connection.Close();
                    connection.Dispose();
                    return dataSql;

                }
            }
        }

        public async Task<List<EstadoCivilClienteEntity>> GetEstadoCivilCliente()
        {
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_GetEstadoCivilCliente", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    //sql.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = descripcion;
                    sql.CommandTimeout = 0;
                    SqlDataReader lect = sql.ExecuteReader();
                    List<EstadoCivilClienteEntity> dataSql = new List<EstadoCivilClienteEntity>();
                    EstadoCivilClienteEntity jsonResult;

                    while (lect.Read())
                    {
                        jsonResult = new EstadoCivilClienteEntity()
                        {
                            Id = Convert.ToInt32(lect["Id"]),
                            Estado = Convert.ToString(lect["Estado"])
                        };

                        dataSql.Add(jsonResult);
                    }

                    lect.Close();
                    connection.Close();
                    connection.Dispose();
                    return dataSql;

                }
            }
        }

        public async Task<List<EstadoVehicularEntity>> GetEstadoVehicular()
        {
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_GetEstadoVehicular", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    //sql.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = descripcion;
                    sql.CommandTimeout = 0;
                    SqlDataReader lect = sql.ExecuteReader();
                    List<EstadoVehicularEntity> dataSql = new List<EstadoVehicularEntity>();
                    EstadoVehicularEntity jsonResult;

                    while (lect.Read())
                    {
                        jsonResult = new EstadoVehicularEntity()
                        {
                            Id = Convert.ToInt32(lect["Id"]),
                            Estado = Convert.ToString(lect["Estado"])
                        };

                        dataSql.Add(jsonResult);
                    }

                    lect.Close();
                    connection.Close();
                    connection.Dispose();
                    return dataSql;

                }
            }
        }


        public async Task<List<EstadoTipoFinanciamientoEntity>> GetEstadoTipoFinanciamiento()
        {
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_GetEstadoTipoFinanciamiento", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    //sql.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = descripcion;
                    sql.CommandTimeout = 0;
                    SqlDataReader lect = sql.ExecuteReader();
                    List<EstadoTipoFinanciamientoEntity> dataSql = new List<EstadoTipoFinanciamientoEntity>();
                    EstadoTipoFinanciamientoEntity jsonResult;

                    while (lect.Read())
                    {
                        jsonResult = new EstadoTipoFinanciamientoEntity()
                        {
                            Id = Convert.ToInt32(lect["Id"]),
                            Descripcion = Convert.ToString(lect["Descripcion"])
                        };

                        dataSql.Add(jsonResult);
                    }

                    lect.Close();
                    connection.Close();
                    connection.Dispose();
                    return dataSql;

                }
            }
        }

        public async Task<List<TipoCalleEntity>> GetTipoCalle()
        {
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_GetTipoCalle", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    //sql.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = descripcion;
                    sql.CommandTimeout = 0;
                    SqlDataReader lect = sql.ExecuteReader();
                    List<TipoCalleEntity> dataSql = new List<TipoCalleEntity>();
                    TipoCalleEntity jsonResult;

                    while (lect.Read())
                    {
                        jsonResult = new TipoCalleEntity()
                        {
                            Id = Convert.ToInt32(lect["Id"]),
                            Descripcion = Convert.ToString(lect["Descripcion"])
                        };

                        dataSql.Add(jsonResult);
                    }

                    lect.Close();
                    connection.Close();
                    connection.Dispose();
                    return dataSql;

                }
            }
        }

        public async Task<List<TipoCreditoFinanciamientoEntity>> GetTipoCreditoFinanciamiento()
        {
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_GetTipoCreditoFinanciamiento", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    //sql.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = descripcion;
                    sql.CommandTimeout = 0;
                    SqlDataReader lect = sql.ExecuteReader();
                    List<TipoCreditoFinanciamientoEntity> dataSql = new List<TipoCreditoFinanciamientoEntity>();
                    TipoCreditoFinanciamientoEntity jsonResult;

                    while (lect.Read())
                    {
                        jsonResult = new TipoCreditoFinanciamientoEntity()
                        {
                            Id = Convert.ToInt32(lect["Id"]),
                            TipoCredito= Convert.ToString(lect["TipoCredito"])
                        };

                        dataSql.Add(jsonResult);
                    }

                    lect.Close();
                    connection.Close();
                    connection.Dispose();
                    return dataSql;

                }
            }
        }

        public async Task<int> UpdateRegistroReglasKnockout(UpdateRegistroReglasNockoutDTO reglasNockoutDTO)
        {
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_UpdateRegistroReglasKnockout", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;

                    sql.Parameters.Add("@IdPreevaluacion", SqlDbType.Int).Value = reglasNockoutDTO.IdPreevaluacion;
                    sql.Parameters.Add("@FechaVencimientoRevisioAnual", SqlDbType.DateTime).Value = reglasNockoutDTO.FechaVencimientoRevisioAnual;
                    sql.Parameters.Add("@FechaVencimientoCilindro", SqlDbType.DateTime).Value = reglasNockoutDTO.FechaVencimientoCilindro;
                    sql.Parameters.Add("@IndicadorCreditoActivo", SqlDbType.Bit).Value = reglasNockoutDTO.IndicadorCreditoActivo;
                    sql.Parameters.Add("@IndicadorParaConsumir", SqlDbType.Bit).Value = reglasNockoutDTO.IndicadorParaConsumir;
                    sql.Parameters.Add("@IndicadorAntiguedadMenos10Anios", SqlDbType.Bit).Value = reglasNockoutDTO.IndicadorAntiguedadMenos10Anios;
                    sql.Parameters.Add("@IndicadorTitular20A65Anios", SqlDbType.Bit).Value = reglasNockoutDTO.IndicadorTitular20A65Anios;
                    sql.Parameters.Add("@IndicadorDniRegistradoEnReniec", SqlDbType.Bit).Value = reglasNockoutDTO.IndicadorDniRegistradoEnReniec;
                    sql.Parameters.Add("@IndicadorDniTitularContrato", SqlDbType.Bit).Value = reglasNockoutDTO.IndicadorDniTitularContrato;
                    sql.Parameters.Add("@IndicadorLicenciaConducirVigente", SqlDbType.Bit).Value = reglasNockoutDTO.IndicadorLicenciaConducirVigente;
                    sql.Parameters.Add("@IndicadorTitularPropietarioVehiculo", SqlDbType.Bit).Value = reglasNockoutDTO.IndicadorTitularPropietarioVehiculo;
                    sql.Parameters.Add("@IndicadorSoatVigente", SqlDbType.Bit).Value = reglasNockoutDTO.IndicadorSoatVigente;
                    sql.Parameters.Add("@IndicadorVehiculoNoMultasPendientePago", SqlDbType.Bit).Value = reglasNockoutDTO.IndicadorVehiculoNoMultasPendientePago;
                    sql.Parameters.Add("@IndicadorTitularNoMultasPendientePago", SqlDbType.Bit).Value = reglasNockoutDTO.IndicadorTitularNoMultasPendientePago;
                    sql.Parameters.Add("@IndicadorVehiculoNoOrdenCaptura", SqlDbType.Bit).Value = reglasNockoutDTO.IndicadorVehiculoNoOrdenCaptura;
                    sql.Parameters.Add("@IndicadorEstadoPreevaluacion", SqlDbType.Bit).Value = reglasNockoutDTO.IndicadorEstadoPreevaluacion;
                    sql.Parameters.Add("@IdEstadoPrevaluacion", SqlDbType.Int).Value = reglasNockoutDTO.IdEstadoPrevaluacion;
                    sql.CommandTimeout = 0;

                    int resultado = await sql.ExecuteNonQueryAsync();

                    connection.Close();
                    connection.Dispose();
                    return resultado;
                }
            }
        }

        public async Task<ResponseRKByIdPrevaluationDTO> ListExistRKByIdPrevaluation(int IdPreevaluacion)
        {
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_ListReglasKnockoutxId", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@IdPreevaluacion", SqlDbType.Int).Value = IdPreevaluacion;
                    sql.CommandTimeout = 0;
                    SqlDataReader lect = sql.ExecuteReader();

                    //List<ResponseRKByIdPrevaluationDTO> dataSql = new List<ResponseRKByIdPrevaluationDTO>();

                    ResponseRKByIdPrevaluationDTO GetRKPrevaluationById = null;

                    while (lect.Read())
                    {


                        GetRKPrevaluationById = new ResponseRKByIdPrevaluationDTO()
                        {

                            valid = true,
                            message = Constants.ReponseExitPrevaluation,
                            // 
                            IdReglanockout = lect.IsDBNull(lect.GetOrdinal("IdReglanockout")) ? default(int) : lect.GetInt32(lect.GetOrdinal("IdReglanockout")),
                            FechaVencimientoRevisioAnual = lect.IsDBNull(lect.GetOrdinal("FechaVencimientoRevisioAnual")) ? default(DateTime) : lect.GetDateTime(lect.GetOrdinal("FechaVencimientoRevisioAnual")),
                            FechaVencimientoCilindro = lect.IsDBNull(lect.GetOrdinal("FechaVencimientoCilindro")) ? default(DateTime) : lect.GetDateTime(lect.GetOrdinal("FechaVencimientoCilindro")),
                            IndicadorCreditoActivo = lect.IsDBNull(lect.GetOrdinal("IndicadorCreditoActivo")) ? default(bool) : lect.GetBoolean(lect.GetOrdinal("IndicadorCreditoActivo")),
                            IndicadorParaConsumir = lect.IsDBNull(lect.GetOrdinal("IndicadorParaConsumir")) ? default(bool) : lect.GetBoolean(lect.GetOrdinal("IndicadorParaConsumir")),
                            IndicadorAntiguedadMenos10Anios = lect.IsDBNull(lect.GetOrdinal("IndicadorAntiguedadMenos10Anios")) ? default(bool) : lect.GetBoolean(lect.GetOrdinal("IndicadorAntiguedadMenos10Anios")),
                            IndicadorTitular20A65Anios = lect.IsDBNull(lect.GetOrdinal("IndicadorTitular20A65Anios")) ? default(bool) : lect.GetBoolean(lect.GetOrdinal("IndicadorTitular20A65Anios")),
                            IndicadorDniRegistradoEnReniec = lect.IsDBNull(lect.GetOrdinal("IndicadorDniRegistradoEnReniec")) ? default(bool) : lect.GetBoolean(lect.GetOrdinal("IndicadorDniRegistradoEnReniec")),
                            IndicadorDniTitularContrato = lect.IsDBNull(lect.GetOrdinal("IndicadorDniTitularContrato")) ? default(bool) : lect.GetBoolean(lect.GetOrdinal("IndicadorDniTitularContrato")),
                            IndicadorLicenciaConducirVigente = lect.IsDBNull(lect.GetOrdinal("IndicadorLicenciaConducirVigente")) ? default(bool) : lect.GetBoolean(lect.GetOrdinal("IndicadorLicenciaConducirVigente")),
                            IndicadorTitularPropietarioVehiculo = lect.IsDBNull(lect.GetOrdinal("IndicadorTitularPropietarioVehiculo")) ? default(bool) : lect.GetBoolean(lect.GetOrdinal("IndicadorTitularPropietarioVehiculo")),
                            IndicadorSoatVigente = lect.IsDBNull(lect.GetOrdinal("IndicadorSoatVigente")) ? default(bool) : lect.GetBoolean(lect.GetOrdinal("IndicadorSoatVigente")),
                            IndicadorVehiculoNoMultasPendientePago = lect.IsDBNull(lect.GetOrdinal("IndicadorVehiculoNoMultasPendientePago")) ? default(bool) : lect.GetBoolean(lect.GetOrdinal("IndicadorVehiculoNoMultasPendientePago")),
                            IndicadorTitularNoMultasPendientePago = lect.IsDBNull(lect.GetOrdinal("IndicadorTitularNoMultasPendientePago")) ? default(bool) : lect.GetBoolean(lect.GetOrdinal("IndicadorTitularNoMultasPendientePago")),
                            IndicadorVehiculoNoOrdenCaptura = lect.IsDBNull(lect.GetOrdinal("IndicadorVehiculoNoOrdenCaptura")) ? default(bool) : lect.GetBoolean(lect.GetOrdinal("IndicadorVehiculoNoOrdenCaptura")),
                            IndicadorEstadoPreevaluacion = lect.IsDBNull(lect.GetOrdinal("IndicadorEstadoPreevaluacion")) ? default(bool) : lect.GetBoolean(lect.GetOrdinal("IndicadorEstadoPreevaluacion")),
                            IdEstadoPrevaluacion = lect.IsDBNull(lect.GetOrdinal("IdEstadoPrevaluacion")) ? default(int) : lect.GetInt32(lect.GetOrdinal("IdEstadoPrevaluacion")),
                            EstadoPrevaluacion = lect.IsDBNull(lect.GetOrdinal("NombreEstadoPrevaluacion")) ? default(string) : lect.GetString(lect.GetOrdinal("NombreEstadoPrevaluacion")),

                            FechaVencimientoSOAT = lect.IsDBNull(lect.GetOrdinal("FechaVencimientoSOAT")) ? default(DateTime?) : lect.GetDateTime(lect.GetOrdinal("FechaVencimientoSOAT")),
                            IndicadorVehiculoFuncionaGNV = lect.IsDBNull(lect.GetOrdinal("IndicadorVehiculoFuncionaGNV")) ? default(bool) : lect.GetBoolean(lect.GetOrdinal("IndicadorVehiculoFuncionaGNV")),

                            fileVehiculoGNV = lect.IsDBNull(lect.GetOrdinal("fileVehiculoGNV")) ? default(string) : lect.GetString(lect.GetOrdinal("fileVehiculoGNV")),
                            fileLicenciaVigente = lect.IsDBNull(lect.GetOrdinal("fileLicenciaVigente")) ? default(string) : lect.GetString(lect.GetOrdinal("fileLicenciaVigente")),
                            filePropietarioVehiculo = lect.IsDBNull(lect.GetOrdinal("filePropietarioVehiculo")) ? default(string) : lect.GetString(lect.GetOrdinal("filePropietarioVehiculo")),
                            fileSoatVigente = lect.IsDBNull(lect.GetOrdinal("fileSoatVigente")) ? default(string) : lect.GetString(lect.GetOrdinal("fileSoatVigente")),
                            fileMultastransito = lect.IsDBNull(lect.GetOrdinal("fileMultastransito")) ? default(string) : lect.GetString(lect.GetOrdinal("fileMultastransito")),
                            fileOrdenCaptura = lect.IsDBNull(lect.GetOrdinal("fileOrdenCaptura")) ? default(string) : lect.GetString(lect.GetOrdinal("fileOrdenCaptura")),

                        };
                        //dataSql.Add(GetRKPrevaluationById);
                    }

                    lect.Close();
                    connection.Close();
                    connection.Dispose();
                    return GetRKPrevaluationById;
                }
            }
        }

        public async Task<ResponseExistPreevaluationDTO> ExistByIdPrevaluation(int IdPreevaluacion)
        {
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_ExistPreevaluationxId", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@IdPreevaluacion", SqlDbType.Int).Value = IdPreevaluacion;
                    sql.CommandTimeout = 0;
                    SqlDataReader lect = sql.ExecuteReader();

                    //List<ResponseExistPreevaluationDTO> dataSql = new List<ResponseExistPreevaluationDTO>();

                    ResponseExistPreevaluationDTO GetPrevaluationById = null;

                    while (lect.Read())
                    {
                        GetPrevaluationById = new ResponseExistPreevaluationDTO()
                        {

                            valid = true,
                            message = Constants.ReponseExitPrevaluation,
                            //
                            IdPreevaluacion = Convert.ToInt32(lect["IdPreevaluacion"]),


                        };
                        //dataSql.Add(GetPrevaluationById);
                    }

                    lect.Close();
                    connection.Close();
                    connection.Dispose();
                    return GetPrevaluationById;
                }
            }
        }

        public async Task<bool> UpdateAsesorPrevaluation(int IdPreevaluacion, int IdAsesor)
        {
            bool result = false;
            await using (var connection = new SqlConnection(configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_UpdatePreevaluaciones_IdAsesor", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@IdPreevaluacion", SqlDbType.Int).Value = IdPreevaluacion;
                    sql.Parameters.Add("@IdAsesor", SqlDbType.Char).Value = IdAsesor;
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

        public async Task<ResponseIdFinanciamientoDTO> GetListIdFinancing(int IdPreevaluacion)
        {
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_ListIdGNV", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@IdPreevaluacion", SqlDbType.Int).Value = IdPreevaluacion;
                    sql.CommandTimeout = 90;
                    SqlDataReader lect = sql.ExecuteReader();

                    //List<ResponseExistPreevaluationDTO> dataSql = new List<ResponseExistPreevaluationDTO>();

                    ResponseIdFinanciamientoDTO GetResponse = null;

                    while (lect.Read())
                    {
                        GetResponse = new ResponseIdFinanciamientoDTO()
                        {
                            IdPreevaluacion= Convert.ToInt32(lect["IdPreevaluacion"]),
                            IdSolicitudFinanciamiento = Convert.ToInt32(lect["IdSolicitudFinanciamiento"]),
                            IdReglanockout = Convert.ToInt32(lect["IdReglanockout"]),
                            IdPostAtencion = Convert.ToInt32(lect["IdPostAtencion"]),

                        };
                        //dataSql.Add(GetPrevaluationById);
                    }

                    lect.Close();
                    connection.Close();
                    connection.Dispose();
                    return GetResponse;
                }
            }
        }
    }
}
