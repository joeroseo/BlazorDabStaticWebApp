using BlazorSportStoreAuth.Interfaces;
using BlazorSportStoreAuth.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorSportStoreAuth.Services
{
    public class ProductOrderInfoManager : IProductOrderInfo
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl;

        public ProductOrderInfoManager(HttpClient httpClient, ApiSettings apiSettings)
        {
            _httpClient = httpClient;
            _apiBaseUrl = $"{apiSettings.BaseUrl}OrderInfos/"; // ✅ Ensure correct API base URL
        }

        public async Task<List<ProductOrderInfo>> GetOrderInfos()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<DataApiResponse<ProductOrderInfo>>(_apiBaseUrl);
                return response?.Value ?? new List<ProductOrderInfo>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ ERROR fetching all orders: {ex.Message}");
                return new List<ProductOrderInfo>();
            }
        }

        public async Task<List<ProductOrderInfo>> GetOrdersByUserEmail(string email)
        {
            try
            {
                // ✅ Use the correct OData `$filter` query syntax
                var requestUrl = $"{_apiBaseUrl}?$filter=email eq '{email}'";
                Console.WriteLine($"DEBUG: Fetching orders from {requestUrl}");

                var response = await _httpClient.GetAsync(requestUrl);

                if (!response.IsSuccessStatusCode)
                {
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"❌ ERROR: Fetching orders failed - {errorResponse}");
                    Console.WriteLine($"DEBUG: Failed Fetching orders from {requestUrl}");

                    return new List<ProductOrderInfo>();
                }

                string jsonResponse = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"DEBUG: Order Infos JSON Response - {jsonResponse}");

                var orders = JsonSerializer.Deserialize<DataApiResponse<ProductOrderInfo>>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return orders?.Value ?? new List<ProductOrderInfo>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ ERROR fetching orders for {email}: {ex.Message}");
                return new List<ProductOrderInfo>();
            }
        }

        public async Task<int> AddOrderInfo(ProductOrderInfo orderInfo)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(_apiBaseUrl, orderInfo);
                if (response.IsSuccessStatusCode)
                {
                    var createdOrder = await response.Content.ReadFromJsonAsync<ProductOrderInfo>();
                    return createdOrder?.Id ?? 0;
                }
                else
                {
                    throw new Exception($"❌ API error: {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"❌ ERROR adding order: {ex.Message}");
            }
        }

        public async Task UpdateOrderInfoDetails(ProductOrderInfo orderInfo)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"{_apiBaseUrl}{orderInfo.Id}", orderInfo);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"❌ ERROR updating order: {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"❌ ERROR updating order: {ex.Message}");
            }
        }

        public async Task<ProductOrderInfo> GetOrderInfoData(int orderId)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<ProductOrderInfo>($"{_apiBaseUrl}{orderId}")
                       ?? throw new Exception($"❌ Order with ID {orderId} not found.");
            }
            catch (Exception ex)
            {
                throw new Exception($"❌ ERROR fetching order: {ex.Message}");
            }
        }

        public async Task DeleteOrderInfo(int orderId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{_apiBaseUrl}{orderId}");
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"❌ ERROR deleting order: {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"❌ ERROR deleting order: {ex.Message}");
            }
        }
    }

    /// <summary>
    /// Wrapper class to match Data API Builder response format.
    /// </summary>
    public class DataApiResponse<T>
    {
        public List<T> Value { get; set; } = new();
    }
}
