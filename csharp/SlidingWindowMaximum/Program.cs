using System;
using System.Diagnostics;
using System.Linq;

namespace SlidingWindowMaximum;

// LeetCode 239: Sliding Window Maximum
// Return an array of maximum values for each contiguous subarray of length k.
internal class Program
{
    private static void Main()
    {
        Console.WriteLine("Sliding Window Maximum");
        Console.WriteLine("=======================\n");

        var solution = new Solution();

        var scenarios = new[]
        {
            (Name: "Example 1", Nums: new[] { 1, 3, -1, -3, 5, 3, 6, 7 }, K: 3, Expected: new[] { 3, 3, 5, 5, 6, 7 }),
            (Name: "Example 2", Nums: [1], K: 1, Expected: [1]),
            (Name: "Edge: Full Window", Nums: [9, 8, 7, 6, 5], K: 5, Expected: [9]),
            (Name: "Edge: Duplicates", Nums: [4, 4, 4, 4], K: 2, Expected: [4, 4, 4]),
            (Name: "Increasing Sequence", Nums: [1, 2, 3, 4, 5], K: 2, Expected: [2, 3, 4, 5]),
            (Name: "Long Example", Nums: [10, 6, 9, 8, 7, 5, 4, 3, 2, 1, 0, 12, 11, 13, 15], K: 4, Expected: [10, 9, 9, 8, 7, 5, 4, 3, 12, 12, 13, 15])
        };

        foreach (var scenario in scenarios)
        {
            RunScenario(solution, scenario.Name, scenario.Nums, scenario.K, scenario.Expected);
        }
    }

    private static void RunScenario(Solution solution, string name, int[] nums, int k, int[] expected)
    {
        var stopwatch = Stopwatch.StartNew();
        var result = solution.MaxSlidingWindow(nums, k);
        stopwatch.Stop();

        Console.WriteLine($"Scenario: {name}");
        Console.WriteLine($"Method: {nameof(Solution.MaxSlidingWindow)}");
        Console.WriteLine($"Input: nums = {FormatArray(nums)}, k = {k}");
        Console.WriteLine($"Result: {FormatArray(result)}, Expected: {FormatArray(expected)}");
        Console.WriteLine($"Elapsed: {stopwatch.Elapsed.TotalMilliseconds:F4} ms");
        Console.WriteLine(new string('-', 60));
    }

    private static string FormatArray(int[] values)
    {
        if (values is null)
        {
            return "null";
        }

        return $"[" + string.Join(", ", values) + "]";
    }
}
