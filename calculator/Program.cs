using System.Collections.Generic;
using System.Text;
using System;

namespace algocs_automata
{
    class Program
    {

        static void Main(string[] args)
        {
            if(1 == args.Length && "test" == args[0])
            {
                Test test = new Test("1+1", 3);
                Test[] tests = new Test[] 
                {
                    new Test("1+1",2),
                    new Test("1+1*7",8),
                    new Test("-1*5+70",65),
                    new Test("-(1+10)",-11),
                    new Test("-(1+11)*10+5",-115), 
                    new Test("-(1+11)*10-5/5",-121),
                    new Test("-7/3+1",-1.3333333333333335),
                    new Test("1+2*3-3/3+4-5-(7+14*3)*5",-240.0),
                    new Test("7/7/7*7",1.0),
                    new Test("6/3*2/2*3",6.0),

                    new Test("-1+15/3*(2-1)+3/3",5.0),
                    new Test("-(7+102/3)*2-5",-87.0),
                    new Test("(13+4*5-10)/(2*1+1-1)",11.5),
                    new Test("(1+(-7*(3+4)-2)*3-7)",-159),
                    new Test("(1+2*(2+3*(3+4*(4+5)))-14)",225), 
                    new Test("4/(2+2)",1),
                    new Test("(12/3/4/100)-5",-4.99),
                    new Test("(1+2*3-3/3+4-5-(7+14*3)*5)/20",-12.0),
                    new Test("-(11*12-71)*(-11+5)/3",122.0),
                    new Test("((1))",1.0)
                };
                for(int i = 0; i < 20; i++)
                {
                    if(tests[i].Check())
                    {
                        Console.Write($"Test{i+1} ...... ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Accepted\n");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write($"Test{i+1} ...... ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Wrong\n");
                        Console.ResetColor();
                        return;
                    }
                }
            }
            else
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
                        /*foreach(var token in polish)
                        {
                            Console.Write($"{token}  ");
                        }*/
                        Console.WriteLine($"\nResult: {calc.Calculate(polish)}");
                    }
                }
            }

        }
        
    }
}
