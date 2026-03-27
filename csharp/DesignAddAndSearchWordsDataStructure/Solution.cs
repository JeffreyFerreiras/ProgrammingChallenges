using System.Data.Common;

namespace DesignAddAndSearchWordsDataStructure;

public class Solution
{
    public WordDictionary CreateWordDictionary()
    {
        return new WordDictionary();
    }

    public class WordDictionary
    {
        public class TrieNode
        {
            public Dictionary<char, TrieNode> Children { get; } = [];
            public bool IsWord { get; set; }
            public char Value { get; private set; }

            public void AddWord(string word)
            {
                TrieNode currentNode = this;
                foreach (char c in word)
                {
                    if (!currentNode.Children.ContainsKey(c))
                    {
                        currentNode.Children[c] = new TrieNode { Value = c };
                    }
                    currentNode = currentNode.Children[c];
                }
                currentNode.IsWord = true;
            }

            public bool Search(string word)
            {
                TrieNode currentNode = this;
                for (int i = 0; i < word.Length; i++)
                {
                    char c = word[i];

                    if (c == '.')
                    {
                        if (i == word.Length - 1 && currentNode.Children.Count > 0)
                        {
                            return true;
                        }

                        (currentNode, bool result) = WildcardSearch(word[i..], currentNode);

                        return result;
                    }

                    if (!currentNode.Children.ContainsKey(c))
                    {
                        return false;
                    }

                    currentNode = currentNode.Children[c];
                }

                return currentNode.IsWord;
            }

            private static (TrieNode, bool) WildcardSearch(string word, TrieNode currentNode)
            {
                foreach (TrieNode child in currentNode.Children.Values)
                {
                    if (child.Search(word[1..]))
                    {
                        currentNode = child;
                        return (currentNode, true);
                    }
                }

                return (currentNode, false);
            }
        }

        private TrieNode _root = new();

        public WordDictionary() { }

        public void AddWord(string word)
        {
            _root.AddWord(word);
        }

        public bool Search(string word)
        {
            return _root.Search(word);
        }
    }
}
