using System;
using System.Collections.Generic;
using System.Linq;

namespace WordSearchII;

public class Solution
{
    public class TrieNode(char value)
    {
        public Dictionary<char, TrieNode> Trie = [];

        public bool IsWord { get; set; }

        public char Value { get; } = value;

        public void AddWord(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
               IsWord = true; 
               return;
            }
            
            char firstChar = word[0];
            if (!Trie.TryGetValue(firstChar, out TrieNode? child))
            {
                child = new TrieNode(firstChar);
                Trie[firstChar] = child;
            }

            child.AddWord(word[1..]);
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

        for (int row = 0; row < board.Length; row++)
        {
            for (int col = 0; col < board[0].Length; col++)
            {
                Dfs((row, col), trieRoot, string.Empty);
            }
        }

        void Dfs((int, int) cell, TrieNode node, string currentWord)
        {
            var (row, col) = cell;
    
            if (row < 0 || col < 0 || row >= board.Length || col >= board[0].Length)
                return;

            if (visited.Contains(cell))
                return;

            char currentChar = board[row][col];
            if (!node.Trie.TryGetValue(currentChar, out var nextNode))
                return;

            visited.Add(cell);
            currentWord += currentChar;

            if (nextNode.IsWord)
            {
                found.Add(currentWord);
            }

            // Explore neighbors
            Dfs((row - 1, col), nextNode, currentWord); // Up
            Dfs((row + 1, col), nextNode, currentWord); // Down
            Dfs((row, col - 1), nextNode, currentWord); // Left
            Dfs((row, col + 1), nextNode, currentWord); // Right

            visited.Remove(cell);
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
