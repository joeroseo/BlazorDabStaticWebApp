using System.Collections.Generic;
using BlazorSportStoreAuth.Models;

namespace BlazorSportStoreAuth.Interfaces // ✅ Correct namespace
{
    public interface IItemListService
    {
        List<Item> ItemList { get; }
        void AddItem(Item item);
    }
}
