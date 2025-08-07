using System;
using System.Collections.Generic;

namespace ValidSudoku
{
    /// <summary>
    /// Solution class for LeetCode 36: Valid Sudoku
    /// Determines if a 9x9 Sudoku board is valid according to Sudoku rules
    /// </summary>
    public class Solution
    {
        public bool IsValidSudoku(char[][] board)
        {
            const byte rowLength = 9;
            const byte colLength = 9;

            for (byte rowIndex = 0; rowIndex < rowLength; rowIndex += 3)
            {
                for (byte colIndex = 0; colIndex < colLength; colIndex += 3)
                {
                    if (!IsValidSubBox(board, rowIndex, colIndex))
                    {
                        return false;
                    }
                }
            }

            bool[] seen = new bool[9];
            
            // check each row for duplicates
            for (byte rowIndex = 0; rowIndex < rowLength; rowIndex++)
            {
                Array.Clear(seen, 0, seen.Length);

                for (byte colIndex = 0; colIndex < colLength; colIndex++)
                {
                    char current = board[rowIndex][colIndex];
                    if (char.IsDigit(current) == false)
                        continue;
                    int seenIndex = (int)char.GetNumericValue(current) - 1;
                    if (seen[seenIndex])
                    {
                        return false;
                    }
                    seen[seenIndex] = true;
                }
            }

            // check each column for duplicates
            for (byte colIndex = 0; colIndex < colLength; colIndex++)
            {
                Array.Clear(seen, 0, seen.Length);
                for (byte rowIndex = 0; rowIndex < rowLength; rowIndex++)
                {
                    char current = board[rowIndex][colIndex];
                    if (char.IsDigit(current) == false)
                        continue;
                    int seenIndex = (int)char.GetNumericValue(current) - 1;
                    if (seen[seenIndex])
                    {
                        return false;
                    }
                    seen[seenIndex] = true;
                }
            }

            return true;
        }

        bool IsValidSubBox(char[][] board, byte row, byte col)
        {
            bool[] seen = new bool[9];
            byte originalRow = row,
                originalCol = col;

            while (row < originalRow + 3)
            {
                while (col < originalCol + 3)
                {
                    char current = board[row][col];
                    //Console.WriteLine($"Value: {current}, Index's: row: {row}, col {col}");

                    if (char.IsDigit(current))
                    {
                        var seenIndex = (int)char.GetNumericValue(current) - 1;
                        if (seen[seenIndex])
                        {
                            return false;
                        }

                        seen[seenIndex] = true;
                    }
                    col++;
                }
                row++;
                col = originalCol;
            }

            //Console.WriteLine($"Index's: row: {originalRow}, col: {originalCol} is valid sub box");

            return true;
        }
    }
}
