using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3
{
    static class PricingServer
    {
        public static float getPrice (UIInfo info)
        {
            // Get number of tariefeenheden
            int tariefeenheden = Tariefeenheden.getTariefeenheden(info.From, info.To);

            // Compute the column in the table based on choices
            int tableColumn;
            // First based on class
            switch (info.Class)
            {
                case UIClass.FirstClass:
                    tableColumn = 3;
                    break;
                default:
                    tableColumn = 0;
                    break;
            }
            // Then, on the discount
            switch (info.Discount)
            {
                case UIDiscount.TwentyDiscount:
                    tableColumn += 1;
                    break;
                case UIDiscount.FortyDiscount:
                    tableColumn += 2;
                    break;
            }

            // Get price
            float price = PricingTable.getPrice(tariefeenheden, tableColumn);
            if (info.Way == UIWay.Return)
            {
                price *= 2;
            }
            // Add 50 cent if paying with credit card
            if (info.Payment == UIPayment.CreditCard)
            {
                price += 0.50f;
            }
            return price;
        }
    }
}
