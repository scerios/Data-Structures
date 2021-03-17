using System;
using System.Text;

namespace Data_Structures.Queue
{
    public class ArrayQueue
    {
        private int[] _items;
        private int _front;
        private int _rear;
        private int _count;

        public ArrayQueue(int length)
        {
            _items = new int[length];
        }

        public void Enqueue(int value)
        {
            if (IsFull())
            {
                throw new IndexOutOfRangeException();
            }

            _items[_rear] = value;
            CirculateRear();
            _count++;
        }

        public int Dequeue()
        {
            if (IsEmpty())
            {
                throw new Exception();
            }

            var value = _items[_front];
            _items[_front] = 0;
            CirculateFront();
            _count--;

            return value;
        }

        public int Peek()
        {
            return _items[_front];
        }

        public bool IsEmpty()
        {
            return _count == 0;
        }

        public bool IsFull()
        {
            return _count == _items.Length;
        }

        private void CirculateFront()
        {
            _front = (_front + 1) % _items.Length;
        }

        private void CirculateRear()
        {
            _rear = (_rear + 1) % _items.Length;
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
    }
}