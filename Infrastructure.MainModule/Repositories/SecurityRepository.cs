using Application.Dto;
using Application.Services.Interfaces;
using Domain.MainModule.Entities;
using Infrastructure.Data.Context;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Application.Dto.Security;
using System.Collections.Generic;

namespace Infrastructure.MainModule.Repositories
{
    public class SecurityRepository : ISecurityService
    {
        private readonly DBGNVContext _context;
        private readonly IConfiguration _configuration;

        public SecurityRepository(DBGNVContext context, IConfiguration configuration)
        {
            this._context = context;
            this._configuration = configuration;
        }

        public async Task<UsuarioEntity> GetLoginCredentials(UserLoginDTO userLogin)
        {
            //return await (from usr in context.Usuarios
            //              where usr.UsuarioEmail.ToUpper() == userLogin.Credential.ToUpper()
            //              && usr.Contrasena.ToUpper() == userLogin.Password.ToUpper()
            //              select usr)
            //              .FirstOrDefaultAsync();

            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();

                await using (var sql = new SqlCommand("Sp_LoginUsuario", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@UsuarioEmail", SqlDbType.VarChar).Value = userLogin.Credential;
                    sql.Parameters.Add("@Contrasena", SqlDbType.VarChar).Value = userLogin.Password;
                    sql.CommandTimeout = 0;

                    SqlDataReader lect = sql.ExecuteReader();
                    UsuarioEntity usuarioEntity = null;

                    while (lect.Read())
                    {
                        usuarioEntity = new UsuarioEntity();

                        usuarioEntity.IdUsuario = Convert.ToInt32(lect["IdUsuario"]);
                        usuarioEntity.UsuarioEmail = Convert.ToString(lect["UsuarioEmail"]);
                        usuarioEntity.Contrasena = Convert.ToString(lect["Contrasena"]);
                        usuarioEntity.NomCliente = Convert.ToString(lect["NomCliente"]);
                        usuarioEntity.ApeCliente = Convert.ToString(lect["ApeCliente"]);
                        usuarioEntity.Ruc = Convert.ToString(lect["Ruc"]);
                        usuarioEntity.RazonSocial = Convert.ToString(lect["RazonSocial"]);
                        usuarioEntity.IdTipoDocumento = !string.IsNullOrEmpty(lect["IdTipoDocumento"].ToString()) ? Convert.ToInt32(lect["IdTipoDocumento"]) : null;
                        usuarioEntity.NumeroDocumento = Convert.ToString(lect["NumeroDocumento"]);
                        usuarioEntity.RolId = Convert.ToInt32(lect["RolId"]);
                        usuarioEntity.FechaNacimiento = !string.IsNullOrEmpty(lect["FechaNacimiento"].ToString()) ? Convert.ToDateTime(lect["FechaNacimiento"]) : null;
                        usuarioEntity.EstadoCivil = !string.IsNullOrEmpty(lect["EstadoCivil"].ToString()) ? Convert.ToInt32(lect["EstadoCivil"]) : null;
                        usuarioEntity.TelefonoFijo = Convert.ToString(lect["TelefonoFijo"]);
                        usuarioEntity.TelefonoMovil = Convert.ToString(lect["TelefonoMovil"]);
                        usuarioEntity.IdTipoCalle = !string.IsNullOrEmpty(lect["IdTipoCalle"].ToString()) ? Convert.ToInt32(lect["IdTipoCalle"]) : null;
                        usuarioEntity.DireccionResidencia = Convert.ToString(lect["DireccionResidencia"]);
                        usuarioEntity.NumeroIntDpto = !string.IsNullOrEmpty(lect["NumeroIntDpto"].ToString()) ? Convert.ToInt32(lect["NumeroIntDpto"]) : null;
                        usuarioEntity.ManzanaLote = Convert.ToString(lect["ManzanaLote"]);
                        usuarioEntity.Referencia = Convert.ToString(lect["Referencia"]);
                        usuarioEntity.IdDepartamento = Convert.ToString(lect["IdDepartamento"]);
                        usuarioEntity.IdProvincia = Convert.ToString(lect["IdProvincia"]);
                        usuarioEntity.IdDistrito = Convert.ToString(lect["IdDistrito"]);
                    }

                    lect.Close();
                    connection.Close();
                    connection.Dispose();

                    return usuarioEntity;
                }
            }
        }
        public async Task<RolMenuDTO> RolMenu_Padre(int rol)
        {
            //return await context.Preevaluaciones.FirstOrDefaultAsync(data => data.IdPreevaluacion == id);
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_RolMenu_Padre", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@rolId", SqlDbType.Int).Value = rol;
                    sql.CommandTimeout = 0;
                    SqlDataReader lect = sql.ExecuteReader();
                    var dataSql = new RolMenuDTO();
                    MenuPadres jsonResult;

