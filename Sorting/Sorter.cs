using System;

namespace Data_Structures.Sorting
{
    public class Sorter
    {
        public int[] Bubble(int[] numbers)
        {
            var index = 0;
            var counter = 0;

            while (numbers.Length - 1 - counter > 0)
            {
                if (numbers[index] > numbers[index + 1])
                {
                    Swap(numbers, index, index + 1);
                }

                index++;

                if (index == numbers.Length - 1 - counter)
                {
                    index = 0;
                    counter++;
                }
            }

            return numbers;
        }

        private void Swap(int[] numbers, int i, int j)
        {
            var temp = numbers[j];
            numbers[j] = numbers[i];
            numbers[i] = temp;
        }
    }
}