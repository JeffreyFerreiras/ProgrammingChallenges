using System;
using System.Diagnostics;

namespace MaximumProductSubarray;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("Maximum Product Subarray");
        Console.WriteLine(new string('=', 28) + "\n");

        var solution = new Solution();

        var scenarios = new[]
        {
            (Name: "Example 1", Nums: new[] { 2, 3, -2, 4 }, Expected: 6),
            (Name: "Example 2", Nums: [-2, 0, -1], Expected: 0),
            (Name: "Single Negative", Nums: [-3], Expected: -3),
            (Name: "All Negative", Nums: [-2, -3, -4], Expected: 12),
            (Name: "Contains Zero", Nums: [0, 2, 0, 3, 4], Expected: 4),
            (Name: "Mixed Values", Nums: [-2, 3, -4], Expected: 24)
        };

        foreach (var scenario in scenarios)
        {
            var stopwatch = Stopwatch.StartNew();
            var result = solution.MaxProduct(scenario.Nums);
            stopwatch.Stop();

            Console.WriteLine($"Scenario: {scenario.Name}");
            Console.WriteLine($"Method: {nameof(Solution.MaxProduct)}");
            Console.WriteLine($"Input: nums = {FormatArray(scenario.Nums)}");
            Console.WriteLine($"Result: {result}, Expected: {scenario.Expected}");
            Console.WriteLine($"Elapsed: {stopwatch.Elapsed.TotalMilliseconds:F4} ms");
            Console.WriteLine(new string('-', 60));
        }
    }

    private static string FormatArray(int[] values) => "[" + string.Join(",", values) + "]";
}
