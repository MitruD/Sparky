using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
        [TestFixture]
    public class ProductXUnitTests
    {
        [Test]
        public void GetproductPrice_platinumCustomer_ReturnPriceWith20Discount()
        {
            Product product = new Product() {Price = 50};
            var result = product.GetPrice(new Customer() { IsPremium = true});
            Assert.That(result, Is.EqualTo(40));
        }
    }
}
