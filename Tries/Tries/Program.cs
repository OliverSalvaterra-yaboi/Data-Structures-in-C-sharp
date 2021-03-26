using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;

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

            foreach (char c in word)
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

        public bool Remove(string word)
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

            if (temp.IsWord)
            {
                temp.IsWord = false;
                return true;
            }

            return false;
        }

        public List<string> GetWords(string word)
        {
            TrieNode temp = root;
            List<string> words = new List<string>();

            foreach(char c in word)
            {
                if (!temp.Children.ContainsKey(c))
                {
                    return words;
                }
                temp = temp.Children[c];
            }

            wordHelper(word.Substring(0, word.Length-1), temp, words);

            return words;
        }

        public void wordHelper(string curWord, TrieNode curNode, List<string> words)
        {
            curWord += curNode.Value;

            if (curNode.IsWord)
            {
                words.Add(curWord);
            }

            foreach(TrieNode n in curNode.Children.Values)
            {
                wordHelper(curWord, n, words);
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dictionary = JsonSerializer.Deserialize<Dictionary<string, string>>(File.ReadAllText("fulldictionary.txt"));

            Trie trie = new Trie();

            string userInputSoFar = Console.ReadLine();

            foreach (string word in dictionary.Keys)
            {
                trie.Insert(word);
            }
            
            List<string> possibleWords = trie.GetWords(userInputSoFar);

            Console.WriteLine();

            foreach (string word in possibleWords)
            {
                Console.WriteLine(word + " : " + dictionary[word]);
            }
        }
    }
}
