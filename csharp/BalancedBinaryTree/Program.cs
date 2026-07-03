// LeetCode 110 - Balanced Binary Tree
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace BalancedBinaryTree
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var scenarios = new[]
            {
                new Scenario("Example 1", new int?[] { 3, 9, 20, null, null, 15, 7 }, true),
                new Scenario("Example 2", new int?[] { 1, 2, 2, 3, 3, null, null, 4, 4 }, false),
                new Scenario("Edge: Empty", new int?[] { }, true),
                new Scenario("Edge: Single Node", new int?[] { 5 }, true),
                new Scenario("Left Heavy", new int?[] { 1, 2, null, 3, null, 4 }, false),
                new Scenario("Balanced Larger", new int?[] { 1, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 4, 4 }, true),
            };

            foreach (var scenario in scenarios)
                RunScenario(scenario);
            Console.WriteLine();
        }

        private static void RunScenario(Scenario scenario)
        {
            Console.WriteLine($"\n=== {scenario.Name} ===");
            var solution = new Solution();
            var root = BuildTree(scenario.Values);
            var methods = typeof(Solution)
                .GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.DeclaredOnly)
                .Where(m => !m.IsSpecialName)
                .Where(m => m.GetParameters().Length == 1)
                .Where(m => m.GetParameters()[0].ParameterType == typeof(TreeNode))
                .Where(m => m.ReturnType == typeof(bool))
                .OrderBy(m => m.Name)
                .ToArray();

            foreach (var method in methods)
            {
                var sw = Stopwatch.StartNew();
                object? result = null; Exception? ex = null;
                try { result = method.Invoke(method.IsStatic ? null : solution, new object?[] { root }); }
                catch (Exception e) { ex = e; } finally { sw.Stop(); }
                Console.Write($"{method.Name} | {sw.Elapsed.TotalMilliseconds:0.0000} ms | ");
                if (ex != null) { Console.WriteLine($"ERROR: {ex.GetBaseException().Message}"); continue; }
                var actual = result?.ToString() ?? "null";
                var expected = scenario.Expected.ToString();
                Console.WriteLine($"{actual} | Expected {expected} | {(actual == expected ? "\u2705 PASS" : "\u274c FAIL")}");
            }
        }

        private static TreeNode? BuildTree(int?[] values)
        {
            if (values.Length == 0 || !values[0].HasValue) return null;
            var root = new TreeNode(values[0]!.Value);
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int i = 1;
            while (queue.Count > 0 && i < values.Length)
            {
                var node = queue.Dequeue();
                if (i < values.Length) { if (values[i].HasValue) { node.left = new TreeNode(values[i]!.Value); queue.Enqueue(node.left); } i++; }
                if (i < values.Length) { if (values[i].HasValue) { node.right = new TreeNode(values[i]!.Value); queue.Enqueue(node.right); } i++; }
            }
            return root;
        }

        private sealed record Scenario(string Name, int?[] Values, bool Expected);
    }
}