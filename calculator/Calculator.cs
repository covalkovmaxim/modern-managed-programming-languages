using System.Collections.Generic;
using System.Text;
using System;

namespace algocs_automata
{
    class Calculator
    {
        public List<Token> ReversePolishNotation(Queue<Token> TokenQueue)
        {
            List<Token> ResultList = new List<Token>();
            Stack<Token> SupportingStack = new Stack<Token>(); 

            foreach (var token in TokenQueue)
            {
                if(token.GetType() == typeof(TokenOperator))
                {
                    while(0 != SupportingStack.Count && token.Priority <= SupportingStack.Peek().Priority)
                    {
                        ResultList.Add(SupportingStack.Pop());

                    }
                    SupportingStack.Push(token);
                }
                if(token.GetType() == typeof(TokenBracket))
                {
                    //TokenBracket bracket = (TokenBracket)token; 
                    if(")"==token.ToString())
                    {
                        while(0 != SupportingStack.Count)
                        {
                            var x = SupportingStack.Pop();
                            if("("==x.ToString())
                            {
                                break;
                            }
                            ResultList.Add(x);

                        }
                    }
                    else
                    {
                        SupportingStack.Push(token);
                    }
                }
                if(token.GetType() == typeof(TokenNumber))
                {
                    ResultList.Add(token);
                }
            }

            while(0 != SupportingStack.Count)
            {
                ResultList.Add(SupportingStack.Pop());
            }

            return ResultList;
        }

        public double Calculate(List<Token> ReversePolishNotation)
        {
            Stack<double> ResultStack = new Stack<double>();
            double x,y;

            foreach(var token in ReversePolishNotation)
            {
                if(token.GetType() == typeof(TokenNumber))
                {
                    TokenNumber number = (TokenNumber) token;
                    ResultStack.Push(number.Value);
                }
                if(token.GetType() == typeof(TokenOperator))
                {
                    switch(token.ToString())
                    {
                        case "UnaryMinus":
                            x = -ResultStack.Pop();
                            ResultStack.Push(x);                
                            break;

                        case "Add":
                            x = ResultStack.Pop();
                            y = ResultStack.Pop();
                            ResultStack.Push(y+x);                
                            break;

                        case "Multiply":
                            x = ResultStack.Pop();
                            y = ResultStack.Pop();
                            ResultStack.Push(y*x);                
                            break;

                        case "Subtract":
                            x = ResultStack.Pop();
                            y = ResultStack.Pop();
                            ResultStack.Push(y-x);                
                            break;

                        case "Divide":
                            x = ResultStack.Pop();
                            y = ResultStack.Pop();
                            ResultStack.Push(y/x);                
                            break;
                    }

                }
            }

            return ResultStack.Pop();
        }
    }
}