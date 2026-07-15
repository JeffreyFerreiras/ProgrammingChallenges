using System;
using System.Collections.Generic;
using System.Linq;

namespace WordSearchII;

public class Solution
{
    public class TrieNode(char value)
    {
        private const char NullChar = '\0';
        public Dictionary<char, TrieNode> Trie = [];

        public bool IsWord { get; set; }

        public char Value { get; } = value;

        public string Word { get; set; } = string.Empty;

        public void AddWord(string word, string fullWord = "")
        {
            if (string.IsNullOrEmpty(word))
            {
                return;
            }
            if (string.IsNullOrEmpty(fullWord) && Value == NullChar)
            {
                fullWord = word;
            }
            char firstChar = word[0];
            Trie[firstChar] = new TrieNode(firstChar);
            Trie[firstChar].AddWord(word[1..], fullWord);

            if (Trie[firstChar].Trie.Count == 0)
            {
                IsWord = true;
                Word = fullWord;
            }
        }

        public bool ContainsWord(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                return false;
            }

            TrieNode currentNode = this;

            foreach (char character in word)
            {
                if (!currentNode.Trie.TryGetValue(character, out var nextNode))
                {
                    return false;
                }

                currentNode = nextNode;
            }

            return currentNode.IsWord;
        }

        public string[] FindWords(string prefix)
        {
            if (string.IsNullOrEmpty(prefix))
                return [];

            TrieNode currentNode = this;
            List<string> words = [];

            foreach (char character in prefix)
            {
                if (!currentNode.Trie.TryGetValue(character, out var nextNode))
                {
                    return [];
                }

                currentNode = nextNode;
            }

            // At this point, currentNode is the node corresponding to the last character of the prefix
            // We need to collect all words that can be formed from this node
            HashSet<TrieNode> seen = [];
            Queue<TrieNode> queue = new();
            queue.Enqueue(currentNode);

            while (queue.Count > 0)
            {
                currentNode = queue.Dequeue();

                if (currentNode.IsWord)
                {
                    words.Add(currentNode.Word);
                }

                foreach (var nextNode in currentNode.Trie.Values)
                {
                    if (!seen.Contains(nextNode))
                    {
                        seen.Add(nextNode);
                        queue.Enqueue(nextNode);
                    }
                }
            }

            return [.. words];
        }
    }

    public IList<string> FindWords(char[][] board, string[] words)
    {
        var trieRoot = new TrieNode('\0');
        foreach (var word in words)
        {
            trieRoot.AddWord(word);
        }

        // BFS to find all words in the board
        var found = new HashSet<string>(StringComparer.Ordinal);
        HashSet<(int, int)> visited = [];
        Queue<(int, int)> queue = new();

        queue.Enqueue((0, 0));

        while (queue.Count > 0)
        {
            var (row, col) = queue.Dequeue();

            if (row < 0 || col < 0 || row >= board.Length || col >= board[0].Length)
            {
                continue;
            }

            if (visited.Contains((row, col)))
            {
                continue;
            }

            var prefix = board[row][col].ToString();
            for (var r = 0; r < board.Length; r++)
            {
                for (var c = 0; c < board[0].Length; c++)
                {
                    var prefix = board[r][c].ToString();
                    var wordsWithPrefix = trieRoot.FindWords(prefix);
                    foreach (var word in wordsWithPrefix)
                    {
                        if (word.StartsWith(prefix))
                        {
                            found.Add(word);
                        }
                    }
                }
            }
        }


        return [.. found];
    }

    public IList<string> FindWords_BruteForce(char[][] board, string[] words)
    {
        if (board == null || board.Length == 0 || words == null || words.Length == 0)
        {
            return Array.Empty<string>();
        }

        var rows = board.Length;
        var cols = board[0].Length;
        var matches = new HashSet<string>(StringComparer.Ordinal);

        foreach (var word in words.Where(w => !string.IsNullOrWhiteSpace(w)))
        {
            if (word.Length == 0)
            {
                continue;
            }

            for (var row = 0; row < rows; row++)
            {
                for (var col = 0; col < cols; col++)
                {
                    if (board[row][col] != word[0])
                    {
                        continue;
                    }

                    if (Search(board, row, col, word, 0, new bool[rows, cols]))
                    {
                        matches.Add(word);
                        break;
                    }
                }

                if (matches.Contains(word))
                {
                    break;
                }
            }
        }

        return matches.OrderBy(word => word).ToList();

        static bool Search(
            char[][] board,
            int row,
            int col,
            string word,
            int index,
            bool[,] visited
        )
        {
            if (index == word.Length)
            {
                return true;
            }

            if (row < 0 || col < 0 || row >= board.Length || col >= board[0].Length)
            {
                return false;
            }

            if (visited[row, col] || board[row][col] != word[index])
            {
                return false;
            }

            visited[row, col] = true;

            var directions = new[] { (-1, 0), (1, 0), (0, -1), (0, 1) };

            foreach (var (deltaRow, deltaCol) in directions)
            {
                if (Search(board, row + deltaRow, col + deltaCol, word, index + 1, visited))
                {
                    return true;
                }
            }

            visited[row, col] = false;
            return false;
        }
    }
}
