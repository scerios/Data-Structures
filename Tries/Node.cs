using System;
using System.Collections.Generic;

namespace Data_Structures.Tries
{
    public class Node
    {
        public char Value { get; set; }
        public Dictionary<char, Node> Children { get; set; } = new Dictionary<char, Node>();
        public bool IsEndOfWord { get; set; }

        public Node(char value)
        {
            Value = value;
        }

        public void AddChild(char c)
        {
            Children.Add(c, new Node(c));
        }

        public bool HasChild(char c)
        {
            return Children.ContainsKey(c);
        }

        public bool HasChildren()
        {
            return Children.Count != 0;
        }

        public Node GetChild(char c)
        {
            return Children[c];
        }

        public Node[] GetAllChildren()
        {
            var nodes = new Node[Children.Count];
            Children.Values.CopyTo(nodes, 0);
            return nodes;
        }

        public void RemoveChild(char c)
        {
            Children.Remove(c);
        }

        public override string ToString()
        {
            return $"Node={ Value }";
        }
    }
}