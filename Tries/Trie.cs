using System;
using System.Collections.Generic;

namespace Data_Structures.Tries
{
    public class Trie
    {
        private readonly Node _root = new Node(' ');

        public void Insert(string word)
        {
            var current = _root;

            foreach (char c in word)
            {
                if (!current.HasChild(c))
                {
                    current.AddChild(c);
                }

                current = current.GetChild(c);
            }

            current.IsEndOfWord = true;
        }

        public bool Contains(string word)
        {
            if (word == null)
            {
                return false;
            }

            var current = _root;

            foreach (char c in word)
            {
                if (!current.HasChild(c))
                {
                    return false;
                }

                current = current.GetChild(c);
            }

            return current.IsEndOfWord;
        }

        public void PreTraverse()
        {
            PreTraverse(_root);
        }

        private void PreTraverse(Node root)
        {
            Console.WriteLine(root.Value);

            foreach (var child in root.GetAllChildren())
            {
                PreTraverse(child);
            }
        }

        public void PostTraverse()
        {
            PostTraverse(_root);
        }

        private void PostTraverse(Node root)
        {
            foreach (var child in root.GetAllChildren())
            {
                PreTraverse(child);
            }

            Console.WriteLine(root.Value);
        }

        public void Delete(string word)
        {
            if (word == null)
            {
                return;
            }

            Delete(_root, word, 0);
        }

        private void Delete(Node root, string word, int index)
        {
            if (index == word.Length)
            {
                root.IsEndOfWord = false;
                return;
            }

            var c = word[index];
            var child = root.GetChild(c);

            if (child == null)
            {
                return;
            }

            Delete(child, word, index + 1);

            if (!child.HasChildren() && !child.IsEndOfWord)
            {
                root.RemoveChild(c);
            }
        }

        public List<string> FindWords(string prefix)
        {
            List<string> words = new List<string>();

            var lastNode = FindLastNodeOf(prefix);
            FindWords(lastNode, prefix, words);

            return words;
        }

        private Node FindLastNodeOf(string prefix)
        {
            if (prefix == null)
            {
                return null;
            }

            var current = _root;

            foreach (char c in prefix)
            {
                var child = current.GetChild(c);

                if (child == null)
                {
                    return null;
                }

                current = child;
            }

            return current;
        }

        private void FindWords(Node root, string prefix, List<string> words)
        {
            if (root == null)
            {
                return;
            }

            if (root.IsEndOfWord)
            {
                words.Add(prefix);
            }

            foreach (var child in root.GetAllChildren())
            {
                FindWords(child, prefix + child.Value, words);
            }
        }
    }
}