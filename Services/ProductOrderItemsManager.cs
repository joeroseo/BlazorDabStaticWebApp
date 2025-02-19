using BlazorSportStoreAuth.Interfaces;
using BlazorSportStoreAuth.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorSportStoreAuth.Services
{
    public class ProductOrderItemsManager : IProductOrderItems
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl;

        public ProductOrderItemsManager(HttpClient httpClient, ApiSettings apiSettings)
        {
            _httpClient = httpClient;
            _apiBaseUrl = $"{apiSettings.BaseUrl}ProductOrderItems"; // ✅ Match API call format of Page 1
        }

        public async Task<List<ProductOrderItems>> GetProductOrderItems()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<ProductOrderItems>>(_apiBaseUrl);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching order items from API: {ex.Message}");
            }
        }

        public async Task<List<ProductOrderItems>> GetProductOrderItems(int? orderId)
        {
            try
            {
                if (orderId.HasValue)
                {
                    return await _httpClient.GetFromJsonAsync<List<ProductOrderItems>>($"{_apiBaseUrl}?orderId={orderId.Value}");
                }
                else
                {
                    return await _httpClient.GetFromJsonAsync<List<ProductOrderItems>>(_apiBaseUrl);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching order items from API: {ex.Message}");
            }
        }

        public async Task AddProductOrderItem(ProductOrderItems productOrderItem)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(_apiBaseUrl, productOrderItem);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Error adding order item to API.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding order item: {ex.Message}");
            }
        }

        public async Task UpdateProductOrderItemDetails(ProductOrderItems productOrderItem)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"{_apiBaseUrl}/{productOrderItem.OrderItemId}", productOrderItem);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Error updating order item in API.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating order item: {ex.Message}");
            }
        }

        public async Task<ProductOrderItems> GetProductOrderItemData(int? orderId)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<ProductOrderItems>($"{_apiBaseUrl}/{orderId}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching order item from API: {ex.Message}");
            }
        }

        public async Task DeleteProductOrderItem(int? orderId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{_apiBaseUrl}/{orderId}");
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Error deleting order item from API.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting order item: {ex.Message}");
            }
        }
    }
}
