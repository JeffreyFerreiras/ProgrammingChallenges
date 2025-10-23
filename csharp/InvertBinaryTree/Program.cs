using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace InvertBinaryTree;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("Invert Binary Tree");
        Console.WriteLine(new string('=', 19) + "\n");

        var solution = new Solution();

        var scenarios = new[]
        {
            (Name: "Example 1", Values: [4, 2, 7, 1, 3, 6, 9], Expected: [4, 7, 2, 9, 6, 3, 1]),
            (Name: "Example 2", Values: [2, 1, 3], Expected: [2, 3, 1]),
            (Name: "Example 3", Values: Array.Empty<int?>(), Expected: Array.Empty<int?>()),
            (Name: "Edge: Single Node", Values: [1], Expected: [1]),
            (Name: "Left-leaning", Values: [5, 4, null, 3], Expected: [5, null, 4, null, 3]),
            (Name: "Perfect Tree", Values: [1, 2, 3, 4, 5, 6, 7], Expected: [1, 3, 2, 7, 6, 5, 4])
        };

        foreach (var scenario in scenarios)
        {
            var root = BuildTree(scenario.Values);

            var stopwatch = Stopwatch.StartNew();
            var result = solution.InvertTree(root);
            stopwatch.Stop();

            var resultStr = FormatTree(result);
            var expectedStr = FormatArray(scenario.Expected);
            var passed = resultStr == expectedStr;
            var statusIcon = passed ? "✓" : "✗";

            Console.WriteLine($"{statusIcon} Scenario: {scenario.Name}");
            Console.WriteLine($"Method: {nameof(Solution.InvertTree)}");
            Console.WriteLine($"Result: {resultStr}");
            Console.WriteLine($"Expected: {expectedStr}");
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

    private static string FormatTree(TreeNode? root)
    {
        if (root is null)
        {
            return "[]";
        }

        var queue = new Queue<TreeNode?>();
        var values = new List<string>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            if (node is null)
            {
                values.Add("null");
                continue;
            }

            values.Add(node.Val.ToString());
            queue.Enqueue(node.Left);
            queue.Enqueue(node.Right);
        }

        for (var i = values.Count - 1; i >= 0; i--)
        {
            if (values[i] != "null")
            {
                break;
            }

            values.RemoveAt(i);
        }

        return "[" + string.Join(",", values) + "]";
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
