using System;
using System.Diagnostics;

namespace HouseRobberII;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("House Robber II");
        Console.WriteLine(new string('=', 15) + "\n");

        var solution = new Solution();

        var scenarios = new[]
        {
            (Name: "Example 1", Houses: new[] { 2, 3, 2 }, Expected: 3),
            (Name: "Example 2", Houses: new[] { 1, 2, 3, 1 }, Expected: 4),
            (Name: "Edge: Single House", Houses: new[] { 5 }, Expected: 5),
            (Name: "Two Houses", Houses: new[] { 2, 4 }, Expected: 4),
            (Name: "All Equal", Houses: new[] { 10, 10, 10, 10 }, Expected: 20),
            (Name: "Alternating High", Houses: new[] { 100, 1, 100, 1, 100 }, Expected: 200)
        };

        foreach (var scenario in scenarios)
        {
            var stopwatch = Stopwatch.StartNew();
            var result = solution.Rob(scenario.Houses);
            stopwatch.Stop();

            Console.WriteLine($"Scenario: {scenario.Name}");
            Console.WriteLine($"Method: {nameof(Solution.Rob)}");
            Console.WriteLine($"Input: nums = {FormatArray(scenario.Houses)}");
            Console.WriteLine($"Result: {result}, Expected: {scenario.Expected}");
            Console.WriteLine($"Elapsed: {stopwatch.Elapsed.TotalMilliseconds:F4} ms");
            Console.WriteLine(new string('-', 60));
        }
    }

    private static string FormatArray(int[] values) => "[" + string.Join(",", values) + "]";
}
