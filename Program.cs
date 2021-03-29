using Data_Structures.Sorting;
using System;

namespace Data_Structures
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var sorter = new Sorter();

            var numbers = new int[] { 7, 2, 4, 5, 1, 3 };
            sorter.Bucket(numbers, 3);

            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}