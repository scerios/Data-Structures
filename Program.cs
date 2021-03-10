using Data_Structures.Heaps;
using Data_Structures.LinkedLists;
using System;

namespace Data_Structures
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var ll = new LinkedList();
            ll.AddLast(1);
            ll.AddLast(2);
            ll.AddLast(3);
            ll.AddLast(4);
            ll.AddLast(5);
            Console.WriteLine(ll.GetKthFromTheEnd(6));
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