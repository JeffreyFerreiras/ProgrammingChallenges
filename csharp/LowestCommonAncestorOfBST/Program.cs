using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace LowestCommonAncestorOfBST;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("Lowest Common Ancestor of BST");
        Console.WriteLine(new string('=', 34) + "\n");

        var solution = new Solution();

        var scenarios = new[]
        {
            (Name: "Example 1", Values: new int?[] { 6, 2, 8, 0, 4, 7, 9, null, null, 3, 5 }, P: 2, Q: 8, Expected: 6),
            (Name: "Example 2", Values: new int?[] { 6, 2, 8, 0, 4, 7, 9, null, null, 3, 5 }, P: 2, Q: 4, Expected: 2),
            (Name: "Edge: Same Node", Values: new int?[] { 5, 3, 7, 2, 4, 6, 8 }, P: 4, Q: 4, Expected: 4),
            (Name: "Root as Ancestor", Values: new int?[] { 2, 1, 3 }, P: 1, Q: 3, Expected: 2),
            (Name: "Left Heavy", Values: new int?[] { 5, 3, null, 2, null, 1 }, P: 1, Q: 3, Expected: 3),
            (Name: "Right Heavy", Values: new int?[] { 5, null, 8, null, 10, null, 12 }, P: 8, Q: 12, Expected: 8),
            (Name: "Deep Nodes", Values: new int?[] { 10, 5, 15, 2, 7, 12, 20, 1, 3, 6, 8, 11, 13, 18, 25 }, P: 3, Q: 8, Expected: 5)
        };

        foreach (var scenario in scenarios)
        {
            var root = BuildTree(scenario.Values);
            var pNode = FindNode(root, scenario.P);
            var qNode = FindNode(root, scenario.Q);

            var stopwatch = Stopwatch.StartNew();
            var result = solution.LowestCommonAncestor(root, pNode, qNode);
            stopwatch.Stop();

            Console.WriteLine($"Scenario: {scenario.Name}");
            Console.WriteLine($"Method: {nameof(Solution.LowestCommonAncestor)}");
            Console.WriteLine($"Tree: {FormatArray(scenario.Values)}");
            Console.WriteLine($"Inputs: p = {scenario.P}, q = {scenario.Q}");
            Console.WriteLine($"Result: {FormatNode(result)}, Expected: {scenario.Expected}");
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

    private static TreeNode? FindNode(TreeNode? root, int value)
    {
        if (root is null)
        {
            return null;
        }

        var queue = new Queue<TreeNode?>();
        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            if (node is null)
            {
                continue;
            }

            if (node.Val == value)
            {
                return node;
            }

            queue.Enqueue(node.Left);
            queue.Enqueue(node.Right);
        }

        return null;
    }

    private static string FormatArray(IReadOnlyList<int?> values)
    {
        if (values.Count == 0)
        {
            return "[]";
        }

        return "[" + string.Join(",", values.Select(v => v?.ToString() ?? "null")) + "]";
    }

    private static string FormatNode(TreeNode? node)
    {
        return node?.Val.ToString() ?? "null";
    }
}
