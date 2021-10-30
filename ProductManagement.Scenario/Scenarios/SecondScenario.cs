using ProductManagement.Scenario.ApiHelper;
using ProductManagement.Scenario.Model;
using ProductManagement.Scenario.Model.Campaign;
using ProductManagement.Scenario.Model.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Scenario.Scenarios
{
    public class SecondScenario
    {
        public async Task Start()
        {
            var restApiGenerator = new RestApiGenerator();
            var baseUrl = "http://localhost:29520/api/";

            var url = string.Empty;


            var productModel = new CreateProductModel()
            {
                ProductCode = "P2",
                Price = 100,
                Stock = 1000
            };
            url = baseUrl + "product/create_product";
            var product = await restApiGenerator.PostApi<ResponseModel<ProductModel>>(productModel, url);
            if (product != null)
                Console.WriteLine(product.Message);


            var campaignModel = new CreateCampaignModel()
            {
                CampaignName = "C2",
                ProductCode = "P2",
                Duration = 5,
                Limit = 20,
                TargetSalesCount = 100
            };
            url = baseUrl + "campaign/create_campaign";
            var campaign = await restApiGenerator.PostApi<ResponseModel<CampaignInfoModel>>(campaignModel, url);
            if (campaign != null)
                Console.WriteLine(campaign.Message);



            url = baseUrl + "product/get_product_info/P2";
            var firstProductInfo = await restApiGenerator.GetApi<ResponseModel<ProductModel>>(url);
            if (firstProductInfo != null)
                Console.WriteLine(firstProductInfo.Message);

            url = baseUrl + "time/increase_time?increment=1";
            var firstTime = await restApiGenerator.PutApi<ResponseModel<string>>(null, url);
            if (firstTime != null)
                Console.WriteLine(firstTime.Message);



            url = baseUrl + "product/get_product_info/P2";
            var secondProductInfo = await restApiGenerator.GetApi<ResponseModel<ProductModel>>(url);
            if (secondProductInfo != null)
                Console.WriteLine(secondProductInfo.Message);

            url = baseUrl + "time/increase_time?increment=1";
            var secondTime = await restApiGenerator.PutApi<ResponseModel<string>>(null, url);
            if (secondTime != null)
                Console.WriteLine(secondTime.Message);


            url = baseUrl + "product/get_product_info/P2";
            var thirdProductInfo = await restApiGenerator.GetApi<ResponseModel<ProductModel>>(url);
            if (thirdProductInfo != null)
                Console.WriteLine(thirdProductInfo.Message);

            url = baseUrl + "time/increase_time?increment=1";
            var thirdTime = await restApiGenerator.PutApi<ResponseModel<string>>(null, url);
            if (thirdTime != null)
                Console.WriteLine(thirdTime.Message);


            url = baseUrl + "product/get_product_info/P2";
            var fourthProductInfo = await restApiGenerator.GetApi<ResponseModel<ProductModel>>(url);
            if (fourthProductInfo != null)
                Console.WriteLine(fourthProductInfo.Message);

            url = baseUrl + "time/increase_time?increment=1";
            var fourthTime = await restApiGenerator.PutApi<ResponseModel<string>>(null, url);
            if (fourthTime != null)
                Console.WriteLine(fourthTime.Message);




            url = baseUrl + "product/get_product_info/P2";
            var fifthProductInfo = await restApiGenerator.GetApi<ResponseModel<ProductModel>>(url);
            if (fifthProductInfo != null)
                Console.WriteLine(fifthProductInfo.Message);

            url = baseUrl + "time/increase_time?increment=2";
            var fifthTime = await restApiGenerator.PutApi<ResponseModel<string>>(null, url);
            if (fifthTime != null)
                Console.WriteLine(fifthTime.Message);

            url = baseUrl + "product/get_product_info/P2";
            var sixthProductInfo = await restApiGenerator.GetApi<ResponseModel<ProductModel>>(url);
            if (sixthProductInfo != null)
                Console.WriteLine(sixthProductInfo.Message);

            url = baseUrl + "campaign/get_campaign_info/C2";
            var campaignInfo = await restApiGenerator.GetApi<ResponseModel<CampaignInfoModel>>(url);
            if (campaignInfo != null)
                Console.WriteLine(campaignInfo.Message);

        }
    }
}
