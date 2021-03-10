using OnlineOrderPlacementSystem.Contracts;
using OnlineOrderPlacementSystem.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OnlineOrderPlacementSystem.Providers
{
    public class ShoppingCartProvider : IShoppingCartContract
    {
        public IInventoryContract _inventoryContract { get; set; }
        public INotificationContract _notificationContract { get; set; }
        public ShoppingCartProvider(IInventoryContract inventoryContract, INotificationContract notificationContract)
        {
            this._inventoryContract = inventoryContract;
            this._notificationContract = notificationContract;
        }
        public bool PlaceOrder(ShoppingCart model)
        {
            if(model.OrderDetails.Items.Any(_=> !this._inventoryContract.CheckInventory(_.Product.Id, _.Quantity)))
            {
                throw new Exception("Some of the products in the cart are out of stock, Please try again after sometime");
            }
            if (this.ChargePayment(model.CardDetails.CardNumber, model.OrderDetails.Amount))
            {
                this._notificationContract.Send(new Email() { To=new List<string>() {"fulfillmentteam@onlinecart.com" }, Subject="Dear Team, New Order Placed"  });
                return true;
            }
            throw new Exception("Unable to process the payment with given card");
        }

        public bool ChargePayment(string creditCardNumber, decimal amount)
        {
            if (this.VerifyCardDetails(creditCardNumber))
            {
                //Deduct amount 
                return true;
            }

            return false;
        }


        private bool VerifyCardDetails(string cardNumber)
        {
            return !string.IsNullOrEmpty(cardNumber);
        }
    }
}
