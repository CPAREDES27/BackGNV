using Application.Dto;
using Application.Dto.CustomEntities;
using Application.Dto.Product;
using Domain.MainModule;
using Domain.MainModule.Entities;
using Domain.MainModule.Entities.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductNuevoEntity>> GetListAsync();
        Task<TotalListProductEntity> GetProductosAllPag(ProductFilterDTO request);
        PagedList<ProductEntity> GetProduct(ProductQueryFilterDTO productQueryFilterDTO);
        Task<ProductNuevoEntity> GetProductById(int idProducto);
        Task<ProductEntity> RegisterProduct(ProductEntity productEntity);
        Task<int> UpdateProduct(ProductEntity productEntity);
        Task<int> UpdateStatusProduct(ProductStatusDTO productDTO);
        Task<List<MarcaEntity>> GetListMarca();
        Task<List<ProveedorEntity>> GetListProveedor();
        Task<List<ProductTipoEntity>> GetListTipoProduct();

        Task<ListProductMaestroEnty> ListMaestroProduct(int IdUsuario, int IdRol);
    }
}
