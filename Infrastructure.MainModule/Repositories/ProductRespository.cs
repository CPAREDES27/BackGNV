using Application.Dto;
using Application.Dto.CustomEntities;
using Application.Dto.Product;
using Application.Services.Interfaces;
using Application.Services.Util.SecurityDirectory;
using AutoMapper;
using Domain.MainModule;
using Domain.MainModule.Entities;
using Domain.MainModule.Entities.Product;
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
    public class ProductRespository : IProductService
    {
        private readonly DBGNVContext context;
        private readonly IConfiguration _configuration;
        private readonly IMapper mapper;
        private readonly PaginationOptions paginationOptions;
        private readonly IMasterRepository masterRepository;

        public ProductRespository(DBGNVContext context, IConfiguration configuration, IMasterRepository masterRepository)
        {
            this.context = context;
            _configuration = configuration;
            this.masterRepository = masterRepository;
        }

        public async Task<List<ProductNuevoEntity>> GetListAsync()
        {
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_ListProduct", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    //sql.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = descripcion;
                    sql.CommandTimeout = 0;
                    SqlDataReader lect = sql.ExecuteReader();
                    List<ProductNuevoEntity> dataSql = new List<ProductNuevoEntity>();
                    ProductNuevoEntity jsonResult;

                    while (lect.Read())
                    {
                        jsonResult = new ProductNuevoEntity()
                        {
                            IdProducto = Convert.ToInt32(lect["IdProducto"]),
                            Descripcion = Convert.ToString(lect["Descripcion"]),
                            Precio = Convert.ToDecimal(lect["Precio"]),
                            Imagen = Convert.ToString(lect["Imagen"]),
                            NumOrden = Convert.ToInt32(lect["NumOrden"]),
                            IdEstado = Convert.ToInt32(lect["Activo"]),
                            NombreProveedor = Convert.ToString(lect["NombreProveedor"])
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

        public async Task<ProductNuevoEntity> GetProductById(int idProducto)
        {
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_ListProductxId", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@idProducto", SqlDbType.Int).Value = idProducto;
                    sql.CommandTimeout = 0;
                    SqlDataReader lect = sql.ExecuteReader();
                    ProductNuevoEntity product = null;

                    while (lect.Read())
                    {
                        product = new ProductNuevoEntity()
                        {
                            IdProducto = Convert.ToInt32(lect["IdProducto"]),
                            Descripcion = Convert.ToString(lect["Descripcion"]),
                            Precio = Convert.ToDecimal(lect["Precio"]),
                            Imagen = Convert.ToString(lect["Imagen"]),
                            NumOrden = Convert.ToInt32(lect["NumOrden"]),
                            IdEstado = Convert.ToInt32(lect["Activo"]),
                            NombreProveedor = Convert.ToString(lect["NombreProveedor"]),
                            FlagProductoGNV = lect.IsDBNull(lect.GetOrdinal("FlagProductoGNV")) ? default(int) : lect.GetInt32(lect.GetOrdinal("FlagProductoGNV")),
                            IdProveedorProducto = lect.IsDBNull(lect.GetOrdinal("IdProveedorProducto")) ? default(int) : lect.GetInt32(lect.GetOrdinal("IdProveedorProducto")),
                            IdTipoProducto= lect.IsDBNull(lect.GetOrdinal("IdTipoProducto")) ? default(int) : lect.GetInt32(lect.GetOrdinal("IdTipoProducto")),
                            IdMarcaProducto = lect.IsDBNull(lect.GetOrdinal("IdMarcaProducto")) ? default(int) : lect.GetInt32(lect.GetOrdinal("IdMarcaProducto")),
                            UsuarioRegistro = lect.IsDBNull(lect.GetOrdinal("UsuarioRegistro")) ? default(int) : lect.GetInt32(lect.GetOrdinal("UsuarioRegistro")),
                            CodigoCalidda = lect.IsDBNull(lect.GetOrdinal("CodigoCalidda")) ? default(string) : lect.GetString(lect.GetOrdinal("CodigoCalidda")),
                        };
                    }

                    lect.Close();
                    connection.Close();
                    connection.Dispose();
                    return product;
                }
            }
        }

        public async Task<TotalListProductEntity> GetProductosAllPag(ProductFilterDTO request)
        {
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("[Sp_GetProductosAllPag]", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@idProducto", SqlDbType.Int).Value = request.IdProducto;
                    sql.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = request.Descripcion;
                    sql.Parameters.Add("@precio", SqlDbType.Decimal).Value = request.Precio;
                    sql.Parameters.Add("@imagen", SqlDbType.VarChar).Value = request.Imagen;
                    sql.Parameters.Add("@numOrden", SqlDbType.Int).Value = request.NumOrden;
                    sql.Parameters.Add("@NumeroPagina", SqlDbType.Int).Value = request.NumeroPagina;
                    sql.Parameters.Add("@NumeroRegistros", SqlDbType.Int).Value = request.NumeroRegistros;
                    sql.Parameters.Add("@IdProveedor", SqlDbType.Int).Value = request.idProveedor;
                    sql.CommandTimeout = 0;
                    SqlDataReader lect = sql.ExecuteReader();
                    TotalListProductEntity response = new TotalListProductEntity();

                    var totalRegistros = 0;
                    while (lect.Read())
                    {
                        if (totalRegistros == 0)
                        {
                            totalRegistros = Convert.ToInt32(lect["TotalRegistros"]);
                        }
                        var entidad = new ListProductEntity()
                        {
                            IdProducto = Convert.ToInt32(lect["IdProducto"]),
                            Descripcion = Convert.ToString(lect["Descripcion"]),
                            IdTipoProducto = Convert.ToInt32(lect["IdTipoProducto"]),
                            TipoDescripcion = Convert.ToString(lect["TipoDescripcion"]),
                            Precio = Convert.ToDecimal(lect["Precio"]),
                            Imagen = Convert.ToString(lect["Imagen"]),
                            NumOrden = Convert.ToInt32(lect["NumOrden"]),
                            ProveedorProducto = Convert.ToString(lect["ProveedorProducto"])
                           
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


        public PagedList<ProductEntity> GetProduct(ProductQueryFilterDTO productQueryFilterDTO)
        {
            productQueryFilterDTO.PageNumber = productQueryFilterDTO.PageNumber == 0 ? paginationOptions.DefaultPageNumber : productQueryFilterDTO.PageNumber;

            productQueryFilterDTO.PageSize = productQueryFilterDTO.PageSize == 0 ? paginationOptions.DefaultPageSize : productQueryFilterDTO.PageSize;

            var products = context.Productos.ToList();

            if (productQueryFilterDTO.IdProducto != null)
            {
                products = products.Where(x => x.IdProducto == productQueryFilterDTO.IdProducto).ToList();
            }

            if (productQueryFilterDTO.Descripcion != null)
            {
                products = products.Where(x => x.Descripcion.Contains(productQueryFilterDTO.Descripcion)).ToList();
            }

            if (productQueryFilterDTO.Precio != null)
            {
                products = products.Where(x => x.Precio == productQueryFilterDTO.Precio).ToList();
            }

            if (productQueryFilterDTO.Imagen != null)
            {
                products = products.Where(x => x.Imagen == productQueryFilterDTO.Imagen).ToList();
            }

            if (productQueryFilterDTO.NumOrden != null)
            {
                products = products.Where(x => x.NumOrden == productQueryFilterDTO.NumOrden).ToList();
            }

            var pagedListProduct = PagedList<ProductEntity>.Create(products, productQueryFilterDTO.PageNumber, productQueryFilterDTO.PageSize);

            return pagedListProduct;
        }

        public async Task<ProductEntity> RegisterProduct(ProductEntity productEntity)
        {
            //Obtiene rutas temporal y fisica poducto
            var rutaFisica = await masterRepository.GetCredentialsUrl(DirectoryConst.PublicPathProductoFisica);
            var result = await masterRepository.GetCredentialsUrl(DirectoryConst.PublicPathProduct);
            //

            //ruta final
            var lastFileName = rutaFisica.Valor;

            if(Convert.ToInt32(productEntity.imagenBase64.Length) > 100)
            {
                //guarda Archivo en la ruta indicada
                await using var stream = new FileStream($"{lastFileName}\\{productEntity.Imagen}", FileMode.Create, FileAccess.Write);
                var fileByte = Convert.FromBase64String(productEntity.imagenBase64.Substring(productEntity.imagenBase64.LastIndexOf(',') + 1));
                stream.Write(fileByte);
            }

            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_RegistrarProducto", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;

                    //sql.Parameters.Add("@IdProducto", SqlDbType.Int).Value = productEntity.IdProducto;
                    sql.Parameters.Add("@IdTipoProducto", SqlDbType.Int).Value = productEntity.IdTipoProducto;
                    sql.Parameters.Add("@IdMarcaProducto", SqlDbType.Int).Value = productEntity.IdMarcaProducto;
                    sql.Parameters.Add("@IdProveedorProducto", SqlDbType.Int).Value = productEntity.IdProveedorProducto;
                    sql.Parameters.Add("@DescripcionProducto", SqlDbType.VarChar).Value = productEntity.Descripcion;
                    sql.Parameters.Add("@PrecioProducto", SqlDbType.Decimal).Value = productEntity.Precio;
                    sql.Parameters.Add("@ImagenProducto", SqlDbType.VarChar).Value = result.Valor + productEntity.Imagen;  //Registra la ruta
                    sql.Parameters.Add("@NumOrdenProducto", SqlDbType.Int).Value = productEntity.NumOrden;
                    sql.Parameters.Add("@ActivoProducto", SqlDbType.Bit).Value = productEntity.IdEstado;
                    sql.Parameters.Add("@UsuarioRegistro", SqlDbType.Int).Value = productEntity.UsuarioRegistro;
                    sql.Parameters.Add("@CodigoCalidda", SqlDbType.VarChar).Value = productEntity.CodigoProducto;
                    
                    sql.CommandTimeout = 0;

                    SqlDataReader lect = sql.ExecuteReader();
                    ProductEntity response = new ProductEntity();

                    while (lect.Read())
                    {
                        response.IdProducto = Convert.ToInt32(lect["IdProducto"]);
                    }

                    lect.Close();
                    connection.Close();
                    connection.Dispose();
                    return response;
                }
            }
        }

        public async Task<int> UpdateProduct(ProductEntity productEntity)
        {
            //Obtiene rutas temporal y fisica poducto
            var rutaFisica = await masterRepository.GetCredentialsUrl(DirectoryConst.PublicPathProductoFisica);
            var result = await masterRepository.GetCredentialsUrl(DirectoryConst.PublicPathProduct);
            //

            //ruta final
            var lastFileName = rutaFisica.Valor;

            if (Convert.ToInt32(productEntity.imagenBase64.Length) > 100)
            {
                //guarda Archivo en la ruta indicada
                await using var stream = new FileStream($"{lastFileName}\\{productEntity.Imagen}", FileMode.Create, FileAccess.Write);
                var fileByte = Convert.FromBase64String(productEntity.imagenBase64.Substring(productEntity.imagenBase64.LastIndexOf(',') + 1));
                stream.Write(fileByte);
            }

            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_UpdateProduct", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;

                    sql.Parameters.Add("@idProducto", SqlDbType.Int).Value = productEntity.IdProducto;
                    sql.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = productEntity.Descripcion;
                    sql.Parameters.Add("@precio", SqlDbType.Decimal).Value = productEntity.Precio;
                    sql.Parameters.Add("@imagen", SqlDbType.VarChar).Value = result.Valor + productEntity.Imagen;
                    sql.Parameters.Add("@numOrden", SqlDbType.Int).Value = productEntity.NumOrden;
                    sql.Parameters.Add("@activo", SqlDbType.Bit).Value = productEntity.IdEstado;
                    sql.CommandTimeout = 0;

                    int resultado = await sql.ExecuteNonQueryAsync();

                    connection.Close();
                    connection.Dispose();
                    return resultado;
                }
            }
        }

        public async Task<int> UpdateStatusProduct(ProductStatusDTO productDTO)
        {
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_UpdateEstadoProduct", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;

                    sql.Parameters.Add("@idProducto", SqlDbType.Int).Value = productDTO.IdProducto;                
                    sql.Parameters.Add("@activo", SqlDbType.Bit).Value = productDTO.Activo;
                    sql.CommandTimeout = 0;

                    int resultado = await sql.ExecuteNonQueryAsync();

                    connection.Close();
                    connection.Dispose();
                    return resultado;
                }
            }
        }

        public async Task<List<MarcaEntity>> GetListMarca()
        {
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_ListMarca", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    //sql.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = descripcion;
                    sql.CommandTimeout = 0;
                    SqlDataReader lect = sql.ExecuteReader();
                    List<MarcaEntity> dataSql = new List<MarcaEntity>();
                    MarcaEntity jsonResult;

                    while (lect.Read())
                    {
                        jsonResult = new MarcaEntity()
                        {
                            IdMarca = Convert.ToInt32(lect["IdMarca"]),
                            Descripcion = Convert.ToString(lect["Descripcion"]),
                            IdEstado = Convert.ToInt32(lect["Activo"])
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

        public async Task<List<ProveedorEntity>> GetListProveedor()
        {
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_ListProveedor", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    //sql.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = descripcion;
                    sql.CommandTimeout = 0;
                    SqlDataReader lect = sql.ExecuteReader();
                    List<ProveedorEntity> dataSql = new List<ProveedorEntity>();
                    ProveedorEntity jsonResult;

                    while (lect.Read())
                    {
                        jsonResult = new ProveedorEntity()
                        {
                            IdProveedor = Convert.ToInt32(lect["IdProveedor"]),
                            RazonSocial = Convert.ToString(lect["RazonSocial"]),
                            IdEstado = Convert.ToInt32(lect["Activo"])
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

        public async Task<List<ProductTipoEntity>> GetListTipoProduct()
        {
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("Sp_TipoProducto", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    //sql.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = descripcion;
                    sql.CommandTimeout = 0;
                    SqlDataReader lect = sql.ExecuteReader();
                    List<ProductTipoEntity> dataSql = new List<ProductTipoEntity>();
                    ProductTipoEntity jsonResult;

                    while (lect.Read())
                    {
                        jsonResult = new ProductTipoEntity()
                        {
                            IdTipoProducto = Convert.ToInt32(lect["IdTipoProducto"]),
                            TipoDescripcion = Convert.ToString(lect["TipoDescripcion"]),
                            IdEstado = Convert.ToInt32(lect["Activo"])
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

        public async Task<ListProductMaestroEnty> ListMaestroProduct(int IdUsuario, int IdRol)
        {
            await using (var connection = new SqlConnection(_configuration["ConnectionStrings:CnnGnvSqlServer"]))
            {
                connection.Open();
                await using (var sql = new SqlCommand("sp_ListaTipoMarcaProveedor", connection))
                {
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = IdUsuario;
                    sql.Parameters.Add("@Idrol", SqlDbType.Int).Value = IdRol;

                    sql.CommandTimeout = 90;

                    ListProductMaestroEnty listFinal;

                    List<ProductTipo> evTipo = new List<ProductTipo>();
                    ProductTipo jresultTipo;

                    List<ProductMarca> evMarca = new List<ProductMarca>();
                    ProductMarca jresultMarca;

                    List<ProductProveedor> evProveedor = new List<ProductProveedor>();
                    ProductProveedor jresultProveedor;

                    listFinal = new ListProductMaestroEnty();

                    using (SqlDataReader lect = sql.ExecuteReader())
                    {
                        while (lect.Read())
                        {
                            jresultTipo = new ProductTipo()

                            {
                                //Lista Financiamientos
                                idTipoProducto = lect.IsDBNull(lect.GetOrdinal("IdTipoProducto")) ? default(int) : lect.GetInt32(lect.GetOrdinal("IdTipoProducto")),
                                tipoDescripcion = lect.IsDBNull(lect.GetOrdinal("TipoProducto")) ? default(string) : lect.GetString(lect.GetOrdinal("TipoProducto")),

                            };
                            evTipo.Add(jresultTipo);
                        }

                        listFinal.ListTipoProducto = evTipo.ToList();

                        if (lect.NextResult())
                        {
                            while (lect.Read())
                            {
                                jresultMarca = new ProductMarca()
                                {
                                    idMarca = lect.IsDBNull(lect.GetOrdinal("IdMarcaProducto")) ? default(int) : lect.GetInt32(lect.GetOrdinal("IdMarcaProducto")),
                                    descripcion = lect.IsDBNull(lect.GetOrdinal("Marca")) ? default(string) : lect.GetString(lect.GetOrdinal("Marca")),

                                };
                                evMarca.Add(jresultMarca);
                            }

                        }

                        listFinal.ListMarcaProducto = evMarca.ToList();

                        if (lect.NextResult())
                        {
                            while (lect.Read())
                            {
                                jresultProveedor = new ProductProveedor()
                                {
                                    idProveedor = lect.IsDBNull(lect.GetOrdinal("IdUsuario")) ? default(int) : lect.GetInt32(lect.GetOrdinal("IdUsuario")),
                                    razonSocial = lect.IsDBNull(lect.GetOrdinal("Proveedor")) ? default(string) : lect.GetString(lect.GetOrdinal("Proveedor")),

                                };
                                evProveedor.Add(jresultProveedor);
                            }

                        }

                        listFinal.ListProveedorProducto = evProveedor.ToList();


                        lect.Close();
                    }


                    connection.Close();
                    connection.Dispose();
                    return listFinal;
                }
            }
        }
    }
}
