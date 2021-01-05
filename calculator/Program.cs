using System.Collections.Generic;
using System.Text;
using System;

namespace algocs_automata
{
    class Program
    {

        static void Main(string[] args)
        {
            while (true)
            {
                string s = Console.ReadLine();
                var parser = new Parser();
                var queue = parser.Parse(s);
                Calculator calc = new Calculator();

                if (queue == null)
                    Console.WriteLine("ERROR");
                else
                {
                    var polish = calc.ReversePolishNotation(queue);
                    foreach(var token in polish)
                    {
                        Console.Write($"{token}  ");
                    }
                    Console.WriteLine($"\nResult: {calc.Calculate(polish)}");
                }
            }
        }
        
    }
}
