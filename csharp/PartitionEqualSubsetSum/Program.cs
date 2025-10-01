using System;
using System.Diagnostics;

namespace PartitionEqualSubsetSum;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("Partition Equal Subset Sum");
        Console.WriteLine(new string('=', 30) + "\n");

        var solution = new Solution();

        var scenarios = new[]
        {
            (Name: "Example 1", Nums: [1, 5, 11, 5], Expected: true),
            (Name: "Example 2", Nums: [1, 2, 3, 5], Expected: false),
            (Name: "Edge: Two Elements", Nums: [2, 2], Expected: true),
            (Name: "Odd Sum", Nums: [1, 1, 3], Expected: false),
            (Name: "Many Ones", Nums: BuildRepeated(20, 1), Expected: true),
            (Name: "Large Input", Nums: BuildRepeated(30, 3), Expected: false)
        };

        foreach (var scenario in scenarios)
        {
            var stopwatch = Stopwatch.StartNew();
            var result = solution.CanPartition(scenario.Nums);
            stopwatch.Stop();

            Console.WriteLine($"Scenario: {scenario.Name}");
            Console.WriteLine($"Method: {nameof(Solution.CanPartition)}");
            Console.WriteLine($"Input: nums = {FormatArray(scenario.Nums)}");
            Console.WriteLine($"Result: {result}, Expected: {scenario.Expected}");
            Console.WriteLine($"Elapsed: {stopwatch.Elapsed.TotalMilliseconds:F4} ms");
            Console.WriteLine(new string('-', 60));
        }
    }

    private static int[] BuildRepeated(int count, int value)
    {
        var result = new int[count];
        Array.Fill(result, value);
        return result;
    }

    private static string FormatArray(int[] values) => "[" + string.Join(",", values) + "]";
}
