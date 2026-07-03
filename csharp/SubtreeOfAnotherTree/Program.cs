using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace SubtreeOfAnotherTree;

internal class Program
{
    private static void Main(string[] args)
    {
        var scenarios = new[]
        {
            new Scenario("Example 1 [3,4,5,1,2] sub [4,1,2]",
                BuildTree(new int?[]{3,4,5,1,2}), BuildTree(new int?[]{4,1,2}), true),
            new Scenario("Example 2 with extra child",
                BuildTree(new int?[]{3,4,5,1,2,null,null,null,null,0}), BuildTree(new int?[]{4,1,2}), false),
            new Scenario("Single match [1] sub [1]",   BuildTree(new int?[]{1}), BuildTree(new int?[]{1}), true),
            new Scenario("Single mismatch [1] sub [2]",BuildTree(new int?[]{1}), BuildTree(new int?[]{2}), false),
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
            .Where(m => m.GetParameters().Length == 2)
            .Where(m => m.ReturnType == typeof(bool))
            .OrderBy(m => m.Name)
            .ToArray();

        foreach (var method in methods)
        {
            var stopwatch = Stopwatch.StartNew();
            object? result = null;
            Exception? exception = null;

            try
            {
                result = method.Invoke(solution, new object?[] { scenario.Root, scenario.SubRoot });
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
            if (l < values.Length) nodes[i]!.left = nodes[l];
            if (r < values.Length) nodes[i]!.right = nodes[r];
        }
        return nodes[0];
    }

    private sealed record Scenario(string Name, TreeNode? Root, TreeNode? SubRoot, bool Expected);
}
