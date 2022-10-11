using Application.Dto.MaintenanceControl;
using Application.Services.Interfaces;
using Infrastructure.Data.Context;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Infrastructure.MainModule.Repositories
{
    public class MaintenanceControlRepository : IMaintenanceControlService
    {
        private readonly DBGNVContext context;
        private readonly IConfiguration configuration;

        public MaintenanceControlRepository(DBGNVContext context
            ,IConfiguration configuration) 
        {
            this.context = context;
            this.configuration = configuration;
        }

        public async Task<List<MaintenanceControlDTO>> ListAsync(int keyOption)
        {
            await using (var connection = new SqlConnection(configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_ListMaintenanceOption", connection))
                { 
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@KeyOption", SqlDbType.Int).Value = keyOption;
                    sql.CommandTimeout = 0;
                    SqlDataReader lect = sql.ExecuteReader();
                    List<MaintenanceControlDTO> dataSql = new List<MaintenanceControlDTO>();
                    MaintenanceControlDTO jsonResult;

                    while (lect.Read())
                    {
                        jsonResult = new MaintenanceControlDTO() { Id = Convert.ToInt32(lect["Id"]), Description = Convert.ToString(lect["Description"]) };
                        dataSql.Add(jsonResult);
                    }

                    lect.Close();
                    connection.Close();
                    connection.Dispose();
                    return dataSql;
                }  
            }
        }

        public async Task<List<StateTypeDTO>> ListStateTypeAsync(string tipoTabla)
        {
            await using (var connection = new SqlConnection(configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_ListTipoEstado", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@TipoTabla", SqlDbType.VarChar).Value = tipoTabla;
                    sql.CommandTimeout = 0;
                    SqlDataReader lect = sql.ExecuteReader();
                    List<StateTypeDTO> dataSql = new List<StateTypeDTO>();
                    StateTypeDTO jsonResult;

                    while (lect.Read())
                    {
                        jsonResult = new StateTypeDTO()
                        {
                            idEstado = Convert.ToInt32(lect["idEstado"]),
                            Estado = Convert.ToString(lect["Estado"]),
                            TipoTabla = Convert.ToString(lect["TipoTabla"])
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
    }
}
