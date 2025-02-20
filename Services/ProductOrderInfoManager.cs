using BlazorSportStoreAuth.Interfaces;
using BlazorSportStoreAuth.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
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
            _apiBaseUrl = $"{apiSettings.BaseUrl}OrderInfos/"; // Ensure trailing slash
        }

        public async Task<List<ProductOrderInfo>> GetOrderInfos()
        {
            try
            {
                var orders = await _httpClient.GetFromJsonAsync<List<ProductOrderInfo>>(_apiBaseUrl);
                return orders ?? new List<ProductOrderInfo>(); // Ensure non-null return
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching all orders: {ex.Message}");
                return new List<ProductOrderInfo>(); // Avoid exception crashes
            }
        }

        public async Task<List<ProductOrderInfo>> GetOrdersByUserEmail(string email)
        {
            try
            {
                var orders = await _httpClient.GetFromJsonAsync<List<ProductOrderInfo>>($"{_apiBaseUrl}?email={email}");
                return orders ?? new List<ProductOrderInfo>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching orders for user {email}: {ex.Message}");
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
                throw new Exception($"❌ Error adding order: {ex.Message}");
            }
        }

        public async Task UpdateOrderInfoDetails(ProductOrderInfo orderInfo)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"{_apiBaseUrl}{orderInfo.Id}", orderInfo);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"❌ Error updating order: {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"❌ Error updating order: {ex.Message}");
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
                throw new Exception($"❌ Error fetching order: {ex.Message}");
            }
        }

        public async Task DeleteOrderInfo(int orderId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{_apiBaseUrl}{orderId}");
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"❌ Error deleting order: {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"❌ Error deleting order: {ex.Message}");
            }
        }
    }
}
