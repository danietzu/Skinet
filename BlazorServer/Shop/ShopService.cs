using BlazorServer.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Reactive.Threading.Tasks;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorServer.Shop
{
    public class ShopService
    {
        private readonly HttpClient _http;
        private readonly string _baseUrl = "https://localhost:4000/api/";

        public ShopService(HttpClient http)
        {
            _http = http;
        }

        public async Task<Pagination> GetProducts()
        {
            var response = await _http.GetAsync(_baseUrl + "products");
            var content = await response.Content.ReadAsStringAsync();
            var pagination = JsonSerializer.Deserialize<Pagination>(content, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return pagination;
        }
    }
}