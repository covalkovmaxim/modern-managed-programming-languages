﻿using System.Collections.Generic;
using System.Text;

namespace algocs_automata
{
    class Parser
    {
        enum State
        {
            Start, Ok, Error, WaitNumber, ReadNumber, ReadNumberHasDot, WaitOperator
        }

        State _state;
        int _brackets;
        StringBuilder _number;
        Queue<Token> _queue;

        public Queue<Token> Parse(string expr)
        {
            _state = State.Start;
            _brackets = 0;
            _queue = new Queue<Token>();
            _number = new StringBuilder();
            foreach (var ch in expr)
            {
                ProcessChar(ch);
                if (_state == State.Error)
                    return null;
            }
            ProcessEnd();
            return _state == State.Ok ? _queue : null;
        }

        private void ProcessChar(char ch)
        {
            if (char.IsWhiteSpace(ch))
                return;
            switch (_state)
            {
                case State.Start:
                    switch (ch)
                    {
                        case '(':
                            _brackets++;
                            _queue.Enqueue(new TokenBracket(true));
                            break;
                        case '+':
                        case '-':
                            _queue.Enqueue(new TokenOperator(ch, true));
                            _state = State.WaitNumber;
                            break;
                        case '0':
                        case '1':
                        case '2':
                        case '3':
                        case '4':
                        case '5':
                        case '6':
                        case '7':
                        case '8':
                        case '9':
                            _number.Append(ch);
                            _state = State.ReadNumber;
                            break;
                        default:
                            _state = State.Error;
                            break;
                    }
                    break;
                case State.WaitNumber:
                    switch (ch)
                    {
                        case '(':
                            _brackets++;
                            _queue.Enqueue(new TokenBracket(true));
                            _state = State.Start;
                            break;
                        case '0':
                        case '1':
                        case '2':
                        case '3':
                        case '4':
                        case '5':
                        case '6':
                        case '7':
                        case '8':
                        case '9':
                            _number.Append(ch);
                            _state = State.ReadNumber;
                            break;
                        default:
                            _state = State.Error;
                            break;
                    }
                    break;
                case State.ReadNumber:
                    switch (ch)
                    {
                        case '0':
                        case '1':
                        case '2':
                        case '3':
                        case '4':
                        case '5':
                        case '6':
                        case '7':
                        case '8':
                        case '9':
                            _number.Append(ch);
                            break;
                        case '.':
                            _number.Append(ch);
                            _state = State.ReadNumberHasDot;
                            break;
                        case '+':
                        case '-':
                        case '*':
                        case '/':
                            _queue.Enqueue(new TokenNumber(_number.ToString()));
                            _number.Clear();
                            _queue.Enqueue(new TokenOperator(ch));
                            _state = State.WaitNumber;
                            break;
                        case ')':
                            _queue.Enqueue(new TokenNumber(_number.ToString()));
                            _number.Clear();
                            _brackets--;
                            _queue.Enqueue(new TokenBracket(false));
                            _state = _brackets >= 0 ? State.WaitOperator : State.Error;
                            break;
                        default:
                            _state = State.Error;
                            break;
                    }
                    break;
                case State.ReadNumberHasDot:
                    switch (ch)
                    {
                        case '0':
                        case '1':
                        case '2':
                        case '3':
                        case '4':
                        case '5':
                        case '6':
                        case '7':
                        case '8':
                        case '9':
                            _number.Append(ch);
                            break;
                        case '+':
                        case '-':
                        case '*':
                        case '/':
                            _queue.Enqueue(new TokenNumber(_number.ToString()));
                            _number.Clear();
                            _queue.Enqueue(new TokenOperator(ch));
                            _state = State.WaitNumber;
                            break;
                        case ')':
                            _queue.Enqueue(new TokenNumber(_number.ToString()));
                            _number.Clear();
                            _brackets--;
                            _queue.Enqueue(new TokenBracket(false));
                            _state = _brackets >= 0 ? State.WaitOperator : State.Error;
                            break;
                        default:
                            _state = State.Error;
                            break;
                    }
                    break;
                case State.WaitOperator:
                    switch (ch)
                    {
                        case ')':
                            _brackets--;
                            _queue.Enqueue(new TokenBracket(false));
                            _state = _brackets >= 0 ? State.WaitOperator : State.Error;
                            break;
                        case '+':
                        case '-':
                        case '*':
                        case '/':
                            _queue.Enqueue(new TokenOperator(ch));
                            _state = State.WaitNumber;
                            break;
                        default:
                            _state = State.Error;
                            break;
                    }
                    break;
            }
        }

        private void ProcessEnd()
        {
            switch (_state)
            {
                case State.Start:
                case State.WaitNumber:
                    _state = State.Error;
                    break;
                case State.ReadNumber:
                case State.ReadNumberHasDot:
                    _queue.Enqueue(new TokenNumber(_number.ToString()));
                    _number.Clear();
                    _state = _brackets == 0 ? State.Ok : State.Error;
                    break;
                case State.WaitOperator:
                    _state = _brackets == 0 ? State.Ok : State.Error;
                    break;
            }
        }
    }
}