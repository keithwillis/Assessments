using System;
namespace Assessment
{
    public class Product
    {
        public Product(string Name, decimal Price)
        {
            this.Name = Name;
            this.Price = Price;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }

    }
}
