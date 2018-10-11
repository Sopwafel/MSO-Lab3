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
        public static string[] doPayment(Ticket info, float price)
        {
            PaymentMethods strategy;
            string[] log = new string[8];

            switch (info.Payment)
            {
                case UIPayment.CreditCard:
                    strategy = new CreditCardPayment(price);
                    break;
                case UIPayment.DebitCard:
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
