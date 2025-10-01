using System;
using System.Diagnostics;
using System.Linq;

namespace BestTimeToBuyAndSellStock;

// LeetCode 121: Best Time to Buy and Sell Stock
// You are given an array prices where prices[i] is the price of a given stock on the i-th day.
// You want to maximize your profit by choosing a single day to buy one stock and a different day in the future to sell that stock.
// Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.
// Full examples and constraints can be found in README.md.
internal class Program
{
    private static void Main()
    {
        Console.WriteLine("Best Time to Buy and Sell Stock");
        Console.WriteLine("===============================\n");

        var solution = new Solution();

        var scenarios = new[]
        {
            (Name: "Example 1", Prices: [7, 1, 5, 3, 6, 4], Expected: 5),
            (Name: "Example 2", Prices: [7, 6, 4, 3, 1], Expected: 0),
            (Name: "Edge: Single Day", Prices: [5], Expected: 0),
            (Name: "No Profit", Prices: [9, 8, 7, 6, 5], Expected: 0),
            (Name: "Long Increasing Run", Prices: Enumerable.Range(1, 50).ToArray(), Expected: 49),
            (Name: "Mixed Fluctuations", Prices: [3, 8, 2, 5, 1, 7, 4, 9], Expected: 8)
        };

        foreach (var scenario in scenarios)
        {
            RunScenario(solution, scenario.Name, scenario.Prices, scenario.Expected);
        }
    }

    private static void RunScenario(Solution solution, string scenarioName, int[] prices, int expected)
    {
        var stopwatch = Stopwatch.StartNew();
        var result = solution.MaxProfit(prices);
        stopwatch.Stop();

        Console.WriteLine($"Scenario: {scenarioName}");
        Console.WriteLine($"Method: {nameof(Solution.MaxProfit)}");
        Console.WriteLine($"Result: {result}, Expected: {expected}");
        Console.WriteLine($"Elapsed: {stopwatch.Elapsed.TotalMilliseconds:F4} ms");
        Console.WriteLine(new string('-', 60));
    }
}
