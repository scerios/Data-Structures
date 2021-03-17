using System;
using System.Text;

namespace Data_Structures.Queue
{
    public class PriorityQueue
    {
        private readonly int[] _items;
        private int _count;

        public PriorityQueue(int length)
        {
            _items = new int[length];
        }

        public void Enqueue(int value)
        {
            if (IsFull())
            {
                throw new IndexOutOfRangeException();
            }

            if (IsEmpty())
            {
                _items[0] = value;
            }
            else
            {
                if (value > _items[_count - 1])
                {
                    _items[_count] = value;
                }
                else
                {
                    var index = GetCorrectIndexToInsert(value);
                    _items[index] = value;
                }
            }

            _count++;
        }

        public int Dequeue()
        {
            if (IsEmpty())
            {
                throw new IndexOutOfRangeException();
            }

            return _items[--_count];
        }

        public override string ToString()
        {
            if (IsEmpty())
            {
                return "[]";
            }

            var msg = new StringBuilder("[");

            for (int i = 0; i < _items.Length - 1; i++)
            {
                msg.Append($"{ _items[i] }, ");
            }

            msg.Append($"{ _items[_items.Length - 1] }]");

            return msg.ToString();
        }

        private bool IsEmpty()
        {
            return _count == 0;
        }

        private bool IsFull()
        {
            return _count == _items.Length;
        }

        private int GetCorrectIndexToInsert(int value)
        {
            var index = _count - 1;

            while (index > -1 && value < _items[index])
            {
                _items[index + 1] = _items[index];
                index--;
            }

            return index + 1;
        }
    }
}