using System;
using System.Collections.Generic;
using System.Text;

namespace Market_Store
{
    public class GoldCard : DiscountCard
    {
        private double discountRate = 0.02;
        public GoldCard(int valueOfPurchase, int turnover) : base(valueOfPurchase, turnover)
        {
        }

        public override string GetDiscount()
        {
            if (Turnover> 100)
            {
            for (int i = 0; i < Turnover; i+=100)
            {
                    discountRate += 0.01;
                    if ((discountRate * 100) >= 10)
                    {
                        break;
                    }
            }

            }

            double discount = discountRate * ValueOfPurchase;
            double total = ValueOfPurchase - discount;

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Purchase value: ${ValueOfPurchase:f2}")
                .AppendLine($"Discount rate: {(discountRate * 100):f1}%")
                .AppendLine($"Discount: ${discount:f2}")
                .AppendLine($"Total: ${total:f2}");

            return sb.ToString();
        }
    }
}
