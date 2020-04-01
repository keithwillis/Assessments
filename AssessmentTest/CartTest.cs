using NUnit.Framework;
using Assessment;

namespace AssessmentTest
{
    public class CartTest
    {

        Cart cart0 = new Cart(.0M);
        Cart cart10 = new Cart(.10M);
        Cart cart15 = new Cart(.15M);

        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void TestBronzeCartTotal()
        {
            cart0.Products = new System.Collections.Generic.List<Product>();
            cart0.Products.Add(new Product("First", 1.50M));
            cart0.Products.Add(new Product("Second", 2.50M));
            cart0.Products.Add(new Product("Third", 3.50M));
            cart0.Products.Add(new Product("First", 4.50M));

            Assert.AreEqual(12M, cart0.GetTotal());
        }

        [Test]
        public void TestSilverCartTotal()
        {
            cart10.Products = new System.Collections.Generic.List<Product>();
            cart10.Products.Add(new Product("First", 1.50M));
            cart10.Products.Add(new Product("Second", 2.50M));
            cart10.Products.Add(new Product("Third", 3.50M));
            cart10.Products.Add(new Product("First", 4.50M));

            Assert.AreEqual(10.8M, cart10.GetTotal());
        }

        [Test]
        public void TestGoldCartTotal()
        {
            cart15.Products = new System.Collections.Generic.List<Product>();
            cart15.Products.Add(new Product("First", 1.50M));
            cart15.Products.Add(new Product("Second", 2.50M));
            cart15.Products.Add(new Product("Third", 3.50M));
            cart15.Products.Add(new Product("First", 4.50M));

            Assert.AreEqual(10.2M, cart15.GetTotal());
        }


    }
}