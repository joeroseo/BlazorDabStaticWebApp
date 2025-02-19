using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorSportStoreAuth.Models;
using Blazored.LocalStorage;

namespace BlazorSportStoreAuth.Services
{
    public class CartService
    {
        private readonly ILocalStorageService _localStorage;

        public List<CartItem> CartItems { get; private set; }

        public CartService(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
            CartItems = new List<CartItem>();
        }

        public void AddToCart(Product product)
        {
            Console.WriteLine("Entered AddToCart"); // Print to console

            var existingItem = CartItems.FirstOrDefault(item => item.Product.Id == product.Id);
            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                CartItems.Add(new CartItem { Product = product, Quantity = 1 });
            }
        }

        public void UpdateQuantity(CartItem cartItem, int quantity)
        {
            if (quantity > 0)
            {
                cartItem.Quantity = quantity;
            }
            else
            {
                CartItems.Remove(cartItem);
            }
        }

        public decimal GetCartTotal()
        {
            return CartItems.Sum(item => item.Quantity * item.Product.Price);
        }

        public List<CartItem> GetAllCartItems()
        {
            return CartItems;
        }

        public int GetCartTotalQuantity()
        {
            return CartItems.Sum(item => item.Quantity);
        }

        public async Task ProcessCheckout()
        {
            await Task.Delay(1000); // Simulating async operation
            CartItems.Clear();
        }
    }
}
