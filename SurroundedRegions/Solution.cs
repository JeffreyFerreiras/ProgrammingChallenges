namespace SurroundedRegions
{
    /*
     * 130. Surrounded Regions
     * 
     * Given an m x n matrix board containing 'X' and 'O', capture all regions surrounded by 'X'.
     * 
     * A region is captured by flipping all 'O's into 'X's in that surrounded region.
     * 
     * Example 1:
     * Input: board = [["X","X","X","X"],["X","O","O","X"],["X","X","O","X"],["X","O","X","X"]]
     * Output: [["X","X","X","X"],["X","X","X","X"],["X","X","X","X"],["X","O","X","X"]]
     * Explanation: Surrounded regions should be converted to 'X'. The 'O' at position (3,1) 
     * is not flipped because it's on the border.
     * 
     * Example 2:
     * Input: board = [["X"]]
     * Output: [["X"]]
     * 
     * Constraints:
     * - m == board.length
     * - n == board[i].length
     * - 1 <= m, n <= 200
     * - board[i][j] is 'X' or 'O'
     */

    public class Solution
    {
        public void Solve(char[][] board)
        {
            if (board == null || board.Length == 0) return;

            int rows = board.Length;
            int cols = board[0].Length;

            // Mark 'O's connected to border with temporary marker
            for (int i = 0; i < rows; i++)
            {
                if (board[i][0] == 'O') DfsMarkSafe(board, i, 0);
                if (board[i][cols - 1] == 'O') DfsMarkSafe(board, i, cols - 1);
            }

            for (int j = 0; j < cols; j++)
            {
                if (board[0][j] == 'O') DfsMarkSafe(board, 0, j);
                if (board[rows - 1][j] == 'O') DfsMarkSafe(board, rows - 1, j);
            }

            // Convert remaining 'O's to 'X' and restore temporary markers
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (board[i][j] == 'O') board[i][j] = 'X';
                    else if (board[i][j] == 'T') board[i][j] = 'O';
                }
            }

            void DfsMarkSafe(char[][] board, int i, int j)
            {
                if (i < 0 || i >= rows || j < 0 || j >= cols || board[i][j] != 'O') return;

                board[i][j] = 'T'; // Temporary marker
                DfsMarkSafe(board, i + 1, j);
                DfsMarkSafe(board, i - 1, j);
                DfsMarkSafe(board, i, j + 1);
                DfsMarkSafe(board, i, j - 1);
            }
        }
    }
}
