namespace algocs_automata
{
    class TokenBracket : Token
    {
        public bool IsOpening { get; }

        public TokenBracket(bool isOpening)
        {
            IsOpening = isOpening;
            Priority = 0;
        }

        public override string ToString()
        {
            return IsOpening ? "(" : ")";
        }
    }
}
