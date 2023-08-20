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
        public void BankLogDummy_LogMockString_Returnstrue()
        {
            var logMock= new Mock<ILogBook>();
            string desireOutput = "Hello";
            logMock.Setup(u=>u.MessageWithReturnStr(It.IsAny<string>())).Returns((string str) => str);

            Assert.That(logMock.Object.MessageWithReturnStr("Hello"), Is.EqualTo(desireOutput));
        }

        [Test]
        public void BankLogDummy_LogMockStringOutputStr_Returnstrue()
        {
            var logMock= new Mock<ILogBook>();
            string desireOutput = "Hello";
            logMock.Setup(u=>u.LogWithOutputResult(It.IsAny<string>(), out desireOutput)).Returns(true);
            string result = "";
            Assert.IsTrue(logMock.Object.LogWithOutputResult("Ben", out result));
            Assert.That(result, Is.EqualTo(desireOutput));
        }


    }
}
