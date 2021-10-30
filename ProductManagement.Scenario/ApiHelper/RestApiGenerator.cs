using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Scenario.ApiHelper
{
    public class RestApiGenerator
    {
        public async Task<T> GetApi<T>(string url)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(url))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(apiResponse);
                }
            }

        }

        public async Task<T> PostApi<T>(object jsonContent, string url)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(jsonContent), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync(url, content))
                {

                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(apiResponse);
                }
            }

        }

        public async Task<T> PutApi<T>(object jsonContent, string url)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(jsonContent), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PutAsync(url, content))
                {

                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(apiResponse);
                }
            }

        }
       
    }
}
