using System;
using System.Collections.Generic;
using Xunit;

namespace Calculator.Test
{
    public partial class CalculatorTests
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
        public void ShouldReturnNanWhenDivideByZero()
        {
            double num1 = 4;
            double num2 = 0;

            Assert.Equal(double.NaN, MyCalculator.DoOperation(num1, num2, "d"));
            Assert.Equal(double.NaN, MyCalculator.DoOperation(num1, num2, "w"));
        }

        [Fact]
        public void ShouldReceiveUserInput()
        {
            IConsoleWrapper console = new MockConsoleWrapper();
            string userInput1 = console.ReadLine();
            Assert.Equal("5", userInput1);
            string userInput2 = console.ReadLine();
            Assert.Equal("2", userInput2);
            string userInput3 = console.ReadLine();
            Assert.Equal("m", userInput3);
            string userInput4 = console.ReadLine();
            Assert.Equal("n", userInput4);
        }

        [Fact]
        public void ShouldMultiply5and2()
        {
            MockConsoleWrapper mockConsoleWrapper = new MockConsoleWrapper();
            MyCalculator.RunCalculator(mockConsoleWrapper);
        }

        public class MockConsoleWrapper : IConsoleWrapper
        {
            Queue<string> UserInputs = new Queue<string>();


            public string ReadLine()
            {
                UserInputs.Enqueue("5");
                UserInputs.Enqueue("2");
                UserInputs.Enqueue("m");
                UserInputs.Enqueue("n");

                return UserInputs.Dequeue();
            }
            
        }
    }
}
