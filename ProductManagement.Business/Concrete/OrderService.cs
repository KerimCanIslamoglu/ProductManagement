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

        public OrderService(IOrderDal orderDal, IProductDal productDal)
        {
            _orderDal = orderDal;
            _productDal = productDal;
        }

        public Order CreateOrder(string productCode, int quantity)
        {
            Order order = null;

            var productDetail = _productDal.GetOne(x => x.ProductCode == productCode);

            if (productDetail != null)
            {
                order = new Order()
                {
                    ProductId = productDetail.Id,
                    Quantity = quantity,
                    TotalPrice = (productDetail.Price) * (quantity)
                };

                _orderDal.Create(order);
            }

            return order;
        }
    }
}
