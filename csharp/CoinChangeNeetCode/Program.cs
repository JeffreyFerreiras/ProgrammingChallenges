using System;
using System.Diagnostics;

namespace CoinChangeNeetCode;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("Coin Change");
        Console.WriteLine(new string('=', 11) + "\n");

        var solution = new Solution();

        var scenarios = new[]
        {
            (Name: "Example 1", Coins: new[] { 1, 2, 5 }, Amount: 11, Expected: 3),
            (Name: "Example 2", Coins: new[] { 2 }, Amount: 3, Expected: -1),
            (Name: "Example 3", Coins: new[] { 1 }, Amount: 0, Expected: 0),
            (Name: "Edge: Single Coin", Coins: new[] { 1 }, Amount: 1, Expected: 1),
            (Name: "Impossible", Coins: new[] { 5, 10 }, Amount: 3, Expected: -1),
            (Name: "Large Amount", Coins: new[] { 1, 3, 4 }, Amount: 27, Expected: 7)
        };

        foreach (var scenario in scenarios)
        {
            var stopwatch = Stopwatch.StartNew();
            var result = solution.CoinChange(scenario.Coins, scenario.Amount);
            stopwatch.Stop();

            Console.WriteLine($"Scenario: {scenario.Name}");
            Console.WriteLine($"Method: {nameof(Solution.CoinChange)}");
            Console.WriteLine($"Input: coins = {FormatArray(scenario.Coins)}, amount = {scenario.Amount}");
            Console.WriteLine($"Result: {result}, Expected: {scenario.Expected}");
            Console.WriteLine($"Elapsed: {stopwatch.Elapsed.TotalMilliseconds:F4} ms");
            Console.WriteLine(new string('-', 60));
        }
    }

    private static string FormatArray(int[] values) => "[" + string.Join(",", values) + "]";
}
