using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace BinaryTreeRightSideView;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("Binary Tree Right Side View");
        Console.WriteLine(new string('=', 31) + "\n");

        var solution = new Solution();

        var scenarios = new[]
        {
            (Name: "Example 1", Values: new int?[] { 1, 2, 3, null, 5, null, 4 }, Expected: new[] { 1, 3, 4 }),
            (Name: "Example 2", Values: new int?[] { 1, null, 3 }, Expected: new[] { 1, 3 }),
            (Name: "Example 3", Values: Array.Empty<int?>(), Expected: Array.Empty<int>()),
            (Name: "Single Node", Values: new int?[] { 7 }, Expected: new[] { 7 }),
            (Name: "Left-heavy", Values: new int?[] { 1, 2, null, 3, null, 4, null, 5 }, Expected: new[] { 1, 2, 3, 4, 5 }),
            (Name: "Full Tree", Values: new int?[] { 1, 2, 3, 4, 5, 6, 7 }, Expected: new[] { 1, 3, 7 }),
            (Name: "Sparse", Values: new int?[] { 1, 2, 3, null, 5, null, null, null, null, 4 }, Expected: new[] { 1, 3, 4 })
        };

        foreach (var scenario in scenarios)
        {
            var root = BuildTree(scenario.Values);

            var stopwatch = Stopwatch.StartNew();
            var result = solution.RightSideView(root);
            stopwatch.Stop();

            Console.WriteLine($"Scenario: {scenario.Name}");
            Console.WriteLine($"Method: {nameof(Solution.RightSideView)}");
            Console.WriteLine($"Result: {FormatList(result)}");
            Console.WriteLine($"Expected: {FormatList(scenario.Expected)}");
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

    private static string FormatList(IEnumerable<int>? values)
    {
        if (values is null)
        {
            return "[]";
        }

        var array = values.ToArray();
        return "[" + string.Join(",", array) + "]";
    }
}
