using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3
{
    abstract class PaymentMethods
    {
        protected float price;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        public abstract string[] Pay();
    }

    class CreditCardPayment : PaymentMethods
    {
        public CreditCardPayment(float price)
        {
            this.price = price;
        }
        public override string[] Pay()
        {
            string[] log = new string[8];
            CreditCard c = new CreditCard();
            c.Connect();
            int ccid = c.BeginTransaction(price);
            c.EndTransaction(ccid);
            log[0] = "success";
            return log;
        }
    }

    class DebitCardPayment : PaymentMethods
    {
        public DebitCardPayment(float price)
        {
            this.price = price;
        }
        public override string[] Pay()
        {
            string[] log = new string[8];
            DebitCard d = new DebitCard();
            d.Connect();
            int dcid = d.BeginTransaction(price);
            d.EndTransaction(dcid);
            log[0] = "success";

            return log;

        }
    }

    class CashPayment : PaymentMethods
    {
        public CashPayment(float price)
        {
            this.price = price;
        }
        public override string[] Pay()
        {
            string[] log = new string[8];

            IKEAMyntAtare2000 coin = new IKEAMyntAtare2000();
            coin.starta();
            coin.betala((int)Math.Round(price * 100));
            coin.stoppa();
            log[0] = "success";

            return log;
        }
    }
}
