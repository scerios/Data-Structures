using Data_Structures.AVL;
using System;

namespace Data_Structures
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var tree = new AVLTree();
            tree.Insert(10);
            tree.Insert(20);
            tree.Insert(15);
            tree.Insert(30);
        }
    }
}