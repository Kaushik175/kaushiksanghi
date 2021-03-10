using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineOrderPlacementSystem.Model
{
    public class OrderLineItem
    {
        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
