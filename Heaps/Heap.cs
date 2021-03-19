using System;

namespace Data_Structures.Heaps
{
    public class Heap
    {
        private readonly int[] _items;
        private int _size;

        public Heap(int itemsCount)
        {
            _items = new int[itemsCount];
        }

        private int GetLeftChildIndex(int index)
        {
            return index * 2 + 1;
        }

        private int GetRightChildIndex(int index)
        {
            return index * 2 + 2;
        }

        private int GetLeftChild(int index)
        {
            return _items[GetLeftChildIndex(index)];
        }

        private int GetRightChild(int index)
        {
            return _items[GetRightChildIndex(index)];
        }

        private bool IsGreaterThanLeftChild(int index)
        {
            return _items[index] >= _items[GetLeftChildIndex(index)];
        }

        private bool IsGreaterThanRightChild(int index)
        {
            return _items[index] >= _items[GetRightChildIndex(index)];
        }

        private bool IsValidParent(int index)
        {
            if (!HasLeftChild(index))
            {
                return true;
            }

            if (!HasRightChild(index))
            {
                return IsGreaterThanLeftChild(index);
            }

            return IsGreaterThanLeftChild(index) && IsGreaterThanRightChild(index);
        }

        private int GetLargerChildIndex(int index)
        {
            if (!HasLeftChild(index))
            {
                return index;
            }

            if (!HasRightChild(index))
            {
                return GetLeftChildIndex(index);
            }

            return GetLeftChild(index) > GetRightChild(index) ?
                    GetLeftChildIndex(index) : GetRightChildIndex(index);
        }

        private void Swap(int first, int second)
        {
            var temp = _items[first];
            _items[first] = _items[second];
            _items[second] = temp;
        }

        private int Parent(int index)
        {
            return (index - 1) / 2;
        }

        private void BubbleUp()
        {
            var index = _size - 1;

            while (index > 0 && _items[index] > _items[Parent(index)])
            {
                Swap(index, Parent(index));
                index = Parent(index);
            }
        }

        private void BubbleDown()
        {
            var index = 0;

            while (!IsValidParent(index))
            {
                var largerChildIndex = GetLargerChildIndex(index);
                Swap(index, largerChildIndex);
                index = largerChildIndex;
            }
        }

        private bool HasLeftChild(int index)
        {
            return GetLeftChildIndex(index) <= _size;
        }

        private bool HasRightChild(int index)
        {
            return GetRightChildIndex(index) <= _size;
        }

        public void Insert(int value)
        {
            if (IsFull())
            {
                throw new IndexOutOfRangeException();
            }

            _items[_size++] = value;

            BubbleUp();
        }

        public int Remove()
        {
            if (IsEmpty())
            {
                throw new IndexOutOfRangeException();
            }

            var root = _items[0];
            _items[0] = _items[--_size];

            BubbleDown();

            return root;
        }

        public bool IsFull()
        {
            return _size == _items.Length;
        }

        public bool IsEmpty()
        {
            return _size == 0;
        }

        public void HeapSort(int[] numbers)
        {
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

        public void Heapify(int[] numbers)
        {
            var lastParentIndex = numbers.Length / 2 - 1;
            for (int i = lastParentIndex; i >= 0; i--)
            {
                Heapify(numbers, i);
            }
        }

        private void Heapify(int[] numbers, int index)
        {
            var largerIndex = index;

            var leftIndex = index * 2 + 1;

            if (leftIndex < numbers.Length && numbers[leftIndex] > numbers[largerIndex])
            {
                largerIndex = leftIndex;
            }

            var rightIndex = index * 2 + 2;

            if (rightIndex < numbers.Length && numbers[rightIndex] > numbers[largerIndex])
            {
                largerIndex = rightIndex;
            }

            if (index == largerIndex)
            {
                return;
            }

            Swap(numbers, index, largerIndex);

            Heapify(numbers, largerIndex);
        }

        private void Swap(int[] numbers, int first, int second)
        {
            var temp = numbers[first];
            numbers[first] = numbers[second];
            numbers[second] = temp;
        }

        public int GetKthInLargest(int k)
        {
            if (k < 1 || k > _items.Length)
            {
                throw new IndexOutOfRangeException();
            }

            for (int i = 0; i < k - 1; i++)
            {
                Remove();
            }

            return _items[0];
        }
    }
}