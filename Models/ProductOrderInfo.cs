using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorSportStoreAuth.Models
{
    [Table("ProductOrderInfos")] // ✅ Ensure correct table mapping



    public class ProductOrderInfo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Zip { get; set; }

        public decimal Subtotal { get; set; }
        public decimal Tax { get; set; }
        public decimal Shipping { get; set; }
        public decimal Total { get; set; }
        public string Status { get; set; } = "Pending";

        public string order_id { get; set; }

        [Required]
        public string OrderDate { get; set; } // Ensure this property is added
    }
}
