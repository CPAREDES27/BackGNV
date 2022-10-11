using Application.Dto;
using Application.Dto.CustomEntities;
using Application.Dto.Product;
using Application.Services.Interfaces;
using Domain.MainModule;
using Domain.MainModule.Entities;
using Domain.MainModule.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<List<ProductNuevoEntity>> GetListAsync()
        {
            return await _unitOfWork.productRepository.GetListAsync();
        }

        public async Task<List<MarcaEntity>> GetListMarca()
        {
            return await _unitOfWork.productRepository.GetListMarca();
        }

        public async Task<List<ProveedorEntity>> GetListProveedor()
        {
            return await _unitOfWork.productRepository.GetListProveedor();
        }

        public async Task<List<ProductTipoEntity>> GetListTipoProduct()
        {
            return await _unitOfWork.productRepository.GetListTipoProduct();
        }
        public async Task<TotalListProductEntity> GetProductosAllPag(ProductFilterDTO request)
        {
            return await _unitOfWork.productRepository.GetProductosAllPag(request);
        }
        public PagedList<ProductEntity> GetProduct(ProductQueryFilterDTO productQueryFilterDTO)
        {
            return _unitOfWork.productRepository.GetProduct(productQueryFilterDTO);
        }

        public async Task<ProductNuevoEntity> GetProductById(int idProducto)
        {
            return await _unitOfWork.productRepository.GetProductById(idProducto);
        }

        public async Task<ProductEntity> RegisterProduct(ProductEntity productEntity)
        {
            return await _unitOfWork.productRepository.RegisterProduct(productEntity);
        }

        public async Task<int> UpdateProduct(ProductEntity productEntity)
        {
            return await _unitOfWork.productRepository.UpdateProduct(productEntity);
        }
        public async Task<int> UpdateStatusProduct(ProductStatusDTO productDTO)
        {
            return await _unitOfWork.productRepository.UpdateStatusProduct(productDTO);
        }

        public async Task<ListProductMaestroEnty> ListMaestroProduct(int IdUsuario, int IdRol)
        {
            return await _unitOfWork.productRepository.ListMaestroProduct(IdUsuario, IdRol);
        }
    }
}
