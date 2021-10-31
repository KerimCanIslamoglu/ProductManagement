using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Api.Model;
using ProductManagement.Api.Model.Product;
using ProductManagement.Business.Abstract;
using ProductManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.Api.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        [Route("api/product/create_product")]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            var product = new Product()
            {
                Price = createProductDto.Price,
                ProductCode = createProductDto.ProductCode,
                Stock = createProductDto.Stock
            };

            var productControl=_productService.CreateProduct(product);

            if (productControl != null)
            {
                return Ok(new ResponseModel<CreateProductDto>
                {
                    Success = true,
                    StatusCode = 200,
                    Message = $"Product created; code {createProductDto.ProductCode}, price {createProductDto.Price}, stock { createProductDto.Stock} ",
                    Response = null
                });
            }
            else
            {
                return NotFound(new ResponseModel<CreateProductDto>
                {
                    Success = false,
                    StatusCode = 404,
                    Message = $"Product is not created",
                    Response = null
                });
            }
        }

        [HttpGet]
        [Route("api/product/get_product_info/{productCode}")]
        public IActionResult GetProductInfoByProductCode(string productCode)
        {
            var product = _productService.GetProductByProductCode(productCode);

            if (product == null)
            {
                return NotFound(new ResponseModel<ProductDto>
                {
                    Success = false,
                    StatusCode = 404,
                    Message = $"Product not found ",
                    Response = null
                });
            }
            else
            {
                var productDto = new ProductDto()
                {
                    Id = product.Id,
                    Price = product.Price,
                    ProductCode = product.ProductCode,
                    Stock = product.Stock
                };

                return Ok(new ResponseModel<ProductDto>
                {
                    Success = true,
                    StatusCode = 200,
                    Message = $"Product {product.ProductCode} info; price {product.Price}, stock {product.Stock} ",
                    Response = productDto
                });
            }
          
        }
    }
}
