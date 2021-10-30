using ProductManagement.Scenario.ApiHelper;
using ProductManagement.Scenario.Model;
using ProductManagement.Scenario.Model.Campaign;
using ProductManagement.Scenario.Model.Order;
using ProductManagement.Scenario.Model.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Scenario.Scenarios
{
    public class FirstScenario
    {
        public async Task Start()
        {
            var restApiGenerator = new RestApiGenerator();
            var baseUrl = "http://localhost:29520/api/";

            var url = string.Empty;



            var productModel = new CreateProductModel()
            {
                ProductCode = "P1",
                Price = 100,
                Stock = 1000
            };
            url = baseUrl + "product/create_product";
            var product = await restApiGenerator.PostApi<ResponseModel<ProductModel>>(productModel,url);
            if (product != null)
                Console.WriteLine(product.Message);


            url = baseUrl + "product/get_product_info/P1";
            var productInfo = await restApiGenerator.GetApi<ResponseModel<ProductModel>>(url);
            if (productInfo != null)
                Console.WriteLine(productInfo.Message);


            var orderModel = new CreateOrderModel()
            {
                ProductCode = "P1",
                Quantity = 3
            };
            url = baseUrl + "order/create_order";
            var order = await restApiGenerator.PostApi<ResponseModel<CreateOrderModel>>(orderModel, url);
            if (order != null)
                Console.WriteLine(order.Message);


            var campaignModel = new CreateCampaignModel()
            {
                CampaignName = "C1",
                ProductCode = "P1",
                Duration = 10,
                Limit = 20,
                TargetSalesCount = 100
            };
            url = baseUrl + "campaign/create_campaign";
            var campaign = await restApiGenerator.PostApi<ResponseModel<CampaignInfoModel>>(campaignModel, url);
            if (campaign != null)
                Console.WriteLine(campaign.Message);

            url = baseUrl + "campaign/get_campaign_info/C1";
            var campaignInfo = await restApiGenerator.GetApi<ResponseModel<CampaignInfoModel>>(url);
            if (campaignInfo != null)
                Console.WriteLine(campaignInfo.Message);

            url = baseUrl + "time/increase_time?increment=1";
            var time = await restApiGenerator.PutApi<ResponseModel<string>>(null, url);
            if (time != null)
                Console.WriteLine(time.Message);


            url = baseUrl + "time/reset_time";
            var resetTime = await restApiGenerator.PutApi<ResponseModel<string>>(null, url);
            if (resetTime != null)
            {
                Console.WriteLine("Time is resetting to 0...");
                Console.WriteLine(resetTime.Message);
            }


        }
    }
}
