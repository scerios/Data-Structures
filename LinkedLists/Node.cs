using System;

namespace Data_Structures.LinkedLists
{
    public class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }

        public Node(int value)
        {
            Value = value;
        }

        public void SetNext(Node next)
        {
            Next = next;
        }

        public bool HasNext()
        {
            return Next != null;
        }
    }
}