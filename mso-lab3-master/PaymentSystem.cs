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
            string[] log = new string[8];

            switch (info.Payment)
            {
                case UIPayment.CreditCard:
                    CreditCard c = new CreditCard();
                    c.Connect();
                    int ccid = c.BeginTransaction(price);
                    c.EndTransaction(ccid);
                    log[0] = "success";
                    break;
                case UIPayment.DebitCard:
                    DebitCard d = new DebitCard();
                    d.Connect();
                    int dcid = d.BeginTransaction(price);
                    d.EndTransaction(dcid);
                    log[0] = "success";

                    break;
                case UIPayment.Cash:
                    IKEAMyntAtare2000 coin = new IKEAMyntAtare2000();
                    coin.starta();
                    coin.betala((int)Math.Round(price * 100));
                    coin.stoppa();
                    log[0] = "success";

                    break;
            }
            return log;

        }
    }
}
