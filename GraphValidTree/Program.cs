using System;
using System.Diagnostics;

namespace GraphValidTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Graph Valid Tree Challenge");
            Console.WriteLine("=========================");
            
            Solution solution = new Solution();
            
            // Test cases
            RunTest(solution, "Example 1", 5, new int[][] { 
                new int[] { 0, 1 }, 
                new int[] { 0, 2 }, 
                new int[] { 0, 3 }, 
                new int[] { 1, 4 } 
            }, true);
            
            RunTest(solution, "Example 2", 5, new int[][] { 
                new int[] { 0, 1 }, 
                new int[] { 1, 2 }, 
                new int[] { 2, 3 }, 
                new int[] { 1, 3 }, 
                new int[] { 1, 4 } 
            }, false);
            
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
        
        static void RunTest(Solution solution, string testName, int n, int[][] edges, bool expected)
        {
            Console.WriteLine($"\nRunning test: {testName}");
            
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            
            bool result = solution.ValidTree(n, edges);
            
            stopwatch.Stop();
            
            Console.WriteLine($"Method: ValidTree");
            Console.WriteLine($"Execution Time: {stopwatch.ElapsedTicks} ticks");
            Console.WriteLine($"Result: `{result}`");
            Console.WriteLine($"Expected: `{expected}`");
        }
    }
}
