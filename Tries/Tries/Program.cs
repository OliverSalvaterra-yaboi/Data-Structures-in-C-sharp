using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Tries
{
    [DebuggerDisplay("{Value} (word: {IsWord}; childCount: {Children.Count})")]
    class TrieNode
    {
        public char Value { get; private set; }
        public Dictionary<char, TrieNode> Children { get; private set; } = new Dictionary<char, TrieNode>();
        public bool IsWord { get; internal set; } = false;

        public TrieNode(char value)
        {
            Value = value;
        }
    }

    class Trie
    {
        private TrieNode root = new TrieNode('\0');

        public bool Insert(string word)
        {
            TrieNode temp = root;
            bool isNewWord = false;

            foreach(char c in word)
            {
                if (!temp.Children.ContainsKey(c))
                {
                    temp.Children.Add(c, new TrieNode(c));
                    isNewWord = true;
                }
                temp = temp.Children[c];
            }

            temp.IsWord = true;

            return isNewWord;
        }

        public bool Contains(string word)
        {
            TrieNode temp = root;

            foreach (char c in word)
            {
                if (!temp.Children.ContainsKey(c))
                {
                    return false;
                }
                temp = temp.Children[c];
            }

            return true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Trie trie = new Trie();

            string userInputSoFar = "ba";

            //List<string> possibleWords = trie.GetWords(userInputSoFar);

            var words = new[]  { "babe", "baby", "he", "hey", "hell", "hello", "heaven", "havana"};

            foreach(string word in words)
            {
                trie.Insert(word);
            }

            Console.WriteLine("Hello World!");
        }
    }
}
