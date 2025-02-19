using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorSportStoreAuth.Models; // ✅ Ensure this is present

namespace BlazorSportStoreAuth.Interfaces
{
    public interface IProductOrderItems
    {
        Task<List<ProductOrderItems>> GetProductOrderItems();
        Task<List<ProductOrderItems>> GetProductOrderItems(int? orderId);
        Task AddProductOrderItem(ProductOrderItems productOrderItem);
        Task UpdateProductOrderItemDetails(ProductOrderItems productOrderItem);
        Task<ProductOrderItems> GetProductOrderItemData(int? orderId);
        Task DeleteProductOrderItem(int? orderId);
    }
}
