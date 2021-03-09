using System;

namespace Data_Structures.AVL
{
    public class AVLTree
    {
        public AVLNode Root { get; set; }

        public void Insert(int value)
        {
            Root = Insert(Root, value);
        }

        private AVLNode Insert(AVLNode node, int value)
        {
            if (node == null)
            {
                return new AVLNode(value);
            }

            if (value < node.Value)
            {
                node.LeftChild = Insert(node.LeftChild, value);
            }
            else
            {
                node.RightChild = Insert(node.RightChild, value);
            }

            SetHeight(node);

            return Balance(node);
        }

        private AVLNode Balance(AVLNode node)
        {
            if (IsLeftHeavy(node))
            {
                if (BalanceFactor(node.LeftChild) < 0)
                {
                    node.LeftChild = RotateLeft(node.LeftChild);
                }

                return RotateRight(node);
            }

            if (IsRightHeavy(node))
            {
                if (BalanceFactor(node.RightChild) > 0)
                {
                    node.RightChild = RotateRight(node.RightChild);
                }

                return RotateLeft(node);
            }

            return node;
        }

        private int GetHeight(AVLNode node)
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

        private void SetHeight(AVLNode node)
        {
            node.Height = 1 + Math.Max(GetHeight(node.LeftChild), GetHeight(node.RightChild));
        }

        private bool IsLeaf(AVLNode node)
            => node.LeftChild == null && node.RightChild == null;

        private int BalanceFactor(AVLNode node)
            => node == null ? 0 : GetHeight(node.LeftChild) - GetHeight(node.RightChild);

        private bool IsLeftHeavy(AVLNode node)
            => BalanceFactor(node) > 1;

        private bool IsRightHeavy(AVLNode node)
            => BalanceFactor(node) < -1;

        private AVLNode RotateLeft(AVLNode node)
        {
            var newRoot = node.RightChild;

            node.RightChild = newRoot.LeftChild;
            newRoot.LeftChild = node;

            SetHeight(node);
            SetHeight(newRoot);

            return newRoot;
        }

        private AVLNode RotateRight(AVLNode node)
        {
            var newRoot = node.LeftChild;

            node.LeftChild = newRoot.RightChild;
            newRoot.RightChild = node;

            SetHeight(node);
            SetHeight(newRoot);

            return newRoot;
        }
    }
}