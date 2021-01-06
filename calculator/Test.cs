using System.Collections.Generic;
using System.Text;
using System;

namespace algocs_automata
{
    class Test
    {
        string InputString;
        double Answer;
        public Test(string input, double ans)
        {
            InputString = input;
            Answer = ans;
        } 
        public bool Check()
        {
            var parser = new Parser();
            var queue = parser.Parse(InputString);
            Calculator calc = new Calculator();
            var polish = calc.ReversePolishNotation(queue);
            double res = calc.Calculate(polish);

            return Math.Abs(res - Answer) < 1e-15;
        }

    }
}