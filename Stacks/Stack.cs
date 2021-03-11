using System;
using System.Text;

namespace Data_Structures.Stacks
{
    public class Stack
    {
        private readonly int[] _items;
        private int _count;

        public Stack(int length)
        {
            _items = new int[length];
        }

        public void Push(int value)
        {
            if (IsFull())
            {
                throw new StackOverflowException();
            }

            _items[_count++] = value;
        }

        public int Pop()
        {
            if (IsEmpty())
            {
                throw new IndexOutOfRangeException();
            }

            return _items[--_count];
        }

        public int Peek()
        {
            if (IsEmpty())
            {
                throw new IndexOutOfRangeException();
            }

            return _items[_count - 1];
        }

        public bool IsEmpty()
            => _count == 0;

        private bool IsFull()
            => _count == _items.Length;

        public override string ToString()
        {
            if (IsEmpty())
            {
                return "[]";
            }

            var msg = new StringBuilder("[");

            for (int i = 0; i < _count - 1; i++)
            {
                msg.Append($"{ _items[i] }, ");
            }

            msg.Append($"{ _items[_count - 1] }]");

            return msg.ToString();
        }
    }
}