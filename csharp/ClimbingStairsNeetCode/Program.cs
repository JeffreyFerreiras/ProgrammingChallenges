using System;
using System.Diagnostics;

namespace ClimbingStairsNeetCode;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("Climbing Stairs");
        Console.WriteLine(new string('=', 15) + "\n");

        var solution = new Solution();

        var scenarios = new[]
        {
            (Name: "Example 1", N: 2, Expected: 2),
            (Name: "Example 2", N: 3, Expected: 3),
            (Name: "Edge: One Step", N: 1, Expected: 1),
            (Name: "Even Steps", N: 8, Expected: 34),
            (Name: "Larger Input", N: 10, Expected: 89),
            (Name: "Upper Bound", N: 45, Expected: 1836311903)
        };

        foreach (var scenario in scenarios)
        {
            var stopwatch = Stopwatch.StartNew();
            var result = solution.ClimbStairs(scenario.N);
            stopwatch.Stop();

            Console.WriteLine($"Scenario: {scenario.Name}");
            Console.WriteLine($"Method: {nameof(Solution.ClimbStairs)}");
            Console.WriteLine($"Input: n = {scenario.N}");
            Console.WriteLine($"Result: {result}, Expected: {scenario.Expected}");
            Console.WriteLine($"Elapsed: {stopwatch.Elapsed.TotalMilliseconds:F4} ms");
            Console.WriteLine(new string('-', 60));
        }
    }
}
