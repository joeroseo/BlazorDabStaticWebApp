using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization; // ✅ Ensure this is included

namespace BlazorSportStoreAuth.Models
{
    [Table("ProductOrderItems")] // ✅ Ensure correct table mapping
    public class ProductOrderItems
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderItemId { get; set; } // Primary key

        [Required]
        [JsonPropertyName("order_id")] // ✅ Ensures it serializes as "order_id"
        public int OrderId { get; set; } // Foreign key to ProductOrderInfo

        [Required]
        [JsonPropertyName("item")] // ✅ Ensures it serializes as "item"
        [MaxLength(255)]
        public string ProductName { get; set; } // ✅ Renamed to match API field name

        [Required]
        [JsonPropertyName("price")] // ✅ Ensures it serializes as "price"
        public decimal Price { get; set; }

        [Required]
        [JsonPropertyName("quantity")] // ✅ Ensures it serializes as "quantity"
        public int Quantity { get; set; }

        [Required]
        [JsonPropertyName("itemTotal")] // ✅ Ensures it serializes as "itemTotal"
        public decimal ItemTotal => Price * Quantity; // ✅ Ensure correct calculation
    }
}
