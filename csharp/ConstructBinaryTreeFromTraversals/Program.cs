using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ConstructBinaryTreeFromTraversals;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("Construct Binary Tree from Traversals");
        Console.WriteLine(new string('=', 41) + "\n");

        var solution = new Solution();

        var scenarios = new[]
        {
            (Name: "Example 1", Preorder: new[] { 3, 9, 20, 15, 7 }, Inorder: new[] { 9, 3, 15, 20, 7 }, Expected: new int?[] { 3, 9, 20, null, null, 15, 7 }),
            (Name: "Example 2", Preorder: new[] { -1 }, Inorder: new[] { -1 }, Expected: new int?[] { -1 }),
            (Name: "Left Skewed", Preorder: new[] { 4, 3, 2, 1 }, Inorder: new[] { 1, 2, 3, 4 }, Expected: new int?[] { 4, null, 3, null, 2, null, 1 }),
            (Name: "Right Skewed", Preorder: new[] { 1, 2, 3, 4 }, Inorder: new[] { 4, 3, 2, 1 }, Expected: new int?[] { 1, 2, null, 3, null, 4 }),
            (Name: "Balanced", Preorder: new[] { 8, 4, 2, 6, 12, 10, 14 }, Inorder: new[] { 2, 4, 6, 8, 10, 12, 14 }, Expected: new int?[] { 8, 4, 12, 2, 6, 10, 14 }),
            (Name: "Large", Preorder: new[] { 10, 5, 2, 7, 15, 12, 20, 17 }, Inorder: new[] { 2, 5, 7, 10, 12, 15, 17, 20 }, Expected: new int?[] { 10, 5, 15, 2, 7, 12, 20, null, null, null, null, null, null, 17 })
        };

        foreach (var scenario in scenarios)
        {
            var stopwatch = Stopwatch.StartNew();
            var result = solution.BuildTree(scenario.Preorder, scenario.Inorder);
            stopwatch.Stop();

            Console.WriteLine($"Scenario: {scenario.Name}");
            Console.WriteLine($"Method: {nameof(Solution.BuildTree)}");
            Console.WriteLine($"Preorder: {FormatArray(scenario.Preorder)}");
            Console.WriteLine($"Inorder: {FormatArray(scenario.Inorder)}");
            Console.WriteLine($"Result: {FormatTree(result)}");
            Console.WriteLine($"Expected: {FormatArray(scenario.Expected)}");
            Console.WriteLine($"Elapsed: {stopwatch.Elapsed.TotalMilliseconds:F4} ms");
            Console.WriteLine(new string('-', 60));
        }
    }

    private static string FormatArray(IEnumerable<int> values)
    {
        return "[" + string.Join(",", values) + "]";
    }

    private static string FormatArray(IEnumerable<int?> values)
    {
        return "[" + string.Join(",", values.Select(v => v?.ToString() ?? "null")) + "]";
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
}
