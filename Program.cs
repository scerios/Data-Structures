using Data_Structures.Sorting;
using System;

namespace Data_Structures
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var sorter = new Sorter();

            var numbers = new int[] { 85, 3, 26, 4, 11, 53, 7, 20, 12, 5, 36 };
            sorter.Bubble(numbers);

            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}