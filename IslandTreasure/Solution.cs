using System;

namespace IslandTreasure;

public class Solution
{
    public void IslandsAndTreasure(int[][] grid)
    {
        // start at the trasure chest
        // for every dfs depth increment count
        // keep track of the max distance from a treasure
        // do not traverse water
        // if existing grid location has a value but its lower than current value, backtrack
        int rows = grid.Length, cols = grid[0].Length;
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < rows; c++)
            {
                if (grid[r][c] == 0)
                {
                    Dfs(r, c, 0);
                }
            }
        }

        void Dfs(int row, int col, int distance)
        {
            //base
            if (row < 0 || row >= rows || col < 0 || col >= cols) return;
            if (grid[row][col] <= -1) return;

            int temp = grid[row][col];
            grid[row][col] = -2; //mark visited

            //dfs
            Dfs(row - 1, col, distance + 1);
            Dfs(row + 1, col, distance + 1);
            Dfs(row, col - 1, distance + 1);
            Dfs(row, col + 1, distance + 1);

            grid[row][col] = temp == 0 ? 0 : Math.Min(distance, temp);
        }
    }
}
