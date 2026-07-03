using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace LowestCommonAncestorOfBST;

internal class Program
{
    private static void Main(string[] args)
    {
        var t1 = BuildTree(new int?[]{6,2,8,0,4,7,9,null,null,3,5});
        var t2 = BuildTree(new int?[]{6,2,8,0,4,7,9,null,null,3,5});
        var t3 = BuildTree(new int?[]{2,1,3});

        var scenarios = new[]
        {
            new Scenario("Example 1 p=2 q=8 -> 6",  t1, FindNode(t1, 2), FindNode(t1, 8),  6),
            new Scenario("Example 2 p=2 q=4 -> 2",  t2, FindNode(t2, 2), FindNode(t2, 4),  2),
            new Scenario("Balanced p=1 q=3 -> 2",   t3, FindNode(t3, 1), FindNode(t3, 3),  2),
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
            .Where(m => m.GetParameters().Length == 3)
            .Where(m => m.ReturnType == typeof(TreeNode))
            .OrderBy(m => m.Name)
            .ToArray();

        foreach (var method in methods)
        {
            var stopwatch = Stopwatch.StartNew();
            object? result = null;
            Exception? exception = null;

            try
            {
                result = method.Invoke(solution, new object?[] { scenario.Root, scenario.P, scenario.Q });
            }
            catch (Exception ex) { exception = ex; }
            finally { stopwatch.Stop(); }

            Console.Write($"{method.Name} | {stopwatch.Elapsed.TotalMilliseconds:0.0000} ms | ");

            if (exception != null)
            {
                Console.WriteLine($"ERROR: {exception.GetBaseException().Message}");
                continue;
            }

            var node = (TreeNode?)result;
            var actual   = node?.val.ToString() ?? "null";
            var expected = scenario.Expected.ToString();
            Console.WriteLine($"{actual} | Expected {expected} | {(actual == expected ? "✅ PASS" : "❌ FAIL")}");
        }
    }

    private static TreeNode? FindNode(TreeNode? root, int val)
    {
        if (root is null) return null;
        if (root.val == val) return root;
        return FindNode(root.left, val) ?? FindNode(root.right, val);
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
            if (l < values.Length) nodes[i]!.left = nodes[l];
            if (r < values.Length) nodes[i]!.right = nodes[r];
        }
        return nodes[0];
    }

    private sealed record Scenario(string Name, TreeNode? Root, TreeNode? P, TreeNode? Q, int Expected);
}
