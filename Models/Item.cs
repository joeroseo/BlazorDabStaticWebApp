//Item.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSportStoreAuth.Models
{
    public class Item
    {
        public string OrderId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}