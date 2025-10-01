using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        // Test scenarios with their expected results
        var scenarios = new Dictionary<int, int>
        {
            { 1, 1 },    // 1 queen on 1x1 board: 1 solution
            { 2, 0 },    // 2 queens on 2x2 board: 0 solutions
            { 3, 0 },    // 3 queens on 3x3 board: 0 solutions
            { 4, 2 },    // 4 queens on 4x4 board: 2 solutions
            { 5, 10 },   // 5 queens on 5x5 board: 10 solutions
            { 6, 4 },    // 6 queens on 6x6 board: 4 solutions
            { 7, 40 },   // 7 queens on 7x7 board: 40 solutions
            { 8, 92 },   // 8 queens on 8x8 board: 92 solutions
            { 9, 352 }   // 9 queens on 9x9 board: 352 solutions
        };

        foreach (var scenario in scenarios)
        {
            int n = scenario.Key;
            int expectedCount = scenario.Value;

            // Test first solution method
            RunTest("SolveNQueens", n, expectedCount, () => NQueensSolution.SolveNQueens(n));

            // Test second solution method using StringBuilder
            RunTest("SolveNQueens2", n, expectedCount, () => NQueensSolution.SolveNQueens2(n));

            Console.WriteLine(new string('=', 50));
        }
    }

    static void RunTest(string methodName, int n, int expectedCount, Func<IList<IList<string>>> solutionMethod)
    {
        Stopwatch stopwatch = new();
        stopwatch.Start();

        IList<IList<string>> result = solutionMethod();

        stopwatch.Stop();

        Console.WriteLine($"Method: {methodName}(n={n})");
        Console.WriteLine($"Time: {stopwatch.ElapsedTicks} ticks");
        Console.WriteLine($"Result: {result.Count} solutions");
        Console.WriteLine($"Expected: {expectedCount} solutions");

        // Print first solution as example if exists
        if (result.Count > 0)
        {
            Console.WriteLine("First solution:");
            foreach (var row in result[0])
            {
                Console.WriteLine(row);
            }
        }

        Console.WriteLine(new string('-', 40));
    }
}
