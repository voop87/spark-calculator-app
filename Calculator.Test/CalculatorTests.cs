using System;
using Xunit;

namespace Calculator.Test
{
    public class CalculatorTests
    {
        [Fact]
        public void ShouldDoOperations()
        {
            double num1 = 4;
            double num2 = 2;

            Assert.Equal(6, MyCalculator.DoOperation(num1, num2, "a"));
            Assert.Equal(2, MyCalculator.DoOperation(num1, num2, "s"));
            Assert.Equal(8, MyCalculator.DoOperation(num1, num2, "m"));
            Assert.Equal(2, MyCalculator.DoOperation(num1, num2, "d"));
        }

        [Fact]
        public void ShouldBreakWhenDivideByZero()
        {
            double num1 = 4;
            double num2 = 0;

            Assert.Equal(double.NaN, MyCalculator.DoOperation(num1, num2, "d"));
        }

    }
}
