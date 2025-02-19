using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorSportStoreAuth.Models
{
    [Table("ProductOrderItems")] // ✅ Ensure correct table mapping
    public class ProductOrderItems
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderItemId { get; set; } // Primary key

        [Required]
        public int OrderId { get; set; } // Foreign key to ProductOrderInfo

        [Required]
        public int ProductId { get; set; } // Foreign key to Products

        [Required]
        [MaxLength(255)]
        public string ProductName { get; set; } // ✅ Renamed from "Description" to "ProductName"

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
