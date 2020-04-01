using System;
using System.Collections.Generic;

namespace Assessment
{
    public class Cart
    {
        public Cart(decimal Discount)
        {
            DiscountAmount = Discount;
            Products = new List<Product>();
        }

        private decimal DiscountAmount=0;

        public List<Product> Products { get; set; }

        public decimal GetTotal()
        {
            decimal total = 0M;
            decimal discount = (1.0M - DiscountAmount);
            foreach (Product p in Products)
            {
                total += p.Price;
            }
            var discountedTotal = total * discount;

            return decimal.Round(discountedTotal, 2);
        }
    }
}
