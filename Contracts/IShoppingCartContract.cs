using OnlineOrderPlacementSystem.Model;

namespace OnlineOrderPlacementSystem.Contracts
{
    public interface IShoppingCartContract
    {
        bool ChargePayment(string creditCardNumber, decimal amount);
        bool PlaceOrder(ShoppingCart card);
    }
}