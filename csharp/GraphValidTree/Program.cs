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

            Solution solution = new();

            // Test cases
            RunTest(solution, "Example 1", 5, [
                [0, 1],
                [0, 2],
                [0, 3],
                [1, 4]
            ], true);

            RunTest(solution, "Example 2", 5, [
                [0, 1],
                [1, 2],
                [2, 3],
                [1, 3],
                [1, 4]
            ], false);

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        static void RunTest(Solution solution, string testName, int n, int[][] edges, bool expected)
        {
            Console.WriteLine($"\nRunning test: {testName}");

            Stopwatch stopwatch = new();
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
