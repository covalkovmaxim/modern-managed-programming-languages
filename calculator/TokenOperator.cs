namespace algocs_automata
{
    class TokenOperator : Token
    {
        public OperatorType Type { get; }
        
        public TokenOperator(char ch, bool unary = false)
        {
            switch (ch)
            {
                case '+':
                    Type = unary ? OperatorType.UnaryPlus : OperatorType.Add;
                    Priority = unary ? 3 : 1;
                    break;
                case '-':
                    Type = unary ? OperatorType.UnaryMinus : OperatorType.Subtract;
                    Priority = unary ? 3 : 1;
                    break;
                case '*':
                    Type = OperatorType.Multiply;
                    Priority = 2;
                    break;
                case '/':
                    Type = OperatorType.Divide;
                    Priority = 2;
                    break;
            }
        }

        public override string ToString()
        {
            return Type.ToString();
        }
    }
}
