using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MaximumDepthOfBinaryTree;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("Maximum Depth of Binary Tree");
        Console.WriteLine(new string('=', 31) + "\n");

        var solution = new Solution();

        var scenarios = new[]
        {
            (Name: "Example 1", Values: [3, 9, 20, null, null, 15, 7], Expected: 3),
            (Name: "Example 2", Values: [1, null, 2], Expected: 2),
            (Name: "Edge: Empty", Values: Array.Empty<int?>(), Expected: 0),
            (Name: "Edge: Single Node", Values: [42], Expected: 1),
            (Name: "Left Skewed", Values: [1, 2, null, 3, null, 4, null, 5], Expected: 5),
            (Name: "Right Skewed", Values: [1, null, 2, null, 3, null, 4], Expected: 4),
            (Name: "Balanced Larger", Values: [1, 2, 3, 4, 5, 6, 7, 8, 9], Expected: 4)
        };

        foreach (var scenario in scenarios)
        {
            var root = BuildTree(scenario.Values);

            var stopwatch = Stopwatch.StartNew();
            var result = solution.MaxDepth(root);
            stopwatch.Stop();

            Console.WriteLine($"Scenario: {scenario.Name}");
            Console.WriteLine($"Method: {nameof(Solution.MaxDepth)}");
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
