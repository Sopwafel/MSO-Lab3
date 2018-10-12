using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3
{
    static class PaymentSystem
    {
        
        /// <summary>
        /// Handles the payment after all information has been put into the UIInfo object. 
        /// TODO: Maybe add a return bool indicating succes or failure.
        /// </summary>
        /// <param name="info"></param>
        public static string[] handlePayment(Ticket info)
        {
            PaymentMethods strategy;
            string[] log = new string[8];

            float price = PricingServer.getPrice(info);
            switch (info.Payment)
            {
                case Payment.CreditCard:
                    strategy = new CreditCardPayment(price);
                    break;
                case Payment.DebitCard:
                    strategy = new DebitCardPayment(price);
                    break;
                default:
                    // We default to a cash payment
                    strategy = new CashPayment(price);
                    break;
            }
            strategy.Pay();
            return log;

        }
    }
}
