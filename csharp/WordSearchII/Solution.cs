using System;
using System.Collections.Generic;
using System.Linq;

namespace WordSearchII;

public class Solution
{
    public class TrieNode(char value)
    {
        public Dictionary<char, TrieNode> Trie = [];

        public bool IsWord {get; set;}

        public char Value {get; private set; } = value;

        void AddWord(string word)
        {
            if(string.IsNullOrEmpty(word))
            {
                return;
            }

            Value = word[0];

            foreach(char character in word[1..])
            {
                Trie[character] = new TrieNode(character);
                Trie[character].AddWord(word[1..]);
            }

            if(Trie.Count == 0) // No more characters to add, mark this node as a complete word
            {
                IsWord = true;
            }
        }
    }

    public IList<string> FindWords(char[][] board, string[] words)
    {
        throw new NotImplementedException("Implement the trie-based solution here.");
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
    
        static bool Search(char[][] board, int row, int col, string word, int index, bool[,] visited)
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

            var directions = new[]
            {
                (-1, 0),
                (1, 0),
                (0, -1),
                (0, 1)
            };

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
