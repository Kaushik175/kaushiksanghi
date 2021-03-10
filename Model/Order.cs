using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineOrderPlacementSystem.Model
{
    public class Order
    {
        public string Id { get; set; }

        public DateTime OrderedDate { get; set; }

        public List<OrderLineItem> Items { get; set; }

        public decimal Amount { get; set; }
        public Address ShippingAddress { get; set; }
    }

}

