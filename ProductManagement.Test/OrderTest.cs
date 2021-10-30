using Moq;
using NUnit.Framework;
using ProductManagement.Business.Abstract;
using ProductManagement.DataAccess.Abstract;
using ProductManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Test
{
    [TestFixture]
    public class OrderTest
    {
        Mock<IOrderService> _mockOrderService;
        Mock<IProductService> _mockProductService;

        Mock<IOrderDal> _mockOrderDal;

        public OrderTest()
        {
            var productList = new List<Product>
            {
                new Product() { Id = 1, ProductCode="P1", Price=100,Stock=1000 },
                new Product() { Id = 2, ProductCode="P2", Price=200,Stock=2000 },
                new Product() { Id = 3, ProductCode="P3", Price=300,Stock=3000 },
            };

            var orderList = new List<Order>
            {
                new Order() { Id = 1, Quantity=10,TotalPrice=1000,ProductId=1},
                new Order() { Id = 2, Quantity=20,TotalPrice=4000,ProductId=2},
                new Order() { Id = 3, Quantity=30,TotalPrice=9000,ProductId=3},
            };

            var mockOrderService = new Mock<IOrderService>();
            var mockProductService = new Mock<IProductService>();
            var mockOrderDal = new Mock<IOrderDal>();
            Order returnedOrder = null;

            mockOrderService.Setup(mr => mr
            .CreateOrder(It.IsAny<string>(), It.IsAny<int>())).Callback(
                (string productCode,int quantity) =>
                {
                    var product = productList.FirstOrDefault(x => x.ProductCode == productCode);
                    var lastOrder = orderList.LastOrDefault();

                    if (product != null)
                    {
                        var order = new Order()
                        {
                            Id= lastOrder.Id+1,
                            ProductId = product.Id,
                            Quantity = quantity,
                            TotalPrice =product.Price*quantity
                        };
                        orderList.Add(order);
                        returnedOrder = order;
                    }
                }).Returns(()=>returnedOrder);
          
            mockProductService.Setup(mr => mr.GetProductByProductCode(It.IsAny<string>())).Returns((string productCode) => productList.Where(x => x.ProductCode == productCode).SingleOrDefault());

            mockOrderDal.Setup(mr => mr.GetById(It.IsAny<int>())).Returns((int id) => orderList.SingleOrDefault(x => x.Id == id));

            _mockOrderService = mockOrderService;
            _mockProductService = mockProductService;
            _mockOrderDal = mockOrderDal;
        }


        [TestCase("P1", 10)]
        [TestCase("P2", 20)]
        [TestCase("P3", 30)]
        [Test]
        public void OrderService_CreateOrder_ShouldCreateProduct(string productCode, int quantity)
        {
            var product = _mockProductService.Object.GetProductByProductCode(productCode);

            var order=_mockOrderService.Object.CreateOrder(product.ProductCode,quantity);

            var createdOrder = _mockOrderDal.Object.GetById(order.Id);

            Assert.IsNotNull(createdOrder);
            Assert.AreEqual(createdOrder.Id, order.Id);
            Assert.AreEqual(createdOrder.ProductId, product.Id);
            Assert.AreEqual(createdOrder.Quantity, order.Quantity);
            Assert.AreEqual(createdOrder.TotalPrice, order.TotalPrice);
        }
    }
}
