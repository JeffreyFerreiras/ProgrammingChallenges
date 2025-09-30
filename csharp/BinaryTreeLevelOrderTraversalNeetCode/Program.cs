using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace BinaryTreeLevelOrderTraversalNeetCode;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("Binary Tree Level Order Traversal");
        Console.WriteLine(new string('=', 37) + "\n");

        var solution = new Solution();

        var scenarios = new[]
        {
            (Name: "Example 1", Values: new int?[] { 3, 9, 20, null, null, 15, 7 }, Expected: new[] { new[] { 3 }, new[] { 9, 20 }, new[] { 15, 7 } }),
            (Name: "Example 2", Values: new int?[] { 1 }, Expected: new[] { new[] { 1 } }),
            (Name: "Example 3", Values: Array.Empty<int?>(), Expected: Array.Empty<int[]>()),
            (Name: "Left-heavy", Values: new int?[] { 1, 2, null, 3, null, 4 }, Expected: new[] { new[] { 1 }, new[] { 2 }, new[] { 3 }, new[] { 4 } }),
            (Name: "Right-heavy", Values: new int?[] { 1, null, 2, null, 3 }, Expected: new[] { new[] { 1 }, new[] { 2 }, new[] { 3 } }),
            (Name: "Complete Tree", Values: new int?[] { 1, 2, 3, 4, 5, 6, 7 }, Expected: new[] { new[] { 1 }, new[] { 2, 3 }, new[] { 4, 5, 6, 7 } })
        };

        foreach (var scenario in scenarios)
        {
            var root = BuildTree(scenario.Values);

            var stopwatch = Stopwatch.StartNew();
            var result = solution.LevelOrder(root);
            stopwatch.Stop();

            Console.WriteLine($"Scenario: {scenario.Name}");
            Console.WriteLine($"Method: {nameof(Solution.LevelOrder)}");
            Console.WriteLine($"Result: {FormatLevels(result)}");
            Console.WriteLine($"Expected: {FormatLevels(scenario.Expected)}");
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

    private static string FormatLevels(IEnumerable<IEnumerable<int>>? levels)
    {
        if (levels is null)
        {
            return "[]";
        }

        var formatted = levels
            .Select(level => "[" + string.Join(",", level) + "]")
            .ToArray();

        return "[" + string.Join(",", formatted) + "]";
    }
}
