using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace CountGoodNodesInBinaryTree;

internal class Program
{
    private static void Main(string[] args)
    {
        var scenarios = new[]
        {
            new Scenario("Example 1 [3,1,4,3,null,1,5]", BuildTree(new int?[]{3,1,4,3,null,1,5}), 4),
            new Scenario("Example 2 [3,3,null,4,2]",     BuildTree(new int?[]{3,3,null,4,2}),     3),
            new Scenario("Single node [1]",               BuildTree(new int?[]{1}),                1),
            new Scenario("Mixed [2,2,2,1,3,2,5]",        BuildTree(new int?[]{2,2,2,1,3,2,5}),    6),
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
            .Where(m => m.GetParameters()[0].ParameterType == typeof(TreeNode).MakeByRefType() ||
                        m.GetParameters()[0].ParameterType == typeof(TreeNode))
            .Where(m => m.ReturnType == typeof(int))
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

            var actual   = result!.ToString()!;
            var expected = scenario.Expected.ToString();
            Console.WriteLine($"{actual} | Expected {expected} | {(actual == expected ? "✅ PASS" : "❌ FAIL")}");
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

    private sealed record Scenario(string Name, TreeNode? Root, int Expected);
}
