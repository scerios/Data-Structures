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
    }
}