using System;

namespace Data_Structures.BinaryTree
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

        private bool ContainsRecursive(Node root, int value)
        {
            if (root == null)
            {
                return false;
            }

            return root.Value == value || ContainsRecursive(root.LeftChild, value) || ContainsRecursive(root.RightChild, value);
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

        private void TraversePreOrder(Node root)
        {
            if (root == null)
            {
                return;
            }

            Console.WriteLine(root.Value);
            TraversePreOrder(root.LeftChild);
            TraversePreOrder(root.RightChild);
        }

        public void TraverseInOrder()
        {
            TraverseInOrder(Root);
        }

        private void TraverseInOrder(Node root)
        {
            if (root == null)
            {
                return;
            }

            TraverseInOrder(root.LeftChild);
            Console.WriteLine(root.Value);
            TraverseInOrder(root.RightChild);
        }

        public void TraversePostOrder()
        {
            TraversePostOrder(Root);
        }

        private void TraversePostOrder(Node root)
        {
            if (root == null)
            {
                return;
            }

            TraverseInOrder(root.LeftChild);
            TraverseInOrder(root.RightChild);
            Console.WriteLine(root.Value);
        }

        public int GetSize()
        {
            return GetSize(Root);
        }

        private int GetSize(Node root)
        {
            if (root == null)
            {
                return 0;
            }

            return GetSize(root.LeftChild)
                    + 1
                    + GetSize(root.RightChild);
        }

        public int GetHeight()
        {
            return GetHeight(Root);
        }

        private int GetHeight(Node root)
        {
            if (root == null)
            {
                return -1;
            }

            if (IsLeaf(root))
            {
                return 0;
            }

            return 1 + Math.Max(GetHeight(root.LeftChild), GetHeight(root.RightChild));
        }

        public int GetMinValue()
        {
            return GetMinValue(Root);
        }

        private int GetMinValue(Node root)
        {
            if (IsLeaf(root))
            {
                return root.Value;
            }

            var left = GetMinValue(root.LeftChild);
            var right = GetMinValue(root.RightChild);

            return Math.Min(Math.Min(left, right), root.Value);
        }

        public int GetMaxValue()
        {
            return GetMaxValue(Root);
        }

        private int GetMaxValue(Node root)
        {
            if (IsLeaf(root))
            {
                return root.Value;
            }

            var left = GetMaxValue(root.LeftChild);
            var right = GetMaxValue(root.RightChild);

            return Math.Max(Math.Max(left, right), root.Value);
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

        private int CountLeaves(Node root)
        {
            if (root == null)
            {
                return 0;
            }

            if (IsLeaf(root))
            {
                return 1;
            }

            return CountLeaves(root.LeftChild) + CountLeaves(root.RightChild);
        }

        public bool AreSiblings(int first, int second)
        {
            return AreSiblings(Root, first, second);
        }

        private bool AreSiblings(Node root, int first, int second)
        {
            if (root == null)
            {
                return false;
            }

            if (root.LeftChild != null && root.RightChild != null)
            {
                if (root.LeftChild.Value == first && root.RightChild.Value == second)
                {
                    return true;
                }
                else if ((root.LeftChild.Value == second && root.RightChild.Value == first))
                {
                    return true;
                }
            }

            if (root.LeftChild != null)
            {
                return AreSiblings(root.LeftChild, first, second);
            }

            if (root.RightChild != null)
            {
                return AreSiblings(root.RightChild, first, second);
            }

            return false;
        }
    }
}