/*
 * 79. Word Search
 * 
 * Given an m x n grid of characters board and a string word, return true if word exists in the grid.
 * The word can be constructed from letters of sequentially adjacent cells, where adjacent cells 
 * are horizontally or vertically neighboring. The same letter cell may not be used more than once.
 */

public class Solution
{
    /// <summary>
    /// Determines if the given word exists in the board.
    /// </summary>
    /// <param name="board">The m x n grid of characters</param>
    /// <param name="word">The word to search for</param>
    /// <returns>true if the word exists in the grid, false otherwise</returns>
    public bool Exist(char[][] board, string word) {
        bool[,] visited = new bool[board.Length, board[0].Length];
        var chars = new List<char>();
        
        for(int i = 0; i < board.Length; i++){
            for(int j = 0; j < board[0].Length; j++) {
                if(board[i][j] != word[0]){ // Find starting point
                    continue;
                }
                
                DFS(i, j); // Start DFS from this point
                
                if(chars.Count == word.Length) {
                    return true;
                }
                
                chars.Clear();
            }
        }

        return false;
        
        void DFS(int row, int col, int index = 0) {
            if(row < 0 
            || row >= board.Length 
            || col < 0 
            || col >= board[0].Length 
            || index >= word.Length
            || visited[row, col]
            || word[index] != board[row][col]
            || chars.Count == word.Length
            ) {
                return;
            }

            visited[row, col] = true;
            chars.Add(word[index]);

            DFS(row + 1, col, index + 1);
            DFS(row - 1, col, index + 1);
            DFS(row, col + 1, index + 1);
            DFS(row, col - 1, index + 1);

            visited[row, col] = false;
        }
    }

    /// <summary>
    /// Determines if the given word exists in the board.
    /// </summary>
    /// <param name="board">The m x n grid of characters</param>
    /// <param name="word">The word to search for</param>
    /// <returns>true if the word exists in the grid, false otherwise</returns>
    public bool Exist2(char[][] board, string word) {
        int rows = board.Length;
        int cols = board[0].Length;
        
        // Try starting from each cell in the grid
        for(int i = 0; i < rows; i++) {
            for(int j = 0; j < cols; j++) {
                if(board[i][j] == word[0] && DFS(i, j, 0)) {
                    return true;
                }
            }
        }

        return false;
        
        // DFS now returns bool to indicate if word was found from this path
        bool DFS(int row, int col, int index) {
            // If we've matched all characters, we found the word
            if(index == word.Length) {
                return true;
            }
            
            // Check bounds, visited status, and character match
            if(row < 0 || row >= rows || 
               col < 0 || col >= cols || 
               board[row][col] != word[index]) {
                return false;
            }
            
            // Mark as visited by temporarily changing the cell value
            char temp = board[row][col];
            board[row][col] = '*'; // Use any character that won't be in the input
            
            // Try all four directions
            bool found = DFS(row + 1, col, index + 1) || 
                         DFS(row - 1, col, index + 1) || 
                         DFS(row, col + 1, index + 1) || 
                         DFS(row, col - 1, index + 1);
            
            // Backtrack - restore the original character
            board[row][col] = temp;
            
            return found;
        }
    }
}