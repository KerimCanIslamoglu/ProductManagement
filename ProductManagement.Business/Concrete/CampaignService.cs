using ProductManagement.Business.Abstract;
using ProductManagement.DataAccess.Abstract;
using ProductManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Business.Concrete
{
    public class CampaignService : ICampaignService
    {
        private readonly ICampaignDal _campaignDal;
        private readonly IProductDal _productDal;

        public CampaignService(ICampaignDal campaignDal, IProductDal productDal)
        {
            _campaignDal = campaignDal;
            _productDal = productDal;
        }

        public Campaign CreateCampaign(string campaignName, string productCode, int duration, int limit, int targetSalesCount)
        {
            Campaign campaign = null;

            var product = _productDal.GetOne(x => x.ProductCode == productCode);

            if (product != null)
            {
                campaign = new Campaign()
                {
                    AverageItemPrice=product.Price,
                    CampaignName=campaignName,
                    Duration=duration,
                    PriceManipulationLimit=limit,
                    ProductId=product.Id,
                    TargetSalesCount=targetSalesCount,
                    TotalSales=0,
                    TurnOver=0
                };

                _campaignDal.Create(campaign);
            }



            return campaign;
        }
    }
}
