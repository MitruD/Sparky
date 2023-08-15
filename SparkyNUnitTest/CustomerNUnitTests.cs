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
            string fullName = customer.GreetAndCombineNames("Dima","Mitru");
            //Assert
            Assert.AreEqual(fullName, "Hello, Dima Mitru");
            Assert.That(fullName, Is.EqualTo("Hello, Dima Mitru"));
            Assert.That(fullName, Does.Contain(","));
            Assert.That(fullName, Does.StartWith("Hello"));
            Assert.That(fullName, Does.EndWith("mitru").IgnoreCase);
            Assert.That(fullName, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
        }
    }
}
