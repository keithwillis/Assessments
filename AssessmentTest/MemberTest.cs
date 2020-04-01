using NUnit.Framework;
using Assessment;
using System;

namespace AssessmentTest
{
    [TestFixture]
    public class MemberTest
    {

        BronzeMember bronzeMember = new BronzeMember();
        SilverMember silverMember = new SilverMember();
        GoldMember goldMember = new GoldMember();

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestBronzeMemberAddItems()
        {
            bronzeMember.Cart.Products = new System.Collections.Generic.List<Product>();
            bronzeMember.AddItemToCart(new Product("First", 1.50M));
            bronzeMember.AddItemToCart(new Product("Second", 2.50M));
            bronzeMember.AddItemToCart(new Product("Third", 3.50M));
            bronzeMember.AddItemToCart(new Product("First", 4.50M));

            Assert.AreEqual(12M, bronzeMember.Cart.GetTotal());
        }

        [Test]
        public void TestBronzeMemberRemoveItem()
        {
            bronzeMember.Cart.Products = new System.Collections.Generic.List<Product>();
            bronzeMember.AddItemToCart(new Product("First", 1.50M));
            bronzeMember.AddItemToCart(new Product("Second", 2.50M));
            bronzeMember.AddItemToCart(new Product("Third", 3.50M));
            bronzeMember.AddItemToCart(new Product("First", 4.50M));

            bronzeMember.RemoveItemFromCart("First");

            Assert.AreEqual(10.5M, bronzeMember.Cart.GetTotal());
        }

        [Test]
        public void TestSilverMemberAddItems()
        {
            silverMember.Cart.Products = new System.Collections.Generic.List<Product>();
            silverMember.AddItemToCart(new Product("First", 1.50M));
            silverMember.AddItemToCart(new Product("Second", 2.50M));
            silverMember.AddItemToCart(new Product("Third", 3.50M));
            silverMember.AddItemToCart(new Product("First", 4.50M));

            Assert.AreEqual(10.8M, silverMember.Cart.GetTotal());
        }

        [Test]
        public void TestSilverMemberRemoveItem()
        {
            silverMember.Cart.Products = new System.Collections.Generic.List<Product>();
            silverMember.AddItemToCart(new Product("First", 1.50M));
            silverMember.AddItemToCart(new Product("Second", 2.50M));
            silverMember.AddItemToCart(new Product("Third", 3.50M));
            silverMember.AddItemToCart(new Product("First", 4.50M));

            silverMember.RemoveItemFromCart("First");

            Assert.AreEqual(9.45M, silverMember.Cart.GetTotal());
        }


        [Test]
        public void TestGoldMemberAddItems()
        {
            goldMember.Cart.Products = new System.Collections.Generic.List<Product>();
            goldMember.AddItemToCart(new Product("First", 1.50M));
            goldMember.AddItemToCart(new Product("Second", 2.50M));
            goldMember.AddItemToCart(new Product("Third", 3.50M));
            goldMember.AddItemToCart(new Product("First", 4.50M));

            Assert.AreEqual(10.2M, goldMember.Cart.GetTotal());
        }

        [Test]
        public void TestGoldMemberRemoveItem()
        {
            goldMember.Cart.Products = new System.Collections.Generic.List<Product>();
            goldMember.AddItemToCart(new Product("First", 1.50M));
            goldMember.AddItemToCart(new Product("Second", 2.50M));
            goldMember.AddItemToCart(new Product("Third", 3.50M));
            goldMember.AddItemToCart(new Product("First", 4.50M));

            try
            {
                goldMember.RemoveItemFromCart("First");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Assert.AreEqual(decimal.Round(8.925M,2), goldMember.Cart.GetTotal());
        }


    }
}