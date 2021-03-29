using System;
using System.Collections.Generic;

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

        public void Merge(int[] numbers)
        {
            if (numbers.Length < 2)
            {
                return;
            }

            int middleIndex = numbers.Length / 2;
            int[] left = new int[middleIndex];

            for (int i = 0; i < middleIndex; i++)
            {
                left[i] = numbers[i];
            }

            int[] right = new int[numbers.Length - middleIndex];

            for (int i = middleIndex; i < numbers.Length; i++)
            {
                right[i - middleIndex] = numbers[i];
            }

            Merge(left);
            Merge(right);
            Merge(left, right, numbers);
        }

        public void Quick(int[] numbers)
        {
            Quick(numbers, 0, numbers.Length - 1);
        }

        public void Counting(int[] numbers, int max)
        {
            var counter = new int[max + 1];

            foreach (var number in numbers)
            {
                counter[number]++;
            }

            var k = 0;

            for (int i = 0; i < counter.Length; i++)
            {
                for (int j = 0; j < counter[i]; j++)
                {
                    numbers[k++] = i;
                }
            }
        }

        public void Bucket(int[] numbers, int numberOfBuckets)
        {
            var index = 0;

            foreach (var bucket in CreateBuckets(numbers, numberOfBuckets))
            {
                bucket.Sort();

                foreach (var number in bucket)
                {
                    numbers[index++] = number;
                }
            }
        }

        private List<List<int>> CreateBuckets(int[] numbers, int numberOfBuckets)
        {
            List<List<int>> buckets = new List<List<int>>();

            for (int i = 0; i < numberOfBuckets; i++)
            {
                buckets.Add(new List<int>());
            }

            foreach (var number in numbers)
            {
                buckets[number / numberOfBuckets].Add(number);
            }

            return buckets;
        }

        private void Quick(int[] numbers, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            var boundary = Partition(numbers, start, end);

            Quick(numbers, start, boundary - 1);
            Quick(numbers, boundary + 1, end);
        }

        private int Partition(int[] numbers, int start, int end)
        {
            int pivot = numbers[end];
            int boundary = start - 1;

            for (int i = start; i <= end; i++)
            {
                if (numbers[i] <= pivot)
                {
                    Swap(numbers, i, ++boundary);
                }
            }

            return boundary;
        }

        private void Merge(int[] left, int[] right, int[] result)
        {
            int i = 0;
            int j = 0;
            int k = 0;

            while (i < left.Length && j < right.Length)
            {
                if (left[i] <= right[j])
                {
                    result[k++] = left[i++];
                }
                else
                {
                    result[k++] = right[j++];
                }
            }

            while (i < left.Length)
            {
                result[k++] = left[i++];
            }

            while (j < right.Length)
            {
                result[k++] = right[j++];
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