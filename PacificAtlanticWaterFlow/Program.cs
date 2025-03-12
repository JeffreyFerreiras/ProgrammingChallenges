using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace PacificAtlanticWaterFlow
{
    class Program
    {
        /*
         * 417. Pacific Atlantic Water Flow
         * 
         * There is an m x n rectangular island that borders both the Pacific Ocean and Atlantic Ocean. 
         * The Pacific Ocean touches the island's left and top edges, and the Atlantic Ocean touches the island's right and bottom edges.
         * 
         * The island is partitioned into a grid of square cells. You are given an m x n integer matrix heights where heights[r][c] 
         * represents the height above sea level of the cell at coordinate (r, c).
         * 
         * The island receives a lot of rain, and the rain water can flow to neighboring cells directly north, south, east, and west 
         * if the neighboring cell's height is less than or equal to the current cell's height. Water can flow from any cell adjacent 
         * to an ocean into the ocean.
         * 
         * Return a 2D list of grid coordinates result where result[i] = [ri, ci] denotes that rain water can flow from cell (ri, ci) 
         * to both the Pacific and Atlantic oceans.
         * 
         * Example 1:
         * Input: heights = [[1,2,2,3,5],[3,2,3,4,4],[2,4,5,3,1],[6,7,1,4,5],[5,1,1,2,4]]
         * Output: [[0,4],[1,3],[1,4],[2,2],[3,0],[3,1],[4,0]]
         * 
         * Example 2:
         * Input: heights = [[2,1],[1,2]]
         * Output: [[0,0],[0,1],[1,0],[1,1]]
         */

        static void Main(string[] args)
        {
            Console.WriteLine("417. Pacific Atlantic Water Flow");
            
            Solution solution = new Solution();
            
            // Test Case 1
            int[][] heights1 = new int[][]
            {
                new int[] {1, 2, 2, 3, 5},
                new int[] {3, 2, 3, 4, 4},
                new int[] {2, 4, 5, 3, 1},
                new int[] {6, 7, 1, 4, 5},
                new int[] {5, 1, 1, 2, 4}
            };
            
            string expected1 = "[[0,4],[1,3],[1,4],[2,2],[3,0],[3,1],[4,0]]";
            
            RunTestCase(solution, heights1, expected1, "Test Case 1: 5x5 Matrix");
            
            // Test Case 2
            int[][] heights2 = new int[][]
            {
                new int[] {2, 1},
                new int[] {1, 2}
            };
            
            string expected2 = "[[0,0],[0,1],[1,0],[1,1]]";
            
            RunTestCase(solution, heights2, expected2, "Test Case 2: 2x2 Matrix");
            
            // Test Case 3: Single cell island
            int[][] heights3 = new int[][] { new int[] { 3 } };
            string expected3 = "[[0,0]]";
            RunTestCase(solution, heights3, expected3, "Test Case 3: Single Cell Island");
            
            // Test Case 4: Uniform height matrix (all cells have same height)
            int[][] heights4 = new int[][]
            {
                new int[] {5, 5, 5},
                new int[] {5, 5, 5},
                new int[] {5, 5, 5}
            };
            string expected4 = "[[0,0],[0,1],[0,2],[1,0],[1,1],[1,2],[2,0],[2,1],[2,2]]";
            RunTestCase(solution, heights4, expected4, "Test Case 4: Uniform Height");
        }
        
        static void RunTestCase(Solution solution, int[][] heights, string expected, string testCaseName)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            
            var result = solution.PacificAtlantic(heights);
            
            sw.Stop();
            
            Console.WriteLine($"Test: {testCaseName}");
            Console.WriteLine($"Elapsed time (ticks): {sw.ElapsedTicks}");
            Console.WriteLine($"Actual result: {FormatResult(result)}");
            Console.WriteLine($"Expected result: {expected}");
            Console.WriteLine($"Match: {FormatResult(result) == expected}");
            Console.WriteLine();
        }
        
        static string FormatResult(IList<IList<int>> result)
        {
            if (result == null || result.Count == 0)
                return "[]";
                
            string output = "[";
            foreach (var item in result)
            {
                output += $"[{item[0]},{item[1]}],";
            }
            output = output.TrimEnd(',') + "]";
            return output;
        }
    }
}
