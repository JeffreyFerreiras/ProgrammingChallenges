using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace KthSmallestElementInABST;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("Kth Smallest Element in a BST");
        Console.WriteLine(new string('=', 34) + "\n");

        var solution = new Solution();

        var scenarios = new[]
        {
            (Name: "Example 1", Values: new int?[] { 3, 1, 4, null, 2 }, K: 1, Expected: 1),
            (Name: "Example 2", Values: new int?[] { 5, 3, 6, 2, 4, null, null, 1 }, K: 3, Expected: 3),
            (Name: "Edge: Smallest", Values: new int?[] { 2, 1, 3 }, K: 1, Expected: 1),
            (Name: "Edge: Largest", Values: new int?[] { 2, 1, 3 }, K: 3, Expected: 3),
            (Name: "Right Skewed", Values: new int?[] { 1, null, 2, null, 3, null, 4 }, K: 4, Expected: 4),
            (Name: "Balanced", Values: new int?[] { 8, 3, 10, 1, 6, null, 14, null, null, 4, 7, 13 }, K: 5, Expected: 7),
            (Name: "Large", Values: new int?[] { 15, 10, 20, 8, 12, 17, 25, 6, 9, 11, 13, 16, 19, 22, 27 }, K: 8, Expected: 15)
        };

        foreach (var scenario in scenarios)
        {
            var root = BuildTree(scenario.Values);

            var stopwatch = Stopwatch.StartNew();
            var result = solution.KthSmallest(root, scenario.K);
            stopwatch.Stop();

            Console.WriteLine($"Scenario: {scenario.Name}");
            Console.WriteLine($"Method: {nameof(Solution.KthSmallest)}");
            Console.WriteLine($"Tree: {FormatArray(scenario.Values)}");
            Console.WriteLine($"Input k: {scenario.K}");
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
