using System.Collections.Generic;
using BlazorSportStoreAuth.Models;
using BlazorSportStoreAuth.Interfaces; // ✅ Corrected to use Interfaces namespace

namespace BlazorSportStoreAuth.Services
{
    public class ItemListService : IItemListService
    {
        private readonly List<Item> _itemList = new();

        public List<Item> ItemList => _itemList;

        public void AddItem(Item item)
        {
            _itemList.Add(item);
        }
    }
}
