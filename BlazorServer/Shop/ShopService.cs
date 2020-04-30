using BlazorServer.Shared.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorServer.Shop
{
    public class ShopService
    {
        private readonly HttpClient _http;
        private readonly string _baseUrl = "https://localhost:4000/api";

        public ShopService(HttpClient http)
        {
            _http = http;
        }

        public async Task<Pagination> GetProducts(int brandId,
                                                  int typeId,
                                                  string sort,
                                                  int pageIndex,
                                                  string searchTerm)
        {
            string brandParam = brandId == 0 ? "" : brandId.ToString();
            string typeParam = typeId == 0 ? "" : typeId.ToString();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                return await GetSingleDeserialized<Pagination>
                    ($"{_baseUrl}/products" +
                     $"?search={searchTerm}");
            }
            else
            {
                return await GetSingleDeserialized<Pagination>
                ($"{_baseUrl}/products" +
                 $"?brandId={brandParam}" +
                 $"&typeId={typeParam}" +
                 $"&sort={sort}" +
                 $"&pageIndex={pageIndex}");
            }
        }

        public async Task<List<ProductBrand>> GetProductBrands()
        {
            return await GetListDeserialized<ProductBrand>(_baseUrl + "/products/brands");
        }

        public async Task<List<ProductType>> GetProductTypes()
        {
            return await GetListDeserialized<ProductType>(_baseUrl + "/products/types");
        }

        private async Task<T> GetSingleDeserialized<T>(string uri)
        {
            var response = await _http.GetAsync(uri);
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(content, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
        }

        private async Task<List<T>> GetListDeserialized<T>(string uri)
        {
            var response = await _http.GetAsync(uri);
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<T>>(content, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
        }
    }
}