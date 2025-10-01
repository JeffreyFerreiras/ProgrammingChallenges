using System;
using System.Diagnostics;

namespace CombinationSumIV;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("Combination Sum IV");
        Console.WriteLine(new string('=', 18) + "\n");

        var solution = new Solution();

        var scenarios = new[]
        {
            (Name: "Example 1", Nums: new[] { 1, 2, 3 }, Target: 4, Expected: 7),
            (Name: "Example 2", Nums: [9], Target: 3, Expected: 0),
            (Name: "Edge: Exact", Nums: [4], Target: 4, Expected: 1),
            (Name: "No Combination", Nums: [5, 6], Target: 3, Expected: 0),
            (Name: "Large Target", Nums: [1, 2], Target: 10, Expected: 89),
            (Name: "Multiple Paths", Nums: [2, 3, 5], Target: 8, Expected: 6)
        };

        foreach (var scenario in scenarios)
        {
            var stopwatch = Stopwatch.StartNew();
            var result = solution.CombinationSum4(scenario.Nums, scenario.Target);
            stopwatch.Stop();

            Console.WriteLine($"Scenario: {scenario.Name}");
            Console.WriteLine($"Method: {nameof(Solution.CombinationSum4)}");
            Console.WriteLine($"Input: nums = {FormatArray(scenario.Nums)}, target = {scenario.Target}");
            Console.WriteLine($"Result: {result}, Expected: {scenario.Expected}");
            Console.WriteLine($"Elapsed: {stopwatch.Elapsed.TotalMilliseconds:F4} ms");
            Console.WriteLine(new string('-', 60));
        }
    }

    private static string FormatArray(int[] values) => "[" + string.Join(",", values) + "]";
}
