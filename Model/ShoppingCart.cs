using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineOrderPlacementSystem.Model
{
    public class ShoppingCart
    {
        public Order OrderDetails { get; set; }
        public PaymentDetails CardDetails { get; set; }
    }
}
