using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace BinaryTreeRightSideView;

internal class Program
{
    private static void Main(string[] args)
    {
        var scenarios = new[]
        {
            new Scenario("Example 1 [1,2,3,null,5,null,4]", BuildTree(new int?[]{1,2,3,null,5,null,4}), "1,3,4"),
            new Scenario("Example 2 [1,null,3]",             BuildTree(new int?[]{1,null,3}),            "1,3"),
            new Scenario("Empty",                            null,                                         ""),
            new Scenario("Single [7]",                       BuildTree(new int?[]{7}),                    "7"),
            new Scenario("Full [1,2,3,4,5,6,7]",            BuildTree(new int?[]{1,2,3,4,5,6,7}),        "1,3,7"),
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
            .Where(m => m.ReturnType == typeof(IList<int>))
            .OrderBy(m => m.Name)
            .ToArray();

        foreach (var method in methods)
        {
            var stopwatch = Stopwatch.StartNew();
            object? result = null;
            Exception? exception = null;

            try
            {
                result = method.Invoke(solution, new object?[] { scenario.Root });
            }
            catch (Exception ex) { exception = ex; }
            finally { stopwatch.Stop(); }

            Console.Write($"{method.Name} | {stopwatch.Elapsed.TotalMilliseconds:0.0000} ms | ");

            if (exception != null)
            {
                Console.WriteLine($"ERROR: {exception.GetBaseException().Message}");
                continue;
            }

            var actual = string.Join(",", (IList<int>)result!);
            Console.WriteLine($"{actual} | Expected {scenario.Expected} | {(actual == scenario.Expected ? "✅ PASS" : "❌ FAIL")}");
        }
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

    private sealed record Scenario(string Name, TreeNode? Root, string Expected);
}
