using Moq;
using NUnit.Framework;
using ProductManagement.Business.Abstract;
using ProductManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Test
{
    [TestFixture]
    public class ProductTest
    {
        Mock<IProductService> _mockProductService;

        public ProductTest()
        {
            var productList = new List<Product>
            {
                new Product() { Id = 1, ProductCode="P1", Price=100,Stock=1000 },
                new Product() { Id = 2, ProductCode="P2", Price=200,Stock=2000 },
                new Product() { Id = 3, ProductCode="P3", Price=300,Stock=3000 },
            };


            var mockProductService = new Mock<IProductService>();

            mockProductService.Setup(mr => mr.GetProductByProductCode(It.IsAny<string>())).Returns((string productCode)=>productList.Where(x=>x.ProductCode== productCode).SingleOrDefault());

            mockProductService.Setup(mr => mr.CreateProduct(It.IsAny<Product>())).Callback(
                (Product target) =>
                {
                    productList.Add(target);
                });

            mockProductService.Setup(mr => mr.Update(It.IsAny<Product>())).Callback(
                (Product target) =>
                {
                    var original = productList.Where(x => x.Id == target.Id).Single();

                    if (original == null)
                    {
                        throw new InvalidOperationException();
                    }

                    original.Id = target.Id;
                    original.ProductCode = target.ProductCode;
                    original.Price = target.Price;
                    original.Stock = target.Stock;

                });

            _mockProductService = mockProductService;
        }


        [TestCase(1,"P1",100,1000)]
        [TestCase(2,"P2",200,2000)]
        [TestCase(3,"P3",300,3000)]
        [Test]
        public void ProductService_GetProductByProductCode_ReturnsProduct(int id,string productCode,double price,int stock)
        {
            var product = _mockProductService.Object.GetProductByProductCode(productCode);

            Assert.IsNotNull(product);
            Assert.AreEqual(product.Id, id);
            Assert.AreEqual(product.ProductCode, productCode);
            Assert.AreEqual(product.Price, price);
            Assert.AreEqual(product.Stock, stock);
        }

        [TestCase(4, "P4", 400, 4000)]
        [TestCase(5, "P5", 500, 5000)]
        [TestCase(6, "P6", 600, 6000)]
        [Test]
        public void ProductService_CreateProduct_ShouldCreateProduct(int id, string productCode, double price, int stock)
        {
            var product = new Product()
            {
                Id = id,
                ProductCode = productCode,
                Price = price,
                Stock = stock
            };

            _mockProductService.Object.CreateProduct(product);

            var createdProduct = _mockProductService.Object.GetProductByProductCode(product.ProductCode);

            Assert.IsNotNull(createdProduct);
            Assert.AreEqual(createdProduct.Id, product.Id);
            Assert.AreEqual(createdProduct.ProductCode, product.ProductCode);
            Assert.AreEqual(createdProduct.Price, product.Price);
            Assert.AreEqual(createdProduct.Stock, product.Stock);
        }

        [TestCase(1, "P1", 100, 1000)]
        [TestCase(1, "P1", 80, 800)]
        [TestCase(1, "P1", 60, 500)]
        [Test]
        public void ProductService_UpdateProduct_ShouldUpdateProduct(int id, string productCode, double price, int stock)
        {
            var product = new Product()
            {
                Id = id,
                ProductCode = productCode,
                Price = price,
                Stock = stock
            };

            _mockProductService.Object.Update(product);

            var updatedProduct = _mockProductService.Object.GetProductByProductCode(product.ProductCode);

            Assert.IsNotNull(updatedProduct);
            Assert.AreEqual(updatedProduct.Id, product.Id);
            Assert.AreEqual(updatedProduct.ProductCode, product.ProductCode);
            Assert.AreEqual(updatedProduct.Price, product.Price);
            Assert.AreEqual(updatedProduct.Stock, product.Stock);
        }
    }
}
