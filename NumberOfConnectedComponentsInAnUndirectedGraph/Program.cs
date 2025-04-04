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

        // Test Case 3: Single node
        int n3 = 1;
        int[][] edges3 = [];
        int expected3 = 1;
        MeasureAndPrint(nameof(Solution.NumberOfConnectedComponents), n3, edges3, expected3);
        
        // Test Case 4: Disconnected nodes (no edges)
        int n4 = 5;
        int[][] edges4 = [];
        int expected4 = 5;
        MeasureAndPrint(nameof(Solution.NumberOfConnectedComponents), n4, edges4, expected4);
        
        // Test Case 5: Fully connected component
        int n5 = 5;
        int[][] edges5 = [[0, 1], [1, 2], [2, 3], [3, 4]];
        int expected5 = 1;
        MeasureAndPrint(nameof(Solution.NumberOfConnectedComponents), n5, edges5, expected5);
        
        // Test Case 6: Multiple small components
        int n6 = 10;
        int[][] edges6 = [[0, 1], [2, 3], [4, 5], [6, 7], [8, 9]];
        int expected6 = 5;
        MeasureAndPrint(nameof(Solution.NumberOfConnectedComponents), n6, edges6, expected6);
        
        // Test Case 7: Complex graph with multiple components
        int n7 = 8;
        int[][] edges7 = [[0, 1], [1, 2], [3, 4], [5, 6], [6, 7]];
        int expected7 = 3;
        MeasureAndPrint(nameof(Solution.NumberOfConnectedComponents), n7, edges7, expected7);
        
        // Test Case 8: Complex scenario with cycle
        int n8 = 7;
        int[][] edges8 = [[0, 1], [1, 2], [2, 0], [3, 4], [4, 5], [5, 6], [6, 3]];
        int expected8 = 2;
        MeasureAndPrint(nameof(Solution.NumberOfConnectedComponents), n8, edges8, expected8);
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
