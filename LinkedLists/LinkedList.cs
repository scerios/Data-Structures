using System;
using System.Text;

namespace Data_Structures.LinkedLists
{
    public class LinkedList
    {
        public int Size { get; set; }
        public Node First { get; set; }
        public Node Last { get; set; }

        public void AddFirst(int value)
        {
            var node = new Node(value);

            if (IsEmpty())
            {
                First = Last = node;
            }
            else
            {
                node.SetNext(First);
                First = node;
            }

            Size++;
        }

        public void AddLast(int value)
        {
            var node = new Node(value);

            if (IsEmpty())
            {
                First = Last = node;
            }
            else
            {
                Last.SetNext(node);
                Last = node;
            }

            Size++;
        }

        public bool IsEmpty()
        {
            return First == null;
        }

        public override string ToString()
        {
            if (IsEmpty())
            {
                return "[]";
            }

            var current = First;
            var msg = new StringBuilder("[");

            while (current.HasNext())
            {
                msg.Append($"{ current.Value }, ");
                current = current.Next;
            }

            msg.Append($"{ current.Value }]");

            return msg.ToString();
        }

        public int DeleteFirst()
        {
            if (IsEmpty())
            {
                throw new NullReferenceException();
            }

            var value = First.Value;

            if (First == Last)
            {
                First = Last = null;
            }
            else
            {
                var second = First.Next;
                First.Next = null;
                First = second;
            }

            Size--;

            return value;
        }

        public int DeleteLast()
        {
            if (IsEmpty())
            {
                throw new NullReferenceException();
            }

            var value = Last.Value;

            if (First == Last)
            {
                First = Last = null;
            }
            else
            {
                var current = First;

                while (current.Next.HasNext())
                {
                    current = current.Next;
                }

                current.Next = null;
            }

            Size--;

            return value;
        }

        public bool Contains(int value)
        {
            return IndexOf(value) != -1;
        }

        public int IndexOf(int value)
        {
            if (IsEmpty())
            {
                throw new NullReferenceException();
            }

            var current = First;
            var index = 0;

            while (current != null)
            {
                if (current.Value == value)
                {
                    return index;
                }

                index++;
                current = current.Next;
            }

            return -1;
        }

        public int GetSize()
        {
            if (IsEmpty())
            {
                return -1;
            }

            return Size;
        }

        public int[] ToArray()
        {
            var array = new int[Size];
            var index = 0;
            var current = First;

            while (current != null)
            {
                array[index++] = current.Value;
                current = current.Next;
            }

            return array;
        }

        public void Reverse()
        {
            if (IsEmpty())
            {
                return;
            }

            var previous = First;
            var current = First.Next;

            while (current != null)
            {
                var next = current.Next;
                current.Next = previous;
                previous = current;
                current = next;
            }

            Last = First;
            Last.Next = null;
            First = previous;
        }

        public int GetKthFromTheEnd(int k)
        {
            var position = Size - k;

            if (position < 0 || k < 1)
            {
                throw new IndexOutOfRangeException();
            }

            var index = 0;
            var current = First;

            while (index != position)
            {
                current = current.Next;
                index++;
            }

            return current.Value;
        }

        public int GetKthFromTheEndNoSize(int k)
        {
            if (IsEmpty())
            {
                throw new NullReferenceException();
            }

            var pointerA = First;
            var pointerB = First;

            for (int i = 0; i < k - 1; i++)
            {
                pointerB = pointerB.Next;
                if (pointerB == null)
                {
                    throw new IndexOutOfRangeException();
                }
            }

            while (pointerB != Last)
            {
                pointerA = pointerA.Next;
                pointerB = pointerB.Next;
            }

            return pointerA.Value;
        }

        public void PrintMiddle()
        {
            if (IsEmpty())
            {
                throw new NullReferenceException();
            }

            var pointerA = First;
            var pointerB = First;

            while (pointerB != Last && pointerB.Next != Last)
            {
                pointerA = pointerA.Next;
                pointerB = pointerB.Next.Next;
            }

            if (pointerB == Last)
            {
                Console.WriteLine($"The middle number is: { pointerA.Value }.");
            }
            else
            {
                Console.WriteLine($"The middle numbers are: { pointerA.Value } and { pointerA.Next.Value }.");
            }
        }

        public bool HasLoop()
        {
            if (IsEmpty())
            {
                throw new NullReferenceException();
            }

            var pointerA = First;
            var pointerB = First;

            while (pointerB != null && pointerB.Next != null)
            {
                pointerA = pointerA.Next;
                pointerB = pointerB.Next.Next;

                if (pointerA == pointerB)
                {
                    return true;
                }
            }

            return false;
        }
    }
}