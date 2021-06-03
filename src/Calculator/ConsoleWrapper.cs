using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{

    public interface IConsoleWrapper
    {
        string ReadLine();
        void WriteLine(string anyString);

        void Write(string anyString);
    }

    public class ConsoleWrapper : IConsoleWrapper
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine(string anyString)
        {
            Console.WriteLine(anyString);
        }

        public void Write(string anyString)
        {
            Console.Write(anyString);
        }
    }

}
