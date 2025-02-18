namespace BlazorDabApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
        public bool IsAvailable { get; set; }
    }
}
