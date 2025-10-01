using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SerializeAndDeserializeBinaryTree;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("Serialize and Deserialize Binary Tree");
        Console.WriteLine(new string('=', 39) + "\n");

        var solution = new Solution();

        var scenarios = new[]
        {
            (Name: "Example 1", Values: [1, 2, 3, null, null, 4, 5], Serialized: "[1,2,3,null,null,4,5]"),
            (Name: "Example 2", Values: Array.Empty<int?>(), Serialized: "[]"),
            (Name: "Single Node", Values: [7], Serialized: "[7]"),
            (Name: "Left-heavy", Values: [5, 4, null, 3, null, 2, null, 1], Serialized: "[5,4,null,3,null,2,null,1]"),
            (Name: "Right-heavy", Values: [5, null, 6, null, 7, null, 8], Serialized: "[5,null,6,null,7,null,8]"),
            (Name: "Mixed Nulls", Values: [10, 5, 15, null, 7, null, 20], Serialized: "[10,5,15,null,7,null,20]"),
            (Name: "Large Sparse", Values: [3, 9, 20, null, null, 15, 7, null, null, null, null, 12], Serialized: "[3,9,20,null,null,15,7,null,null,null,null,12]" )
        };

        foreach (var scenario in scenarios)
        {
            var root = BuildTree(scenario.Values);

            var serializeWatch = Stopwatch.StartNew();
            var serialized = solution.Serialize(root);
            serializeWatch.Stop();

            Console.WriteLine($"Scenario: {scenario.Name}");
            Console.WriteLine($"Method: {nameof(Solution.Serialize)}");
            Console.WriteLine($"Result: {serialized}");
            Console.WriteLine($"Expected: {scenario.Serialized}");
            Console.WriteLine($"Elapsed: {serializeWatch.Elapsed.TotalMilliseconds:F4} ms");

            var deserializeWatch = Stopwatch.StartNew();
            var deserialized = solution.Deserialize(scenario.Serialized);
            deserializeWatch.Stop();

            Console.WriteLine($"Method: {nameof(Solution.Deserialize)}");
            Console.WriteLine($"Result: {FormatTree(deserialized)}");
            Console.WriteLine($"Expected: {FormatArray(scenario.Values)}");
            Console.WriteLine($"Elapsed: {deserializeWatch.Elapsed.TotalMilliseconds:F4} ms");
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

    private static string FormatArray(IEnumerable<int?> values)
    {
        return "[" + string.Join(",", values.Select(v => v?.ToString() ?? "null")) + "]";
    }
}
