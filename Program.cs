using Data_Structures.Searching;
using System;

namespace Data_Structures
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var searcher = new Searcher();

            var numbers = new int[] { 1, 3, 5, 6, 7, 8 };
            Console.WriteLine(searcher.Ternary(numbers, 4));
        }
    }
}