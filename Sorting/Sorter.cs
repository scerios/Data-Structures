using System;

namespace Data_Structures.Sorting
{
    public class Sorter
    {
        public void Bubble(int[] numbers)
        {
            bool isSorted;

            for (int i = 0; i < numbers.Length; i++)
            {
                isSorted = true;
                for (int j = 1; j < numbers.Length; j++)
                {
                    if (numbers[j] < numbers[j - 1])
                    {
                        Swap(numbers, j, j - 1);
                        isSorted = false;
                    }
                }

                if (isSorted)
                {
                    return;
                }
            }

            // My solution
            //var index = 0;
            //var counter = 0;

            //while (numbers.Length - 1 - counter > 0)
            //{
            //    if (numbers[index] > numbers[index + 1])
            //    {
            //        Swap(numbers, index, index + 1);
            //    }

            //    index++;

            //    if (index == numbers.Length - 1 - counter)
            //    {
            //        index = 0;
            //        counter++;
            //    }
            //}
        }

        public void Selection(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                var minIndex = FindMinIndex(numbers, i);

                Swap(numbers, minIndex, i);
            }

            // My solution
            //int smallestIndex = 0;
            //int counter = 0;

            //for (int i = 1; i < numbers.Length; i++)
            //{
            //    if (numbers[i] < numbers[smallestIndex])
            //    {
            //        smallestIndex = i;
            //    }

            //    if (i == numbers.Length - 1)
            //    {
            //        Swap(numbers, counter, smallestIndex);
            //        i = counter++ + 1;
            //        smallestIndex = counter;
            //    }
            //}
        }

        public void Insertion(int[] numbers)
        {
            for (int i = 1; i < numbers.Length; i++)
            {
                var current = numbers[i];
                var leftIndex = i - 1;

                while (leftIndex >= 0 && numbers[leftIndex] > current)
                {
                    numbers[leftIndex + 1] = numbers[leftIndex];
                    leftIndex--;
                }
                numbers[leftIndex + 1] = current;
            }
        }

        private int FindMinIndex(int[] numbers, int i)
        {
            var minIndex = i;

            for (int j = i; j < numbers.Length; j++)
            {
                if (numbers[j] < numbers[minIndex])
                {
                    minIndex = j;
                }
            }
            return minIndex;
        }

        private void Swap(int[] numbers, int i, int j)
        {
            var temp = numbers[j];
            numbers[j] = numbers[i];
            numbers[i] = temp;
        }
    }
}