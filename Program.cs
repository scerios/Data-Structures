using Data_Structures.Heaps;
using System;

namespace Data_Structures
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int[] numbers = { 5, 3, 8, 4, 1, 2 };

            var heap = new Heap(6);

            foreach (var number in numbers)
            {
                heap.Insert(number);
            }

            Console.WriteLine(heap.GetKthInLargest(1));
        }
    }
}