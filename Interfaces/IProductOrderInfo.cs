using BlazorSportStoreAuth.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorSportStoreAuth.Interfaces
{
    public interface IProductOrderInfo
    {
        Task<List<OrderInfo>> GetOrderInfos();
        Task<int> AddOrderInfo(OrderInfo orderInfo);
        Task UpdateOrderInfoDetails(OrderInfo orderInfo);
        Task<OrderInfo> GetOrderInfoData(int orderId);
        Task DeleteOrderInfo(int orderId);
    }
}
