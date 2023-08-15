using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    [TestFixture]
    public class CustomerNUnitTests
    {
        [Test]
        public void CombineName_InputFirstAndLastName_ReturnFullName()
        {
            //Arange
            var customer = new Customer();
            //Act
            customer.GreetAndCombineNames("Dima","Mitru");
            //Assert
            Assert.AreEqual(customer.GreetMessage, "Hello, Dima Mitru");
            Assert.That(customer.GreetMessage, Is.EqualTo("Hello, Dima Mitru"));
            Assert.That(customer.GreetMessage, Does.Contain(","));
            Assert.That(customer.GreetMessage, Does.StartWith("Hello"));
            Assert.That(customer.GreetMessage, Does.EndWith("mitru").IgnoreCase);
            Assert.That(customer.GreetMessage, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
        }

        [Test]
        public void GreetMessage_NotGreeted_ReturnNull()
        {
            //arange
            var customer = new Customer();

            //act

            //assert
            Assert.IsNull(customer.GreetMessage);
        }

    }
}
