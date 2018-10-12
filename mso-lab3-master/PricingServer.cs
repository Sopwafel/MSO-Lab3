using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3
{
    static class PricingServer
    {
        public static float getPrice (Ticket info)
        {
            // Get number of tariefeenheden
            int tariefeenheden = Tariefeenheden.getTariefeenheden(info.From, info.To);

            // Compute the column in the table based on choices
            int tableColumn;
            // First based on class
            switch (info.Class)
            {
                case Class.FirstClass:
                    tableColumn = 3;
                    break;
                default:
                    tableColumn = 0;
                    break;
            }
            // Then, on the discount
            switch (info.Discount)
            {
                case Discount.TwentyDiscount:
                    tableColumn += 1;
                    break;
                case Discount.FortyDiscount:
                    tableColumn += 2;
                    break;
            }

            // Get price
            float price = PricingTable.getPrice(tariefeenheden, tableColumn);
            if (info.Way == Way.Return)
            {
                price *= 2;
            }
            // Add 50 cent if paying with credit card
            if (info.Payment == Payment.CreditCard)
            {
                price += 0.50f;
            }
            return price;
        }
    }
}
