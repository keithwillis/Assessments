using System;
namespace Assessment
{
    public class MemberBase : Member
    {
        public MemberBase()
        {
            Cart = new Cart(0);
        }

        public string Name { get; set; }
        public int ID { get; set; }

        public virtual decimal Discount { get { return 0; } }

        public Cart Cart { get; set; }

        public void AddItemToCart(Product product)
        {
            Cart.Products.Add(product);
        }


        public void RemoveItemFromCart(string productName)
        {
            Cart.Products.Remove(Cart.Products.Find(p => p.Name == productName));
        }

        
    }
}
