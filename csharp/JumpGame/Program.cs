using System;
using System.Diagnostics;

namespace JumpGame;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("Jump Game");
        Console.WriteLine(new string('=', 9) + "\n");

        var solution = new Solution();

        var scenarios = new[]
        {
            (Name: "Example 1", Nums: new[] { 2, 3, 1, 1, 4 }, Expected: true),
            (Name: "Example 2", Nums: [3, 2, 1, 0, 4], Expected: false),
            (Name: "Edge: Single", Nums: [0], Expected: true),
            (Name: "Single Jump", Nums: [1, 0, 0, 0], Expected: false),
            (Name: "Long Reach", Nums: [5, 0, 0, 0, 0], Expected: true),
            (Name: "Alternating", Nums: [2, 0, 2, 0, 1], Expected: true)
        };

        foreach (var scenario in scenarios)
        {
            var stopwatch = Stopwatch.StartNew();
            var result = solution.CanJump(scenario.Nums);
            stopwatch.Stop();

            Console.WriteLine($"Scenario: {scenario.Name}");
            Console.WriteLine($"Method: {nameof(Solution.CanJump)}");
            Console.WriteLine($"Input: nums = {FormatArray(scenario.Nums)}");
            Console.WriteLine($"Result: {result}, Expected: {scenario.Expected}");
            Console.WriteLine($"Elapsed: {stopwatch.Elapsed.TotalMilliseconds:F4} ms");
            Console.WriteLine(new string('-', 60));
        }
    }

    private static string FormatArray(int[] values) => "[" + string.Join(",", values) + "]";
}
