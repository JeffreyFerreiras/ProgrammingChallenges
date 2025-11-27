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
            // Tree:
            //     1
            //    / \
            //   2   3
            //      / \
            //     4   5
            (Name: "Example 1", Values: [1, 2, 3, null, null, 4, 5], Serialized: "[1,2,3,null,null,4,5]"),

            // Tree: (empty)
            (Name: "Example 2", Values: Array.Empty<int?>(), Serialized: "[]"),

            // Tree:
            //  7
            (Name: "Single Node", Values: [7], Serialized: "[7]"),

            // Tree (mixed nulls):
            //     10
            //    /  \
            //   5   15
            //    \    \
            //     7    20
            (Name: "Mixed Nulls", Values: [10, 5, 15, null, 7, null, 20], Serialized: "[10,5,15,null,7,null,20]"),

            // Tree:
            //       1
            //      / \
            //     2   3
            //    / \ / \
            //   n  n 4  5
            //          / \
            //         6   7
            (Name: "Example with Bottom Level", Values: [1, 2, 3, null, null, 4, 5, 6, 7], Serialized: "[1,2,3,null,null,4,5,6,7]")
        };

        foreach (var scenario in scenarios)
        {
            var root = BuildTree(scenario.Values);

            var serializeWatch = Stopwatch.StartNew();
            var serialized = solution.Serialize(root);
            serializeWatch.Stop();

            Console.WriteLine($"Scenario: {scenario.Name}");
            Console.WriteLine($"Method: {nameof(Solution.Serialize)}");
            var serializePassed = string.Equals(serialized, scenario.Serialized, StringComparison.Ordinal);
            Console.WriteLine($"Result: {serialized} {(serializePassed ? "✔️" : "❌")}");
            Console.WriteLine($"Expected: {scenario.Serialized}");
            Console.WriteLine($"Elapsed: {serializeWatch.Elapsed.TotalMilliseconds:F4} ms");

            var deserializeWatch = Stopwatch.StartNew();
            var deserialized = solution.Deserialize(scenario.Serialized);
            deserializeWatch.Stop();

            Console.WriteLine($"Method: {nameof(Solution.Deserialize)}");
            var deserializedStr = FormatTree(deserialized);
            var deserializePassed = string.Equals(deserializedStr, FormatArray(scenario.Values), StringComparison.Ordinal);
            Console.WriteLine($"Result: {deserializedStr} {(deserializePassed ? "✔️" : "❌")}");
            Console.WriteLine($"Expected: {FormatArray(scenario.Values)}");
            Console.WriteLine($"Elapsed: {deserializeWatch.Elapsed.TotalMilliseconds:F4} ms");
            Console.WriteLine(new string('-', 60));
        }
    }

    private static TreeNode? BuildTree(IReadOnlyList<int?> values)
    {
        if (values.Count == 0 || values[0] is null)
        {
            return null;
        }

        var root = new TreeNode(values[0]!.Value);
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        var i = 1;
        while (i < values.Count && queue.Count > 0)
        {
            var current = queue.Dequeue();

            // Left child
            if (i < values.Count)
            {
                if (values[i].HasValue)
                {
                    current.left = new TreeNode(values[i]!.Value);
                    queue.Enqueue(current.left);
                }
                i++;
            }

            // Right child
            if (i < values.Count)
            {
                if (values[i].HasValue)
                {
                    current.right = new TreeNode(values[i]!.Value);
                    queue.Enqueue(current.right);
                }
                i++;
            }
        }

        return root;
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

            values.Add(node.val.ToString());
            queue.Enqueue(node.left);
            queue.Enqueue(node.right);
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
