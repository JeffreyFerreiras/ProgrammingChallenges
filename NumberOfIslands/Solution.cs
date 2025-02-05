public class Solution
{
    private int[][] directions = new int[][]
    {
        new int[] { 0, 1 },
        new int[] { 0, -1 },
        new int[] { 1, 0 },
        new int[] { -1, 0 }
    };

    public int NumIslands(char[][] grid)
    {
        if (grid == null || grid.Length == 0) return 0;

        int islandCount = 0;
        int rows = grid.Length;
        int cols = grid[0].Length;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (grid[i][j] == '1')
                {
                    islandCount++;
                    ExploreIsland(grid, i, j);
                }
            }
        }

        return islandCount;
    }

    private void ExploreIsland(char[][] grid, int row, int col)
    {
        var queue = new Queue<(int, int)>();
        queue.Enqueue((row, col));

        while(queue.Count > 0)
        {
            var (direction_row, direction_col) = queue.Dequeue();

            for (int i = 0; i < directions.Length; i++)
            {
                int newRow = direction_row + directions[i][0];
                int newCol = direction_col + directions[i][1];

                if (0 <= newRow && newRow < grid.Length && 0 <= newCol && newCol < grid[0].Length && grid[newRow][newCol] == '1')
                {
                    grid[newRow][newCol] = '0';
                    queue.Enqueue((newRow, newCol));
                }
            }
        }
    }
}
