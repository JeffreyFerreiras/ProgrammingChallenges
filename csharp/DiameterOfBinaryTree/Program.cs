using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DiameterOfBinaryTree;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("Diameter of Binary Tree");
        Console.WriteLine(new string('=', 24) + "\n");

        var solution = new Solution();

        var scenarios = new[]
        {
            (Name: "Example 1", Values: new int?[] { 1, 2, 3, 4, 5 }, Expected: 3),
            (Name: "Example 2", Values: new int?[] { 1, 2 }, Expected: 1),
            (Name: "Edge: Single Node", Values: new int?[] { 7 }, Expected: 0),
            (Name: "Left Skewed", Values: new int?[] { 1, 2, null, 3, null, 4, null, 5 }, Expected: 4),
            (Name: "Right Skewed", Values: new int?[] { 1, null, 2, null, 3, null, 4, null, 5 }, Expected: 4),
            (Name: "Balanced", Values: new int?[] { 1, 2, 3, 4, 5, 6, 7 }, Expected: 4),
            (Name: "Deep Subtree", Values: new int?[] { 1, 2, 3, 4, null, 5, null, 6, null, 7 }, Expected: 5)
        };

        foreach (var scenario in scenarios)
        {
            var root = BuildTree(scenario.Values);

            var stopwatch = Stopwatch.StartNew();
            var result = solution.DiameterOfBinaryTree(root);
            stopwatch.Stop();

            Console.WriteLine($"Scenario: {scenario.Name}");
            Console.WriteLine($"Method: {nameof(Solution.DiameterOfBinaryTree)}");
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
