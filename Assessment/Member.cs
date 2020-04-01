using System;
namespace Assessment
{
    public interface Member
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public decimal Discount { get; }

        public Cart Cart { get; set; }

        public void AddItemToCart(Product product);

        public void RemoveItemFromCart(string ProductName);

    }
}
