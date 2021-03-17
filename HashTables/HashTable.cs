using System;
using System.Collections.Generic;

namespace Data_Structures.HashTables
{
    // Probing

    // Linear: (hash1 + i) % size

    // Quadratic: (hash1 + i^2) % size

    // Double Hash: (hash1 + i * hash2) % size

    public class HashTable
    {
        private LinkedList<Entry>[] _map;

        public HashTable(int length)
        {
            _map = new LinkedList<Entry>[length];
        }

        public void Put(int key, string value)
        {
            var entry = GetEntryBy(key);

            if (entry != null)
            {
                entry.Value = value;
                return;
            }

            GetOrCreateBucketBy(key).AddLast(new Entry(key, value));
        }

        public string Get(int key)
        {
            var entry = GetEntryBy(key);

            return entry?.Value;
        }

        public void Remove(int key)
        {
            var entry = GetEntryBy(key);
            if (entry == null)
            {
                throw new NullReferenceException();
            }

            GetBucketBy(key).Remove(entry);
        }

        private LinkedList<Entry> GetBucketBy(int key)
        {
            return _map[GetHashedIndexBy(key)];
        }

        private LinkedList<Entry> GetOrCreateBucketBy(int key)
        {
            var index = GetHashedIndexBy(key);
            if (_map[index] == null)
            {
                _map[index] = new LinkedList<Entry>();
            }

            return _map[index];
        }

        private Entry GetEntryBy(int key)
        {
            var bucket = GetBucketBy(key);

            if (bucket != null)
            {
                foreach (var entry in bucket)
                {
                    if (entry.Key == key)
                    {
                        return entry;
                    }
                }
            }

            return null;
        }

        private int GetHashedIndexBy(int key)
        {
            return key % _map.Length;
        }
    }
}