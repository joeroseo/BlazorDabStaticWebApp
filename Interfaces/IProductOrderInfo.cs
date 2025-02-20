using BlazorSportStoreAuth.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorSportStoreAuth.Interfaces
{
    public interface IProductOrderInfo
    {
        Task<List<ProductOrderInfo>> GetOrderInfos();
        Task<int> AddOrderInfo(ProductOrderInfo orderInfo);
        Task UpdateOrderInfoDetails(ProductOrderInfo orderInfo);
        Task<ProductOrderInfo> GetOrderInfoData(int orderId);
        Task DeleteOrderInfo(int orderId);
    }
}
