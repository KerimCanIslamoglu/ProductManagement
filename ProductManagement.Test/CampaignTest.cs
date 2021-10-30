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
    public class CampaignTest
    {
        Mock<ICampaignService> _mockCampaignService;
        Mock<IProductService> _mockProductService;

        Mock<ICampaignDal> _mockCampaignDal;


        public CampaignTest()
        {
            var productList = new List<Product>
            {
                new Product() { Id = 1, ProductCode="P1", Price=100,Stock=1000 },
                new Product() { Id = 2, ProductCode="P2", Price=200,Stock=2000 },
                new Product() { Id = 3, ProductCode="P3", Price=300,Stock=3000 },
            };

            var campaignList = new List<Campaign>
            {
                new Campaign() { Id = 1, CampaignName="C1",AverageItemPrice=100,Duration=10,PriceManipulationLimit=10,TargetSalesCount=100,TotalSales=0,TurnOver=0 },
                new Campaign() { Id = 2, CampaignName="C2",AverageItemPrice=200,Duration=20,PriceManipulationLimit=20,TargetSalesCount=200,TotalSales=0,TurnOver=0 },
                 new Campaign() { Id = 3, CampaignName="C3",AverageItemPrice=300,Duration=30,PriceManipulationLimit=30,TargetSalesCount=300,TotalSales=0,TurnOver=0 },
            };

            Campaign returnedCampaign = null;


            var mockCampaignService = new Mock<ICampaignService>();
            var mockProductService = new Mock<IProductService>();
            var mockCampaignDal = new Mock<ICampaignDal>();

            mockCampaignService.Setup(mr => mr.GetCampaignByName(It.IsAny<string>()))
                .Returns((string campaignName) => campaignList.Where(x => x.CampaignName == campaignName).SingleOrDefault());

    
            mockCampaignService.Setup(mr => mr
              .CreateCampaign(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Callback(
                  (string campaignName,string productCode,int duration,int limit,int targetSalesCount) =>
                  {
                      var product = productList.FirstOrDefault(x => x.ProductCode == productCode);
                      var lastCampaign = campaignList.LastOrDefault();

                      if (product != null)
                      {
                          var campaign = new Campaign()
                          {
                              Id = lastCampaign.Id + 1,
                              ProductId = product.Id,
                             AverageItemPrice=product.Price,
                             CampaignName=campaignName,
                             Duration=duration,
                             PriceManipulationLimit=limit,
                             TargetSalesCount=targetSalesCount,
                             TotalSales=0,
                             TurnOver=0
                          };
                          campaignList.Add(campaign);
                          returnedCampaign = campaign;
                      }
                  }).Returns(() => returnedCampaign);


            mockProductService.Setup(mr => mr.GetProductByProductCode(It.IsAny<string>())).Returns((string productCode) => productList.Where(x => x.ProductCode == productCode).SingleOrDefault());

            mockCampaignDal.Setup(mr => mr.GetById(It.IsAny<int>())).Returns((int id) => campaignList.SingleOrDefault(x => x.Id == id));

            _mockCampaignService = mockCampaignService;
            _mockProductService = mockProductService;
            _mockCampaignDal = mockCampaignDal;
        }


        [TestCase( "C1", 100, 10,10,100)]
        [TestCase( "C2", 200, 20, 20, 200)]
        [TestCase( "C3", 300, 30, 30, 300)]
        [Test]
        public void CampaignService_GetCampaignByName_ReturnsCampaign( string campaignName, int averageItemPrice, int duration,int priceManipulationLimit,int targetSalesCount)
        {
            var campaign = _mockCampaignService.Object.GetCampaignByName(campaignName);

            Assert.IsNotNull(campaign);
            Assert.AreEqual(campaign.CampaignName, campaignName);
            Assert.AreEqual(campaign.AverageItemPrice, averageItemPrice);
            Assert.AreEqual(campaign.Duration, duration);
            Assert.AreEqual(campaign.PriceManipulationLimit, priceManipulationLimit);
            Assert.AreEqual(campaign.TargetSalesCount, targetSalesCount);
        }

        [TestCase("C4", "P1", 40, 20,400)]
        [TestCase("C5", "P2", 50, 15,500)]
        [TestCase("C6", "P3", 60, 10,600)]
        [Test]
        public void CampaignService_CreateCampaign_ShouldCreateCampaign(string campaignName,string productCode,  int duration, int priceManipulationLimit, int targetSalesCount)
        {
            var product = _mockProductService.Object.GetProductByProductCode(productCode);

            var campaign = _mockCampaignService.Object.CreateCampaign(campaignName,productCode,duration,priceManipulationLimit,targetSalesCount);

            var createdCampaign= _mockCampaignDal.Object.GetById(campaign.Id);

            Assert.IsNotNull(createdCampaign);
            Assert.AreEqual(createdCampaign.CampaignName, campaignName);
            Assert.AreEqual(createdCampaign.ProductId, product.Id);
            Assert.AreEqual(createdCampaign.Duration, duration);
            Assert.AreEqual(createdCampaign.PriceManipulationLimit, priceManipulationLimit);
            Assert.AreEqual(createdCampaign.TargetSalesCount, targetSalesCount);
        }
    }
}
