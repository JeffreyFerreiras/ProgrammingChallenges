using System;

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
            int rowLower = 0, colLower = 0;
            int rowUpper = board.Length - 1, colUpper = board[0].Length - 1;
            for (int i = 1; i <= rowUpper; i++)
            {
                for (int j = 1; j <= colUpper; j++)
                {
                    if (board[i][j] == 'O')
                        Dfs(i, j);
                }
            }

            for (int i = 1; i <= rowUpper; i++)
            {
                for (int j = 1; j <= colUpper; j++)
                {
                    if (board[i][j] == 'J')
                        board[i][j] = 'O';
                }
            }

            bool Dfs(int row, int col)
            {
                if (row <= rowLower || col <= colLower
                || row >= rowUpper || col >= colUpper
                || board[row][col] == 'X')
                {
                    return false;
                }

                if (row - 1 == rowLower && board[rowLower][col] == 'O'
                || row + 1 == rowUpper && board[rowUpper][col] == 'O'
                || col - 1 == colLower && board[row][colLower] == 'O'
                || col + 1 == colLower && board[row][colUpper] == 'O')
                {
                    return true;
                }

                board[row][col] = 'X';

                bool escaped = Dfs(row + 1, col)
                || Dfs(row - 1, col)
                || Dfs(row, col + 1)
                || Dfs(row, col - 1);

                if (escaped)
                    board[row][col] = 'J';
                return escaped;
            }
        }
    }
}
