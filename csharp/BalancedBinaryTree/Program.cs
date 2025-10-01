using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BalancedBinaryTree;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("Balanced Binary Tree");
        Console.WriteLine(new string('=', 20) + "\n");

        var solution = new Solution();

        var scenarios = new[]
        {
            (Name: "Example 1", Values: [3, 9, 20, null, null, 15, 7], Expected: true),
            (
                Name: "Example 2",
                Values: [1, 2, 2, 3, 3, null, null, 4, 4],
                Expected: false
            ),
            (Name: "Edge: Empty", Values: Array.Empty<int?>(), Expected: true),
            (Name: "Edge: Single Node", Values: [5], Expected: true),
            (Name: "Left Heavy", Values: [1, 2, null, 3, null, 4], Expected: false),
            (Name: "Right Heavy", Values: [1, null, 2, null, 3], Expected: false),
            (
                Name: "Balanced Larger",
                Values: [1, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 4, 4],
                Expected: true
            ),
        };

        foreach (var scenario in scenarios)
        {
            var root = BuildTree(scenario.Values);

            var stopwatch = Stopwatch.StartNew();
            var result = solution.IsBalanced(root);
            stopwatch.Stop();

            Console.WriteLine($"Scenario: {scenario.Name}");
            Console.WriteLine($"Method: {nameof(Solution.IsBalanced)}");
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
}
