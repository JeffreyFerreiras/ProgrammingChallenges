using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ValidateBinarySearchTree;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("Validate Binary Search Tree");
        Console.WriteLine(new string('=', 30) + "\n");

        var solution = new Solution();

        var scenarios = new[]
        {
            (Name: "Example 1", Values: new int?[] { 2, 1, 3 }, Expected: true),
            (Name: "Example 2", Values: new int?[] { 5, 1, 4, null, null, 3, 6 }, Expected: false),
            (Name: "Edge: Empty", Values: Array.Empty<int?>(), Expected: true),
            (Name: "Single Node", Values: new int?[] { 8 }, Expected: true),
            (Name: "Duplicates", Values: new int?[] { 2, 2, 2 }, Expected: false),
            (Name: "Deep Violation", Values: new int?[] { 10, 5, 15, null, null, 6, 20 }, Expected: false),
            (Name: "Valid Large", Values: new int?[] { 13, 9, 17, 5, 11, 15, 19, 3, 7, 10, 12, 14, 16, 18, 21 }, Expected: true)
        };

        foreach (var scenario in scenarios)
        {
            var root = BuildTree(scenario.Values);

            var stopwatch = Stopwatch.StartNew();
            var result = solution.IsValidBST(root);
            stopwatch.Stop();

            Console.WriteLine($"Scenario: {scenario.Name}");
            Console.WriteLine($"Method: {nameof(Solution.IsValidBST)}");
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
