using System;

namespace Data_Structures.Heaps
{
    public class Heap
    {
        public int[] Items { get; set; }
        private int _size;

        public Heap(int itemsCount)
        {
            Items = new int[itemsCount];
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
            return Items[GetLeftChildIndex(index)];
        }

        private int GetRightChild(int index)
        {
            return Items[GetRightChildIndex(index)];
        }

        private bool IsGreaterThanLeftChild(int index)
        {
            return Items[index] >= Items[GetLeftChildIndex(index)];
        }

        private bool IsGreaterThanRightChild(int index)
        {
            return Items[index] >= Items[GetRightChildIndex(index)];
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
            var temp = Items[first];
            Items[first] = Items[second];
            Items[second] = temp;
        }

        private int Parent(int index)
        {
            return (index - 1) / 2;
        }

        private void BubbleUp()
        {
            var index = _size - 1;

            while (index > 0 && Items[index] > Items[Parent(index)])
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

            Items[_size++] = value;

            BubbleUp();
        }

        public int Remove()
        {
            if (IsEmpty())
            {
                throw new IndexOutOfRangeException();
            }

            var root = Items[0];
            Items[0] = Items[--_size];

            BubbleDown();

            return root;
        }

        public bool IsFull()
        {
            return _size == Items.Length;
        }

        public bool IsEmpty()
        {
            return _size == 0;
        }
    }
}