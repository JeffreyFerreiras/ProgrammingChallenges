using System;
using System.Diagnostics;

namespace HouseRobber;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("House Robber");
        Console.WriteLine(new string('=', 12) + "\n");

        var solution = new Solution();

        var scenarios = new[]
        {
            (Name: "Example 1", Houses: new[] { 1, 2, 3, 1 }, Expected: 4),
            (Name: "Example 2", Houses: new[] { 2, 7, 9, 3, 1 }, Expected: 12),
            (Name: "Edge: Zero", Houses: new[] { 0 }, Expected: 0),
            (Name: "Single House", Houses: new[] { 10 }, Expected: 10),
            (Name: "Large Values", Houses: new[] { 100, 1, 1, 100 }, Expected: 200),
            (Name: "Long Street", Houses: BuildAlternating(12), Expected: 66)
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

    private static int[] BuildAlternating(int length)
    {
        var array = new int[length];
        for (var i = 0; i < length; i++)
        {
            array[i] = i % 2 == 0 ? 11 : 0;
        }

        return array;
    }

    private static string FormatArray(int[] values) => "[" + string.Join(",", values) + "]";
}
