using OnlineOrderPlacementSystem.Model;

namespace OnlineOrderPlacementSystem.Contracts
{
    public interface IInventoryContract
    {
        string AddProduct(Product product, int qnt);
        bool CheckInventory(string productId, int qty);
        Product GetProductByName(string name);
        bool IsProductExists(Product product);
        void ReduceProductQuantity(string productId, int qnt);
    }
}