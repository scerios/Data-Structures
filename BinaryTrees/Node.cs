namespace Data_Structures.BinaryTrees
{
    public class Node
    {
        public int Value { get; set; }
        public Node LeftChild { get; set; }
        public Node RightChild { get; set; }

        public Node(int value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return $"Node={ Value }";
        }
    }
}