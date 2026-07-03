using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace InvertBinaryTree;

internal class Program
{
    private static void Main(string[] args)
    {
        var scenarios = new[]
        {
            new Scenario("Example 1 [4,2,7,1,3,6,9]",  new int?[]{4,2,7,1,3,6,9}, "[4,7,2,9,6,3,1]"),
            new Scenario("Example 2 [2,1,3]",            new int?[]{2,1,3},          "[2,3,1]"),
            new Scenario("Empty",                        new int?[]{},               "[]"),
            new Scenario("Single [1]",                   new int?[]{1},              "[1]"),
        };

        foreach (var scenario in scenarios)
            RunScenario(scenario);

        Console.WriteLine();
    }

    private static void RunScenario(Scenario scenario)
    {
        Console.WriteLine($"\n=== {scenario.Name} ===");

        var solution = new Solution();
        var methods = typeof(Solution)
            .GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly)
            .Where(m => !m.IsSpecialName)
            .Where(m => m.GetParameters().Length == 1)
            .Where(m => m.ReturnType == typeof(TreeNode))
            .OrderBy(m => m.Name)
            .ToArray();

        foreach (var method in methods)
        {
            var root = BuildTree(scenario.Values);
            var stopwatch = Stopwatch.StartNew();
            object? result = null;
            Exception? exception = null;

            try
            {
                result = method.Invoke(solution, new object?[] { root });
            }
            catch (Exception ex) { exception = ex; }
            finally { stopwatch.Stop(); }

            Console.Write($"{method.Name} | {stopwatch.Elapsed.TotalMilliseconds:0.0000} ms | ");

            if (exception != null)
            {
                Console.WriteLine($"ERROR: {exception.GetBaseException().Message}");
                continue;
            }

            var actual = LevelOrder((TreeNode?)result);
            Console.WriteLine($"{actual} | Expected {scenario.Expected} | {(actual == scenario.Expected ? "✅ PASS" : "❌ FAIL")}");
        }
    }

    private static string LevelOrder(TreeNode? root)
    {
        if (root is null) return "[]";
        var q = new Queue<TreeNode?>();
        var vals = new List<string>();
        q.Enqueue(root);
        while (q.Count > 0)
        {
            var node = q.Dequeue();
            if (node is null) { vals.Add("null"); continue; }
            vals.Add(node.Val.ToString());
            q.Enqueue(node.Left);
            q.Enqueue(node.Right);
        }
        while (vals.Count > 0 && vals[^1] == "null") vals.RemoveAt(vals.Count - 1);
        return "[" + string.Join(",", vals) + "]";
    }

    private static TreeNode? BuildTree(int?[] values)
    {
        if (values.Length == 0) return null;
        var nodes = new TreeNode?[values.Length];
        for (int i = 0; i < values.Length; i++)
            if (values[i].HasValue) nodes[i] = new TreeNode(values[i]!.Value);
        for (int i = 0; i < values.Length; i++)
        {
            if (nodes[i] is null) continue;
            int l = 2 * i + 1, r = 2 * i + 2;
            if (l < values.Length) nodes[i]!.Left = nodes[l];
            if (r < values.Length) nodes[i]!.Right = nodes[r];
        }
        return nodes[0];
    }

    private sealed record Scenario(string Name, int?[] Values, string Expected);
}
