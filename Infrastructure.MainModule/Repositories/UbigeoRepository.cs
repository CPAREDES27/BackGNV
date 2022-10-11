using Application.Services.Interfaces;
using Domain.MainModule.Entities;
using Infrastructure.Data.Context;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Infrastructure.MainModule.Repositories
{
    public class UbigeoRepository : IUbigeoService
    {
        private readonly DBGNVContext context;
        private readonly IConfiguration _configuration;

        public UbigeoRepository(DBGNVContext context, IConfiguration configuration)
        {
            this.context = context;
            _configuration = configuration;
        }

        public async Task<List<UbigeoDepartamentoEntity>> GetListAsync()
        {
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_ListDepartment", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure; 
                    sql.CommandTimeout = 0;
                    SqlDataReader lect = sql.ExecuteReader();
                    List<UbigeoDepartamentoEntity> dataSql = new List<UbigeoDepartamentoEntity>();
                    UbigeoDepartamentoEntity jsonResult;

                    while (lect.Read())
                    {
                        jsonResult = new UbigeoDepartamentoEntity() { IdDepartamento = Convert.ToString(lect["Id"]), Departamento = Convert.ToString(lect["Description"]) };
                        dataSql.Add(jsonResult);
                    }

                    lect.Close();
                    connection.Close();
                    connection.Dispose();
                    return dataSql;
                }
            }
        }

        public async Task<List<UbigeoProvinciaEntity>> ListProvinceAsync(string idDepartment)
        {
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_ListProvince", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@idDepartment", SqlDbType.VarChar).Value = idDepartment;
                    sql.CommandTimeout = 0;
                    SqlDataReader lect = sql.ExecuteReader();
                    List<UbigeoProvinciaEntity> dataSql = new List<UbigeoProvinciaEntity>();
                    UbigeoProvinciaEntity jsonResult;

                    while (lect.Read())
                    {
                        jsonResult = new UbigeoProvinciaEntity() { IdProvinicia = Convert.ToString(lect["Id"]), Provincia = Convert.ToString(lect["Description"]) };
                        dataSql.Add(jsonResult);
                    }

                    lect.Close();
                    connection.Close();
                    connection.Dispose();
                    return dataSql;
                }
            }
        }

        public async Task<List<UbigeoDistritoEntity>> ListDistrictAsync(string idProvince)
        {
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_ListDistrict", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@idProvince", SqlDbType.VarChar).Value = idProvince;
                    sql.CommandTimeout = 0;
                    SqlDataReader lect = sql.ExecuteReader();
                    List<UbigeoDistritoEntity> dataSql = new List<UbigeoDistritoEntity>();
                    UbigeoDistritoEntity jsonResult;

                    while (lect.Read())
                    {
                        jsonResult = new UbigeoDistritoEntity() { IdDistrito = Convert.ToString(lect["Id"]), Distrito = Convert.ToString(lect["Description"]) };
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
 