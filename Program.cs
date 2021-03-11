using Data_Structures.Heaps;
using Data_Structures.Stacks;
using System;

namespace Data_Structures
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var stack = new Stack(5);
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);
            stack.Pop();
            Console.WriteLine(stack);
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