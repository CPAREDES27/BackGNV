using Application.Dto.CustomEntities;
using Application.Dto.MaintenanceUser;
using Application.Services.Interfaces;
using Domain.MainModule.Entities;
using Domain.MainModule.Entities.Usuario;
using Domain.MainModule.Settings;
using Infrastructure.Data.Context;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Application.Dto.Usuario;

namespace Infrastructure.MainModule.Repositories
{
    public class UserRepository : IUserService
    {
        private readonly DBGNVContext _context;
        private readonly IConfiguration configuration;
        private readonly PaginationOptions paginationOptions;

        public UserRepository(
            DBGNVContext context, 
            IConfiguration configuration,
            IOptions<PaginationOptions> paginationOptions)
        {
            this._context = context;
            this.configuration = configuration;
            this.paginationOptions = paginationOptions.Value;
        }
         
        public async Task<UsuarioEntity> RegisterCustomerUser(UsuarioEntity usuarioEntity)
        {
            await using (var connection = new SqlConnection(configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_RegisterCustomerUser", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@UsuarioEmail", SqlDbType.VarChar).Value = usuarioEntity.UsuarioEmail;
                    sql.Parameters.Add("@Contrasena", SqlDbType.VarChar).Value = usuarioEntity.Contrasena;
                    
                    sql.Parameters.Add("@NomCliente", SqlDbType.VarChar).Value = usuarioEntity.NomCliente;
                    sql.Parameters.Add("@ApeCliente", SqlDbType.VarChar).Value = usuarioEntity.ApeCliente;
                    sql.Parameters.Add("@Ruc", SqlDbType.VarChar).Value = usuarioEntity.Ruc;
                    sql.Parameters.Add("@RazonSocial", SqlDbType.VarChar).Value = usuarioEntity.RazonSocial;
                    sql.Parameters.Add("@TelefonoFijo", SqlDbType.VarChar).Value = usuarioEntity.TelefonoFijo;
                    sql.Parameters.Add("@TelefonoMovil", SqlDbType.VarChar).Value = usuarioEntity.TelefonoMovil;

                    sql.Parameters.Add("@IdTipoDocumento", SqlDbType.Int).Value = usuarioEntity.IdTipoDocumento;
                    sql.Parameters.Add("@NumeroDocumento", SqlDbType.VarChar).Value = usuarioEntity.NumeroDocumento;

                    sql.Parameters.Add("@RolId", SqlDbType.Int).Value = usuarioEntity.RolId;

                    sql.Parameters.Add("@TermPoliticasPrivacidad", SqlDbType.Bit).Value = usuarioEntity.RolId;
                    sql.Parameters.Add("@TermFinesComerciales", SqlDbType.Bit).Value = usuarioEntity.RolId;

                    sql.CommandTimeout = 0;

                    SqlDataReader lect = sql.ExecuteReader();
                    UsuarioEntity response = new UsuarioEntity();

                    while (lect.Read())
                    {
                        response.IdUsuario = Convert.ToInt32(lect["IdUsuario"]);
                    }

                    lect.Close();
                    connection.Close();
                    connection.Dispose();
                    return response;
                }
            } 
        }

