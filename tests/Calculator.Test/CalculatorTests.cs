using System;
using System.Collections.Generic;
using Xunit;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            IConsoleWrapper console = new MockConsoleWrapper("5", "2", "m", "n");
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
            MockConsoleWrapper mockConsoleWrapper = new MockConsoleWrapper("5", "2", "m", "n");
            double result = MyCalculator.RunCalculator(mockConsoleWrapper);
            Assert.Equal(10, result);
        }

        [Fact]
        public void ShouldReturnNaNWhenInvalidOp()
        {
            MockConsoleWrapper mockConsoleWrapper = new MockConsoleWrapper("5", "2", "b", "n");
            double result = MyCalculator.RunCalculator(mockConsoleWrapper);
            Assert.Equal(double.NaN, result);
        }

        [Fact]
        public void ShouldReturnErrorMsgWhenInvalidInput()
        {
            MockConsoleWrapper mockConsoleWrapper = new MockConsoleWrapper("a", "2", "b", "n");
            MyCalculator.RunCalculator(mockConsoleWrapper);
            string errorMsg = mockConsoleWrapper.MessageList[0];
            Assert.Equal("This is not valid input. Please enter an integer value: ", errorMsg);
        }

        public class MockConsoleWrapper : IConsoleWrapper
        {
            Queue<string> UserInputs = new Queue<string>();
            public List<string> MessageList { get; set; } = new List<string>();

            string _input1;
            string _input2;
            string _input3;
            string _input4;

            public MockConsoleWrapper (string input1, string input2, string input3, string input4)
            {
                _input1 = input1;
                _input2 = input2;
                _input3 = input3;
                _input4 = input4;
            }

            public string ReadLine()
            {
                UserInputs.Enqueue(_input1);
                UserInputs.Enqueue(_input2);
                UserInputs.Enqueue(_input3);
                UserInputs.Enqueue(_input4);

                return UserInputs.Dequeue();
            }

            public void WriteLine(string anyString)
            {
                StringWriter stringWriter = new StringWriter();//stringWriter to store an output
                Console.SetOut(stringWriter);//redirect output to the stringWriter
                Console.WriteLine(anyString);//write a message
                MessageList.Add(stringWriter.ToString());//add the stored in the stringWriter into the list


            }

            public void Write(string anyString)
            {
                StringWriter stringWriter = new StringWriter();
                Console.SetOut(stringWriter);
                Console.Write(anyString);
                MessageList.Add(stringWriter.ToString());

            }

        }
    }
}
