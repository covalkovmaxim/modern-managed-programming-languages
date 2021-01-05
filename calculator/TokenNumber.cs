﻿using System;

namespace algocs_automata
{
    class TokenNumber : Token
    {
        public double Value { get; }

        public TokenNumber(double value)
        {
            Value = value;
        }

        public TokenNumber(string value)
        {
            Value = Convert.ToDouble(value);
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
