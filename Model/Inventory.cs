using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineOrderPlacementSystem.Model
{
    public class Inventory
    {
        public Inventory()
        {
            this.ProductStocks = new InventoryStock<Product>()
            {

                Products=new List<Product>(),
                Quantity = 100
            };
        }

        public InventoryStock<Product> ProductStocks { get; set; }
        public void Add(Product product)
        {
            this.ProductStocks.Quantity = this.ProductStocks.Quantity + 1;
            this.ProductStocks.Products.Add(product);
        }
        public void Remove(string productId, int qty)
        {
            var stocks = this.ProductStocks.Products.FirstOrDefault(e => e.Id == productId);
            this.ProductStocks.Quantity = this.ProductStocks.Quantity - qty;
        }
    }
}
