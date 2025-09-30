using System;
using System.Diagnostics;

namespace JumpGameII;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("Jump Game II");
        Console.WriteLine(new string('=', 12) + "\n");

        var solution = new Solution();

        var scenarios = new[]
        {
            (Name: "Example 1", Nums: new[] { 2, 3, 1, 1, 4 }, Expected: 2),
            (Name: "Example 2", Nums: new[] { 2, 3, 0, 1, 4 }, Expected: 2),
            (Name: "Edge: Single", Nums: new[] { 0 }, Expected: 0),
            (Name: "Single Jump", Nums: new[] { 5, 0, 0, 0 }, Expected: 1),
            (Name: "Increasing Reach", Nums: new[] { 1, 2, 3, 4, 5 }, Expected: 3),
            (Name: "Long Array", Nums: BuildRange(10), Expected: 3)
        };

        foreach (var scenario in scenarios)
        {
            var stopwatch = Stopwatch.StartNew();
            var result = solution.Jump(scenario.Nums);
            stopwatch.Stop();

            Console.WriteLine($"Scenario: {scenario.Name}");
            Console.WriteLine($"Method: {nameof(Solution.Jump)}");
            Console.WriteLine($"Input: nums = {FormatArray(scenario.Nums)}");
            Console.WriteLine($"Result: {result}, Expected: {scenario.Expected}");
            Console.WriteLine($"Elapsed: {stopwatch.Elapsed.TotalMilliseconds:F4} ms");
            Console.WriteLine(new string('-', 60));
        }
    }

    private static int[] BuildRange(int length)
    {
        var array = new int[length];
        for (var i = 0; i < length; i++)
        {
            array[i] = i % 4 + 1;
        }

        return array;
    }

    private static string FormatArray(int[] values) => "[" + string.Join(",", values) + "]";
}
