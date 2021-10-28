using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Api.Model;
using ProductManagement.Api.Model.Campaign;
using ProductManagement.Business.Abstract;
using ProductManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.Api.Controllers
{
    [ApiController]
    public class CampaignController : ControllerBase
    {
        private readonly ICampaignService _campaignService;

        public CampaignController(ICampaignService campaignService)
        {
            _campaignService = campaignService;
        }

        [HttpPost]
        [Route("api/campaign/create_campaign")]
        public IActionResult CreateProduct(CreateCampaignDto createCampaignDto)
        {

            var campaign=_campaignService
                .CreateCampaign(createCampaignDto.CampaignName,createCampaignDto.ProductCode,createCampaignDto.Duration,createCampaignDto.Limit,createCampaignDto.TargetSalesCount);

            if (campaign != null)
            {
                return Ok(new ResponseModel<CreateCampaignDto>
                {
                    Success = true,
                    StatusCode = 200,
                    Message = $"Campaign created; name {createCampaignDto.CampaignName}, product {createCampaignDto.ProductCode}, duration { createCampaignDto.Duration}, limit { createCampaignDto.Limit}, target sales count { createCampaignDto.TargetSalesCount} ",
                    Response = null
                });
            }
            else
            {
                return NotFound(new ResponseModel<CreateCampaignDto>
                {
                    Success = false,
                    StatusCode = 404,
                    Message = $"Campaign is not created; the product with the {createCampaignDto.ProductCode} code does not exist",
                    Response = null
                });
            }
           
        }



        [HttpGet]
        [Route("api/product/get_campaign_info/{campaignName}")]
        public IActionResult GetCampaignInfo(string campaignName)
        {
            //TODO yapılacak.
            return null;
            //var product = _productService.GetProductByProductCode(productCode);

            //if (product == null)
            //{
            //    return NotFound(new ResponseModel<ProductDto>
            //    {
            //        Success = false,
            //        StatusCode = 404,
            //        Message = $"Product not found ",
            //        Response = null
            //    });
            //}
            //else
            //{
            //    var productDto = new ProductDto()
            //    {
            //        Id = product.Id,
            //        Price = product.Price,
            //        ProductCode = product.ProductCode,
            //        Stock = product.Stock
            //    };

            //    return Ok(new ResponseModel<ProductDto>
            //    {
            //        Success = true,
            //        StatusCode = 200,
            //        Message = $"Product {product.ProductCode} info; price {product.Price}, stock {product.Stock} ",
            //        Response = productDto
            //    });
            //}

        }
    }
}
