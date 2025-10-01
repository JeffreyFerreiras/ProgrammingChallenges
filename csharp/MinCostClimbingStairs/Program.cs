using System;
using System.Diagnostics;

namespace MinCostClimbingStairs;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("Min Cost Climbing Stairs");
        Console.WriteLine(new string('=', 26) + "\n");

        var solution = new Solution();

        var scenarios = new[]
        {
            (Name: "Example 1", Cost: [10, 15, 20], Expected: 15),
            (Name: "Example 2", Cost: [1, 100, 1, 1, 1, 100, 1, 1, 100, 1], Expected: 6),
            (Name: "Edge: Zero Cost", Cost: [0, 0], Expected: 0),
            (Name: "Alternating", Cost: [1, 100, 1, 100, 1, 100], Expected: 203),
            (Name: "Large Values", Cost: [100, 200, 300, 1], Expected: 101),
            (Name: "Long Input", Cost: BuildLongInput(20), Expected: 10)
        };

        foreach (var scenario in scenarios)
        {
            var stopwatch = Stopwatch.StartNew();
            var result = solution.MinCostClimbingStairs(scenario.Cost);
            stopwatch.Stop();

            Console.WriteLine($"Scenario: {scenario.Name}");
            Console.WriteLine($"Method: {nameof(Solution.MinCostClimbingStairs)}");
            Console.WriteLine($"Input: cost = {FormatArray(scenario.Cost)}");
            Console.WriteLine($"Result: {result}, Expected: {scenario.Expected}");
            Console.WriteLine($"Elapsed: {stopwatch.Elapsed.TotalMilliseconds:F4} ms");
            Console.WriteLine(new string('-', 60));
        }
    }

    private static int[] BuildLongInput(int length)
    {
        var result = new int[length];
        for (var i = 0; i < length; i++)
        {
            result[i] = i % 2;
        }

        return result;
    }

    private static string FormatArray(int[] values)
    {
        return "[" + string.Join(",", values) + "]";
    }
}
