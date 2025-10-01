using System;
using System.Diagnostics;

namespace LongestIncreasingSubsequence;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("Longest Increasing Subsequence");
        Console.WriteLine(new string('=', 34) + "\n");

        var solution = new Solution();

        var scenarios = new[]
        {
            (Name: "Example 1", Nums: new[] { 10, 9, 2, 5, 3, 7, 101, 18 }, Expected: 4),
            (Name: "Example 2", Nums: [0, 1, 0, 3, 2, 3], Expected: 4),
            (Name: "Example 3", Nums: [7, 7, 7, 7, 7, 7, 7], Expected: 1),
            (Name: "Edge: Single", Nums: [1], Expected: 1),
            (Name: "Increasing", Nums: [1, 2, 3, 4, 5], Expected: 5),
            (Name: "Decreasing", Nums: [5, 4, 3, 2, 1], Expected: 1)
        };

        foreach (var scenario in scenarios)
        {
            var stopwatch = Stopwatch.StartNew();
            var result = solution.LengthOfLIS(scenario.Nums);
            stopwatch.Stop();

            Console.WriteLine($"Scenario: {scenario.Name}");
            Console.WriteLine($"Method: {nameof(Solution.LengthOfLIS)}");
            Console.WriteLine($"Input: nums = {FormatArray(scenario.Nums)}");
            Console.WriteLine($"Result: {result}, Expected: {scenario.Expected}");
            Console.WriteLine($"Elapsed: {stopwatch.Elapsed.TotalMilliseconds:F4} ms");
            Console.WriteLine(new string('-', 60));
        }
    }

    private static string FormatArray(int[] values) => "[" + string.Join(",", values) + "]";
}
