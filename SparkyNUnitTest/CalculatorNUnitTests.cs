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
        [TestCase(110)]
        [TestCase(130)]
        public void ResulFalse(int a)
        {
            //Arange
            Calculator calc = new Calculator();

            //Act
            bool resultfalse = calc.IsOddNumber(a);

            //Assert
            Assert.AreEqual(false, resultfalse);
        }

        [Test]
        [TestCase(10, ExpectedResult = false)]
        [TestCase(111, ExpectedResult = true)]
        public bool IsOddChecker_InputNumber_ReturnTrueIfOdd(int a)
        {
            Calculator calc = new Calculator();

            return calc.IsOddNumber(a);
        }


        [Test]
        [TestCase(5.4, 10.5)]
        [TestCase(5.43, 10.53)]
        [TestCase(5.49, 10.59)]
        public void AddNumbersDouble_InputTwoDouble_GetCorrectAddition(double a, double b)
        {
            //Arange
            Calculator calc = new Calculator();

            //Act
            double result = calc.AddNumbersDouble(a, b);

            //Assert
            Assert.AreEqual(15.9, result,.2);
        }


        [Test]
        public void OddRange_InputMinAndMaxRange_ReturnValidOddNumberRange()
        { 
            //arange
            Calculator calc = new Calculator();
            List<int> expectedOddRange = new() { 5, 7, 9 };

            //act
            List<int> result = calc.GetOddRange(5, 10);

            //assert
            Assert.That(result, Is.EquivalentTo(expectedOddRange));
        }
    }
}
