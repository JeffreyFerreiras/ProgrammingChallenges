using System.Text;

public static class NQueensSolution
{
    /// <summary>
    /// Returns all distinct solutions to the n-queens puzzle.
    /// </summary>
    /// <param name="n">The size of the board and number of queens</param>
    /// <returns>All distinct solutions where each solution is represented as a list of strings</returns>
    public static IList<IList<string>> SolveNQueens(int n)
    {
        List<IList<string>> result = [];
        var grid = new List<string>(n);

        // fill the grid with empty cells
        for (int i = 0; i < n; i++)
        {
            grid.Add(new string('.', n));
        }

        SolveNQueens(grid, 0);

        return result;

        bool IsSafePlacement(List<string> currentBoard, int row, int col)
        {
            // check column 
            for (int i = 0; i < n; i++)
            {
                if (currentBoard[i][col] == 'Q')
                {
                    return false;
                }
            }

            // check diagnal back
            for (int i = row - 1, j = col - 1; i >= 0 && j >= 0; i--, j--)
            {
                if (currentBoard[i][j] == 'Q')
                {
                    return false;
                }
            }

            //check diagnal forward
            for (int i = row - 1, j = col + 1; i >= 0 && j < n; i--, j++)
            {
                if (currentBoard[i][j] == 'Q')
                {
                    return false;
                }
            }

            return true;
        }

        void SolveNQueens(List<string> currentBoard, int row)
        {
            if (n == row)
            {
                result.Add([.. currentBoard]);
                return;
            }

            for (int i = 0; i < n; i++)
            {
                if (!IsSafePlacement(currentBoard, row, i))
                {
                    continue;
                }

                var rowChars = currentBoard[row].ToCharArray();
                rowChars[i] = 'Q';
                currentBoard[row] = new string(rowChars);

                SolveNQueens(currentBoard, row + 1);

                rowChars[i] = '.';
                currentBoard[row] = new string(rowChars);
            }
        }
    }

    /// <summary>
    /// Returns all distinct solutions to the n-queens puzzle using StringBuilder for string manipulation.
    /// </summary>
    /// <param name="n">The size of the board and number of queens</param>
    /// <returns>All distinct solutions where each solution is represented as a list of strings</returns>
    public static IList<IList<string>> SolveNQueens2(int n)
    {
        List<IList<string>> result = [];
        var grid = new List<StringBuilder>(n);

        // fill the grid with empty cells using StringBuilder
        for (int i = 0; i < n; i++)
        {
            StringBuilder row = new();
            row.Append('.', n);
            grid.Add(row);
        }

        SolveNQueens(grid, 0);

        return result;

        bool IsSafePlacement(List<StringBuilder> currentBoard, int row, int col)
        {
            // check column 
            for (int i = 0; i < n; i++)
            {
                if (currentBoard[i][col] == 'Q')
                {
                    return false;
                }
            }

            // check diagonal back
            for (int i = row - 1, j = col - 1; i >= 0 && j >= 0; i--, j--)
            {
                if (currentBoard[i][j] == 'Q')
                {
                    return false;
                }
            }

            // check diagonal forward
            for (int i = row - 1, j = col + 1; i >= 0 && j < n; i--, j++)
            {
                if (currentBoard[i][j] == 'Q')
                {
                    return false;
                }
            }

            return true;
        }

        void SolveNQueens(List<StringBuilder> currentBoard, int row)
        {
            if (n == row)
            {
                // Convert StringBuilder to string when adding to result
                List<string> solution = [];
                foreach (var sb in currentBoard)
                {
                    solution.Add(sb.ToString());
                }
                result.Add(solution);
                return;
            }

            for (int i = 0; i < n; i++)
            {
                if (!IsSafePlacement(currentBoard, row, i))
                {
                    continue;
                }

                // Set queen using StringBuilder indexer
                currentBoard[row][i] = 'Q';

                SolveNQueens(currentBoard, row + 1);

                // Remove queen using StringBuilder indexer
                currentBoard[row][i] = '.';
            }
        }
    }
}
