using Data_Structures.Searching;
using System;

namespace Data_Structures
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var searcher = new Searcher();

            var numbers = new int[] { 3, 5, 6, 9, 11, 18, 20, 21, 24, 30 };
            Console.WriteLine(searcher.Jump(numbers, 3));
        }
    }
}