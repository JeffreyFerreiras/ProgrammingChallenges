using System;
using System.Collections.Generic;

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
        Console.WriteLine("Hello, World!");

        // Scenario 1
        Console.WriteLine("Scenario 1:");
        char[][] grid1 = new char[][] {
            "11110".ToCharArray(),
            "11010".ToCharArray(),
            "11000".ToCharArray(),
            "00000".ToCharArray()
        };
        // Expected: 1
        Console.WriteLine("Input: grid1");
        Console.WriteLine("Expected Output: 1");
        var sw = System.Diagnostics.Stopwatch.StartNew();
        int result1 = solution.NumIslands(grid1);
        sw.Stop();
        Console.WriteLine($"Time: {sw.ElapsedMilliseconds}ms");
        Console.WriteLine($"Result: {result1}");
        Console.WriteLine();

        // Scenario 2
        Console.WriteLine("Scenario 2:");
        char[][] grid2 = new char[][] {
            "11000".ToCharArray(),
            "11000".ToCharArray(),
            "00100".ToCharArray(),
            "00011".ToCharArray()
        };
        // Expected: 3
        Console.WriteLine("Input: grid2");
        Console.WriteLine("Expected Output: 3");
        sw.Restart();
        int result2 = solution.NumIslands(grid2);
        sw.Stop();
        Console.WriteLine($"Time: {sw.ElapsedMilliseconds}ms");
        Console.WriteLine($"Result: {result2}");
    }
}