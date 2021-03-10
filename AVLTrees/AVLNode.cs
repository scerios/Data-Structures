using System;

namespace Data_Structures.AVLTrees
{
    public class AVLNode
    {
        public int Value { get; set; }
        public int Height { get; set; } = 0;
        public AVLNode LeftChild { get; set; }
        public AVLNode RightChild { get; set; }

        public AVLNode(int value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return $"Node={ Value }";
        }
    }
}