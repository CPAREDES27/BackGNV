using Application.Dto.UploadDocuments.RequestFinancing;
using Application.Services.Interfaces;
using Application.Services.Util.SecurityDirectory;
using Domain.MainModule.Entities;
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
using System.Threading.Tasks;

namespace Infrastructure.MainModule.Repositories
{
    public class FinancingRequestRepository : IFinancingRequestService
    {
        private readonly DBGNVContext context;
        private readonly IConfiguration _configuration;
        private readonly IMasterRepository masterRepository;

        public FinancingRequestRepository(DBGNVContext context,
            IConfiguration configuration,
            IMasterRepository masterRepository)
        {
            this.context = context;
            this._configuration = configuration;
            this.masterRepository = masterRepository;
        }

        public async Task<RegistroSolicitudFinanciamientoEntity> AddCustomerFinancingAsync(RegistroSolicitudFinanciamientoEntity registroSolicitudFinanciamientoEntity)
        {
            try
            {
                await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Sp_RegistrarSolicitudFinanciamiento", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = registroSolicitudFinanciamientoEntity.IdCliente;
                    cmd.Parameters.Add("@Nombres", SqlDbType.VarChar).Value = registroSolicitudFinanciamientoEntity.Nombres;
                    cmd.Parameters.Add("@Apellidos", SqlDbType.VarChar).Value = registroSolicitudFinanciamientoEntity.Apellidos;
                    cmd.Parameters.Add("@NumeroDocumento", SqlDbType.VarChar).Value = registroSolicitudFinanciamientoEntity.NumeroDocumento;
                    cmd.Parameters.Add("@FechaNacimiento", SqlDbType.DateTime).Value = registroSolicitudFinanciamientoEntity.FechaNacimiento;
                    cmd.Parameters.Add("@EstadoCivil", SqlDbType.Int).Value = registroSolicitudFinanciamientoEntity.EstadoCivil;
                    cmd.Parameters.Add("@CorreoElectronico", SqlDbType.VarChar).Value = registroSolicitudFinanciamientoEntity.CorreoElectronico;
                    cmd.Parameters.Add("@Celular", SqlDbType.VarChar).Value = registroSolicitudFinanciamientoEntity.Celular;
                    cmd.Parameters.Add("@IdNivelEstudios", SqlDbType.Int).Value = registroSolicitudFinanciamientoEntity.IdNivelEstudios;
                    cmd.Parameters.Add("@Ocupacion", SqlDbType.VarChar).Value = registroSolicitudFinanciamientoEntity.Ocupacion;

                    cmd.Parameters.Add("@TipoContrato", SqlDbType.VarChar).Value = registroSolicitudFinanciamientoEntity.TipoContrato;
                    cmd.Parameters.Add("@TiempoEmpleoCliente", SqlDbType.VarChar).Value = registroSolicitudFinanciamientoEntity.TiempoEmpleoCliente;
                    cmd.Parameters.Add("@TipoCalle", SqlDbType.VarChar).Value = registroSolicitudFinanciamientoEntity.TipoCalle;
                    cmd.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = registroSolicitudFinanciamientoEntity.Direccion;
                    cmd.Parameters.Add("@NumeroInterior", SqlDbType.Int).Value = registroSolicitudFinanciamientoEntity.NumeroInterior;
                    cmd.Parameters.Add("@MzLt", SqlDbType.VarChar).Value = registroSolicitudFinanciamientoEntity.MzLt;
                    cmd.Parameters.Add("@Distrito", SqlDbType.VarChar).Value = registroSolicitudFinanciamientoEntity.Distrito;
                    cmd.Parameters.Add("@ReferenciaDomicilio", SqlDbType.VarChar).Value = registroSolicitudFinanciamientoEntity.ReferenciaDomicilio;
                    cmd.Parameters.Add("@TipoVivienda", SqlDbType.VarChar).Value = registroSolicitudFinanciamientoEntity.TipoVivienda;
                    cmd.Parameters.Add("@TiempoAnoVivienda", SqlDbType.Int).Value = registroSolicitudFinanciamientoEntity.TiempoAnoVivienda;
                    cmd.Parameters.Add("@TiempoMesesVivienda", SqlDbType.Int).Value = registroSolicitudFinanciamientoEntity.TiempoMesesVivienda;

                    cmd.Parameters.Add("@IsGasNatural", SqlDbType.Bit).Value = registroSolicitudFinanciamientoEntity.IsGasNatural;
                    cmd.Parameters.Add("@NumeroPlaca", SqlDbType.VarChar).Value = registroSolicitudFinanciamientoEntity.NumeroPlaca;
                    cmd.Parameters.Add("@MarcaAuto", SqlDbType.VarChar).Value = registroSolicitudFinanciamientoEntity.MarcaAuto;
                    cmd.Parameters.Add("@ModeloAuto", SqlDbType.VarChar).Value = registroSolicitudFinanciamientoEntity.ModeloAuto;
                    cmd.Parameters.Add("@FechaFabricacion", SqlDbType.VarChar).Value = registroSolicitudFinanciamientoEntity.FechaFabricacion;
                    cmd.Parameters.Add("@NumeroTarjetaPropiedad", SqlDbType.VarChar).Value = registroSolicitudFinanciamientoEntity.NumeroTarjetaPropiedad;

                    cmd.Parameters.Add("@TipoUsoVehicular", SqlDbType.Bit).Value = registroSolicitudFinanciamientoEntity.TipoUsoVehicular;
                    cmd.Parameters.Add("@EstadoVehiculo", SqlDbType.Int).Value = registroSolicitudFinanciamientoEntity.EstadoVehiculo;
                    cmd.Parameters.Add("@IngresoMensual", SqlDbType.VarChar).Value = registroSolicitudFinanciamientoEntity.IngresoMensual;
                    cmd.Parameters.Add("@NumeroHijos", SqlDbType.Int).Value = registroSolicitudFinanciamientoEntity.NumeroHijos;
                    cmd.Parameters.Add("@NombreEstablecimiento", SqlDbType.VarChar).Value = registroSolicitudFinanciamientoEntity.NombreEstablecimiento;
                    cmd.Parameters.Add("@TipoFinanciamiento", SqlDbType.VarChar).Value = registroSolicitudFinanciamientoEntity.TipoFinanciamiento;
                    cmd.Parameters.Add("@TipoCredito", SqlDbType.Int).Value = registroSolicitudFinanciamientoEntity.TipoCredito;
                    cmd.Parameters.Add("@PlazoCuotasFinanciamiento", SqlDbType.VarChar).Value = registroSolicitudFinanciamientoEntity.PlazoCuotasFinanciamiento;

                    cmd.Parameters.Add("@MontoFinanciamiento", SqlDbType.VarChar).Value = registroSolicitudFinanciamientoEntity.MontoFinanciamiento;

                    if (registroSolicitudFinanciamientoEntity.ClaseVehiculo == null)
                    {
                        cmd.Parameters.Add("@ClaseVehiculo", SqlDbType.VarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters.Add("@ClaseVehiculo", SqlDbType.VarChar).Value = registroSolicitudFinanciamientoEntity.ClaseVehiculo;
                    }
                    cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar).Value = registroSolicitudFinanciamientoEntity.Observaciones;

                    if (registroSolicitudFinanciamientoEntity.NumeroAsientos == null)
                    {
                        cmd.Parameters.Add("@NumeroAsientos", SqlDbType.VarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters.Add("@NumeroAsientos", SqlDbType.VarChar).Value = registroSolicitudFinanciamientoEntity.NumeroAsientos;
                    }

                    if (registroSolicitudFinanciamientoEntity.NumeroMotor == null)
                    {
                        cmd.Parameters.Add("@NumeroMotor", SqlDbType.VarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters.Add("@NumeroMotor", SqlDbType.VarChar).Value = registroSolicitudFinanciamientoEntity.NumeroMotor;
                    }
                    if (registroSolicitudFinanciamientoEntity.NumeroSerie == null)
                    {
                        cmd.Parameters.Add("@NumeroSerie", SqlDbType.VarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters.Add("@NumeroSerie", SqlDbType.VarChar).Value = registroSolicitudFinanciamientoEntity.NumeroSerie;
                    }

                    cmd.Parameters.Add("@NumeroScore", SqlDbType.Int).Value = registroSolicitudFinanciamientoEntity.NumeroScore;
                    cmd.Parameters.Add("@idPreevaluacion", SqlDbType.Int).Value = registroSolicitudFinanciamientoEntity.IdPreevaluacion;

                    //@FlagContratoFinanciamiento
                    if (registroSolicitudFinanciamientoEntity.FlagContratoFinanciamiento == null)
                    {
                        cmd.Parameters.Add("@FlagContratoFinanciamiento", SqlDbType.Bit).Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters.Add("@FlagContratoFinanciamiento", SqlDbType.Bit).Value = registroSolicitudFinanciamientoEntity.FlagContratoFinanciamiento;
                    }

                    //@FlagFormatoConformidad
                    if (registroSolicitudFinanciamientoEntity.FlagFormatoConformidad == null)
                    {
                        cmd.Parameters.Add("@FlagFormatoConformidad", SqlDbType.Bit).Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters.Add("@FlagFormatoConformidad", SqlDbType.Bit).Value = registroSolicitudFinanciamientoEntity.FlagFormatoConformidad;
                    }

                    //@FlagDNI
                    if (registroSolicitudFinanciamientoEntity.FlagDNI == null)
                    {
                        cmd.Parameters.Add("@FlagDNI", SqlDbType.Bit).Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters.Add("@FlagDNI", SqlDbType.Bit).Value = registroSolicitudFinanciamientoEntity.FlagDNI;
                    }

                    //@FlagDNI
                    if (registroSolicitudFinanciamientoEntity.DigitoVerificadorDNI == null)
                    {
                        cmd.Parameters.Add("@DigitoVerificadorDNI", SqlDbType.VarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters.Add("@DigitoVerificadorDNI", SqlDbType.VarChar).Value = registroSolicitudFinanciamientoEntity.DigitoVerificadorDNI;
                    }

                    if (registroSolicitudFinanciamientoEntity.FlagPoliticasCondiciones == null)
                    {
                        cmd.Parameters.Add("@FlagpoliticasCondiciones", SqlDbType.Bit).Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters.Add("@FlagpoliticasCondiciones", SqlDbType.Bit).Value = registroSolicitudFinanciamientoEntity.FlagPoliticasCondiciones;
                    }

                    cmd.Parameters.Add("@MesAnio", SqlDbType.NVarChar).Value = registroSolicitudFinanciamientoEntity.MesAnio;

                    cmd.Parameters.Add("@idSfClienteTemp", SqlDbType.BigInt).Value = registroSolicitudFinanciamientoEntity.IdSfClientetemp;



                    cmd.CommandTimeout = 0;

                    SqlDataReader lect = cmd.ExecuteReader();
                    RegistroSolicitudFinanciamientoEntity _registroSolicitudFinanciamiento = new RegistroSolicitudFinanciamientoEntity();

                    while (lect.Read())
                    {
                        _registroSolicitudFinanciamiento.IdSfCliente = Convert.ToInt32(lect["IdSfCliente"]);
                    }

                    lect.Close();
                    connection.Close();
                    connection.Dispose();

                    return _registroSolicitudFinanciamiento;
                }
            }catch(Exception ex)
            {
                RegistroSolicitudFinanciamientoEntity _registroSolicitudFinanciamiento = new RegistroSolicitudFinanciamientoEntity();
                return _registroSolicitudFinanciamiento;
            }
        }


        public async Task<List<ConsultaTallerEntity>> ListServiceCenterAsync(string nombre,int idProveedor)
        {
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_ListServiceCenter", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre;
                    sql.Parameters.Add("@idProveedor", SqlDbType.Int).Value = idProveedor;
                    SqlDataReader lect = sql.ExecuteReader();
                    var response = new List<ConsultaTallerEntity>();
                    ConsultaTallerEntity jsonResult;

                    while (lect.Read())
                    {
                        jsonResult = new ConsultaTallerEntity()
                        {
                            Nombre = Convert.ToString(lect["Nombre"]),
                            Direccion = Convert.ToString(lect["Direccion"]),
                            Activo = Convert.ToInt32(lect["Activo"]),
                            IdProveedor = Convert.ToInt32(lect["IdProveedor"]),
                            IdTaller = Convert.ToInt32(lect["IdTaller"]),
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

        public async Task<List<RegistroSolicitudFinanciamientoEntity>> UpdateIdAsync(int idSfClient, int idWorkshop)
        {
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("Sp_UpdateIdServiceCenter", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@idSfClient", SqlDbType.Int).Value = idSfClient;
                cmd.Parameters.Add("@idWorkshop", SqlDbType.Int).Value = idWorkshop;
                cmd.CommandTimeout = 0;

                SqlDataReader lect = cmd.ExecuteReader();
                List<RegistroSolicitudFinanciamientoEntity> dataSql = new List<RegistroSolicitudFinanciamientoEntity>();
                RegistroSolicitudFinanciamientoEntity jsonResult;

                while (lect.Read())
                {
                    jsonResult = new RegistroSolicitudFinanciamientoEntity() { Value = Convert.ToInt32(lect["Value"]) };
                    dataSql.Add(jsonResult);
                }

                lect.Close();
                connection.Close();
                connection.Dispose();

                return dataSql;
            }
        }

        public async Task<bool> UploadAsync(UploadDocumentsDTO uploadDocumentsDto, int idSfClient)
        {
            try
            {
                var result = await masterRepository.GetCredentialsUrl(DirectoryConst.PublicFinancingRequestKey);

                if (result != null)
                {
                    DateTime dateTimeCreate = DateTime.Now;
                    //Se crea la carpeta de un cliente para n archivos
                    
                    var tipoProceso = uploadDocumentsDto.Archivos.Select(x => x.ProcessType).FirstOrDefault();
                    if(tipoProceso == null )
                    {
                        tipoProceso = "SF";
                    }
                    var fileDirectoryClient = tipoProceso + "_" + uploadDocumentsDto.IdCliente + "_" + $"{DateTime.Now:ddMMyyyy_HHmmssffff}";
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
                        await RegisterFilePathAsync($"{lastFileName}"+ @"\" + _uploadDocumentsDto.FileName, _uploadDocumentsDto.ProcessType, idSfClient, _uploadDocumentsDto.NombreDocumento, _uploadDocumentsDto.IdEstado);

                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
          
        }

        public async Task<bool> RegisterFilePathAsync(string root, string processType, int idSfClient,string nombreDocumento,int idEstado)
        {
            bool result = false;
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_Insert_UploadDocument_FinancingRequest", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@root", SqlDbType.VarChar).Value = root;
                    sql.Parameters.Add("@processType", SqlDbType.VarChar).Value = processType;
                    sql.Parameters.Add("@idSfClient", SqlDbType.Int).Value = idSfClient;
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

        public async Task<bool> AddCustomerFinancingAsyncTemp(RegistroSolicitudFinanciamientoEntity registroSolicitudFinanciamientoEntity)
        {
            bool result = false;
            try
            {
                await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("Sp_RegistrarSolicitudFinanciamientoTemp", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdSfCliente", SqlDbType.BigInt).Value = registroSolicitudFinanciamientoEntity.IdSfCliente;
                    cmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = registroSolicitudFinanciamientoEntity.IdCliente;
                    cmd.Parameters.Add("@Nombres", SqlDbType.VarChar).Value = registroSolicitudFinanciamientoEntity.Nombres;
                    cmd.Parameters.Add("@Apellidos", SqlDbType.VarChar).Value = registroSolicitudFinanciamientoEntity.Apellidos;
                    cmd.Parameters.Add("@NumeroDocumento", SqlDbType.VarChar).Value = registroSolicitudFinanciamientoEntity.NumeroDocumento;
                    cmd.Parameters.Add("@FechaNacimiento", SqlDbType.DateTime).Value = registroSolicitudFinanciamientoEntity.FechaNacimiento;
                    cmd.Parameters.Add("@EstadoCivil", SqlDbType.Int).Value = registroSolicitudFinanciamientoEntity.EstadoCivil;
                    cmd.Parameters.Add("@CorreoElectronico", SqlDbType.VarChar).Value = registroSolicitudFinanciamientoEntity.CorreoElectronico;
                    cmd.Parameters.Add("@Celular", SqlDbType.VarChar).Value = registroSolicitudFinanciamientoEntity.Celular;
                    cmd.Parameters.Add("@IdNivelEstudios", SqlDbType.Int).Value = registroSolicitudFinanciamientoEntity.IdNivelEstudios;
                    cmd.Parameters.Add("@Ocupacion", SqlDbType.VarChar).Value = registroSolicitudFinanciamientoEntity.Ocupacion;

                    cmd.Parameters.Add("@TipoContrato", SqlDbType.VarChar).Value = registroSolicitudFinanciamientoEntity.TipoContrato;
                    cmd.Parameters.Add("@TiempoEmpleoCliente", SqlDbType.VarChar).Value = registroSolicitudFinanciamientoEntity.TiempoEmpleoCliente;
                    cmd.Parameters.Add("@TipoCalle", SqlDbType.VarChar).Value = registroSolicitudFinanciamientoEntity.TipoCalle;
                    cmd.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = registroSolicitudFinanciamientoEntity.Direccion;
                    cmd.Parameters.Add("@NumeroInterior", SqlDbType.Int).Value = registroSolicitudFinanciamientoEntity.NumeroInterior;
                    cmd.Parameters.Add("@MzLt", SqlDbType.VarChar).Value = registroSolicitudFinanciamientoEntity.MzLt;
                    cmd.Parameters.Add("@Distrito", SqlDbType.VarChar).Value = registroSolicitudFinanciamientoEntity.Distrito;
                    cmd.Parameters.Add("@ReferenciaDomicilio", SqlDbType.VarChar).Value = registroSolicitudFinanciamientoEntity.ReferenciaDomicilio;
                    cmd.Parameters.Add("@TipoVivienda", SqlDbType.VarChar).Value = registroSolicitudFinanciamientoEntity.TipoVivienda;
                    cmd.Parameters.Add("@TiempoAnoVivienda", SqlDbType.Int).Value = registroSolicitudFinanciamientoEntity.TiempoAnoVivienda;
                    cmd.Parameters.Add("@TiempoMesesVivienda", SqlDbType.Int).Value = registroSolicitudFinanciamientoEntity.TiempoMesesVivienda;

                    cmd.Parameters.Add("@IsGasNatural", SqlDbType.Bit).Value = registroSolicitudFinanciamientoEntity.IsGasNatural;
                    cmd.Parameters.Add("@NumeroPlaca", SqlDbType.VarChar).Value = registroSolicitudFinanciamientoEntity.NumeroPlaca;
                    cmd.Parameters.Add("@MarcaAuto", SqlDbType.VarChar).Value = registroSolicitudFinanciamientoEntity.MarcaAuto;
                    cmd.Parameters.Add("@ModeloAuto", SqlDbType.VarChar).Value = registroSolicitudFinanciamientoEntity.ModeloAuto;
                    cmd.Parameters.Add("@FechaFabricacion", SqlDbType.VarChar).Value = registroSolicitudFinanciamientoEntity.FechaFabricacion;
                    cmd.Parameters.Add("@NumeroTarjetaPropiedad", SqlDbType.VarChar).Value = registroSolicitudFinanciamientoEntity.NumeroTarjetaPropiedad;

                    cmd.Parameters.Add("@TipoUsoVehicular", SqlDbType.Bit).Value = registroSolicitudFinanciamientoEntity.TipoUsoVehicular;
                    cmd.Parameters.Add("@EstadoVehiculo", SqlDbType.Int).Value = registroSolicitudFinanciamientoEntity.EstadoVehiculo;
                    cmd.Parameters.Add("@IngresoMensual", SqlDbType.VarChar).Value = registroSolicitudFinanciamientoEntity.IngresoMensual;
                    cmd.Parameters.Add("@NumeroHijos", SqlDbType.Int).Value = registroSolicitudFinanciamientoEntity.NumeroHijos;
                    cmd.Parameters.Add("@NombreEstablecimiento", SqlDbType.VarChar).Value = registroSolicitudFinanciamientoEntity.NombreEstablecimiento;
                    cmd.Parameters.Add("@TipoFinanciamiento", SqlDbType.VarChar).Value = registroSolicitudFinanciamientoEntity.TipoFinanciamiento;
                    cmd.Parameters.Add("@TipoCredito", SqlDbType.Int).Value = registroSolicitudFinanciamientoEntity.TipoCredito;
                    cmd.Parameters.Add("@PlazoCuotasFinanciamiento", SqlDbType.VarChar).Value = registroSolicitudFinanciamientoEntity.PlazoCuotasFinanciamiento;

                    cmd.Parameters.Add("@MontoFinanciamiento", SqlDbType.Int).Value = registroSolicitudFinanciamientoEntity.MontoFinanciamiento;

                    if (registroSolicitudFinanciamientoEntity.ClaseVehiculo == null)
                    {
                        cmd.Parameters.Add("@ClaseVehiculo", SqlDbType.VarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters.Add("@ClaseVehiculo", SqlDbType.VarChar).Value = registroSolicitudFinanciamientoEntity.ClaseVehiculo;
                    }
                    cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar).Value = registroSolicitudFinanciamientoEntity.Observaciones;

                    if (registroSolicitudFinanciamientoEntity.NumeroAsientos == null)
                    {
                        cmd.Parameters.Add("@NumeroAsientos", SqlDbType.VarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters.Add("@NumeroAsientos", SqlDbType.VarChar).Value = registroSolicitudFinanciamientoEntity.NumeroAsientos;
                    }

                    if (registroSolicitudFinanciamientoEntity.NumeroMotor == null)
                    {
                        cmd.Parameters.Add("@NumeroMotor", SqlDbType.VarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters.Add("@NumeroMotor", SqlDbType.VarChar).Value = registroSolicitudFinanciamientoEntity.NumeroMotor;
                    }
                    if (registroSolicitudFinanciamientoEntity.NumeroSerie == null)
                    {
                        cmd.Parameters.Add("@NumeroSerie", SqlDbType.VarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters.Add("@NumeroSerie", SqlDbType.VarChar).Value = registroSolicitudFinanciamientoEntity.NumeroSerie;
                    }

                    cmd.Parameters.Add("@NumeroScore", SqlDbType.Int).Value = registroSolicitudFinanciamientoEntity.NumeroScore;
                    cmd.Parameters.Add("@idPreevaluacion", SqlDbType.Int).Value = registroSolicitudFinanciamientoEntity.IdPreevaluacion;


                    //@FlagContratoFinanciamiento
                    if (registroSolicitudFinanciamientoEntity.FlagContratoFinanciamiento == null)
                    {
                        cmd.Parameters.Add("@FlagContratoFinanciamiento", SqlDbType.Bit).Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters.Add("@FlagContratoFinanciamiento", SqlDbType.Bit).Value = registroSolicitudFinanciamientoEntity.FlagContratoFinanciamiento;
                    }

                    //@FlagFormatoConformidad
                    if (registroSolicitudFinanciamientoEntity.FlagFormatoConformidad == null)
                    {
                        cmd.Parameters.Add("@FlagFormatoConformidad", SqlDbType.Bit).Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters.Add("@FlagFormatoConformidad", SqlDbType.Bit).Value = registroSolicitudFinanciamientoEntity.FlagFormatoConformidad;
                    }

                    //@FlagDNI
                    if (registroSolicitudFinanciamientoEntity.FlagDNI == null)
                    {
                        cmd.Parameters.Add("@FlagDNI", SqlDbType.Bit).Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters.Add("@FlagDNI", SqlDbType.Bit).Value = registroSolicitudFinanciamientoEntity.FlagDNI;
                    }

                    //@FlagDNI
                    if (registroSolicitudFinanciamientoEntity.DigitoVerificadorDNI == null)
                    {
                        cmd.Parameters.Add("@DigitoVerificadorDNI", SqlDbType.VarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters.Add("@DigitoVerificadorDNI", SqlDbType.VarChar).Value = registroSolicitudFinanciamientoEntity.DigitoVerificadorDNI;
                    }

                    if (registroSolicitudFinanciamientoEntity.FlagPoliticasCondiciones == null)
                    {
                        cmd.Parameters.Add("@FlagpoliticasCondiciones", SqlDbType.Bit).Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters.Add("@FlagpoliticasCondiciones", SqlDbType.Bit).Value = registroSolicitudFinanciamientoEntity.FlagPoliticasCondiciones;
                    }

                    if (registroSolicitudFinanciamientoEntity.MesAnio == null)
                    {
                        cmd.Parameters.Add("@MesAnio", SqlDbType.NVarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters.Add("@MesAnio", SqlDbType.NVarChar).Value = registroSolicitudFinanciamientoEntity.MesAnio;
                    }

                    cmd.CommandTimeout = 0;

                    SqlDataReader lect = cmd.ExecuteReader();
                    RegistroSolicitudFinanciamientoEntity _registroSolicitudFinanciamiento = new RegistroSolicitudFinanciamientoEntity();

                    while (lect.Read())
                    {
                        _registroSolicitudFinanciamiento.IdSfCliente = Convert.ToInt32(lect["IdSfCliente"]);
                    }

                    lect.Close();
                    connection.Close();
                    connection.Dispose();

                    result = true;

                    return result;
                }
            }
            catch (Exception ex)
            {
                string mes = ex.Message.ToString();
                return false;
            }
            
        }

        public async Task<TotalListPendienteSolicitud> ListPendienteTempSolicitud(int IdTipoDocumento, string Numdocumento, int NumPag, int NumReg)
        {
            if (Numdocumento == null)
            {
                Numdocumento = "";
            }

            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_ListaPendienteSolicitud", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@idTipoDocumento", SqlDbType.Int).Value = IdTipoDocumento;
                    sql.Parameters.Add("@NumDocumento", SqlDbType.VarChar).Value = Numdocumento;
                    sql.Parameters.Add("@NumeroPagina", SqlDbType.VarChar).Value = NumPag;
                    sql.Parameters.Add("@NumeroRegistros", SqlDbType.VarChar).Value = NumReg;

                    SqlDataReader lect = sql.ExecuteReader();

                    TotalListPendienteSolicitud response = new TotalListPendienteSolicitud();

                    //var response = new List<ListPendienteSolicitud>();
                    //ListPendienteSolicitud jsonResult;

                    var totalRegistros = 0;

                    while (lect.Read())
                    {
                        if (totalRegistros == 0)
                        {
                            totalRegistros = Convert.ToInt32(lect["TotalRegistros"]);
                        }

                        var entidad = new ListPendienteSolicitud()
                        {
                            idsfcliente = Convert.ToInt32(lect["idsfcliente"]),
                            idcliente = Convert.ToInt32(lect["idcliente"]),
                            Nombres = Convert.ToString(lect["Nombres"]),
                            Apellidos = Convert.ToString(lect["Apellidos"]),
                            IdPreevaluacion = lect.IsDBNull(lect.GetOrdinal("IdPreevaluacion")) ? default(int) : lect.GetInt32(lect.GetOrdinal("IdPreevaluacion")), //Convert.ToInt32(lect["IdPreevaluacion"]),
                            Producto = lect.IsDBNull(lect.GetOrdinal("Producto")) ? default(string) : lect.GetString(lect.GetOrdinal("Producto")), //Convert.ToString(lect["Producto"]),
                            FechaRegistro = lect.IsDBNull(lect.GetOrdinal("FechaRegistro")) ? default(DateTime) : lect.GetDateTime(lect.GetOrdinal("FechaRegistro")), //Convert.ToDateTime(lect["FechaRegistro"]),

                        };
                        response.Data.Add(entidad);
                        //response.Add(jsonResult);
                    }

                    var totalPaginaInt = 0;
                    var totalPaginaDec = 0;
                    totalPaginaInt = (totalRegistros / NumReg);
                    totalPaginaDec = (totalRegistros % NumReg);
                    if (totalPaginaDec > 0)
                    {
                        totalPaginaInt = totalPaginaInt + 1;
                    }
                    response.Meta.TotalCount = totalRegistros;
                    response.Meta.PageSize = NumReg;
                    response.Meta.CurrentPage = NumPag;
                    response.Meta.TotalPages = totalPaginaInt;

                    lect.Close();
                    connection.Close();
                    connection.Dispose();
                    return response;
                }
            }
        }

        public async Task<List<ListPendienteSolicitudId>> ListPendienteSolicitidById(Int64 IdSfCliente)
        {
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_ListaPendienteSolicitudById", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@IdSfCliente", SqlDbType.BigInt).Value = IdSfCliente;
                    SqlDataReader lect = sql.ExecuteReader();
                    var response = new List<ListPendienteSolicitudId>();
                    ListPendienteSolicitudId jsonResult;

                    while (lect.Read())
                    {
                        jsonResult = new ListPendienteSolicitudId()
                        {
                            IdSfCliente = lect.IsDBNull(lect.GetOrdinal("IdSfCliente")) ? default(Int64) : lect.GetInt64(lect.GetOrdinal("IdSfCliente")),
                            IdCliente = lect.IsDBNull(lect.GetOrdinal("IdCliente")) ? default(Int32) : lect.GetInt32(lect.GetOrdinal("IdCliente")),
                            Nombres = lect.IsDBNull(lect.GetOrdinal("Nombres")) ? default(string) : lect.GetString(lect.GetOrdinal("Nombres")),
                            Apellidos = lect.IsDBNull(lect.GetOrdinal("Apellidos")) ? default(string) : lect.GetString(lect.GetOrdinal("Apellidos")),
                            NumeroDocumento = lect.IsDBNull(lect.GetOrdinal("NumeroDocumento")) ? default(string) : lect.GetString(lect.GetOrdinal("NumeroDocumento")),
                            FechaNacimiento = lect.IsDBNull(lect.GetOrdinal("FechaNacimiento")) ? default(DateTime) : lect.GetDateTime(lect.GetOrdinal("FechaNacimiento")),
                            EstadoCivil = lect.IsDBNull(lect.GetOrdinal("EstadoCivil")) ? default(Int32) : lect.GetInt32(lect.GetOrdinal("EstadoCivil")),
                            CorreoElectronico = lect.IsDBNull(lect.GetOrdinal("CorreoElectronico")) ? default(string) : lect.GetString(lect.GetOrdinal("CorreoElectronico")),
                            Celular = lect.IsDBNull(lect.GetOrdinal("Celular")) ? default(string) : lect.GetString(lect.GetOrdinal("Celular")),
                            IdNivelEstudios = lect.IsDBNull(lect.GetOrdinal("IdNivelEstudios")) ? default(Int32) : lect.GetInt32(lect.GetOrdinal("IdNivelEstudios")),
                            Ocupacion = lect.IsDBNull(lect.GetOrdinal("Ocupacion")) ? default(string) : lect.GetString(lect.GetOrdinal("Ocupacion")),
                            TipoContrato = lect.IsDBNull(lect.GetOrdinal("TipoContrato")) ? default(string) : lect.GetString(lect.GetOrdinal("TipoContrato")),
                            TiempoEmpleoCliente = lect.IsDBNull(lect.GetOrdinal("TiempoEmpleoCliente")) ? default(string) : lect.GetString(lect.GetOrdinal("TiempoEmpleoCliente")),
                            TipoCalle = lect.IsDBNull(lect.GetOrdinal("TipoCalle")) ? default(string) : lect.GetString(lect.GetOrdinal("TipoCalle")),
                            Direccion = lect.IsDBNull(lect.GetOrdinal("Direccion")) ? default(string) : lect.GetString(lect.GetOrdinal("Direccion")),
                            NumeroInterior = lect.IsDBNull(lect.GetOrdinal("NumeroInterior")) ? default(Int32) : lect.GetInt32(lect.GetOrdinal("NumeroInterior")),
                            MzLt = lect.IsDBNull(lect.GetOrdinal("MzLt")) ? default(string) : lect.GetString(lect.GetOrdinal("MzLt")),
                            Distrito = lect.IsDBNull(lect.GetOrdinal("Distrito")) ? default(string) : lect.GetString(lect.GetOrdinal("Distrito")),
                            ReferenciaDomicilio = lect.IsDBNull(lect.GetOrdinal("ReferenciaDomicilio")) ? default(string) : lect.GetString(lect.GetOrdinal("ReferenciaDomicilio")),
                            TipoVivienda = lect.IsDBNull(lect.GetOrdinal("TipoVivienda")) ? default(string) : lect.GetString(lect.GetOrdinal("TipoVivienda")),
                            TiempoAnoVivienda = lect.IsDBNull(lect.GetOrdinal("TiempoAnoVivienda")) ? default(Int32) : lect.GetInt32(lect.GetOrdinal("TiempoAnoVivienda")),
                            TiempoMesesVivienda = lect.IsDBNull(lect.GetOrdinal("TiempoMesesVivienda")) ? default(Int32) : lect.GetInt32(lect.GetOrdinal("TiempoMesesVivienda")),
                            IsGasNatural = lect.IsDBNull(lect.GetOrdinal("IsGasNatural")) ? default(bool) : lect.GetBoolean(lect.GetOrdinal("IsGasNatural")),
                            NumeroPlaca = lect.IsDBNull(lect.GetOrdinal("NumeroPlaca")) ? default(string) : lect.GetString(lect.GetOrdinal("NumeroPlaca")),
                            MarcaAuto = lect.IsDBNull(lect.GetOrdinal("MarcaAuto")) ? default(string) : lect.GetString(lect.GetOrdinal("MarcaAuto")),
                            ModeloAuto = lect.IsDBNull(lect.GetOrdinal("ModeloAuto")) ? default(string) : lect.GetString(lect.GetOrdinal("ModeloAuto")),
                            FechaFabricacion = lect.IsDBNull(lect.GetOrdinal("FechaFabricacion")) ? default(string) : lect.GetString(lect.GetOrdinal("FechaFabricacion")),
                            NumeroTarjetaPropiedad = lect.IsDBNull(lect.GetOrdinal("NumeroTarjetaPropiedad")) ? default(string) : lect.GetString(lect.GetOrdinal("NumeroTarjetaPropiedad")),
                            TipoUsoVehicular = lect.IsDBNull(lect.GetOrdinal("TipoUsoVehicular")) ? default(bool) : lect.GetBoolean(lect.GetOrdinal("TipoUsoVehicular")),
                            EstadoVehiculo = lect.IsDBNull(lect.GetOrdinal("EstadoVehiculo")) ? default(Int32) : lect.GetInt32(lect.GetOrdinal("EstadoVehiculo")),
                            IngresoMensual = lect.IsDBNull(lect.GetOrdinal("IngresoMensual")) ? default(string) : lect.GetString(lect.GetOrdinal("IngresoMensual")),
                            NumeroHijos = lect.IsDBNull(lect.GetOrdinal("NumeroHijos")) ? default(Int32) : lect.GetInt32(lect.GetOrdinal("NumeroHijos")),
                            NombreEstablecimiento = lect.IsDBNull(lect.GetOrdinal("NombreEstablecimiento")) ? default(string) : lect.GetString(lect.GetOrdinal("NombreEstablecimiento")),
                            TipoFinanciamiento = lect.IsDBNull(lect.GetOrdinal("TipoFinanciamiento")) ? default(Int32) : lect.GetInt32(lect.GetOrdinal("TipoFinanciamiento")),
                            TipoCredito = lect.IsDBNull(lect.GetOrdinal("TipoCredito")) ? default(Int32) : lect.GetInt32(lect.GetOrdinal("TipoCredito")),
                            PlazoCuotasFinanciamiento = lect.IsDBNull(lect.GetOrdinal("PlazoCuotasFinanciamiento")) ? default(string) : lect.GetString(lect.GetOrdinal("PlazoCuotasFinanciamiento")),
                            MontoFinanciamiento = lect.IsDBNull(lect.GetOrdinal("MontoFinanciamiento")) ? default(Int32) : lect.GetInt32(lect.GetOrdinal("MontoFinanciamiento")),
                            Observaciones = lect.IsDBNull(lect.GetOrdinal("Observaciones")) ? default(string) : lect.GetString(lect.GetOrdinal("Observaciones")),
                            IdTaller = lect.IsDBNull(lect.GetOrdinal("IdTaller")) ? default(Int32) : lect.GetInt32(lect.GetOrdinal("IdTaller")),
                            IdCargaDocumentos = lect.IsDBNull(lect.GetOrdinal("IdCargaDocumentos")) ? default(Int32) : lect.GetInt32(lect.GetOrdinal("IdCargaDocumentos")),
                            ClaseVehiculo = lect.IsDBNull(lect.GetOrdinal("ClaseVehiculo")) ? default(string) : lect.GetString(lect.GetOrdinal("ClaseVehiculo")),
                            NumeroAsientos = lect.IsDBNull(lect.GetOrdinal("NumeroAsientos")) ? default(string) : lect.GetString(lect.GetOrdinal("NumeroAsientos")),
                            NumeroMotor = lect.IsDBNull(lect.GetOrdinal("NumeroMotor")) ? default(string) : lect.GetString(lect.GetOrdinal("NumeroMotor")),
                            NumeroSerie = lect.IsDBNull(lect.GetOrdinal("NumeroSerie")) ? default(string) : lect.GetString(lect.GetOrdinal("NumeroSerie")),
                            NumeroScore = lect.IsDBNull(lect.GetOrdinal("NumeroScore")) ? default(Int32) : lect.GetInt32(lect.GetOrdinal("NumeroScore")),
                            IdPreevaluacion = lect.IsDBNull(lect.GetOrdinal("IdPreevaluacion")) ? default(Int32) : lect.GetInt32(lect.GetOrdinal("IdPreevaluacion")),
                            FlagContratoFinanciamiento = lect.IsDBNull(lect.GetOrdinal("FlagContratoFinanciamiento")) ? default(bool) : lect.GetBoolean(lect.GetOrdinal("FlagContratoFinanciamiento")),
                            FlagFormatoConformidad = lect.IsDBNull(lect.GetOrdinal("FlagFormatoConformidad")) ? default(bool) : lect.GetBoolean(lect.GetOrdinal("FlagFormatoConformidad")),
                            FlagDNI = lect.IsDBNull(lect.GetOrdinal("FlagDNI")) ? default(bool) : lect.GetBoolean(lect.GetOrdinal("FlagDNI")),
                            DigitoVerificadorDNI = lect.IsDBNull(lect.GetOrdinal("DigitoVerificadorDNI")) ? default(string) : lect.GetString(lect.GetOrdinal("DigitoVerificadorDNI")),
                            MesAnio = lect.IsDBNull(lect.GetOrdinal("MesAnio")) ? default(string) : lect.GetString(lect.GetOrdinal("MesAnio")),
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

        public async Task<TotalList40Preguntas> List40Preguntas(int IdtipoDocumento, string NumDocumento, int NumPag, int NumReg)
        {
            if(NumDocumento==null)
            {
                NumDocumento = "";
            }
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_Lista40Preguntas", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@IdTipoDocumento", SqlDbType.Int).Value = IdtipoDocumento;
                    sql.Parameters.Add("@NumeroPagina", SqlDbType.Int).Value = NumPag;
                    sql.Parameters.Add("@NumeroRegistros", SqlDbType.Int).Value = NumReg;
                    sql.Parameters.Add("@NroDocumento", SqlDbType.VarChar).Value = NumDocumento.ToString();
                    sql.CommandTimeout = 90;
                    SqlDataReader lect = sql.ExecuteReader();

                    TotalList40Preguntas response = new TotalList40Preguntas();

                    //var response = new List<List40Preguntas>();
                    //List40Preguntas jsonResult;

                    var totalRegistros = 0;

                    while (lect.Read())
                    {
                        if (totalRegistros == 0)
                        {
                            totalRegistros = Convert.ToInt32(lect["TotalRegistros"]);
                        }

                        var entidad = new List40Preguntas()
                        {
                            IdSfCliente = lect.IsDBNull(lect.GetOrdinal("IdSfCliente")) ? default(int) : lect.GetInt32(lect.GetOrdinal("IdSfCliente")),
                            IdCliente = lect.IsDBNull(lect.GetOrdinal("IdCliente")) ? default(Int32) : lect.GetInt32(lect.GetOrdinal("IdCliente")),
                            Nombres = lect.IsDBNull(lect.GetOrdinal("Nombres")) ? default(string) : lect.GetString(lect.GetOrdinal("Nombres")),
                            Apellidos = lect.IsDBNull(lect.GetOrdinal("Apellidos")) ? default(string) : lect.GetString(lect.GetOrdinal("Apellidos")),
                            TipoDocumento = lect.IsDBNull(lect.GetOrdinal("TipoDocumento")) ? default(string) : lect.GetString(lect.GetOrdinal("TipoDocumento")),
                            NumeroDocumento = lect.IsDBNull(lect.GetOrdinal("NumeroDocumento")) ? default(string) : lect.GetString(lect.GetOrdinal("NumeroDocumento")),
                            FechaNacimiento = lect.IsDBNull(lect.GetOrdinal("FechaNacimiento")) ? default(DateTime) : lect.GetDateTime(lect.GetOrdinal("FechaNacimiento")),
                            EstadoCivil = lect.IsDBNull(lect.GetOrdinal("EstadoCivil")) ? default(Int32) : lect.GetInt32(lect.GetOrdinal("EstadoCivil")),
                            CorreoElectronico = lect.IsDBNull(lect.GetOrdinal("CorreoElectronico")) ? default(string) : lect.GetString(lect.GetOrdinal("CorreoElectronico")),
                            Celular = lect.IsDBNull(lect.GetOrdinal("Celular")) ? default(string) : lect.GetString(lect.GetOrdinal("Celular")),
                            IdNivelEstudios = lect.IsDBNull(lect.GetOrdinal("IdNivelEstudios")) ? default(Int32) : lect.GetInt32(lect.GetOrdinal("IdNivelEstudios")),
                            Ocupacion = lect.IsDBNull(lect.GetOrdinal("Ocupacion")) ? default(string) : lect.GetString(lect.GetOrdinal("Ocupacion")),
                            TipoContrato = lect.IsDBNull(lect.GetOrdinal("TipoContrato")) ? default(string) : lect.GetString(lect.GetOrdinal("TipoContrato")),
                            TiempoEmpleoCliente = lect.IsDBNull(lect.GetOrdinal("TiempoEmpleoCliente")) ? default(string) : lect.GetString(lect.GetOrdinal("TiempoEmpleoCliente")),
                            TipoCalle = lect.IsDBNull(lect.GetOrdinal("TipoCalle")) ? default(string) : lect.GetString(lect.GetOrdinal("TipoCalle")),
                            Direccion = lect.IsDBNull(lect.GetOrdinal("Direccion")) ? default(string) : lect.GetString(lect.GetOrdinal("Direccion")),
                            NumeroInterior = lect.IsDBNull(lect.GetOrdinal("NumeroInterior")) ? default(Int32) : lect.GetInt32(lect.GetOrdinal("NumeroInterior")),
                            MzLt = lect.IsDBNull(lect.GetOrdinal("MzLt")) ? default(string) : lect.GetString(lect.GetOrdinal("MzLt")),
                            Distrito = lect.IsDBNull(lect.GetOrdinal("Distrito")) ? default(string) : lect.GetString(lect.GetOrdinal("Distrito")),
                            ReferenciaDomicilio = lect.IsDBNull(lect.GetOrdinal("ReferenciaDomicilio")) ? default(string) : lect.GetString(lect.GetOrdinal("ReferenciaDomicilio")),
                            TipoVivienda = lect.IsDBNull(lect.GetOrdinal("TipoVivienda")) ? default(string) : lect.GetString(lect.GetOrdinal("TipoVivienda")),
                            TiempoAnoVivienda = lect.IsDBNull(lect.GetOrdinal("TiempoAnoVivienda")) ? default(Int32) : lect.GetInt32(lect.GetOrdinal("TiempoAnoVivienda")),
                            TiempoMesesVivienda = lect.IsDBNull(lect.GetOrdinal("TiempoMesesVivienda")) ? default(Int32) : lect.GetInt32(lect.GetOrdinal("TiempoMesesVivienda")),
                            IsGasNatural = lect.IsDBNull(lect.GetOrdinal("IsGasNatural")) ? default(bool) : lect.GetBoolean(lect.GetOrdinal("IsGasNatural")),
                            NumeroPlaca = lect.IsDBNull(lect.GetOrdinal("NumeroPlaca")) ? default(string) : lect.GetString(lect.GetOrdinal("NumeroPlaca")),
                            MarcaAuto = lect.IsDBNull(lect.GetOrdinal("MarcaAuto")) ? default(string) : lect.GetString(lect.GetOrdinal("MarcaAuto")),
                            ModeloAuto = lect.IsDBNull(lect.GetOrdinal("ModeloAuto")) ? default(string) : lect.GetString(lect.GetOrdinal("ModeloAuto")),
                            FechaFabricacion = lect.IsDBNull(lect.GetOrdinal("FechaFabricacion")) ? default(string) : lect.GetString(lect.GetOrdinal("FechaFabricacion")),
                            NumeroTarjetaPropiedad = lect.IsDBNull(lect.GetOrdinal("NumeroTarjetaPropiedad")) ? default(string) : lect.GetString(lect.GetOrdinal("NumeroTarjetaPropiedad")),
                            TipoUsoVehicular = lect.IsDBNull(lect.GetOrdinal("TipoUsoVehicular")) ? default(bool) : lect.GetBoolean(lect.GetOrdinal("TipoUsoVehicular")),
                            EstadoVehiculo = lect.IsDBNull(lect.GetOrdinal("EstadoVehiculo")) ? default(Int32) : lect.GetInt32(lect.GetOrdinal("EstadoVehiculo")),
                            IngresoMensual = lect.IsDBNull(lect.GetOrdinal("IngresoMensual")) ? default(string) : lect.GetString(lect.GetOrdinal("IngresoMensual")),
                            NumeroHijos = lect.IsDBNull(lect.GetOrdinal("NumeroHijos")) ? default(Int32) : lect.GetInt32(lect.GetOrdinal("NumeroHijos")),
                            NombreEstablecimiento = lect.IsDBNull(lect.GetOrdinal("NombreEstablecimiento")) ? default(string) : lect.GetString(lect.GetOrdinal("NombreEstablecimiento")),
                            TipoFinanciamiento = lect.IsDBNull(lect.GetOrdinal("TipoFinanciamiento")) ? default(Int32) : lect.GetInt32(lect.GetOrdinal("TipoFinanciamiento")),
                            TipoCredito = lect.IsDBNull(lect.GetOrdinal("TipoCredito")) ? default(int) : lect.GetInt32(lect.GetOrdinal("TipoCredito")),
                            PlazoCuotasFinanciamiento = lect.IsDBNull(lect.GetOrdinal("PlazoCuotasFinanciamiento")) ? default(string) : lect.GetString(lect.GetOrdinal("PlazoCuotasFinanciamiento")),
                            MontoFinanciamiento = lect.IsDBNull(lect.GetOrdinal("MontoFinanciamiento")) ? default(Int32) : lect.GetInt32(lect.GetOrdinal("MontoFinanciamiento")),
                            Observaciones = lect.IsDBNull(lect.GetOrdinal("Observaciones")) ? default(string) : lect.GetString(lect.GetOrdinal("Observaciones")),
                            IdTaller = lect.IsDBNull(lect.GetOrdinal("IdTaller")) ? default(Int32) : lect.GetInt32(lect.GetOrdinal("IdTaller")),
                            IdCargaDocumentos = lect.IsDBNull(lect.GetOrdinal("IdCargaDocumentos")) ? default(Int32) : lect.GetInt32(lect.GetOrdinal("IdCargaDocumentos")),
                            ClaseVehiculo = lect.IsDBNull(lect.GetOrdinal("ClaseVehiculo")) ? default(string) : lect.GetString(lect.GetOrdinal("ClaseVehiculo")),
                            NumeroAsientos = lect.IsDBNull(lect.GetOrdinal("NumeroAsientos")) ? default(string) : lect.GetString(lect.GetOrdinal("NumeroAsientos")),
                            NumeroMotor = lect.IsDBNull(lect.GetOrdinal("NumeroMotor")) ? default(string) : lect.GetString(lect.GetOrdinal("NumeroMotor")),
                            NumeroSerie = lect.IsDBNull(lect.GetOrdinal("NumeroSerie")) ? default(string) : lect.GetString(lect.GetOrdinal("NumeroSerie")),
                            NumeroScore = lect.IsDBNull(lect.GetOrdinal("NumeroScore")) ? default(Int32) : lect.GetInt32(lect.GetOrdinal("NumeroScore")),
                            IdPreevaluacion = lect.IsDBNull(lect.GetOrdinal("IdPreevaluacion")) ? default(Int32) : lect.GetInt32(lect.GetOrdinal("IdPreevaluacion")),
                            FlagContratoFinanciamiento = lect.IsDBNull(lect.GetOrdinal("FlagContratoFinanciamiento")) ? default(bool) : lect.GetBoolean(lect.GetOrdinal("FlagContratoFinanciamiento")),
                            FlagFormatoConformidad = lect.IsDBNull(lect.GetOrdinal("FlagFormatoConformidad")) ? default(bool) : lect.GetBoolean(lect.GetOrdinal("FlagFormatoConformidad")),
                            FlagDNI = lect.IsDBNull(lect.GetOrdinal("FlagDNI")) ? default(bool) : lect.GetBoolean(lect.GetOrdinal("FlagDNI")),
                            DigitoVerificadorDNI = lect.IsDBNull(lect.GetOrdinal("DigitoVerificadorDNI")) ? default(string) : lect.GetString(lect.GetOrdinal("DigitoVerificadorDNI")),
                            FechaDespacho = lect.IsDBNull(lect.GetOrdinal("FechaDespacho")) ? default(string) : lect.GetString(lect.GetOrdinal("FechaDespacho")),
                            MesAnio= lect.IsDBNull(lect.GetOrdinal("MesAnio")) ? default(string) : lect.GetString(lect.GetOrdinal("MesAnio")),
                            Producto= lect.IsDBNull(lect.GetOrdinal("Producto")) ? default(string) : lect.GetString(lect.GetOrdinal("Producto")),
                            Precio= lect.IsDBNull(lect.GetOrdinal("Precio")) ? default(decimal) : lect.GetDecimal(lect.GetOrdinal("Precio")),
                            Taller = lect.IsDBNull(lect.GetOrdinal("Taller")) ? default(string) : lect.GetString(lect.GetOrdinal("Taller")),
                        };

                        response.Data.Add(entidad);
                        //response.Add(jsonResult);
                    }

                    var totalPaginaInt = 0;
                    var totalPaginaDec = 0;
                    totalPaginaInt = (totalRegistros / NumReg);
                    totalPaginaDec = (totalRegistros % NumReg);
                    if (totalPaginaDec > 0)
                    {
                        totalPaginaInt = totalPaginaInt + 1;
                    }
                    response.Meta.TotalCount = totalRegistros;
                    response.Meta.PageSize = NumReg;
                    response.Meta.CurrentPage = NumPag;
                    response.Meta.TotalPages = totalPaginaInt;

                    lect.Close();
                    connection.Close();
                    connection.Dispose();
                    return response;
                }
            }
        }

        public async Task<List<ListLineaTiempoEntity>> ListLineaTiempo(string Clave, int Id)
        {
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("SP_ListLineaTiempo", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@Clave", SqlDbType.VarChar).Value = Clave;
                    sql.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
                    sql.CommandTimeout = 0;
                    SqlDataReader lect = sql.ExecuteReader();
                    var response = new List<ListLineaTiempoEntity>();
                    ListLineaTiempoEntity jsonResult;

                    while (lect.Read())
                    {
                        jsonResult = new ListLineaTiempoEntity()
                        {
                            IdPreevaluacion = lect.IsDBNull(lect.GetOrdinal("IdPreevaluacion")) ? default(int) : lect.GetInt32(lect.GetOrdinal("IdPreevaluacion")),
                            FechaRegistro = lect.IsDBNull(lect.GetOrdinal("FechaRegistro")) ? default(string) : lect.GetString(lect.GetOrdinal("FechaRegistro")),
                            Estado = lect.IsDBNull(lect.GetOrdinal("Estado")) ? default(string) : lect.GetString(lect.GetOrdinal("Estado")),
                            Producto = lect.IsDBNull(lect.GetOrdinal("Descripcion")) ? default(string) : lect.GetString(lect.GetOrdinal("Descripcion")),
                            Observaciones = lect.IsDBNull(lect.GetOrdinal("Observaciones")) ? default(string) : lect.GetString(lect.GetOrdinal("Observaciones")),
                            FechaDespacho = lect.IsDBNull(lect.GetOrdinal("FechaDespacho")) ? default(string) : lect.GetString(lect.GetOrdinal("FechaDespacho")),
                            Eactual = lect.IsDBNull(lect.GetOrdinal("Eactual")) ? default(string) : lect.GetString(lect.GetOrdinal("Eactual")),
                            NroPaso= lect.IsDBNull(lect.GetOrdinal("PasoActual")) ? default(int) : lect.GetInt32(lect.GetOrdinal("PasoActual")),
                            DescripcionPaso = lect.IsDBNull(lect.GetOrdinal("DesripcionPaso")) ? default(string) : lect.GetString(lect.GetOrdinal("DesripcionPaso")),

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

        public async Task<ListUltimoRegPreevaluacion> ListultimoRegistroPreevalucion(int IdUsuario)
        {
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("SP_UltimoRegPreevaluacion", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = IdUsuario;

                    sql.CommandTimeout = 0;
                    SqlDataReader lect = sql.ExecuteReader();
                    ListUltimoRegPreevaluacion listLast = null;

                    while (lect.Read())
                    {
                        listLast = new ListUltimoRegPreevaluacion()
                        {
                            Apellido= lect.IsDBNull(lect.GetOrdinal("Apellido")) ? default(string) : lect.GetString(lect.GetOrdinal("Apellido")),
                            Nombre = lect.IsDBNull(lect.GetOrdinal("Nombre")) ? default(string) : lect.GetString(lect.GetOrdinal("Nombre")),
                            IdTipoDocumento = lect.IsDBNull(lect.GetOrdinal("IdTipoDocumento")) ? default(int) : lect.GetInt32(lect.GetOrdinal("IdTipoDocumento")),
                            NumDocumento= lect.IsDBNull(lect.GetOrdinal("NumDocumento")) ? default(string) : lect.GetString(lect.GetOrdinal("NumDocumento")),
                            NumPlaca = lect.IsDBNull(lect.GetOrdinal("NumPlaca")) ? default(string) : lect.GetString(lect.GetOrdinal("NumPlaca")),
                            Email = lect.IsDBNull(lect.GetOrdinal("Email")) ? default(string) : lect.GetString(lect.GetOrdinal("Email")),
                            Celular = lect.IsDBNull(lect.GetOrdinal("Celular")) ? default(string) : lect.GetString(lect.GetOrdinal("Celular")),
                        };
                    }

                    lect.Close();
                    connection.Close();
                    connection.Dispose();
                    return listLast;
                }
            }
        }

        public async Task<ListultimoReg40Preguntas> ListultimoRegistro40Preguntas(int IdUsuario)
        {
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("SP_UltimoReg40Preguntas", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = IdUsuario;

                    sql.CommandTimeout = 0;
                    SqlDataReader lect = sql.ExecuteReader();
                    ListultimoReg40Preguntas listLast = null;

                    while (lect.Read())
                    {
                        listLast = new ListultimoReg40Preguntas()
                        {
                            IdSfCliente = lect.IsDBNull(lect.GetOrdinal("IdSfCliente")) ? default(int) : lect.GetInt32(lect.GetOrdinal("IdSfCliente")),
                            Nombres = lect.IsDBNull(lect.GetOrdinal("Nombres")) ? default(string) : lect.GetString(lect.GetOrdinal("Nombres")),
                            Apellidos = lect.IsDBNull(lect.GetOrdinal("Apellidos")) ? default(string) : lect.GetString(lect.GetOrdinal("Apellidos")),
                            NumeroDocumento = lect.IsDBNull(lect.GetOrdinal("NumeroDocumento")) ? default(string) : lect.GetString(lect.GetOrdinal("NumeroDocumento")),
                            FechaNacimiento = lect.IsDBNull(lect.GetOrdinal("FechaNacimiento")) ? default(string) : lect.GetString(lect.GetOrdinal("FechaNacimiento")),
                            EstadoCivil = lect.IsDBNull(lect.GetOrdinal("EstadoCivil")) ? default(int) : lect.GetInt32(lect.GetOrdinal("EstadoCivil")),
                            CorreoElectronico = lect.IsDBNull(lect.GetOrdinal("CorreoElectronico")) ? default(string) : lect.GetString(lect.GetOrdinal("CorreoElectronico")),
                            Celular = lect.IsDBNull(lect.GetOrdinal("Celular")) ? default(string) : lect.GetString(lect.GetOrdinal("Celular")),
                            IdNivelEstudios = lect.IsDBNull(lect.GetOrdinal("IdNivelEstudios")) ? default(int) : lect.GetInt32(lect.GetOrdinal("IdNivelEstudios")),
                            Direccion = lect.IsDBNull(lect.GetOrdinal("Direccion")) ? default(string) : lect.GetString(lect.GetOrdinal("Direccion")),
                            Distrito = lect.IsDBNull(lect.GetOrdinal("Distrito")) ? default(string) : lect.GetString(lect.GetOrdinal("Distrito")),
                            ReferenciaDomicilio = lect.IsDBNull(lect.GetOrdinal("ReferenciaDomicilio")) ? default(string) : lect.GetString(lect.GetOrdinal("ReferenciaDomicilio")),
                            MzLt = lect.IsDBNull(lect.GetOrdinal("MzLt")) ? default(string) : lect.GetString(lect.GetOrdinal("MzLt")),
                            NumeroInterior = lect.IsDBNull(lect.GetOrdinal("NumeroInterior")) ? default(int) : lect.GetInt32(lect.GetOrdinal("NumeroInterior")),
                        };
                    }

                    lect.Close();
                    connection.Close();
                    connection.Dispose();
                    return listLast;
                }
            }
        }

        public async Task<LineaCreditoEntity> LineaCredito(int NumScore, string ValorCR)
        {
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("SP_LineaCredito", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@NumScore", SqlDbType.Int).Value = NumScore;
                    sql.Parameters.Add("@ValorCR", SqlDbType.VarChar).Value = ValorCR.ToUpper();

                    sql.CommandTimeout = 0;
                    SqlDataReader lect = sql.ExecuteReader();
                    LineaCreditoEntity listLast = null;

                    while (lect.Read())
                    {
                        listLast = new LineaCreditoEntity()
                        {
                            Riesgo = lect.IsDBNull(lect.GetOrdinal("Riesgo")) ? default(string) : lect.GetString(lect.GetOrdinal("Riesgo")),
                            LineaCredito = lect.IsDBNull(lect.GetOrdinal("LineaCredito")) ? default(decimal) : lect.GetDecimal(lect.GetOrdinal("LineaCredito")),
                            
                        };
                    }

                    lect.Close();
                    connection.Close();
                    connection.Dispose();
                    return listLast;
                }
            }
        }
    }
}
