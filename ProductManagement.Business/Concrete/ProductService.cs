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
    public class ProductService : IProductService
    {
        private readonly IProductDal _productDal;
        private readonly ICampaignDal _campaignDal;
        private readonly ITimeService _timeService;

        public ProductService(IProductDal productDal, ICampaignDal campaignDal, ITimeService timeService)
        {
            _productDal = productDal;
            _campaignDal = campaignDal;
            _timeService = timeService;
        }

        public Product CreateProduct(Product product)
        {
            Product productToBeCreated = null;
            var productControll = _productDal.GetOne(x => x.ProductCode == product.ProductCode);
            if (productControll == null)
            {
                _productDal.Create(product);
                productToBeCreated = _productDal.GetOne(x => x.ProductCode == product.ProductCode);
            }

            return productToBeCreated;
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }

        public Product GetProductByProductCode(string productCode)
        {
            Product productDetail = _productDal.GetOne(x => x.ProductCode == productCode);

            if (productDetail != null)
            {
                var currentTime = _timeService.GetCurrentTime();
                var campaign = _campaignDal.GetOne(x => x.Product.ProductCode == productCode);

                if (campaign != null)
                {
                    if (currentTime.CurrentTime > 0
                        && (campaign.Duration > currentTime.CurrentTime)
                        && campaign.TotalSales < campaign.TargetSalesCount)
                    {
                        var random = new Random();
                        var discount = random.Next(1, campaign.PriceManipulationLimit);

                        productDetail.Price = ((100 - discount) * productDetail.Price) / 100;
                    }
                }
            }

            return productDetail;
        }
    }
}
