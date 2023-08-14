using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    [TestFixture]
    public class CalculatorNUnitTests
    {
        [Test]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        {
            //Arange
            Calculator calc = new Calculator();

            //Act
            int result = calc.AddNumbers(10, 20);

            //Assert
            Assert.AreEqual(30, result);
        }
        
        [Test]
        public void ResulTrue()
        {
            //Arange
            Calculator calc = new Calculator();

            //Act
            bool resultrue = calc.IsOddNumber(1);

            //Assert
            Assert.AreEqual(true, resultrue);
            Assert.That(resultrue,Is.EqualTo(true));
            Assert.IsTrue(resultrue);
        }
        
        [Test]
        public void ResulFalse()
        {
            //Arange
            Calculator calc = new Calculator();

            //Act
            bool resultfalse = calc.IsOddNumber(2);

            //Assert
            Assert.AreEqual(false, resultfalse);
        }
    }
}
