using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Sparky
{
    public class CalculatorXUnitTests
    {
        [Fact]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        {
            //Arange
            Calculator calc = new Calculator();

            //Act
            int result = calc.AddNumbers(10, 20);

            //Assert
            Assert.Equal(30, result);
        }

        [Fact]
        public void ResulTrue()
        {
            //Arange
            Calculator calc = new Calculator();

            //Act
            bool resultrue = calc.IsOddNumber(1);

            //Assert
            Assert.Equal(true, resultrue);
            Assert.True(resultrue);
        }

        [Theory]
        [InlineData(110)]
        [InlineData(130)]
        public void ResulFalse(int a)
        {
            //Arange
            Calculator calc = new Calculator();

            //Act
            bool resultfalse = calc.IsOddNumber(a);

            //Assert
            Assert.Equal(false, resultfalse);
        }

        [Theory]
        [InlineData(10, false)]
        [InlineData(111, true)]
        public void IsOddChecker_InputNumber_ReturnTrueIfOdd(int a, bool expectedResult)
        {
            Calculator calc = new Calculator();

            var result =  calc.IsOddNumber(a);
            Assert.Equal(expectedResult, result);
        }


        [Theory]
        [InlineData(5.4, 10.5)]
        //[InlineData(5.43, 10.53)]
        //[InlineData(5.49, 10.59)]
        public void AddNumbersDouble_InputTwoDouble_GetCorrectAddition(double a, double b)
        {
            //Arange
            Calculator calc = new Calculator();

            //Act
            double result = calc.AddNumbersDouble(a, b);

            //Assert
            Assert.Equal(15.9, result, 2);
        }


        [Fact]
        public void OddRange_InputMinAndMaxRange_ReturnValidOddNumberRange()
        {
            //arange
            Calculator calc = new Calculator();
            List<int> expectedOddRange = new() { 5, 7, 9 };

            //act
            List<int> result = calc.GetOddRange(5, 10);

            //assert
            Assert.Equal(expectedOddRange, result);
            Assert.Contains(7,result);
            Assert.NotEmpty(result);
            Assert.Equal(3,result.Count);
            Assert.DoesNotContain(4,result);
            Assert.Equal(result.OrderBy(u=>u), result);
        }
    }
}
