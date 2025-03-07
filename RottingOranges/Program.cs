using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace RottingOranges;
public class Program
{
    public static void Main(string[] args)
    {
        /* 
        LeetCode Problem: 994. Rotting Oranges
        Description:
        You are given an m x n grid where each cell can have one of three values:
            0 representing an empty cell,
            1 representing a fresh orange, or
            2 representing a rotten orange.
        Every minute, any fresh orange that is adjacent (4-directionally) to a rotten orange becomes rotten.
        Return the minimum number of minutes that must elapse until no cell has a fresh orange.
        If this is impossible, return -1.
        
        Example 1:
        Input: grid = [[2,1,1],[1,1,0],[0,1,1]]
        Output: 4
        
        Example 2:
        Input: grid = [[2,1,1],[0,1,1],[1,0,1]]
        Output: -1
        
        Example 3:
        Input: grid = [[0,2]]
        Output: 0
        */
        
        // List of test scenarios: grid input, expected result, and a name identifier.
        var tests = new List<(int[][] grid, int expected, string name)> {
            ( new int[][] {
                [2,1,1],
                [1,1,0],
                [0,1,1]
              }, 4, "Test1" ),
            ( new int[][] {
                [2,1,1],
                [0,1,1],
                [1,0,1]
              }, -1, "Test2" ),
            ( new int[][] {
                [0,2]
              }, 0, "Test3" ),
            // added test case: grid = [[0]]
            ( new int[][] {
                [0]
              }, 0, "Test4" ),
            // added test case: grid with only fresh oranges (no rotten) => expected -1.
            ( new int[][] {
                [1,1],
                [1,1]
              }, -1, "Test5" ),
            // added test case: grid with all rotten oranges => expected 0.
            ( new int[][] {
                [2,2],
                [2,2]
              }, 0, "Test6" ),
            // added test case: one-row grid with adjacent fresh and rotten => expected 1.
            ( new int[][] {
                [1,2]
              }, 1, "Test7" ),
            // added test case: grid with only empty cells => expected 0.
            ( new int[][] {
                [0,0,0,0]
              }, 0, "Test8" )
        };
        
        foreach (var (grid, expected, name) in tests)
        {
            var sw = Stopwatch.StartNew();
            //int result = OrangesRotting(grid);
            int result = new Solution().OrangesRotting(grid);
            sw.Stop();
            Console.WriteLine($"{name} - Method: OrangesRotting, Time: {sw.ElapsedTicks} ticks, Result: {result}, Expected: {expected}");
        }
    }
    
    public static int OrangesRotting(int[][] grid)
    {
        if (grid == null || grid.Length == 0) return -1;
        
        int rows = grid.Length;
        int cols = grid[0].Length;
        var queue = new Queue<(int r, int c)>();
        int fresh = 0;
        
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (grid[i][j] == 2)
                    queue.Enqueue((i, j));
                else if (grid[i][j] == 1)
                    fresh++;
            }
        }
        
        if (fresh == 0) return 0; // no fresh oranges
        
        int minutes = 0;
        int[][] directions = [
            [1, 0],
            [-1, 0],
            [0, 1],
            [0, -1]
        ];
        
        while (queue.Count > 0)
        {
            int size = queue.Count;
            bool rottedThisMinute = false;
            for (int i = 0; i < size; i++)
            {
                var (r, c) = queue.Dequeue();
                foreach (var d in directions)
                {
                    int nr = r + d[0];
                    int nc = c + d[1];
                    if (nr >= 0 && nr < rows && nc >= 0 && nc < cols && grid[nr][nc] == 1)
                    {
                        grid[nr][nc] = 2;
                        queue.Enqueue((nr, nc));
                        fresh--;
                        rottedThisMinute = true;
                    }
                }
            }
            if (rottedThisMinute) minutes++;
        }
        
        return fresh == 0 ? minutes : -1;
    }
}