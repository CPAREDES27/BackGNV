using Application.Services.Interfaces;
using AutoMapper;
using Domain.MainModule.Entities.ReportDashboard;
using Domain.MainModule.Settings;
using Infrastructure.Data.Context;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.MainModule.Repositories
{
    public class ReportDashboardRepository : IReportDashboardService
    {
        private readonly DBGNVContext context;
        private readonly IConfiguration _configuration;
        private readonly IMapper mapper;
        private readonly PaginationOptions paginationOptions;

        public ReportDashboardRepository(DBGNVContext context, IConfiguration configuration)
        {
            this.context = context;
            _configuration = configuration;
        }

        public async Task<ListAsesorDetalleDashboard> DashboarGeneralDetalle(int IdAsesor, DateTime FechaInicio, DateTime FechaFin)
        {
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_DashboardGeneralDetalle", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@IdAsesor", SqlDbType.Int).Value = IdAsesor;
                    sql.Parameters.Add("@FechaInicio", SqlDbType.DateTime).Value = FechaInicio;
                    sql.Parameters.Add("@FechaFin", SqlDbType.DateTime).Value = FechaFin;

                    sql.CommandTimeout = 90;
                    //SqlDataReader lect = sql.ExecuteReader();

                    //ListAsesorDetalleDashboard evDetalle = new ListAsesorDetalleDashboard();
                    //ListAsesorDetalleDashboard jresult;


                    ListAsesorDetalleDashboard listFinal;

                    List<ListDashboardFinanciamientos> evFinanciamiento = new List<ListDashboardFinanciamientos>();
                    ListDashboardFinanciamientos jresultFinanciamientos;

                    List<ListDashboardFinanciamientosAprobados> evAprobados = new List<ListDashboardFinanciamientosAprobados>();
                    ListDashboardFinanciamientosAprobados jresultAprobados;

                    listFinal = new ListAsesorDetalleDashboard();

                    using (SqlDataReader lect = sql.ExecuteReader())
                    {
                        while (lect.Read())
                        {
                            jresultFinanciamientos = new ListDashboardFinanciamientos()

                            {
                                //Lista Financiamientos
                                IdPreevaluacion = lect.IsDBNull(lect.GetOrdinal("IdPreevaluacion")) ? default(int) : lect.GetInt32(lect.GetOrdinal("IdPreevaluacion")),
                                Cliente = lect.IsDBNull(lect.GetOrdinal("Cliente")) ? default(string) : lect.GetString(lect.GetOrdinal("Cliente")),
                                TipoDocumento = lect.IsDBNull(lect.GetOrdinal("TipoDocumento")) ? default(string) : lect.GetString(lect.GetOrdinal("TipoDocumento")),
                                NumDocumento = lect.IsDBNull(lect.GetOrdinal("NumDocumento")) ? default(string) : lect.GetString(lect.GetOrdinal("NumDocumento")),
                                Email = lect.IsDBNull(lect.GetOrdinal("Email")) ? default(string) : lect.GetString(lect.GetOrdinal("Email")),
                                Celular = lect.IsDBNull(lect.GetOrdinal("Celular")) ? default(string) : lect.GetString(lect.GetOrdinal("Celular")),
                                NumPlaca = lect.IsDBNull(lect.GetOrdinal("NumPlaca")) ? default(string) : lect.GetString(lect.GetOrdinal("NumPlaca")),
                                ProductoFinanciar = lect.IsDBNull(lect.GetOrdinal("ProductoFinanciar")) ? default(string) : lect.GetString(lect.GetOrdinal("ProductoFinanciar")),
                                Precio = lect.IsDBNull(lect.GetOrdinal("Precio")) ? default(decimal) : lect.GetDecimal(lect.GetOrdinal("Precio")),
                                ProveedorProducto = lect.IsDBNull(lect.GetOrdinal("ProveedorProducto")) ? default(string) : lect.GetString(lect.GetOrdinal("ProveedorProducto")),
                                RUC = lect.IsDBNull(lect.GetOrdinal("RUC")) ? default(string) : lect.GetString(lect.GetOrdinal("RUC")),
                                EmailProveedor = lect.IsDBNull(lect.GetOrdinal("EmailProveedor")) ? default(string) : lect.GetString(lect.GetOrdinal("EmailProveedor")),
                                EstadoActual = lect.IsDBNull(lect.GetOrdinal("EstadoActual")) ? default(string) : lect.GetString(lect.GetOrdinal("EstadoActual")),
                                FechaSolicitud = lect.IsDBNull(lect.GetOrdinal("FechaSolicitud")) ? default(DateTime) : lect.GetDateTime(lect.GetOrdinal("FechaSolicitud")),
                            };
                            evFinanciamiento.Add(jresultFinanciamientos);
                        }

                        listFinal.listaFinanciamientos = evFinanciamiento.ToList();

                        if (lect.NextResult())
                        {
                            while (lect.Read())
                            {
                                jresultAprobados = new ListDashboardFinanciamientosAprobados()
                                {
                                    IdPreevaluacion = lect.IsDBNull(lect.GetOrdinal("IdPreevaluacion")) ? default(int) : lect.GetInt32(lect.GetOrdinal("IdPreevaluacion")),
                                    Cliente = lect.IsDBNull(lect.GetOrdinal("Cliente")) ? default(string) : lect.GetString(lect.GetOrdinal("Cliente")),
                                    TipoDocumento = lect.IsDBNull(lect.GetOrdinal("TipoDocumento")) ? default(string) : lect.GetString(lect.GetOrdinal("TipoDocumento")),
                                    NumDocumento = lect.IsDBNull(lect.GetOrdinal("NumDocumento")) ? default(string) : lect.GetString(lect.GetOrdinal("NumDocumento")),
                                    Email = lect.IsDBNull(lect.GetOrdinal("Email")) ? default(string) : lect.GetString(lect.GetOrdinal("Email")),
                                    Celular = lect.IsDBNull(lect.GetOrdinal("Celular")) ? default(string) : lect.GetString(lect.GetOrdinal("Celular")),
                                    NumPlaca = lect.IsDBNull(lect.GetOrdinal("NumPlaca")) ? default(string) : lect.GetString(lect.GetOrdinal("NumPlaca")),
                                    ProductoFinanciar = lect.IsDBNull(lect.GetOrdinal("ProductoFinanciar")) ? default(string) : lect.GetString(lect.GetOrdinal("ProductoFinanciar")),
                                    Precio = lect.IsDBNull(lect.GetOrdinal("Precio")) ? default(decimal) : lect.GetDecimal(lect.GetOrdinal("Precio")),
                                    ProveedorProducto = lect.IsDBNull(lect.GetOrdinal("ProveedorProducto")) ? default(string) : lect.GetString(lect.GetOrdinal("ProveedorProducto")),
                                    RUC = lect.IsDBNull(lect.GetOrdinal("RUC")) ? default(string) : lect.GetString(lect.GetOrdinal("RUC")),
                                    EmailProveedor = lect.IsDBNull(lect.GetOrdinal("EmailProveedor")) ? default(string) : lect.GetString(lect.GetOrdinal("EmailProveedor")),
                                    //EstadoActual = lect.IsDBNull(lect.GetOrdinal("EstadoActual")) ? default(string) : lect.GetString(lect.GetOrdinal("EstadoActual")),
                                    FechaAprobacion = lect.IsDBNull(lect.GetOrdinal("FechaAprobacion")) ? default(DateTime) : lect.GetDateTime(lect.GetOrdinal("FechaAprobacion")),
                                    FechaEntregaProducto = lect.IsDBNull(lect.GetOrdinal("FechaEntregaProducto")) ? default(DateTime) : lect.GetDateTime(lect.GetOrdinal("FechaEntregaProducto")),
                                    Observacion = lect.IsDBNull(lect.GetOrdinal("Observacion")) ? default(string) : lect.GetString(lect.GetOrdinal("Observacion")),
                                    FechaSolicitud = lect.IsDBNull(lect.GetOrdinal("FechaSolicitud")) ? default(DateTime) : lect.GetDateTime(lect.GetOrdinal("FechaSolicitud")),
                                };
                                evAprobados.Add(jresultAprobados);
                            }

                        }

                        listFinal.listaFinanciamientosAprobados = evAprobados.ToList();

                        lect.Close();
                    }


                    connection.Close();
                    connection.Dispose();
                    return listFinal;
                }
            }
        }

        public async Task<ListCabeceraDashboard> GetDashboarGeneral(DateTime FechaInicio, DateTime FechaFin)
        {
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_DashboardGeneralTotales", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@IdAsesor", SqlDbType.Int).Value = 0;
                    sql.Parameters.Add("@FechaInicio", SqlDbType.DateTime).Value = FechaInicio;
                    sql.Parameters.Add("@FechaFin", SqlDbType.DateTime).Value = FechaFin;

                    sql.CommandTimeout = 0;
                    SqlDataReader lect = sql.ExecuteReader();
                    ListCabeceraDashboard evclient = null;

                    while (lect.Read())
                    {
                        evclient = new ListCabeceraDashboard()
                        {
                            //
                            Productos_vendidos = lect.IsDBNull(lect.GetOrdinal("Financiamientos_Aprobados")) ? default(int) : lect.GetInt32(lect.GetOrdinal("Financiamientos_Aprobados")),
                            CantidadTotal_Financiamiento = lect.IsDBNull(lect.GetOrdinal("Cantidad_Financiamientos")) ? default(int) : lect.GetInt32(lect.GetOrdinal("Cantidad_Financiamientos")),
                            Porcentaje_Ventas = lect.IsDBNull(lect.GetOrdinal("Porcentaje_Ventas")) ? default(decimal) : lect.GetDecimal(lect.GetOrdinal("Porcentaje_Ventas")),
                            MontoTotal_Financiado = lect.IsDBNull(lect.GetOrdinal("MontoTotal_Financiado")) ? default(decimal) : lect.GetDecimal(lect.GetOrdinal("MontoTotal_Financiado")),

                        };
                    }

                    lect.Close();
                    connection.Close();
                    connection.Dispose();
                    return evclient;
                }
            }
        }

        public async Task<ListReportGrafico> GetListaReporteGrafico(int IdUsuario, DateTime FechaInicio, DateTime FechaFin)
        {
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_DashboardGeneralGrafico", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@IdAsesor", SqlDbType.Int).Value = IdUsuario;
                    sql.Parameters.Add("@FechaInicio", SqlDbType.DateTime).Value = FechaInicio;
                    sql.Parameters.Add("@FechaFin", SqlDbType.DateTime).Value = FechaFin;

                    sql.CommandTimeout = 90;

                    ListReportGrafico listFinal;

                    List<ListReportGraficoDatos> evCliente = new List<ListReportGraficoDatos>();
                    ListReportGraficoDatos jresultCliente;

                    List<ListReportGraficoExtra> evExtra = new List<ListReportGraficoExtra>();
                    ListReportGraficoExtra jresultExtra;

                    listFinal = new ListReportGrafico();

                    using (SqlDataReader lect = sql.ExecuteReader())
                    {
                        while (lect.Read())
                        {
                            jresultCliente = new ListReportGraficoDatos()

                            {
                                //Lista Cliente
                                name = lect.IsDBNull(lect.GetOrdinal("Periodo")) ? default(string) : lect.GetString(lect.GetOrdinal("Periodo")),
                                value = lect.IsDBNull(lect.GetOrdinal("Total")) ? default(decimal) : lect.GetDecimal(lect.GetOrdinal("Total")),
                                //extra = 0;
                            };
                            evCliente.Add(jresultCliente);
                        }

                        listFinal.datos = evCliente.ToList();

                        lect.Close();
                    }


                    connection.Close();
                    connection.Dispose();
                    return listFinal;
                }
            }
        }

        public async Task<ListReporteSAP> GetListaReporteSAP(int IdUsuario, DateTime FechaInicio, DateTime FechaFin)
        {
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("SP_ListReporteSAP", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@IdCliente", SqlDbType.Int).Value = IdUsuario;
                    sql.Parameters.Add("@FechaInicio", SqlDbType.DateTime).Value = FechaInicio;
                    sql.Parameters.Add("@FechaFin", SqlDbType.DateTime).Value = FechaFin;

                    sql.CommandTimeout = 90;

                    ListReporteSAP listFinal;

                    List<ListReportSAPCLiente> evCliente = new List<ListReportSAPCLiente>();
                    ListReportSAPCLiente jresultCliente;

                    List<ListReportSAPVenta> evVenta = new List<ListReportSAPVenta>();
                    ListReportSAPVenta jresultVenta;

                    listFinal = new ListReporteSAP();

                    using (SqlDataReader lect = sql.ExecuteReader())
                    {
                        while (lect.Read())
                        {
                            jresultCliente = new ListReportSAPCLiente()

                            {
                                //Lista Cliente
                                
                                Idcliente = lect.IsDBNull(lect.GetOrdinal("Idcliente")) ? default(int) : lect.GetInt32(lect.GetOrdinal("Idcliente")),
                                Apellido = lect.IsDBNull(lect.GetOrdinal("Apellido")) ? default(string) : lect.GetString(lect.GetOrdinal("Apellido")),
                                Nombre = lect.IsDBNull(lect.GetOrdinal("Nombre")) ? default(string) : lect.GetString(lect.GetOrdinal("Nombre")),
                                TipoDocumento = lect.IsDBNull(lect.GetOrdinal("TipoDocumento")) ? default(string) : lect.GetString(lect.GetOrdinal("TipoDocumento")),
                                NumDocumento = lect.IsDBNull(lect.GetOrdinal("NumDocumento")) ? default(string) : lect.GetString(lect.GetOrdinal("NumDocumento")),
                                //Ruc = lect.IsDBNull(lect.GetOrdinal("Ruc")) ? default(string) : lect.GetString(lect.GetOrdinal("Ruc")),
                                RazonSocial = lect.IsDBNull(lect.GetOrdinal("RazonSocial")) ? default(string) : lect.GetString(lect.GetOrdinal("RazonSocial")),
                                Email = lect.IsDBNull(lect.GetOrdinal("Email")) ? default(string) : lect.GetString(lect.GetOrdinal("Email")),
                                TelefonoFijo = lect.IsDBNull(lect.GetOrdinal("TelefonoFijo")) ? default(string) : lect.GetString(lect.GetOrdinal("TelefonoFijo")),
                                TelefonoMovil = lect.IsDBNull(lect.GetOrdinal("TelefonoMovil")) ? default(string) : lect.GetString(lect.GetOrdinal("TelefonoMovil")),
                                FechaNacimiento = lect.IsDBNull(lect.GetOrdinal("FechaNacimiento")) ? default(DateTime) : lect.GetDateTime(lect.GetOrdinal("FechaNacimiento")),
                                DireccionResidencia = lect.IsDBNull(lect.GetOrdinal("DireccionResidencia")) ? default(string) : lect.GetString(lect.GetOrdinal("DireccionResidencia")),
                                NumeroIntDpto = lect.IsDBNull(lect.GetOrdinal("NumeroIntDpto")) ? default(int) : lect.GetInt32(lect.GetOrdinal("NumeroIntDpto")),
                                ManzanaLote = lect.IsDBNull(lect.GetOrdinal("ManzanaLote")) ? default(string) : lect.GetString(lect.GetOrdinal("ManzanaLote")),
                                Departamento = lect.IsDBNull(lect.GetOrdinal("Departamento")) ? default(string) : lect.GetString(lect.GetOrdinal("Departamento")),
                                Provincia = lect.IsDBNull(lect.GetOrdinal("Provincia")) ? default(string) : lect.GetString(lect.GetOrdinal("Provincia")),
                                Distrito = lect.IsDBNull(lect.GetOrdinal("Distrito")) ? default(string) : lect.GetString(lect.GetOrdinal("Distrito")),

                            };
                            evCliente.Add(jresultCliente);
                        }

                        listFinal.ListCiente = evCliente.ToList();

                        if (lect.NextResult())
                        {
                            while (lect.Read())
                            {
                                jresultVenta = new ListReportSAPVenta()
                                {
                                    
                                    IdCliente = lect.IsDBNull(lect.GetOrdinal("IdCliente")) ? default(int) : lect.GetInt32(lect.GetOrdinal("IdCliente")),
                                    IdPreevaluacion = lect.IsDBNull(lect.GetOrdinal("IdPreevaluacion")) ? default(int) : lect.GetInt32(lect.GetOrdinal("IdPreevaluacion")),
                                    Cliente = lect.IsDBNull(lect.GetOrdinal("Cliente")) ? default(string) : lect.GetString(lect.GetOrdinal("Cliente")),
                                    TipoDocumento = lect.IsDBNull(lect.GetOrdinal("TipoDocumento")) ? default(string) : lect.GetString(lect.GetOrdinal("TipoDocumento")),
                                    NumDocumento = lect.IsDBNull(lect.GetOrdinal("NumDocumento")) ? default(string) : lect.GetString(lect.GetOrdinal("NumDocumento")),
                                    Email = lect.IsDBNull(lect.GetOrdinal("Email")) ? default(string) : lect.GetString(lect.GetOrdinal("Email")),
                                    Celular = lect.IsDBNull(lect.GetOrdinal("Celular")) ? default(string) : lect.GetString(lect.GetOrdinal("Celular")),
                                    NumPlaca = lect.IsDBNull(lect.GetOrdinal("NumPlaca")) ? default(string) : lect.GetString(lect.GetOrdinal("NumPlaca")),
                                    ProductoFinanciar = lect.IsDBNull(lect.GetOrdinal("ProductoFinanciar")) ? default(string) : lect.GetString(lect.GetOrdinal("ProductoFinanciar")),
                                    Precio = lect.IsDBNull(lect.GetOrdinal("Precio")) ? default(decimal) : lect.GetDecimal(lect.GetOrdinal("Precio")),
                                    ProveedorProducto = lect.IsDBNull(lect.GetOrdinal("ProveedorProducto")) ? default(string) : lect.GetString(lect.GetOrdinal("ProveedorProducto")),
                                    RUC = lect.IsDBNull(lect.GetOrdinal("RUC")) ? default(string) : lect.GetString(lect.GetOrdinal("RUC")),
                                    EmailProveedor = lect.IsDBNull(lect.GetOrdinal("EmailProveedor")) ? default(string) : lect.GetString(lect.GetOrdinal("EmailProveedor")),
                                    FechaSolicitud = lect.IsDBNull(lect.GetOrdinal("FechaSolicitud")) ? default(DateTime) : lect.GetDateTime(lect.GetOrdinal("FechaSolicitud")),
                                    FechaAprobacion = lect.IsDBNull(lect.GetOrdinal("FechaAprobacion")) ? default(DateTime) : lect.GetDateTime(lect.GetOrdinal("FechaAprobacion")),
                                    FechaEntregaProducto = lect.IsDBNull(lect.GetOrdinal("FechaEntregaProducto")) ? default(DateTime) : lect.GetDateTime(lect.GetOrdinal("FechaEntregaProducto")),
                                    Observacion = lect.IsDBNull(lect.GetOrdinal("Observacion")) ? default(string) : lect.GetString(lect.GetOrdinal("Observacion")),
                                    NumeroScore = lect.IsDBNull(lect.GetOrdinal("NumeroScore")) ? default(int) : lect.GetInt32(lect.GetOrdinal("NumeroScore")),
                                    NumeroPlaca = lect.IsDBNull(lect.GetOrdinal("NumeroPlaca")) ? default(string) : lect.GetString(lect.GetOrdinal("NumeroPlaca")),
                                    MarcaAuto = lect.IsDBNull(lect.GetOrdinal("MarcaAuto")) ? default(string) : lect.GetString(lect.GetOrdinal("MarcaAuto")),
                                    ModeloAuto = lect.IsDBNull(lect.GetOrdinal("ModeloAuto")) ? default(string) : lect.GetString(lect.GetOrdinal("ModeloAuto")),
                                    FechaFabricacion = lect.IsDBNull(lect.GetOrdinal("FechaFabricacion")) ? default(string) : lect.GetString(lect.GetOrdinal("FechaFabricacion")),
                                    MontoFinanciamiento = lect.IsDBNull(lect.GetOrdinal("MontoFinanciamiento")) ? default(int) : lect.GetInt32(lect.GetOrdinal("MontoFinanciamiento")),

                                };
                                evVenta.Add(jresultVenta);
                            }

                        }

                        listFinal.ListVenta = evVenta.ToList();

                        lect.Close();
                    }


                    connection.Close();
                    connection.Dispose();
                    return listFinal;
                }
            }
        }

        public async Task<ListAsesorDetalleDashboard> GetListAsesorDetalleDashboard(int IdAsesor, DateTime FechaInicio, DateTime FechaFin)
        {
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_DashboardAsesorDetalle", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@IdAsesor", SqlDbType.Int).Value = IdAsesor;
                    sql.Parameters.Add("@FechaInicio", SqlDbType.DateTime).Value = FechaInicio;
                    sql.Parameters.Add("@FechaFin", SqlDbType.DateTime).Value = FechaFin;

                    sql.CommandTimeout = 90;
                    //SqlDataReader lect = sql.ExecuteReader();

                    //ListAsesorDetalleDashboard evDetalle = new ListAsesorDetalleDashboard();
                    //ListAsesorDetalleDashboard jresult;


                    ListAsesorDetalleDashboard listFinal;

                    List<ListDashboardFinanciamientos> evFinanciamiento = new List<ListDashboardFinanciamientos>();
                    ListDashboardFinanciamientos jresultFinanciamientos;

                    List<ListDashboardFinanciamientosAprobados> evAprobados = new List<ListDashboardFinanciamientosAprobados>();
                    ListDashboardFinanciamientosAprobados jresultAprobados;

                    listFinal = new ListAsesorDetalleDashboard();

                    using (SqlDataReader lect = sql.ExecuteReader())
                    {
                        while (lect.Read())
                        {
                            jresultFinanciamientos = new ListDashboardFinanciamientos()

                            {
                                //Lista Financiamientos
                                IdPreevaluacion = lect.IsDBNull(lect.GetOrdinal("IdPreevaluacion")) ? default(int) : lect.GetInt32(lect.GetOrdinal("IdPreevaluacion")),
                                Cliente = lect.IsDBNull(lect.GetOrdinal("Cliente")) ? default(string) : lect.GetString(lect.GetOrdinal("Cliente")),
                                TipoDocumento = lect.IsDBNull(lect.GetOrdinal("TipoDocumento")) ? default(string) : lect.GetString(lect.GetOrdinal("TipoDocumento")),
                                NumDocumento = lect.IsDBNull(lect.GetOrdinal("NumDocumento")) ? default(string) : lect.GetString(lect.GetOrdinal("NumDocumento")),
                                Email = lect.IsDBNull(lect.GetOrdinal("Email")) ? default(string) : lect.GetString(lect.GetOrdinal("Email")),
                                Celular = lect.IsDBNull(lect.GetOrdinal("Celular")) ? default(string) : lect.GetString(lect.GetOrdinal("Celular")),
                                NumPlaca = lect.IsDBNull(lect.GetOrdinal("NumPlaca")) ? default(string) : lect.GetString(lect.GetOrdinal("NumPlaca")),
                                ProductoFinanciar = lect.IsDBNull(lect.GetOrdinal("ProductoFinanciar")) ? default(string) : lect.GetString(lect.GetOrdinal("ProductoFinanciar")),
                                Precio = lect.IsDBNull(lect.GetOrdinal("Precio")) ? default(decimal) : lect.GetDecimal(lect.GetOrdinal("Precio")),
                                ProveedorProducto = lect.IsDBNull(lect.GetOrdinal("ProveedorProducto")) ? default(string) : lect.GetString(lect.GetOrdinal("ProveedorProducto")),
                                RUC = lect.IsDBNull(lect.GetOrdinal("RUC")) ? default(string) : lect.GetString(lect.GetOrdinal("RUC")),
                                EmailProveedor = lect.IsDBNull(lect.GetOrdinal("EmailProveedor")) ? default(string) : lect.GetString(lect.GetOrdinal("EmailProveedor")),
                                EstadoActual = lect.IsDBNull(lect.GetOrdinal("EstadoActual")) ? default(string) : lect.GetString(lect.GetOrdinal("EstadoActual")),
                                FechaSolicitud = lect.IsDBNull(lect.GetOrdinal("FechaSolicitud")) ? default(DateTime) : lect.GetDateTime(lect.GetOrdinal("FechaSolicitud")),
                            };
                            evFinanciamiento.Add(jresultFinanciamientos);
                        }

                        listFinal.listaFinanciamientos =  evFinanciamiento.ToList();

                        if (lect.NextResult())
                        {
                            while (lect.Read())
                            {
                                jresultAprobados = new ListDashboardFinanciamientosAprobados()
                                {
                                    IdPreevaluacion = lect.IsDBNull(lect.GetOrdinal("IdPreevaluacion")) ? default(int) : lect.GetInt32(lect.GetOrdinal("IdPreevaluacion")),
                                    Cliente = lect.IsDBNull(lect.GetOrdinal("Cliente")) ? default(string) : lect.GetString(lect.GetOrdinal("Cliente")),
                                    TipoDocumento = lect.IsDBNull(lect.GetOrdinal("TipoDocumento")) ? default(string) : lect.GetString(lect.GetOrdinal("TipoDocumento")),
                                    NumDocumento = lect.IsDBNull(lect.GetOrdinal("NumDocumento")) ? default(string) : lect.GetString(lect.GetOrdinal("NumDocumento")),
                                    Email = lect.IsDBNull(lect.GetOrdinal("Email")) ? default(string) : lect.GetString(lect.GetOrdinal("Email")),
                                    Celular = lect.IsDBNull(lect.GetOrdinal("Celular")) ? default(string) : lect.GetString(lect.GetOrdinal("Celular")),
                                    NumPlaca = lect.IsDBNull(lect.GetOrdinal("NumPlaca")) ? default(string) : lect.GetString(lect.GetOrdinal("NumPlaca")),
                                    ProductoFinanciar = lect.IsDBNull(lect.GetOrdinal("ProductoFinanciar")) ? default(string) : lect.GetString(lect.GetOrdinal("ProductoFinanciar")),
                                    Precio = lect.IsDBNull(lect.GetOrdinal("Precio")) ? default(decimal) : lect.GetDecimal(lect.GetOrdinal("Precio")),
                                    ProveedorProducto = lect.IsDBNull(lect.GetOrdinal("ProveedorProducto")) ? default(string) : lect.GetString(lect.GetOrdinal("ProveedorProducto")),
                                    RUC = lect.IsDBNull(lect.GetOrdinal("RUC")) ? default(string) : lect.GetString(lect.GetOrdinal("RUC")),
                                    EmailProveedor = lect.IsDBNull(lect.GetOrdinal("EmailProveedor")) ? default(string) : lect.GetString(lect.GetOrdinal("EmailProveedor")),
                                    //EstadoActual = lect.IsDBNull(lect.GetOrdinal("EstadoActual")) ? default(string) : lect.GetString(lect.GetOrdinal("EstadoActual")),
                                    FechaAprobacion = lect.IsDBNull(lect.GetOrdinal("FechaAprobacion")) ? default(DateTime) : lect.GetDateTime(lect.GetOrdinal("FechaAprobacion")),
                                    FechaEntregaProducto = lect.IsDBNull(lect.GetOrdinal("FechaEntregaProducto")) ? default(DateTime) : lect.GetDateTime(lect.GetOrdinal("FechaEntregaProducto")),
                                    Observacion = lect.IsDBNull(lect.GetOrdinal("Observacion")) ? default(string) : lect.GetString(lect.GetOrdinal("Observacion")),
                                    FechaSolicitud = lect.IsDBNull(lect.GetOrdinal("FechaSolicitud")) ? default(DateTime) : lect.GetDateTime(lect.GetOrdinal("FechaSolicitud")),
                                };
                                evAprobados.Add(jresultAprobados);
                            }

                        }

                        listFinal.listaFinanciamientosAprobados = evAprobados.ToList();

                        lect.Close();
                    }      

                    
                    connection.Close();
                    connection.Dispose();
                    return listFinal;
                }
            }
        }

        public async Task<ListAsesorCabeceraDashboard> GetTotalesAsesorById(int IdAsesor, DateTime FechaInicio, DateTime FechaFin)
        {
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_DashboardAsesorTotales", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@IdAsesor", SqlDbType.Int).Value = IdAsesor;
                    sql.Parameters.Add("@FechaInicio", SqlDbType.DateTime).Value = FechaInicio;
                    sql.Parameters.Add("@FechaFin", SqlDbType.DateTime).Value = FechaFin;

                    sql.CommandTimeout = 0;
                    SqlDataReader lect = sql.ExecuteReader();
                    ListAsesorCabeceraDashboard evclient = null;

                    while (lect.Read())
                    {
                        evclient = new ListAsesorCabeceraDashboard()
                        {
                            //
                            CantidadTotal_Financiamieno= lect.IsDBNull(lect.GetOrdinal("Cantidad_Financiamientos")) ? default(int) : lect.GetInt32(lect.GetOrdinal("Cantidad_Financiamientos")),
                            Porcentaje_Ventas = lect.IsDBNull(lect.GetOrdinal("Porcentaje_Ventas")) ? default(decimal) : lect.GetDecimal(lect.GetOrdinal("Porcentaje_Ventas")),
                            Financiamientos_Aprobados = lect.IsDBNull(lect.GetOrdinal("Financiamientos_Aprobados")) ? default(int) : lect.GetInt32(lect.GetOrdinal("Financiamientos_Aprobados")),
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
