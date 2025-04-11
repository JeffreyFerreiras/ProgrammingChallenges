public class SolutionOptimal
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
            return 0;

        int fresh = 0, m = grid.Length, n = grid[0].Length;
        Queue<(int, int)> queue = new Queue<(int, int)>();

        // Count fresh and enqueue rotten oranges.
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] == 1)
                    fresh++;
                else if (grid[i][j] == 2)
                    queue.Enqueue((i, j));
            }
        }

        if (fresh == 0)
            return 0;

        int minutes = 0;
        while (queue.Count > 0)
        {
            int size = queue.Count;
            bool rottedAny = false;
            for (int i = 0; i < size; i++)
            {
                var (row, col) = queue.Dequeue();
                foreach (var coord in coords)
                {
                    int newRow = row + coord[0];
                    int newCol = col + coord[1];
                    if (newRow >= 0 && newRow < m &&
                        newCol >= 0 && newCol < n &&
                        grid[newRow][newCol] == 1)
                    {
                        grid[newRow][newCol] = 2;
                        queue.Enqueue((newRow, newCol));
                        fresh--;
                        rottedAny = true;
                    }
                }
            }
            if (rottedAny)
                minutes++;
        }

        return fresh == 0 ? minutes : -1;
    }
}