//using NUnit.Framework;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Sparky
//{
//    [TestFixture]
//    public class CustomerXUnitTests
//    {
//        private Customer customer;
//        [SetUp]
//        public void SetUp()
//        {
//            customer = new Customer();
//        }

//        [Test]
//        public void CombineName_InputFirstAndLastName_ReturnFullName()
//        {

//            //Arange
//            //Act
//            customer.GreetAndCombineNames("Dima", "Mitru");
//            //Assert

//            Assert.Multiple(() =>
//            {
//                Assert.AreEqual(customer.GreetMessage, "Hello, Dima Mitru");
//                Assert.That(customer.GreetMessage, Is.EqualTo("Hello, Dima Mitru"));
//                Assert.That(customer.GreetMessage, Does.Contain(","));
//                Assert.That(customer.GreetMessage, Does.StartWith("Hello"));
//                Assert.That(customer.GreetMessage, Does.EndWith("mitru").IgnoreCase);
//                Assert.That(customer.GreetMessage, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
//            });
//        }

//        [Test]
//        public void GreetMessage_NotGreeted_ReturnNull()
//        {
//            //arange
//            var customer = new Customer();

//            //act

//            //assert
//            Assert.IsNull(customer.GreetMessage);
//        }

//        [Test]  
//        public void DiscountCheck_DefaultCustomer_ReturnDiscountInRange()
//        {
//            int result = customer.Discount;
//            Assert.That(result, Is.InRange(10,25));
//        }

//        [Test]
//        public void GreetMessage_GreetWithoutLastName_ReturnNotNull()
//        {
//            customer.GreetAndCombineNames("Dima","");

//            Assert.IsNotNull(customer.GreetMessage);
//            Assert.IsFalse(string.IsNullOrEmpty(customer.GreetMessage));
//        }

//        [Test]
//        public void GreetChecker_EmptuFirstName_ThrowsException()
//        {
//            var exceprionDetails = Assert.Throws<ArgumentException>(() 
//                => customer.GreetAndCombineNames(" ", "Mitru"));

//            Assert.AreEqual("Empty First Name", exceprionDetails.Message);

//            Assert.That(()=>customer.GreetAndCombineNames("","Mitru"),
//                Throws.ArgumentException.With.Message.EqualTo("Empty First Name"));

//            Assert.Throws<ArgumentException>(()
//                => customer.GreetAndCombineNames(" ", "Mitru"));

//            Assert.That(() => customer.GreetAndCombineNames("", "Mitru"),
//                Throws.ArgumentException);
//        }

//        [Test]
//        public void CustomerType_CreateCustomerWithLessThan100Order_ReturnBasicCustomer()
//        {
//            customer.OrderTotal = 10;
//            var result = customer.GetCustomerdetails();
//            Assert.That(result, Is.TypeOf<BasicCustomer>());
//        }

//        [Test]
//        public void CustomerType_CreateCustomerWithMoreThan100Order_ReturnPremiumCustomer()
//        {
//            customer.OrderTotal = 101;
//            var result = customer.GetCustomerdetails();
//            Assert.That(result, Is.TypeOf<PremiumCustomer>());
//        }

//    }
//}
