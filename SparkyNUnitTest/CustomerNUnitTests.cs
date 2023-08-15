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
            Assert.That(fullName, Is.EqualTo("Hello, Dima Mitru"));
        }
        //[Test]
        //public void CombineName_InputFirstAndLastName_ReturnFullName(string firstName, string lastName)
        //{
        //    var customer = new Customer();

        //    string fullName = customer.GreetAndCombineNames(firstName, lastName);
        //}
    }
}
