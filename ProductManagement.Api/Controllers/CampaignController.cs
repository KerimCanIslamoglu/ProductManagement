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
        private readonly ITimeService _timeService;

        public CampaignController(ICampaignService campaignService, ITimeService timeService)
        {
            _campaignService = campaignService;
            _timeService = timeService;
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
        [Route("api/campaign/get_campaign_info/{campaignName}")]
        public IActionResult GetCampaignInfo(string campaignName)
        {
            var campaignInfoDto = new CampaignInfoDto();

            var campaign = _campaignService.GetCampaignByName(campaignName);
            var currentTime = _timeService.GetCurrentTime();

            if ((currentTime.CurrentTime < campaign.Duration) 
                && (campaign.TotalSales < campaign.TargetSalesCount))
                campaignInfoDto.Status = "Active";
            else
                campaignInfoDto.Status = "Ended";


            campaignInfoDto.AverageItemPrice = campaign.AverageItemPrice;
            campaignInfoDto.CampaignName = campaign.CampaignName;
            campaignInfoDto.TargetSales = campaign.TargetSalesCount;
            campaignInfoDto.TotalSales = campaign.TotalSales;
            campaignInfoDto.TurnOver = campaign.TurnOver;


            if (campaign != null)
            {
                return Ok(new ResponseModel<CreateCampaignDto>
                {
                    Success = true,
                    StatusCode = 200,
                    Message = $"Campaign {campaignInfoDto.CampaignName} info; Status {campaignInfoDto.Status}, Target Sales {campaignInfoDto.TargetSales}, Total Sales {campaignInfoDto.TotalSales}, Turnover {campaignInfoDto.TurnOver}, Average Item Price {campaignInfoDto.AverageItemPrice}",
                    Response = null
                });
            }
            else
            {
                return NotFound(new ResponseModel<CreateCampaignDto>
                {
                    Success = false,
                    StatusCode = 404,
                    Message = $"Campaign cannot found. Invalid campaign name: {campaignName}.",
                    Response = null
                });
            }





           

        }
    }
}
