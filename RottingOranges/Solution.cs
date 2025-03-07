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

        List<int> mins = [];
        HashSet<(int, int)> visited = [];

        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[0].Length; j++)
            {
                if (grid[i][j] == 2)
                {
                    var min = ExploreBFS(grid, i, j, visited);
                    if(ValidateGrid(grid, visited)) {
                        mins.Add(min);
                    }
                    visited.Clear();
                }
            }
        }

        return mins.Count > 0 ? mins.Min() : -1;

        static bool ValidateGrid(int[][] grid, HashSet<(int, int)> visited)
        {
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == 1 && !visited.Contains((i, j)))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }

    private int ExploreBFS(int[][] grid, int row, int col, HashSet<(int, int)> visited)
    {
        Queue<(int, int)> queue = [];
        int mins = 0;
        
        queue.Enqueue((row, col));

        while (queue.Count > 0)
        {
            (row, col) = queue.Dequeue();

            foreach (var coord in coords)
            {
                var newRow = row + coord[0];
                var newCol = col + coord[1];

                if (visited.Contains((newRow, newCol))
                || newRow < 0
                || newCol < 0
                || newRow > grid.Length -1
                || newCol > grid[0].Length -1
                || grid[newRow][newCol] != 1
                )
                {
                    continue;
                }

                queue.Enqueue((newRow, newCol));
                visited.Add((newRow, newCol));

                if (visited.Contains((row, col)))
                {
                    mins += 1;
                }
            }
        }

        return mins;
    }
}