using Data_Structures.Sorting;
using System;

namespace Data_Structures
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var sorter = new Sorter();

            var numbers = new int[] { 2, 3, 5, 3, 4, 2, 5 };
            sorter.Counting(numbers, 5);

            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}