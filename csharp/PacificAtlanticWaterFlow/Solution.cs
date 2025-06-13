using System.Collections.Generic;

namespace PacificAtlanticWaterFlow;

public class Solution
{
    private int[][] directions = [
        [-1, 0],
        [+1, 0],
        [0, -1],
        [0, +1]
    ];
    public IList<IList<int>> PacificAtlantic(int[][] heights)
    {
        List<IList<int>> result = [];
        int rowLen = heights.Length;
        int colLen = heights[0].Length;

        for (int i = 0; i < rowLen; i++)
        {
            for (int j = 0; j < colLen; j++)
            {
                if (CanFlow(heights, i, j))
                {
                    result.Add([i, j]);
                }
            }
        }

        return result;

        bool CanFlow(int[][] heights, int row, int col)
        {
            HashSet<(int, int)> visited = [];
            Queue<(int, int)> queue = [];

            queue.Enqueue((row, col));
            bool reachedPacific = false;
            bool reachedAtlantic = false;

            while (queue.Count > 0)
            {
                (row, col) = queue.Dequeue();

                foreach (var dir in directions)
                {
                    int nrow = row + dir[0];
                    int ncol = col + dir[1];

                    if (visited.Contains((nrow, ncol)))
                    {
                        continue;
                    }

                    if (nrow < 0 || ncol < 0)
                    {
                        reachedPacific = true;
                        continue;
                    }

                    if (nrow >= heights.Length || ncol >= heights[0].Length)
                    {
                        reachedAtlantic = true;
                        continue;
                    }

                    if (heights[nrow][ncol] <= heights[row][col])
                    {
                        visited.Add((nrow, ncol));
                        queue.Enqueue((nrow, ncol));
                    }
                }
            }

            return reachedPacific && reachedAtlantic;
        }
    }
}