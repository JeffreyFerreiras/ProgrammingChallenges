using System.Diagnostics;
using RedundantConnection;

// Redundant Connection
// 
// You are given a connected undirected graph with n nodes labeled from 1 to n. 
// Initially, it contained no cycles and consisted of n-1 edges.
//
// We have now added one additional edge to the graph. The edge has two different 
// vertices chosen from 1 to n, and was not an edge that previously existed in the graph.
//
// The graph is represented as an array edges of length n where edges[i] = [ai, bi] 
// represents an edge between nodes ai and bi in the graph.
//
// Return an edge that can be removed so that the graph is still a connected non-cyclical graph. 
// If there are multiple answers, return the edge that appears last in the input edges.

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Redundant Connection - LeetCode Problem");
        Console.WriteLine("=======================================");

        // Test cases
        RunTestCase("Example 1",
        [
            [1, 2],
            [1, 3],
            [2, 3]
        ], [2, 3]);

        RunTestCase("Example 2",
        [
            [1, 2],
            [2, 3],
            [3, 4],
            [1, 4],
            [1, 5]
        ], [1, 4]);

        // Additional test case
        RunTestCase("Example 3",
        [
            [1, 2],
            [2, 3],
            [3, 4],
            [4, 1],
            [1, 5],
            [5, 6],
            [6, 7]
        ], [4, 1]);

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }

    static void RunTestCase(string testName, int[][] edges, int[] expectedResult)
    {
        Console.WriteLine($"\nRunning {testName}:");
        Console.WriteLine($"Input: {FormatEdges(edges)}");

        var solution = new Solution();
        var stopwatch = new Stopwatch();

        stopwatch.Start();
        var result = solution.FindRedundantConnection(edges);
        stopwatch.Stop();

        Console.WriteLine($"Output: [{result[0]},{result[1]}]");
        Console.WriteLine($"Expected: [{expectedResult[0]},{expectedResult[1]}]");
        Console.WriteLine($"Time Elapsed: {stopwatch.ElapsedTicks} ticks ({stopwatch.ElapsedMilliseconds} ms)");

        if (result[0] == expectedResult[0] && result[1] == expectedResult[1])
            Console.WriteLine("✓ Test Passed");
        else
            Console.WriteLine("✗ Test Failed");
    }

    static string FormatEdges(int[][] edges)
    {
        var result = "[";
        for (int i = 0; i < edges.Length; i++)
        {
            result += $"[{edges[i][0]},{edges[i][1]}]";
            if (i < edges.Length - 1)
                result += ",";
        }
        result += "]";
        return result;
    }
}
