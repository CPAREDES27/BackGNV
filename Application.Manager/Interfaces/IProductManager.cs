using Application.Dto;
using Application.Dto.CustomEntities;
using Application.Dto.Product;
using Domain.MainModule;
using Domain.MainModule.Entities;
using Domain.MainModule.Entities.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Manager.Interfaces
{
    public interface IProductManager
    {
        Task<List<ProductNuevoEntity>> ListAsync();
        Task<TotalListProductEntity> GetProductosAllPag(ProductFilterDTO request);
        PagedList<ProductEntity> ListPageProduct(ProductQueryFilterDTO productQueryFilterDTO);
        Task<ProductNuevoEntity> GetProductById(int idProducto);
        Task<ProductDTO> RegisterProduct(ProductRequestDTO productDTO);
        Task<int> UpdateProduct(ProductRequestDTO productDTO);

        Task<int> UpdateStatusProduct(ProductStatusDTO productDTO);

        Task<List<MarcaDTO>> ListMarca();
        Task<List<ProveedorDTO>> ListProveedor();
        Task<List<ProductTipoDTO>> ListTipoProduct();

        Task<ListProductMaestroEnty> ListMaestroProduct(int IdUsuario, int IdRol);

    }
}
