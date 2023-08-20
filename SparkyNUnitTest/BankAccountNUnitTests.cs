using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    [TestFixture]
    public class BankAccountNUnitTests
    {
        private BankAccount account;
        [SetUp]
        public void Setup()
        {

        }

        //[Test]
        //public void BankDepositLogFakker_Add100_ReturnTrue()
        //{
        //    BankAccount bankAccount = new(new LogFakker());
        //    var result = bankAccount.Deposit(100);
        //    Assert.IsTrue(result);
        //    Assert.That(bankAccount.GetBalance, Is.EqualTo(100));
        //}

        [Test]
        public void BankDeposit_Add100_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();


            BankAccount bankAccount = new(logMock.Object);
            var result = bankAccount.Deposit(100);
            Assert.IsTrue(result);
            Assert.That(bankAccount.GetBalance, Is.EqualTo(100));
        }

        [Test]
        [TestCase(200,100)]
        [TestCase(200,150)]
        public void BankWithdraw_Withdraw100With200Balance_ReturnsTrue(int balance, int withdraw)
        {
            var logMock= new Mock<ILogBook>();
            logMock.Setup(u=>u.LogToDB(It.IsAny<string>())).Returns(true);
            logMock.Setup(u=>u.LogBalanceAfterWithdrawal(It.Is<int>(x=>x>0))).Returns(true);

            BankAccount bankAccount = new(logMock.Object);
            bankAccount.Deposit(balance);
            var result = bankAccount.Withdraw(withdraw);
            Assert.IsTrue(result);
        }

        [Test]
        public void BankWithdraw_Withdraw300With200Balance_ReturnsFalse()
        {
            var logMock= new Mock<ILogBook>();
            //logMock.Setup(u=>u.LogBalanceAfterWithdrawal(It.Is<int>(x=>x<0))).Returns(false);
            logMock.Setup(u=>u.LogBalanceAfterWithdrawal(It.IsInRange<int>(int.MinValue,-1,Moq.Range.Inclusive))).Returns(false);

            BankAccount bankAccount = new(logMock.Object);
            bankAccount.Deposit(200);
            var result = bankAccount.Withdraw(300);
            Assert.IsFalse(result);
        }

        [Test]
        public void BankLogDummy_LogMockString_ReturnsTrue()
        {
            var logMock= new Mock<ILogBook>();
            string desireOutput = "Hello";
            logMock.Setup(u=>u.MessageWithReturnStr(It.IsAny<string>())).Returns((string str) => str);

            Assert.That(logMock.Object.MessageWithReturnStr("Hello"), Is.EqualTo(desireOutput));
        }

        [Test]
        public void BankLogDummy_LogMockStringOutputStr_ReturnsTrue()
        {
            var logMock= new Mock<ILogBook>();
            string desireOutput = "Hello";
            logMock.Setup(u=>u.LogWithOutputResult(It.IsAny<string>(), out desireOutput)).Returns(true);
            string result = "";
            Assert.IsTrue(logMock.Object.LogWithOutputResult("Ben", out result));
            Assert.That(result, Is.EqualTo(desireOutput));
        }
        

        [Test]
        public void BankLogDummy_LogRefChecker_ReturnsTrue()
        {
            var logMock= new Mock<ILogBook>();
            Customer customer= new Customer();
            Customer customerNotUsed= new Customer();

            logMock.Setup(u=>u.LogWithRefObj(ref customer)).Returns(true);
            Assert.IsTrue(logMock.Object.LogWithRefObj(ref customer));
            Assert.IsFalse(logMock.Object.LogWithRefObj(ref customerNotUsed));
        }

        [Test]
        public void BankLogDummySetAndGetLogTypeAndSeverityMock_MockTest()
        {
            var logMock= new Mock<ILogBook>();
            logMock.SetupAllProperties();
            logMock.Setup(u => u.LogSeverity).Returns(100);
            logMock.Setup(u => u.LogType).Returns("warning");
           
            logMock.Object.LogSeverity = 100;
            Assert.That(logMock.Object.LogSeverity,Is.EqualTo(100));
            Assert.That(logMock.Object.LogType,Is.EqualTo("warning"));

            //callbacks
            string logTemp = "Hello, ";
            logMock.Setup(u => u.LogToDB(It.IsAny<string>()))
                .Returns(true).Callback((string str) => logTemp += str);
            logMock.Object.LogToDB("Ben");
            Assert.That(logTemp, Is.EqualTo("Hello, Ben"));

            //callbacks
            int counter = 5;
            logMock.Setup(u => u.LogToDB(It.IsAny<string>()))
                .Returns(true).Callback(() => counter++);
            logMock.Object.LogToDB("Ben");
            logMock.Object.LogToDB("Ben");
            Assert.That(counter, Is.EqualTo(7));
        }

        [Test]
        public void BankLogDummy_VerifyExample()
        {
            var logMock = new Mock<ILogBook>();
            BankAccount bankAccount = new(logMock.Object);
            bankAccount.Deposit(100);
            Assert.That(bankAccount.GetBalance, Is.EqualTo(100));


            //verification
            logMock.Verify(u=>u.Message(It.IsAny<string>()),Times.Exactly(2));
            logMock.VerifySet(u=>u.LogSeverity = 101,Times.Once);
            logMock.VerifyGet(u=>u.LogSeverity,Times.Once);
            logMock.Verify(u=>u.Message("Test") ,Times.AtLeastOnce);
        }
    }
}
