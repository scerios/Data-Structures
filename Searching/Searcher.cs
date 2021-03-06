using System;

namespace Data_Structures.Searching
{
    public class Searcher
    {
        public int Linear(int[] numbers, int target)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == target)
                {
                    return i;
                }
            }

            return -1;
        }

        public int Binary(int[] numbers, int target)
        {
            var left = 0;
            var right = numbers.Length - 1;

            while (left <= right)
            {
                var middle = (left + right) / 2;

                if (target == numbers[middle])
                {
                    return middle;
                }

                if (target < numbers[middle])
                {
                    right = middle - 1;
                }
                else
                {
                    left = middle + 1;
                }
            }

            return -1;
        }

        public int BinaryRec(int[] numbers, int target)
        {
            return BinaryRec(numbers, target, 0, numbers.Length - 1);
        }

        public int Ternary(int[] numbers, int target)
        {
            return Ternary(numbers, target, 0, numbers.Length - 1);
        }

        public int Jump(int[] numbers, int target)
        {
            var blockSize = (int)Math.Sqrt(numbers.Length);
            var start = 0;
            var next = blockSize;

            while (start < numbers.Length && numbers[next - 1] < target)
            {
                start = next;
                next += blockSize;

                if (next > numbers.Length)
                {
                    next = numbers.Length;
                }
            }

            for (int i = start; i < next; i++)
            {
                if (numbers[i] == target)
                {
                    return i;
                }
            }

            return -1;
        }

        public int Exponential(int[] numbers, int target)
        {
            var bound = 1;

            while (bound < numbers.Length && numbers[bound] < target)
            {
                bound *= 2;
            }

            int left = bound / 2;
            int right = Math.Min(bound, numbers.Length - 1);

            return BinaryRec(numbers, target, left, right);
        }

        private int BinaryRec(int[] numbers, int target, int left, int right)
        {
            if (right < left)
            {
                return -1;
            }

            var middle = (left + right) / 2;

            if (target == numbers[middle])
            {
                return middle;
            }

            if (target < numbers[middle])
            {
                return BinaryRec(numbers, target, left, middle - 1);
            }

            return BinaryRec(numbers, target, middle + 1, right);
        }

        private int Ternary(int[] numbers, int target, int left, int right)
        {
            if (left > right)
            {
                return -1;
            }

            var partitionSize = (right - left) / 3;
            var midOne = left + partitionSize;
            var midTwo = right - partitionSize;

            if (numbers[midOne] == target)
            {
                return midOne;
            }

            if (numbers[midTwo] == target)
            {
                return midTwo;
            }

            if (target < numbers[midOne])
            {
                return Ternary(numbers, target, left, midOne - 1);
            }

            if (target > numbers[midTwo])
            {
                return Ternary(numbers, target, midTwo + 1, right);
            }

            return Ternary(numbers, target, midOne + 1, midTwo - 1);
        }
    }
}