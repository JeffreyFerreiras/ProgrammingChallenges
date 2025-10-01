public class Solution
{
    private readonly int[][] coords =
    [
        [-1, 0], // Up
        [1, 0],  // Down
        [0, -1], // Left
        [0, 1]   // Right
    ];

    public int OrangesRotting(int[][] grid)
    {
        if (grid == null || grid.Length == 0)
        {
            return -1;
        }

        if (grid.Length == 1 && grid[0].Length == 1)
        {
            return grid[0][0] == 1 ? -1 : 0;
        }

        int mins = 0;
        Queue<(int, int)> queue = [];
        HashSet<(int, int)> visited = [];

        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[0].Length; j++)
            {
                if (grid[i][j] == 2)
                {
                    queue.Enqueue((i, j));
                    visited.Add((i, j));
                }
            }
        }

        while (queue.Count > 0)
        {
            int size = queue.Count; // Process all oranges at current time
            bool rottenAny = false;

            // Process all oranges at the current minute
            for (int i = 0; i < size; i++)
            {
                var (row, col) = queue.Dequeue();

                foreach (var coord in coords)
                {
                    var newRow = row + coord[0];
                    var newCol = col + coord[1];

                    if (visited.Contains((newRow, newCol))
                    || newRow < 0
                    || newCol < 0
                    || newRow > grid.Length - 1
                    || newCol > grid[0].Length - 1
                    || grid[newRow][newCol] != 1
                    )
                    {
                        continue;
                    }

                    queue.Enqueue((newRow, newCol));
                    visited.Add((newRow, newCol));
                    grid[newRow][newCol] = 2;
                    rottenAny = true;
                }
            }

            // Only increment time if we rotted any oranges this minute
            if (rottenAny)
            {
                mins++;
            }
        }

        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[0].Length; j++)
            {
                if (grid[i][j] == 1)
                {
                    return -1;
                }
            }
        }

        return mins;
    }
}