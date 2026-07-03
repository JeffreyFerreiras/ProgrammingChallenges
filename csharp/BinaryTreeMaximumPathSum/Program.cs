using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace BinaryTreeMaximumPathSum;

internal class Program
{
    private static void Main(string[] args)
    {
        var scenarios = new[]
        {
            new Scenario("Example 1 [1,2,3]",       BuildTree(new int?[]{1,2,3}),          6),
            new Scenario("Example 2 [-10,9,20,n,n,15,7]", BuildTree(new int?[]{-10,9,20,null,null,15,7}), 42),
            new Scenario("Single negative [-3]",     BuildTree(new int?[]{-3}),             -3),
            new Scenario("All negative [-2,-1]",     BuildTree(new int?[]{-2,-1}),          -1),
            new Scenario("Mixed [5,4,8,11,n,13,4,7,2,n,n,5,1]",
                BuildTree(new int?[]{5,4,8,11,null,13,4,7,2,null,null,5,1}), 53),
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
            .Where(m => m.GetParameters().Length >= 1)
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
                // MaxPathSum has optional int parameter; invoke with just root
                var args2 = method.GetParameters().Length == 1
                    ? new object?[] { scenario.Root }
                    : new object?[] { scenario.Root, 0 };
                result = method.Invoke(solution, args2);
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

    private sealed record Scenario(string Name, TreeNode? Root, int Expected);
}
