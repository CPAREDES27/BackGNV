using Application.Dto;
using Application.Dto.CustomEntities;
using Application.Dto.Product;
using Application.Manager.Interfaces;
using Application.Services.Util;
using AutoMapper;
using Domain.MainModule;
using Domain.MainModule.Entities;
using Infrastructure.MainModule.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Services.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductManager productManager;
        private readonly IMapper mapper;
        private readonly IUriService uriService;

        public ProductController(
            IProductManager productManager,
            IMapper mapper,
            IUriService uriService)
        {
            this.productManager = productManager;
            this.mapper = mapper;
            this.uriService = uriService;
        }

        [HttpGet("ListProduct")]
        public async Task<IActionResult> ListProduct()
        {
            List<ProductNuevoEntity> resultProductEntity= await productManager.ListAsync();
            if(resultProductEntity.Count < 0)
            {
                return BadRequest(new { valid = false, message = Constants.InvalidListProduct });
            }
            return Ok(resultProductEntity);
        }

        [HttpGet("GetProductById")]
        public async Task<IActionResult> GetProductById(int idProducto)
        {
            ProductNuevoEntity resultProduct = await productManager.GetProductById(idProducto);

            if (resultProduct == null)
            {
                return BadRequest(new { valid = false, message = Constants.InvalidListProduct });
            }

            return Ok(resultProduct);
        }
        

        [HttpPost("AllProductPag_homo")]
        public async Task<IActionResult> GetProductosAllPag(ProductFilterDTO request)
        {
            var resultado = await productManager.GetProductosAllPag(request);
            if (resultado == null)
            {
                return Ok(new { valid = false, messaje = Constants.InvalidGetListProduct });
            }
            return Ok(resultado);
        }


        [HttpGet("AllProductPag")]
        public async Task<IActionResult> AllProductPag([FromQuery] ProductQueryFilterDTO productQueryFilterDTO)
        {
            var resultProduct = productManager.ListPageProduct(productQueryFilterDTO);
            var resultProductDtos = mapper.Map<List<ProductDTO>>(resultProduct);
            var metaData = new MetaData
            {
                TotalCount = resultProduct.TotalCount,
                PageSize = resultProduct.PageSize,
                CurrentPage = resultProduct.CurrentPage,
                TotalPages = resultProduct.TotalPages,
                HasNextPage = resultProduct.HasNextPage,
                HasPreviousPage = resultProduct.HasPreviousPage,
                NextPageUrl = uriService.GetPostPaginationProductUri(productQueryFilterDTO, Url.RouteUrl(RouteData.Values)).ToString(),
                PreviousPageUrl = uriService.GetPostPaginationProductUri(productQueryFilterDTO, Url.RouteUrl(RouteData.Values)).ToString()
            };

            var response = new ApiResponse<List<ProductDTO>>(resultProductDtos)
            {
                Meta = metaData
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metaData));

            return Ok(response);
        }

        [HttpPost("RegisterProduct")]
        public async Task<IActionResult> RegisterProduct([FromBody] ProductRequestDTO productDTO)
        {
            try
            {
                ProductDTO produtDTO = await productManager.RegisterProduct(productDTO);
                if (produtDTO.IdProducto < 0)
                {
                    return BadRequest(new { valid = false, message = Constants.ResponseRegisterProduct });
                }
                return Ok(new { valid = true, message = Constants.ReponseAddProduct });
            }
            catch(Exception ex)
            {
                throw ex;
            }
           
        }

        [HttpPost("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductRequestDTO productDTO)
        {
            try
            {
                int resultado = await productManager.UpdateProduct(productDTO);

                if (resultado <= 0)
                {
                    return BadRequest(new { valid = false, message = Constants.ResponseUpdateProductError });
                }

                return Ok(new { valid = true, message = Constants.ResponseUpdateProduct });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("UpdateStatusProduct")]
        public async Task<IActionResult> UpdateStatusProduct([FromBody] ProductStatusDTO productDTO)
        {
            try
            {
                int resultado = await productManager.UpdateStatusProduct(productDTO);

                if (resultado <= 0)
                {
                    return BadRequest(new { valid = false, message = Constants.ResponseUpdateStatusProductError });
                }

                return Ok(new { valid = true, message = Constants.ResponseUpdateStatusProduct });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("ListMarca")]
        public async Task<IActionResult> ListMarca()
        {
            List<MarcaDTO> resultMarcaDto = await productManager.ListMarca();
            if (resultMarcaDto.Count < 0)
            {
                return BadRequest(new { valid = false, message = Constants.InvalidListProduct });
            }
            return Ok(resultMarcaDto);
        }

        [HttpGet("ListProveedor")]
        public async Task<IActionResult> ListProveedor()
        {
            List<ProveedorDTO> resultProveedorDto = await productManager.ListProveedor();
            if (resultProveedorDto.Count < 0)
            {
                return BadRequest(new { valid = false, message = Constants.InvalidListProduct });
            }
            return Ok(resultProveedorDto);
        }

        [HttpGet("ListTipoProduct")]
        public async Task<IActionResult> ListTipoProduct()
        {
            List<ProductTipoDTO> resultProveedorDto = await productManager.ListTipoProduct();
            if (resultProveedorDto.Count < 0)
            {
                return BadRequest(new { valid = false, message = Constants.InvalidListProduct });
            }
            return Ok(resultProveedorDto);
        }

        [HttpGet("ListMaestroProduct")]
        public async Task<IActionResult> ListMaestroProduct(int IdUsuario, int IdRol)
        {
            var resultProductDto = await productManager.ListMaestroProduct(IdUsuario, IdRol);
            if (resultProductDto == null)
            {
                return Ok(new { valid = false, message = Constants.InvalidListProduct });
            }
            return Ok(resultProductDto);
        }

    }
}
