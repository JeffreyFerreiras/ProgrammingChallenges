using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace BinaryTreeMaximumPathSum;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("Binary Tree Maximum Path Sum");
        Console.WriteLine(new string('=', 32) + "\n");

        var solution = new Solution();

        var scenarios = new[]
        {
            (Name: "Example 1", Values: new int?[] { 1, 2, 3 }, Expected: 6),
            (Name: "Example 2", Values: new int?[] { -10, 9, 20, null, null, 15, 7 }, Expected: 42),
            (Name: "Edge: Single Negative", Values: new int?[] { -3 }, Expected: -3),
            (Name: "All Negative", Values: new int?[] { -2, -1 }, Expected: -1),
            (Name: "Mixed", Values: new int?[] { 5, 4, 8, 11, null, 13, 4, 7, 2, null, null, 5, 1 }, Expected: 48),
            (Name: "Skewed", Values: new int?[] { 1, 2, null, 3, null, 4 }, Expected: 10),
            (Name: "Balanced", Values: new int?[] { 2, -1, -2, 3, 4, -5, 6 }, Expected: 8)
        };

        foreach (var scenario in scenarios)
        {
            var root = BuildTree(scenario.Values);

            var stopwatch = Stopwatch.StartNew();
            var result = solution.MaxPathSum(root);
            stopwatch.Stop();

            Console.WriteLine($"Scenario: {scenario.Name}");
            Console.WriteLine($"Method: {nameof(Solution.MaxPathSum)}");
            Console.WriteLine($"Tree: {FormatArray(scenario.Values)}");
            Console.WriteLine($"Result: {result}, Expected: {scenario.Expected}");
            Console.WriteLine($"Elapsed: {stopwatch.Elapsed.TotalMilliseconds:F4} ms");
            Console.WriteLine(new string('-', 60));
        }
    }

    private static TreeNode? BuildTree(IReadOnlyList<int?> values)
    {
        if (values.Count == 0)
        {
            return null;
        }

        var nodes = new TreeNode?[values.Count];
        for (var i = 0; i < values.Count; i++)
        {
            if (values[i].HasValue)
            {
                nodes[i] = new TreeNode(values[i]!.Value);
            }
        }

        for (var i = 0; i < values.Count; i++)
        {
            var current = nodes[i];
            if (current is null)
            {
                continue;
            }

            var leftIndex = 2 * i + 1;
            var rightIndex = 2 * i + 2;

            if (leftIndex < values.Count)
            {
                current.Left = nodes[leftIndex];
            }

            if (rightIndex < values.Count)
            {
                current.Right = nodes[rightIndex];
            }
        }

        return nodes[0];
    }

    private static string FormatArray(IReadOnlyList<int?> values)
    {
        if (values.Count == 0)
        {
            return "[]";
        }

        return "[" + string.Join(",", values.Select(v => v?.ToString() ?? "null")) + "]";
    }
}
