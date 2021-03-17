using System;

namespace Data_Structures.HashTables
{
    public class Entry
    {
        public int Key { get; set; }
        public string Value { get; set; }

        public Entry(int key, string value)
        {
            Key = key;
            Value = value;
        }
    }
}