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
            _apiBaseUrl = $"{apiSettings.BaseUrl}OrderInfos";
        }

        public async Task<List<ProductOrderInfo>> GetOrderInfos()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<ProductOrderInfo>>(_apiBaseUrl);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching orders from API: {ex.Message}");
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
                    return createdOrder.Id;
                }
                else
                {
                    throw new Exception("Error adding order to API.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding order: {ex.Message}");
            }
        }

        public async Task UpdateOrderInfoDetails(ProductOrderInfo orderInfo)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"{_apiBaseUrl}/{orderInfo.Id}", orderInfo);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Error updating order in API.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating order: {ex.Message}");
            }
        }

        public async Task<ProductOrderInfo> GetOrderInfoData(int orderId)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<ProductOrderInfo>($"{_apiBaseUrl}/{orderId}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching order from API: {ex.Message}");
            }
        }

        public async Task DeleteOrderInfo(int orderId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{_apiBaseUrl}/{orderId}");
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Error deleting order from API.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting order: {ex.Message}");
            }
        }
    }
}
