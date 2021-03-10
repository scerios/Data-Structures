using System;

namespace Data_Structures.BinaryTrees
{
    public class Tree
    {
        public Node Root { get; set; }

        public bool Contains(int value)
        {
            var current = Root;

            while (current != null)
            {
                if (value < current.Value)
                {
                    current = current.LeftChild;
                }
                else if (value > current.Value)
                {
                    current = current.RightChild;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        public bool ContainsRecursive(int value)
        {
            return ContainsRecursive(Root, value);
        }

        private bool ContainsRecursive(Node node, int value)
        {
            if (node == null)
            {
                return false;
            }

            return node.Value == value || ContainsRecursive(node.LeftChild, value) || ContainsRecursive(node.RightChild, value);
        }

        public void Insert(int value)
        {
            var newNode = new Node(value);

            if (Root == null)
            {
                Root = newNode;
                return;
            }

            var current = Root;

            while (true)
            {
                if (current.Value < value)
                {
                    if (current.RightChild == null)
                    {
                        current.RightChild = newNode;
                        break;
                    }

                    current = current.RightChild;
                }

                if (current.Value > value)
                {
                    if (current.LeftChild == null)
                    {
                        current.LeftChild = newNode;
                        break;
                    }

                    current = current.LeftChild;
                }
            }
        }

        public void TraversePreOrder()
        {
            TraversePreOrder(Root);
        }

        private void TraversePreOrder(Node node)
        {
            if (node == null)
            {
                return;
            }

            Console.WriteLine(node.Value);
            TraversePreOrder(node.LeftChild);
            TraversePreOrder(node.RightChild);
        }

        public void TraverseInOrder()
        {
            TraverseInOrder(Root);
        }

        private void TraverseInOrder(Node node)
        {
            if (node == null)
            {
                return;
            }

            TraverseInOrder(node.LeftChild);
            Console.WriteLine(node.Value);
            TraverseInOrder(node.RightChild);
        }

        public void TraversePostOrder()
        {
            TraversePostOrder(Root);
        }

        private void TraversePostOrder(Node node)
        {
            if (node == null)
            {
                return;
            }

            TraverseInOrder(node.LeftChild);
            TraverseInOrder(node.RightChild);
            Console.WriteLine(node.Value);
        }

        public int GetSize()
        {
            return GetSize(Root);
        }

        private int GetSize(Node node)
        {
            if (node == null)
            {
                return 0;
            }

            return GetSize(node.LeftChild)
                    + 1
                    + GetSize(node.RightChild);
        }

        public int GetHeight()
        {
            return GetHeight(Root);
        }

        private int GetHeight(Node node)
        {
            if (node == null)
            {
                return -1;
            }

            if (IsLeaf(node))
            {
                return 0;
            }

            return 1 + Math.Max(GetHeight(node.LeftChild), GetHeight(node.RightChild));
        }

        public int GetMinValue()
        {
            return GetMinValue(Root);
        }

        private int GetMinValue(Node node)
        {
            if (IsLeaf(node))
            {
                return node.Value;
            }

            var left = GetMinValue(node.LeftChild);
            var right = GetMinValue(node.RightChild);

            return Math.Min(Math.Min(left, right), node.Value);
        }

        public int GetMaxValue()
        {
            return GetMaxValue(Root);
        }

        private int GetMaxValue(Node node)
        {
            if (IsLeaf(node))
            {
                return node.Value;
            }

            var left = GetMaxValue(node.LeftChild);
            var right = GetMaxValue(node.RightChild);

            return Math.Max(Math.Max(left, right), node.Value);
        }

        private bool IsLeaf(Node node)
        {
            return node.LeftChild == null && node.RightChild == null;
        }

        public bool IsEquals(Tree tree)
        {
            if (tree == null)
            {
                return false;
            }

            return IsEquals(Root, tree.Root);
        }

        private bool IsEquals(Node first, Node second)
        {
            if (first == null && second == null)
            {
                return true;
            }

            if (first != null && second != null)
            {
                return first.Value == second.Value
                    && IsEquals(first.LeftChild, second.LeftChild)
                    && IsEquals(first.RightChild, second.RightChild);
            }

            return false;
        }

        public bool IsBinarySearchTree()
        {
            return IsBinarySearchTree(Root, Int32.MinValue, Int32.MaxValue);
        }

        private bool IsBinarySearchTree(Node node, int min, int max)
        {
            if (node == null)
            {
                return true;
            }

            if (node.Value < min || node.Value > max)
            {
                return false;
            }

            return
                IsBinarySearchTree(node.LeftChild, min, node.Value - 1)
                && IsBinarySearchTree(node.RightChild, node.Value + 1, max);
        }

        public void GetValueAtDistance(int distance)
        {
            GetValueAtDistance(Root, distance);
        }

        private void GetValueAtDistance(Node node, int distance)
        {
            if (node == null)
            {
                return;
            }

            if (distance == 0)
            {
                Console.WriteLine(node.Value);
                return;
            }

            GetValueAtDistance(node.LeftChild, distance - 1);
            GetValueAtDistance(node.RightChild, distance - 1);
        }

        public void TraverseLevelOrder()
        {
            for (var i = 0; i <= GetHeight(); i++)
            {
                GetValueAtDistance(i);
            }
        }

        public int CountLeaves()
        {
            return CountLeaves(Root);
        }

        private int CountLeaves(Node node)
        {
            if (node == null)
            {
                return 0;
            }

            if (IsLeaf(node))
            {
                return 1;
            }

            return CountLeaves(node.LeftChild) + CountLeaves(node.RightChild);
        }

        public bool AreSiblings(int first, int second)
        {
            return AreSiblings(Root, first, second);
        }

        private bool AreSiblings(Node node, int first, int second)
        {
            if (node == null)
            {
                return false;
            }

            if (node.LeftChild != null && node.RightChild != null)
            {
                if (node.LeftChild.Value == first && node.RightChild.Value == second)
                {
                    return true;
                }
                else if ((node.LeftChild.Value == second && node.RightChild.Value == first))
                {
                    return true;
                }
            }

            if (node.LeftChild != null)
            {
                return AreSiblings(node.LeftChild, first, second);
            }

            if (node.RightChild != null)
            {
                return AreSiblings(node.RightChild, first, second);
            }

            return false;
        }
    }
}