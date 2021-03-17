using Data_Structures.HashTables;
using Data_Structures.Heaps;
using System;

namespace Data_Structures
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var table = new HashTable(5);
            table.Put(6, "A");
            table.Put(8, "B");
            table.Put(11, "C");
            Console.WriteLine(table.Get(11));
        }

        private static void HeapSort()
        {
            int[] numbers = { 45, 30, 67, 11, 13, 58, 104, 66, 51 };
            var heap = new Heap(numbers.Length);

            foreach (int number in numbers)
            {
                heap.Insert(number);
            }

            for (var i = 0; i < numbers.Length; i++)
            {
                numbers[i] = heap.Remove();
                Console.WriteLine(numbers[i]);
            }
        }
    }
}