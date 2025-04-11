/*
LeetCode #200 - Number of Islands

Given an m x n 2D binary grid 'grid' which represents a map of '1's (land) and '0's (water), 
return the number of islands.

An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. 
You may assume all four edges of the grid are all surrounded by water.

Example 1:
Input: grid = [
  ["1","1","1","1","0"],
  ["1","1","0","1","0"],
  ["1","1","0","0","0"],
  ["0","0","0","0","0"]
]
Output: 1

Example 2:
Input: grid = [
  ["1","1","0","0","0"],
  ["1","1","0","0","0"],
  ["0","0","1","0","0"],
  ["0","0","0","1","1"]
]
Output: 3
*/
class Program
{
    static void Main(string[] args)
    {
        var solution = new Solution();

        Console.WriteLine("=========================================");
        Console.WriteLine("  Number of Islands Challenge Results");
        Console.WriteLine("=========================================\n");

        var sw = System.Diagnostics.Stopwatch.StartNew();

        // Scenario 1
        Console.WriteLine("---------- Scenario 1 ----------");
        char[][] grid1 = new char[][] {
            "11110".ToCharArray(),
            "11010".ToCharArray(),
            "11000".ToCharArray(),
            "00000".ToCharArray()
        };
        Console.WriteLine("Input: grid1");
        Console.WriteLine("Expected Output: 1");
        sw.Restart();
        int result1 = solution.NumIslands(grid1);
        sw.Stop();
        Console.WriteLine($"Result: {result1}");
        Console.WriteLine($"Time: {sw.ElapsedTicks} tics\n");

        // Scenario 2
        Console.WriteLine("---------- Scenario 2 ----------");
        char[][] grid2 = new char[][] {
            "11000".ToCharArray(),
            "11000".ToCharArray(),
            "00100".ToCharArray(),
            "00011".ToCharArray()
        };
        Console.WriteLine("Input: grid2");
        Console.WriteLine("Expected Output: 3");
        sw.Restart();
        int result2 = solution.NumIslands(grid2);
        sw.Stop();
        Console.WriteLine($"Result: {result2}");
        Console.WriteLine($"Time: {sw.ElapsedTicks} tics\n");

        // Scenario 3
        // The grid is divided by water-only rows (rows 4, 8, 12, and 16),
        // resulting in 4 separate connected blocks (islands)
        Console.WriteLine("---------- Scenario 3 ----------");
        char[][] grid3 = new char[][] {
            "11110111101111011110".ToCharArray(),
            "11010110101101011010".ToCharArray(),
            "11000110001100011000".ToCharArray(),
            "00000000000000000000".ToCharArray(), // separator
            "11110111101111011110".ToCharArray(),
            "11010110101101011010".ToCharArray(),
            "11000110001100011000".ToCharArray(),
            "00000000000000000000".ToCharArray(), // separator
            "11110111101111011110".ToCharArray(),
            "11010110101101011010".ToCharArray(),
            "11000110001100011000".ToCharArray(),
            "00000000000000000000".ToCharArray(), // separator
            "11110111101111011110".ToCharArray(),
            "11010110101101011010".ToCharArray(),
            "11000110001100011000".ToCharArray(),
            "00000000000000000000".ToCharArray()  // separator (optional last water row)
        };
        Console.WriteLine("Input: grid3");
        Console.WriteLine("Expected Output: 16");
        sw.Restart();
        int result3 = solution.NumIslands(grid3);
        sw.Stop();
        Console.WriteLine($"Result: {result3}");
        Console.WriteLine($"Time: {sw.ElapsedTicks} tics\n");

        Console.WriteLine("=========================================");
    }
}