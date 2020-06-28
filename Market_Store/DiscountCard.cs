using System;
using System.Collections.Generic;
using System.Text;

namespace Market_Store
{
   public abstract class DiscountCard : IDiscount
    {
        public DiscountCard(int valueOfPurchase, int turnover)
        {
            this.ValueOfPurchase = valueOfPurchase;
            this.Turnover = turnover;
        }

        public abstract string GetDiscount();

        protected int ValueOfPurchase { get; set; }

        protected int Turnover { get; set; }
    }
}
