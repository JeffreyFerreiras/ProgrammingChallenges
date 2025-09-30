using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CountGoodNodesInBinaryTree;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("Count Good Nodes in Binary Tree");
        Console.WriteLine(new string('=', 32) + "\n");

        var solution = new Solution();

        var scenarios = new[]
        {
            (Name: "Example 1", Values: new int?[] { 3, 1, 4, 3, null, 1, 5 }, Expected: 4),
            (Name: "Example 2", Values: new int?[] { 3, 3, null, 4, 2 }, Expected: 3),
            (Name: "Example 3", Values: new int?[] { 1 }, Expected: 1),
            (Name: "Strictly Decreasing", Values: new int?[] { 5, 4, null, 3, null, 2, null, 1 }, Expected: 1),
            (Name: "Strictly Increasing", Values: new int?[] { 1, null, 2, null, 3, null, 4 }, Expected: 4),
            (Name: "Mixed Values", Values: new int?[] { 2, 2, 2, 1, 3, 2, 5 }, Expected: 5),
            (Name: "Large Balanced", Values: new int?[] { 7, 3, 9, 3, 5, 9, 10, 3, null, null, 6, null, null, 10, 11 }, Expected: 6)
        };

        foreach (var scenario in scenarios)
        {
            var root = BuildTree(scenario.Values);

            var stopwatch = Stopwatch.StartNew();
            var result = solution.GoodNodes(root);
            stopwatch.Stop();

            Console.WriteLine($"Scenario: {scenario.Name}");
            Console.WriteLine($"Method: {nameof(Solution.GoodNodes)}");
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
