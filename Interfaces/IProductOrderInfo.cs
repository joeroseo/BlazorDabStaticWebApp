using BlazorSportStoreAuth.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorSportStoreAuth.Interfaces
{
    public interface IProductOrderInfo
    {
        Task<List<ProductOrderInfo>> GetOrderInfos();
        Task<List<ProductOrderInfo>> GetOrdersByUserEmail(string email); // ✅ New method for user-specific orders
        Task<int> AddOrderInfo(ProductOrderInfo orderInfo);
        Task UpdateOrderInfoDetails(ProductOrderInfo orderInfo);
        Task<ProductOrderInfo> GetOrderInfoData(int orderId);
        Task DeleteOrderInfo(int orderId);
    }
}
