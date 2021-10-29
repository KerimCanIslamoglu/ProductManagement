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
    public class OrderService : IOrderService
    {
        private readonly IOrderDal _orderDal;
        private readonly IProductDal _productDal;
        private readonly ICampaignDal _campaignDal;
        private readonly ITimeService _timeService;

        public OrderService(IOrderDal orderDal, IProductDal productDal, ICampaignDal campaignDal, ITimeService timeService)
        {
            _orderDal = orderDal;
            _productDal = productDal;
            _campaignDal = campaignDal;
            _timeService = timeService;
        }

        public Order CreateOrder(string productCode, int quantity)
        {
            Order order = null;

            var productDetail = _productDal.GetOne(x => x.ProductCode == productCode);

            if (productDetail != null)
            {
                if (productDetail.Stock >= quantity)
                {
                    var currentTime = _timeService.GetCurrentTime();
                    var campaign = _campaignDal.GetOne(x => x.Product.ProductCode == productCode);

                    if (campaign != null)
                    {
                        if ((campaign.Duration > currentTime.CurrentTime)
                            && campaign.TotalSales < campaign.TargetSalesCount
                           && ((campaign.TotalSales + quantity) <= campaign.TargetSalesCount))
                        {
                            var random = new Random();
                            var discount = random.Next(1, campaign.PriceManipulationLimit);

                            productDetail.Price = ((100 - discount) * productDetail.Price) / 100;

                            var productOrders = _orderDal.GetAll(x => x.Product.ProductCode == productCode);

                            double totalProductPrice = productDetail.Price;

                            foreach (var productOrder in productOrders)
                            {
                                totalProductPrice += (productOrder.TotalPrice / productOrder.Quantity);
                            }

                            campaign.TotalSales += quantity;
                            campaign.TurnOver += (quantity * productDetail.Price);
                            campaign.AverageItemPrice = totalProductPrice / productOrders.Count;

                            _campaignDal.Update(campaign);
                        }

                        order = new Order()
                        {
                            ProductId = productDetail.Id,
                            Quantity = quantity,
                            TotalPrice = (productDetail.Price) * (quantity)
                        };

                        _orderDal.Create(order);
                    }
                    else
                    {
                        order = new Order()
                        {
                            ProductId = productDetail.Id,
                            Quantity = quantity,
                            TotalPrice = (productDetail.Price) * (quantity)
                        };

                        _orderDal.Create(order);
                    }
                }
            }
            return order;

        }
    }
}
