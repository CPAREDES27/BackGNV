using Application.Dto;
using Application.Dto.CustomEntities;
using Application.Dto.Product;
using Application.Manager.Interfaces;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.MainModule;
using Domain.MainModule.Entities;
using Domain.MainModule.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Manager.Implementation
{
    public class ProductManager : IProductManager
    {
        private readonly IProductService productService;
        private readonly IMapper mapper;

        public ProductManager(IProductService productService,IMapper mapper)
        {
            this.productService = productService;
            this.mapper = mapper;
        }

        public async Task<List<ProductNuevoEntity>> ListAsync()
        {
            List<ProductNuevoEntity> product = await productService.GetListAsync();
            //List<ProductDTO> result = mapper.Map<List<ProductDTO>>(product);
            return product;
        }
        public async Task<TotalListProductEntity> GetProductosAllPag(ProductFilterDTO request)
        {
            var resultado = productService.GetProductosAllPag(request);
            return  await resultado;
        }
        public PagedList<ProductEntity> ListPageProduct(ProductQueryFilterDTO productQueryFilterDTO)
        {
            var _productEntity = productService.GetProduct(productQueryFilterDTO);
            return _productEntity;
        }

        public async Task<ProductNuevoEntity> GetProductById(int idProducto)
        {
            return await productService.GetProductById(idProducto);
        }

        public async Task<ProductDTO> RegisterProduct(ProductRequestDTO productoDTO)
        {
            try
            {
                ProductEntity productEntity = mapper.Map<ProductEntity>(productoDTO);
                ProductEntity _productEntity = await productService.RegisterProduct(productEntity);
                ProductDTO customerDTO = mapper.Map<ProductDTO>(_productEntity);
                return customerDTO;
            }catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<int> UpdateProduct(ProductRequestDTO productoDTO)
        {
            try
            {
                ProductEntity productEntity = mapper.Map<ProductEntity>(productoDTO);
                int resultado = await productService.UpdateProduct(productEntity);
                
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> UpdateStatusProduct(ProductStatusDTO productoDTO)
        {
            try
            {
                //ProductEntity productEntity = mapper.Map<ProductEntity>(productoDTO);
                int resultado = await productService.UpdateStatusProduct(productoDTO);            
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<MarcaDTO>> ListMarca()
        {
            List<MarcaEntity> marca = await productService.GetListMarca();
            List<MarcaDTO> result = mapper.Map<List<MarcaDTO>>(marca);
            return result;
        }

        public async Task<List<ProveedorDTO>> ListProveedor()
        {
            List<ProveedorEntity> marca = await productService.GetListProveedor();
            List<ProveedorDTO> result = mapper.Map<List<ProveedorDTO>>(marca);
            return result;
        }

        public async Task<List<ProductTipoDTO>> ListTipoProduct()
        {
            List<ProductTipoEntity> marca = await productService.GetListTipoProduct();
            List<ProductTipoDTO> result = mapper.Map<List<ProductTipoDTO>>(marca);
            return result;
        }

        public async Task<ListProductMaestroEnty> ListMaestroProduct(int IdUsuario, int IdRol)
        {
            return await productService.ListMaestroProduct(IdUsuario, IdRol);
        }
    }
}
