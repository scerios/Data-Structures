using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Data_Structures.StringUtils
{
    public class StringUtil
    {
        public static int CountVowels(string text)
        {
            if (text == null)
            {
                return 0;
            }

            int counter = 0;

            foreach (char c in text.ToLower())
            {
                if (IsVowel(c))
                {
                    counter++;
                }
            }

            return counter;
        }

        public static string Reverse(string text)
        {
            if (text == null)
            {
                return "";
            }

            StringBuilder reversed = new StringBuilder();

            for (int i = text.Length - 1; i >= 0; i--)
            {
                reversed.Append(text[i]);
            }

            return reversed.ToString();
        }

        public static string ReverseWords(string text)
        {
            if (text == null)
            {
                return "";
            }

            string[] words = text.Split(' ');

            StringBuilder reversed = new StringBuilder();

            for (int i = words.Length - 1; i >= 0; i--)
            {
                reversed.Append($"{ words[i] } ");
            }

            return reversed.ToString().Trim();
        }

        public static bool AreRotations(string textOne, string textTwo)
        {
            if (textOne == null || textTwo == null)
            {
                return false;
            }

            return textOne.Length == textTwo.Length && (textOne + textOne).Contains(textTwo);
        }

        public static string RemoveDuplicates(string text)
        {
            if (text == null)
            {
                return "";
            }

            StringBuilder output = new StringBuilder();
            HashSet<char> chars = new HashSet<char>();

            foreach (char c in text)
            {
                if (!chars.Contains(c))
                {
                    chars.Add(c);
                    output.Append(c);
                }
            }

            return output.ToString();
        }

        public static char GetMostRepeatedCharacter(string text)
        {
            if (text == null || text == "")
            {
                throw new ArgumentException();
            }

            Dictionary<char, int> chars = new Dictionary<char, int>();

            foreach (char c in text)
            {
                if (!chars.ContainsKey(c))
                {
                    chars.Add(c, 1);
                }
                else
                {
                    chars[c]++;
                }
            }

            int highest = 0;
            char mostFrequent = ' ';

            foreach (var key in chars.Keys)
            {
                if (chars[key] > highest)
                {
                    highest = chars[key];
                    mostFrequent = key;
                }
            }

            return mostFrequent;
        }

        public static string Capitalize(string text)
        {
            if (text == null || text == "")
            {
                return "";
            }

            text = Regex.Replace(text, @"\ +", " ");

            string[] words = text.Trim().Split(" ");

            for (int i = 0; i < words.Length; i++)
            {
                words[i] = words[i].Substring(0, 1).ToUpper() + words[i][1..].ToLower();
            }

            return String.Join(" ", words);
        }

        public static bool AreAnagrams(string textOne, string textTwo)
        {
            if (textOne == null || textTwo == null || textOne.Length != textTwo.Length)
            {
                return false;
            }

            var textOneChars = textOne.ToCharArray();
            Array.Sort(textOneChars);

            var textTwoChars = textTwo.ToCharArray();
            Array.Sort(textTwoChars);

            return Enumerable.SequenceEqual(textOneChars, textTwoChars);
        }

        public static bool AreAnagramsByHistogram(string textOne, string textTwo)
        {
            if (textOne == null || textTwo == null)
            {
                return false;
            }

            const int ENGLISH_ALPHABET = 26;
            int[] frequencies = new int[ENGLISH_ALPHABET];

            textOne = textOne.ToLower();

            for (int i = 0; i < textOne.Length; i++)
            {
                frequencies[textOne[i] - 'a']++;
            }

            textTwo = textTwo.ToLower();

            for (int i = 0; i < textTwo.Length; i++)
            {
                var index = textTwo[i] - 'a';
                if (frequencies[index] == 0)
                {
                    return false;
                }
                frequencies[index]--;
            }

            return true;
        }

        public static bool IsPalindrome(string text)
        {
            if (text == null || text == "")
            {
                return false;
            }

            int left = 0;
            int right = text.Length - 1;

            while (left < right)
            {
                if (text[left++] != text[right--])
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsVowel(char c)
        {
            string vowels = "aeiou";

            return vowels.Contains(c);
        }
    }
}