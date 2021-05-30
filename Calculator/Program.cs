using System;

namespace Calculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            MyCalculator.RunCalculator(new ConsoleWrapper());
        }
    }
}