                    while (lect.Read())
                    {
                        jsonResult = new MenuPadres
                        {
                            RolId = Convert.ToInt32(lect["RolId"]),
                            IdPadre = Convert.ToInt32(lect["IdMenuPadre"]),
                            DescMenu = Convert.ToString(lect["DescMenu"]),
                            UrlImagen = Convert.ToString(lect["UrlImagen"])
                           

                        };
                        dataSql.menusPadre.Add(jsonResult);
                    }

                    lect.Close();
                    connection.Close();
                    connection.Dispose();
                    return dataSql;
                }
            }

        }

        public async Task<List<RolMenuHijoDTO>> RolMenu_Hijo(int rolId , int idMenuPadre)
        {        
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_RolMenu_Hijo", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@rolId", SqlDbType.Int).Value = rolId;
                    sql.Parameters.Add("@idMenuPadre", SqlDbType.Int).Value = idMenuPadre;
                    sql.CommandTimeout = 0;
                    SqlDataReader lect = sql.ExecuteReader();
                    var dataSql = new List<RolMenuHijoDTO>();
                    RolMenuHijoDTO jsonResult;

                    while (lect.Read())
                    {
                        jsonResult = new RolMenuHijoDTO()
                        {

                            IdMenuPadre = Convert.ToInt32(lect["IdMenuPadre"]),
                            IdMenuHijo = Convert.ToInt32(lect["IdMenuHijo"]),
                            IdOpcion = Convert.ToInt32(lect["IdOpcion"]),
                            DescMenu = Convert.ToString(lect["DescMenu"]),
                            Url = Convert.ToString(lect["Url"]),
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

        public async Task<MenuResponseDTO> GetListRolOptions(int rol)
        {
            MenuResponseDTO menuResponseDTO = new MenuResponseDTO();
            MenuDTO objMenu = new MenuDTO();

            objMenu.MenusPadre = await (from optionRol in _context.RolesMenus
                                        join optionMenuPadre in _context.MenuPadre on optionRol.OptionId equals optionMenuPadre.IdOpcion
                                        where optionRol.RolId == rol && optionMenuPadre.Activo == true
                                        orderby optionMenuPadre.Orden ascending
                                        select new MenuPadre
                                        {
                                            IdPadre = optionMenuPadre.IdOpcion,
                                            DescMenu = optionMenuPadre.DescMenu,
                                            UrlImagen = optionMenuPadre.UrlImagen
                                        }).ToListAsync();

            objMenu.MenusPadre.ForEach(itemPadre =>
            {
                itemPadre.MenusHijos = (from optionRol in _context.RolesMenus
                                        join optionMenuHijo in _context.MenuHijo on optionRol.OptionId equals optionMenuHijo.IdOpcion
                                        where optionRol.RolId == rol && optionMenuHijo.Activo == true && optionMenuHijo.IdMenuPadre == itemPadre.IdPadre
                                        select new MenuHijo
                                        {
                                            IdPadre = optionMenuHijo.IdMenuPadre,
                                            IdHijo = optionMenuHijo.IdMenuHijo,
                                            IdOpcion = optionMenuHijo.IdOpcion.Value,
                                            DescMenu = optionMenuHijo.DescMenu,
                                            Url = optionMenuHijo.Url,
                                            ActivoHijo = optionMenuHijo.Activo
                                        }).ToList();
            });
            menuResponseDTO.Menus = objMenu;
            return menuResponseDTO;
        }
    }
}
