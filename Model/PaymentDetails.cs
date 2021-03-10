using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineOrderPlacementSystem.Model
{
    public class PaymentDetails
    {

        public PaymentType PaymentMode { get; set; }
        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }

        public string HashedCVV { get; set; }
    }
    public enum PaymentType
    {
        CashOnDelivery = 0,
        NetBanking = 1,
        DebitCard = 2,
        CreditCard = 3,
        Wallet = 4
    }
}