        public async Task<UsuarioEntity> AddAsync(UsuarioEntity user)
        { 
            await using (var connection = new SqlConnection(configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open(); 
                await using (var sql = new SqlCommand("Sp_RegistrarUsuario", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@UsuarioEmail", SqlDbType.VarChar).Value = user.UsuarioEmail;
                    sql.Parameters.Add("@Contrasena", SqlDbType.VarChar).Value = user.Contrasena;
                    sql.Parameters.Add("@RolId", SqlDbType.Int).Value = user.RolId;
                    sql.Parameters.Add("@NomCliente", SqlDbType.VarChar).Value = user.NomCliente;
                    sql.Parameters.Add("@ApeCliente", SqlDbType.VarChar).Value = user.ApeCliente;
                    sql.Parameters.Add("@Ruc", SqlDbType.VarChar).Value = user.Ruc;
                    sql.Parameters.Add("@RazonSocial", SqlDbType.VarChar).Value = user.RazonSocial;
                    sql.Parameters.Add("@IdTipoDocumento", SqlDbType.Int).Value = user.IdTipoDocumento;
                    sql.Parameters.Add("@NumeroDocumento", SqlDbType.VarChar).Value = user.NumeroDocumento;
                    sql.Parameters.Add("@FechaNacimiento", SqlDbType.DateTime).Value = user.FechaNacimiento;
                    sql.Parameters.Add("@EstadoCivil", SqlDbType.Int).Value = user.EstadoCivil;
                    sql.Parameters.Add("@TelefonoFijo", SqlDbType.VarChar).Value = user.TelefonoFijo;
                    sql.Parameters.Add("@TelefonoMovil", SqlDbType.VarChar).Value = user.TelefonoMovil;
                    sql.Parameters.Add("@IdTipoCalle", SqlDbType.Int).Value = user.IdTipoCalle;
                    sql.Parameters.Add("@DireccionResidencia", SqlDbType.VarChar).Value = user.DireccionResidencia;
                    sql.Parameters.Add("@NumeroIntDpto", SqlDbType.Int).Value = user.NumeroIntDpto;
                    sql.Parameters.Add("@ManzanaLote", SqlDbType.VarChar).Value = user.ManzanaLote;
                    sql.Parameters.Add("@Referencia", SqlDbType.VarChar).Value = user.Referencia;
                    sql.Parameters.Add("@IdDepartamento", SqlDbType.VarChar).Value = user.IdDepartamento;
                    sql.Parameters.Add("@IdProvincia", SqlDbType.VarChar).Value = user.IdProvincia;
                    sql.Parameters.Add("@IdDistrito", SqlDbType.VarChar).Value = user.IdDistrito; 
                    sql.Parameters.Add("@Activo", SqlDbType.Bit).Value = user.Activo;
                    sql.Parameters.Add("@FecRegistro", SqlDbType.DateTime).Value = user.FecRegistro; 
                    sql.Parameters.Add("@UsuarioRegistra", SqlDbType.Int).Value = user.UsuarioRegistra;
                    sql.CommandTimeout = 0;

                    SqlDataReader lect = sql.ExecuteReader();
                    UsuarioEntity response = new UsuarioEntity();

                    while (lect.Read())
                    {
                        response.IdUsuario = Convert.ToInt32(lect["IdUsuario"]);
                    }

                    lect.Close();
                    connection.Close();
                    connection.Dispose(); 
                    return response;
                }
            }
        }

        public async Task<bool> UpdateAsync(UserDTO userDto)
        {
            await using (var connection = new SqlConnection(configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open(); 
                await using (var sql = new SqlCommand("Sp_ModificarUsuario", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = userDto.IdUsuario;
                    sql.Parameters.Add("@UsuarioEmail", SqlDbType.VarChar).Value = userDto.UsuarioEmail;
                    sql.Parameters.Add("@Contrasena", SqlDbType.VarChar).Value = userDto.Contrasena;
                    sql.Parameters.Add("@RolId", SqlDbType.Int).Value = userDto.RolId;
                    sql.Parameters.Add("@NomCliente", SqlDbType.VarChar).Value = userDto.NomCliente;
                    sql.Parameters.Add("@ApeCliente", SqlDbType.VarChar).Value = userDto.ApeCliente;
                    sql.Parameters.Add("@Ruc", SqlDbType.VarChar).Value = userDto.Ruc;
                    sql.Parameters.Add("@RazonSocial", SqlDbType.VarChar).Value = userDto.RazonSocial;
                    sql.Parameters.Add("@IdTipoDocumento", SqlDbType.Int).Value = userDto.IdTipoDocumento;
                    sql.Parameters.Add("@NumeroDocumento", SqlDbType.VarChar).Value = userDto.NumeroDocumento;
                    sql.Parameters.Add("@FechaNacimiento", SqlDbType.DateTime).Value = userDto.FechaNacimiento;
                    sql.Parameters.Add("@EstadoCivil", SqlDbType.Int).Value = userDto.EstadoCivil;
                    sql.Parameters.Add("@TelefonoFijo", SqlDbType.VarChar).Value = userDto.TelefonoFijo;
                    sql.Parameters.Add("@TelefonoMovil", SqlDbType.VarChar).Value = userDto.TelefonoMovil;
                    sql.Parameters.Add("@IdTipoCalle", SqlDbType.Int).Value = userDto.IdTipoCalle;
                    sql.Parameters.Add("@DireccionResidencia", SqlDbType.VarChar).Value = userDto.DireccionResidencia;
                    sql.Parameters.Add("@NumeroIntDpto", SqlDbType.Int).Value = userDto.NumeroIntDpto;
                    sql.Parameters.Add("@ManzanaLote", SqlDbType.VarChar).Value = userDto.ManzanaLote;
                    sql.Parameters.Add("@Referencia", SqlDbType.VarChar).Value = userDto.Referencia;
                    sql.Parameters.Add("@IdDepartamento", SqlDbType.VarChar).Value = userDto.IdDepartamento;
                    sql.Parameters.Add("@IdProvincia", SqlDbType.VarChar).Value = userDto.IdProvincia;
                    sql.Parameters.Add("@IdDistrito", SqlDbType.VarChar).Value = userDto.IdDistrito;
                    sql.Parameters.Add("@Activo", SqlDbType.Bit).Value = userDto.Activo;
                    sql.Parameters.Add("@FechaModifica", SqlDbType.DateTime).Value = userDto.FechaModifica;
                    sql.Parameters.Add("@UsuarioModifica", SqlDbType.Int).Value = userDto.UsuarioModifica;
                    sql.CommandTimeout = 0; 
                    SqlDataReader lect = sql.ExecuteReader();
                    var result = false; 
                    while (lect.Read()) { result = Convert.ToBoolean(lect["Respuesta"]); } 
                    lect.Close();
                    connection.Close();
                    connection.Dispose();
                    return result;
                }
            } 
        }
        public async Task<int> DeleteUserMaintence(int idUsuario , int idUsuarioLog)
        {
            await using (var connection = new SqlConnection(configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_DeleteUserMaintence", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;

                    sql.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;
                    sql.Parameters.Add("@idLogUsuario", SqlDbType.Int).Value = idUsuarioLog;

                    sql.CommandTimeout = 0;
                    //SqlDataReader lect = sql.ExecuteReader();

                    int resultado = await sql.ExecuteNonQueryAsync();

                    connection.Close();
                    connection.Dispose();
                    return resultado;
                }
            }
        }

        public async Task<bool> DeleteAsync(int idUsuario, int idUsuarioLog)
        {
            var user = _context.Usuarios.FirstOrDefault(item => item.IdUsuario == idUsuario);

            if (user != null)
            {
                user.Activo = false;
                user.UsuarioModifica = idUsuarioLog;
                _context.SaveChanges();
                return true;
            }
            else { return false; } 
        }

        public async Task<List<UserDTO>> SelectAsync(int idUsuario)
        {
            await using (var connection = new SqlConnection(configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_ListUserId", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@IdUser", SqlDbType.Int).Value = idUsuario; 
                    sql.CommandTimeout = 0;

                    SqlDataReader lect = sql.ExecuteReader();
                    List<UserDTO> dataSql = new List<UserDTO>();
                    UserDTO jsonResult;

                    while (lect.Read())
                    {
                        jsonResult = new UserDTO() 
                        {
                            IdUsuario = Convert.ToInt32(lect["IdUsuario"]),
                            UsuarioEmail = Convert.ToString(lect["UsuarioEmail"]),
                            Contrasena = Convert.ToString(lect["Contrasena"]),
                            NomCliente = Convert.ToString(lect["NomCliente"]),
                            ApeCliente = Convert.ToString(lect["ApeCliente"]),
                            Ruc = Convert.ToString(lect["Ruc"]),
                            RazonSocial = Convert.ToString(lect["RazonSocial"]),
                            IdTipoDocumento = Convert.ToInt32(lect["IdTipoDocumento"]),
                            NumeroDocumento = Convert.ToString(lect["NumeroDocumento"]),
                            RolId = Convert.ToInt32(lect["RolId"]),
                            FechaNacimiento = Convert.ToDateTime(lect["FechaNacimiento"]),
                            EstadoCivil = Convert.ToInt32(lect["EstadoCivil"]),
                            TelefonoFijo = Convert.ToString(lect["TelefonoFijo"]),
                            TelefonoMovil = Convert.ToString(lect["TelefonoMovil"]),
                            IdTipoCalle = Convert.ToInt32(lect["IdTipoCalle"]),
                            DireccionResidencia = Convert.ToString(lect["DireccionResidencia"]),
                            NumeroIntDpto = Convert.ToInt32(lect["NumeroIntDpto"]),
                            ManzanaLote = Convert.ToString(lect["ManzanaLote"]),
                            Referencia = Convert.ToString(lect["Referencia"]),
                            IdDepartamento = Convert.ToString(lect["IdDepartamento"]),
                            IdProvincia = Convert.ToString(lect["IdProvincia"]),
                            IdDistrito = Convert.ToString(lect["IdDistrito"]),
                            Activo = Convert.ToBoolean(lect["Activo"])
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


        public async Task<TotalListUserEntity> ListUserMaintence(ListUserFilterDTO request)
        {
            await using (var connection = new SqlConnection(configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("[Sp_ListUserMaintence]", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@NumeroPagina", SqlDbType.Int).Value = request.NumeroPagina;
                    sql.Parameters.Add("@NumeroRegistros", SqlDbType.Int).Value = request.NumeroRegistros;
                    sql.Parameters.Add("@rolId", SqlDbType.Int).Value = request.RolId;
                    sql.Parameters.Add("@numDocumento", SqlDbType.VarChar).Value = request.NumDocumento;
                    sql.CommandTimeout = 0;
                    SqlDataReader lect = sql.ExecuteReader();
                    TotalListUserEntity response = new TotalListUserEntity();




                    var totalRegistros = 0;
                    while (lect.Read())
                    {
                        if (totalRegistros == 0)
                        {
                            totalRegistros = Convert.ToInt32(lect["TotalRegistros"]);
                        }
                        var entidad = new ListUserEntity()
                        {
                            IdUsuario = Convert.ToInt32(lect["IdUsuario"]),
                            UsuarioEmail = Convert.ToString(lect["UsuarioEmail"]),
                            NomCliente = Convert.ToString(lect["NomCliente"]),
                            ApeCliente = Convert.ToString(lect["ApeCliente"]),
                            RolId = Convert.ToInt32(lect["RolId"]),
                            TipoDocumento = Convert.ToString(lect["TipoDocumento"]),
                            NumeroDocumento = Convert.ToString(lect["NumeroDocumento"]),
                            Ruc = Convert.ToString(lect["Ruc"]),
                            RazonSocial = Convert.ToString(lect["RazonSocial"]),
                            DescRol = Convert.ToString(lect["DescRol"]),
                            TelefonoMovil = Convert.ToString(lect["TelefonoMovil"]),

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

        public async Task<TotalListUserEntity> ListUserEstadoMaintence(ListUserEstadoFilterDTO request)
        {
            await using (var connection = new SqlConnection(configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("[Sp_ListUserEstadoMaintence]", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@NumeroPagina", SqlDbType.Int).Value = request.NumeroPagina;
                    sql.Parameters.Add("@NumeroRegistros", SqlDbType.Int).Value = request.NumeroRegistros;
                    sql.Parameters.Add("@rolId", SqlDbType.Int).Value = request.RolId;
                    sql.Parameters.Add("@IdEstado", SqlDbType.Int).Value = request.IdEstado;
                    sql.Parameters.Add("@numDocumento", SqlDbType.VarChar).Value = request.NumDocumento;
                    sql.CommandTimeout = 0;
                    SqlDataReader lect = sql.ExecuteReader();
                    TotalListUserEntity response = new TotalListUserEntity();

                    var totalRegistros = 0;
                    while (lect.Read())
                    {
                        if (totalRegistros == 0)
                        {
                            totalRegistros = Convert.ToInt32(lect["TotalRegistros"]);
                        }
                        var entidad = new ListUserEntity()
                        {
                            IdUsuario = Convert.ToInt32(lect["IdUsuario"]),
                            UsuarioEmail = Convert.ToString(lect["UsuarioEmail"]),
                            NomCliente = Convert.ToString(lect["NomCliente"]),
                            ApeCliente = Convert.ToString(lect["ApeCliente"]),
                            RolId = Convert.ToInt32(lect["RolId"]),
                            TipoDocumento = Convert.ToString(lect["TipoDocumento"]),
                            NumeroDocumento = Convert.ToString(lect["NumeroDocumento"]),
                            Ruc = Convert.ToString(lect["Ruc"]),
                            RazonSocial = Convert.ToString(lect["RazonSocial"]),
                            DescRol = Convert.ToString(lect["DescRol"]),
                            TelefonoMovil = Convert.ToString(lect["TelefonoMovil"]),
                            IdEstado = lect.IsDBNull(lect.GetOrdinal("IdEstado")) ? default(bool) : lect.GetBoolean(lect.GetOrdinal("IdEstado")),
                            Estado = lect.IsDBNull(lect.GetOrdinal("Estado")) ? default(string) : lect.GetString(lect.GetOrdinal("Estado")),

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

        public PagedList<UsuarioTempEntity> ListAsync(FilterUserDTO filterUserDTO)
        {
            filterUserDTO.PageNumber = filterUserDTO.PageNumber == 0 ? paginationOptions.DefaultPageNumber : filterUserDTO.PageNumber;

            filterUserDTO.PageSize = filterUserDTO.PageSize == 0 ? paginationOptions.DefaultPageSize : filterUserDTO.PageSize;

            //var prevaluations = _context.Usuarios.ToList();

            List<UsuarioTempEntity> prevaluations; // = new List<UsuarioEntity>();

            prevaluations = (from op in _context.Usuarios
                                        join rl in _context.Roles
                                        on op.RolId equals rl.RolId
                                        join td in _context.TipoDocumento
                                        on op.IdTipoDocumento equals td.IdTipoDocumento
                                        into tdoc
                                        from tipodoc in tdoc.DefaultIfEmpty()
                                   where op.Activo == true
                                            select new UsuarioTempEntity
                                            {
                                                IdUsuario = op.IdUsuario,
                                                UsuarioEmail = op.UsuarioEmail,
                                                NomCliente = op.NomCliente,
                                                ApeCliente = op.ApeCliente,
                                                RolId = op.RolId,
                                                TipoDocumento = tipodoc.TipoDocumento,
                                                NumeroDocumento = op.NumeroDocumento,
                                                Ruc = op.Ruc,
                                                RazonSocial = op.RazonSocial,
                                                DescRol = rl.DescRol,
                                                TelefonoMovil = op.TelefonoMovil
                                            }).ToList();

            // Filtro solo por RolId
            if (filterUserDTO.RolId != 0 && filterUserDTO.NumDocumento == null)
            {
                prevaluations = prevaluations.Where(x => x.RolId == filterUserDTO.RolId).ToList();
            }
            // Filtro por Rol y Nro Documento
            if (filterUserDTO.NumDocumento != null)
            {
                if (filterUserDTO.RolId == 7 && filterUserDTO.NumDocumento != null)
                {
                    //Busca por RUC cuando el rol = 7
                    prevaluations = prevaluations.Where(x => x.Ruc == filterUserDTO.NumDocumento).ToList();                }
                else
                {
                    //Nro documento cuando es DNI, otros
                    prevaluations = prevaluations.Where(x => x.NumeroDocumento == filterUserDTO.NumDocumento).ToList();
                }
            }

        var usuarios = PagedList<UsuarioTempEntity>.Create(prevaluations, filterUserDTO.PageNumber, filterUserDTO.PageSize);

            return usuarios;
        }

        public async Task<List<UsuarioEntity>> ValidateUsuario(string emailUsuario)
        {
            await using (var connection = new SqlConnection(configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();

                await using (var sql = new SqlCommand("Sp_ValidarEmailUsuario", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@UsuarioEmail", SqlDbType.VarChar).Value = emailUsuario;
                    sql.CommandTimeout = 0;

                    SqlDataReader lect = sql.ExecuteReader();
                    List<UsuarioEntity> usuarioEntity = new List<UsuarioEntity>();

                    while (lect.Read())
                    {
                        usuarioEntity.Add(new UsuarioEntity()
                        {
                            IdUsuario = Convert.ToInt32(lect["IdUsuario"]),
                            UsuarioEmail = Convert.ToString(lect["UsuarioEmail"])
                        });
                    }

                    lect.Close();
                    connection.Close();
                    connection.Dispose();

                    return usuarioEntity;
                }
            }
        }

        public async Task<UsuarioEntity> ValidarEstadoUsuario(string usuarioemail)
        {
            await using (var connection = new SqlConnection(configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_ValidarEstadoUsuario", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@email", SqlDbType.VarChar).Value = usuarioemail;
                    sql.CommandTimeout = 0;
                    SqlDataReader lect = sql.ExecuteReader();
                    UsuarioEntity usuario = null;

                    while (lect.Read())
                    {
                        usuario = new UsuarioEntity()
                        {
                            Activo = Convert.ToBoolean(lect["Activo"]),
                            Mensaje = Convert.ToString(lect["Mensaje"])
               
                        };
                    }

                    lect.Close();
                    connection.Close();
                    connection.Dispose();
                    return usuario;
                }
            }
        }

        public async Task<ConsultaUsuarioEntity> ConsultaDatosUsuario(int idUsuario)
        {
            await using (var connection = new SqlConnection(configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_ConsultaUsuario", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;
                    
                    sql.CommandTimeout = 0;
                    SqlDataReader lect = sql.ExecuteReader();
                    ConsultaUsuarioEntity usuario = null;

                    while (lect.Read())
                    {
                        usuario = new ConsultaUsuarioEntity()
                        {
                            NomCliente = Convert.ToString(lect["NomCliente"]),
                            ApeCliente = Convert.ToString(lect["ApeCliente"]),
                            FechaNacimiento = Convert.ToDateTime(lect["FechaNacimiento"]),
                            EstadoCivil = Convert.ToInt32(lect["EstadoCivil"]),
                            UsuarioEmail = Convert.ToString(lect["UsuarioEmail"]),
                            TelefonoMovil = Convert.ToString(lect["TelefonoMovil"])

                        };
                    }

                    lect.Close();
                    connection.Close();
                    connection.Dispose();
                    return usuario;
                }
            }
        }

        public async Task<ConsultaDatosAdicionalesUsuarioEntity> ConsultaDatosAdicionalesUsuarioById(int idUsuario, int IdPreevaluacion)
        {
            await using (var connection = new SqlConnection(configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_ListUsuarioDatosAdiconalesxIdUsuario", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;
                    sql.Parameters.Add("@IdPreevaluacion", SqlDbType.Int).Value = IdPreevaluacion;
                    sql.CommandTimeout = 0;
                    SqlDataReader lect = sql.ExecuteReader();
                    ConsultaDatosAdicionalesUsuarioEntity usuario = null;

                    while (lect.Read())
                    {
                        usuario = new ConsultaDatosAdicionalesUsuarioEntity()
                        {
                            IdUsuario = lect.IsDBNull(lect.GetOrdinal("IdUsuario")) ? default(int) : lect.GetInt32(lect.GetOrdinal("IdUsuario")),
                            NomCliente = lect.IsDBNull(lect.GetOrdinal("NomCliente")) ? default(string) : lect.GetString(lect.GetOrdinal("NomCliente")),
                            ApeCliente = lect.IsDBNull(lect.GetOrdinal("ApeCliente")) ? default(string) : lect.GetString(lect.GetOrdinal("ApeCliente")),
                            ModeloAuto = lect.IsDBNull(lect.GetOrdinal("ModeloAuto")) ? default(string) : lect.GetString(lect.GetOrdinal("ModeloAuto")),
                            MarcaAuto = lect.IsDBNull(lect.GetOrdinal("MarcaAuto")) ? default(string) : lect.GetString(lect.GetOrdinal("MarcaAuto")),
                            DireccionEntrega = lect.IsDBNull(lect.GetOrdinal("DireccionEntrega")) ? default(string) : lect.GetString(lect.GetOrdinal("DireccionEntrega")),
                            FechaFabricacion = lect.IsDBNull(lect.GetOrdinal("FechaFabricacion")) ? default(DateTime) : lect.GetDateTime(lect.GetOrdinal("FechaFabricacion")),
                            FechaNacimiento = lect.IsDBNull(lect.GetOrdinal("FechaNacimiento")) ? default(DateTime) : lect.GetDateTime(lect.GetOrdinal("FechaNacimiento")),
                            valid = true,
                            message = "Resultado Datos Adicionales",
                            IdTaller = lect.IsDBNull(lect.GetOrdinal("IdTaller")) ? default(int) : lect.GetInt32(lect.GetOrdinal("IdTaller")),
                            NombreTaller = lect.IsDBNull(lect.GetOrdinal("NombreTaller")) ? default(string) : lect.GetString(lect.GetOrdinal("NombreTaller")),
                            TelefonoFijo = lect.IsDBNull(lect.GetOrdinal("TelefonoFijo")) ? default(string) : lect.GetString(lect.GetOrdinal("TelefonoFijo")),
                            TelefonoMovil = lect.IsDBNull(lect.GetOrdinal("TelefonoMovil")) ? default(string) : lect.GetString(lect.GetOrdinal("TelefonoMovil")),
                            IdDepartamento = lect.IsDBNull(lect.GetOrdinal("IdDepartamento")) ? default(string) : lect.GetString(lect.GetOrdinal("IdDepartamento")),
                            Departamento = lect.IsDBNull(lect.GetOrdinal("Departamento")) ? default(string) : lect.GetString(lect.GetOrdinal("Departamento")),
                            IdProvincia = lect.IsDBNull(lect.GetOrdinal("IdProvincia")) ? default(string) : lect.GetString(lect.GetOrdinal("IdProvincia")),
                            Provincia = lect.IsDBNull(lect.GetOrdinal("Provincia")) ? default(string) : lect.GetString(lect.GetOrdinal("Provincia")),
                            IdDistrito = lect.IsDBNull(lect.GetOrdinal("IdDistrito")) ? default(string) : lect.GetString(lect.GetOrdinal("IdDistrito")),
                            Distrito = lect.IsDBNull(lect.GetOrdinal("Distrito")) ? default(string) : lect.GetString(lect.GetOrdinal("Distrito")),
                            DireccionResidencia = lect.IsDBNull(lect.GetOrdinal("DireccionResidencia")) ? default(string) : lect.GetString(lect.GetOrdinal("DireccionResidencia")),

                        };
                    }

                    lect.Close();
                    connection.Close();
                    connection.Dispose();
                    return usuario;
                }
            }
        }

        public async Task<bool> UserRecordDatosAdicionales(UserDataAdditionalRequestDTO userRequestDTO)
        {
            await using (var connection = new SqlConnection(configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_InsertUsuarioDatosAdiconales", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = userRequestDTO.IdUsuario;
                    sql.Parameters.Add("@IdPreevaluacion", SqlDbType.Int).Value = userRequestDTO.IdPreevaluacion;
                    sql.Parameters.Add("@ModeloAuto", SqlDbType.VarChar).Value = userRequestDTO.ModeloAuto;
                    sql.Parameters.Add("@MarcaAuto", SqlDbType.VarChar).Value = userRequestDTO.MarcaAuto;
                    sql.Parameters.Add("@FechaFabricacion", SqlDbType.DateTime).Value = userRequestDTO.FechaFabricacion;
                    sql.Parameters.Add("@DireccionEntrega", SqlDbType.VarChar).Value = userRequestDTO.DireccionEntrega;
                    sql.Parameters.Add("@FechaNacimiento", SqlDbType.DateTime).Value = userRequestDTO.FechaNacimiento;
                    sql.Parameters.Add("@Observacion", SqlDbType.VarChar).Value = userRequestDTO.Observacion;
                    sql.Parameters.Add("@UsuarioRegistro", SqlDbType.Int).Value = userRequestDTO.IdUsuarioRegistro;
                    sql.Parameters.Add("@ApeCliente", SqlDbType.VarChar).Value = userRequestDTO.ApeCliente;
                    sql.Parameters.Add("@NomCliente", SqlDbType.VarChar).Value = userRequestDTO.NomCliente;
                    sql.Parameters.Add("@TelefonoFijo", SqlDbType.VarChar).Value = userRequestDTO.TelefonoFijo;
                    sql.Parameters.Add("@TelefonoMovil", SqlDbType.VarChar).Value = userRequestDTO.TelefonoMovil;
                    sql.Parameters.Add("@DireccionResidencia", SqlDbType.VarChar).Value = userRequestDTO.DireccionResidencia;
                    sql.Parameters.Add("@IdDepartamento", SqlDbType.VarChar).Value = userRequestDTO.IdDepartamento;
                    sql.Parameters.Add("@IdProvincia", SqlDbType.VarChar).Value = userRequestDTO.IdProvincia;
                    sql.Parameters.Add("@IdDistrito", SqlDbType.VarChar).Value = userRequestDTO.IdDistrito;
                    sql.Parameters.Add("@IdTaller", SqlDbType.Int).Value = userRequestDTO.IdTaller;



                    sql.CommandTimeout = 0;
                    SqlDataReader lect = sql.ExecuteReader();
                    var result = false;
                    while (lect.Read()) { result = Convert.ToBoolean(lect["Respuesta"]); }
                    lect.Close();
                    connection.Close();
                    connection.Dispose();
                    return result;
                }
            }
        }
    }
}
