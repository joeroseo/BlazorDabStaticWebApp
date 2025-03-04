namespace BlazorSportStoreAuth.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public Product Product { get; set; } = new Product(); // Ensure it's never null
        public int Quantity { get; set; }
    }
}
