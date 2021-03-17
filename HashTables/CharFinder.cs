using System;
using System.Collections.Generic;

namespace Data_Structures.HashTables
{
    public class CharFinder
    {
        public char FindFirstNotRepeatedCharIn(string text)
        {
            var dic = new Dictionary<char, int>();

            foreach (char c in text)
            {
                if (dic.ContainsKey(c))
                {
                    dic[c]++;
                }
                else
                {
                    dic.Add(c, 1);
                }
            }

            foreach (char c in text)
            {
                if (dic[c] == 1)
                {
                    return c;
                }
            }

            return Char.MinValue;
        }

        public char FindFirstRepeatedCharIn(string text)
        {
            var set = new HashSet<char>();

            foreach (var c in text)
            {
                if (set.Contains(c))
                {
                    return c;
                }

                set.Add(c);
            }

            return Char.MinValue;
        }
    }
}