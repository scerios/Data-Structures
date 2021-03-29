using Data_Structures.Sorting;
using System;

namespace Data_Structures
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var sorter = new Sorter();

            var numbers = new int[] { 15, 6, 3, 1, 22, 10, 13 };
            sorter.Quick(numbers);

            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}