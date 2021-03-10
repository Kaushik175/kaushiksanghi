using OnlineOrderPlacementSystem.Contracts;
using OnlineOrderPlacementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineOrderPlacementSystem.Providers
{
    public class InventoryProvider : IInventoryContract
    {
        private Inventory Inventory { get; set; }

        public InventoryProvider()
        {
            this.Inventory = new Inventory();
        }

        public bool CheckInventory(string productId, int qty)
        {
            return this.Inventory.ProductStocks.Quantity > 0 && this.Inventory.ProductStocks.Products.Any(_ => _.Id == productId);
        }

        public Product GetProductByName(string name)
        {
            return this.Inventory.ProductStocks.Products.FirstOrDefault(e => e.Name == name);
        }

        public string AddProduct(Product product, int qnt)
        {
                var p = new Product
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price
                };
                this.Inventory.Add(p);
                return p.Id;
        }

        public bool IsProductExists(Product product)
        {
            return this.Inventory.ProductStocks.Products.Where(e => e.Name == product.Name).Any();
        }

        public void ReduceProductQuantity(string productId, int qnt)
        {
            this.Inventory.Remove(productId, qnt);
        }
    }
}
