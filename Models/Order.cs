using System;
using System.Collections.Generic;

namespace BlazorSportStoreAuth.Models
{

    public class Order
    {
        public int Id { get; set; }
        public List<CartItem> CartItems { get; set; }
        public string UserId { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
