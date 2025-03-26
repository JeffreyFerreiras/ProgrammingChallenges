using System.Diagnostics;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Number of Connected Components in an Undirected Graph");

        // Example 1
        int n1 = 3;
        int[][] edges1 = [[0, 1], [0, 2]];
        int expected1 = 1;
        MeasureAndPrint(nameof(Solution.NumberOfConnectedComponents), n1, edges1, expected1);

        // Example 2
        int n2 = 6;
        int[][] edges2 = [[0, 1], [1, 2], [2, 3], [4, 5]];
        int expected2 = 2;
        MeasureAndPrint(nameof(Solution.NumberOfConnectedComponents), n2, edges2, expected2);
    }

    static void MeasureAndPrint(string methodName, int n, int[][] edges, int expected)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        int result = Solution.NumberOfConnectedComponents(n, edges);
        stopwatch.Stop();

        Console.WriteLine($"{methodName} took {stopwatch.ElapsedTicks} ticks.");
        Console.WriteLine($"Result: {result}, Expected: {expected}");
    }
}
