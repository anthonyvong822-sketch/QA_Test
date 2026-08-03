using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace QA
{
    public interface IProductService
    {
        Task<ProductListResponse> SearchProductsAsync(string searchTerm);
    }

    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        private const string ApiUrl = "https://automationexercise.com/api/productsList";

        public ProductService(HttpClient httpClient)
        {
            if (httpClient == null) throw new ArgumentNullException(nameof(httpClient));
            _httpClient = httpClient;

            _httpClient.DefaultRequestHeaders.Add("User-Agent", "QA-Automation-HttpClient-C#7.3");
        }

        public async Task<ProductListResponse> SearchProductsAsync(string searchTerm)
        {
            var urlWithParam = ApiUrl + "?search_product=" + Uri.EscapeDataString(searchTerm);
            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, urlWithParam))
            {
                using (HttpResponseMessage response = await _httpClient.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();

                    string jsonString = await response.Content.ReadAsStringAsync();

                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    return JsonSerializer.Deserialize<ProductListResponse>(jsonString, options);
                }
            }
        }
    }

    public static class ServiceFactory
    {
        public static IProductService CreateProductService()
        {
            HttpClient client = new HttpClient();
            client.Timeout = TimeSpan.FromSeconds(15);
            return new ProductService(client);
        }
    }
}
