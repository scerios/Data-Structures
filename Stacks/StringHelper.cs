using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Structures.Stacks
{
    public class StringHelper
    {
        private readonly List<char> _openingBrackets = new List<char> { '(', '[', '{', '<' };
        private readonly List<char> _closingBrackets = new List<char> { ')', ']', '}', '>' };

        public string Reverse(string input)
        {
            if (input == null)
            {
                throw new NullReferenceException();
            }

            Stack<char> chars = new Stack<char>();

            foreach (char ch in input)
            {
                chars.Push(ch);
            }

            var reversed = new StringBuilder();

            while (!IsEmpty(chars))
            {
                reversed.Append(chars.Pop());
            }

            return reversed.ToString();
        }

        public bool IsBalanced(string input)
        {
            if (input == null)
            {
                throw new NullReferenceException();
            }

            Stack<char> brackets = new Stack<char>();

            foreach (char ch in input)
            {
                if (IsLeftBracket(ch))
                {
                    brackets.Push(ch);
                    continue;
                }

                if (IsRightBracket(ch))
                {
                    if (IsEmpty(brackets) || !IsBracketsMatch(brackets.Pop(), ch))
                    {
                        return false;
                    }
                }
            }

            return IsEmpty(brackets);
        }

        private bool IsEmpty<T>(Stack<T> stack)
            => stack.Count == 0;

        private bool IsLeftBracket(char bracket)
            => _openingBrackets.Contains(bracket);

        private bool IsRightBracket(char bracket)
            => _closingBrackets.Contains(bracket);

        private bool IsBracketsMatch(char left, char right)
            => _openingBrackets.IndexOf(left) == _closingBrackets.IndexOf(right);
    }
}