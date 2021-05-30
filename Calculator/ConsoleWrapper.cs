using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{

    public interface IConsoleWrapper
    {
        string ReadLine();
    }

    public class ConsoleWrapper : IConsoleWrapper
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }

}
