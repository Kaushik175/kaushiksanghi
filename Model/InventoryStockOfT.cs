using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineOrderPlacementSystem.Model
{
    public class InventoryStock<T> where T: Product
    {
       
        public List<T> Products { get; set; }
        public int Quantity { get; set; }
    }
}
