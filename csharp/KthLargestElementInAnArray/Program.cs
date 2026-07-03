// LeetCode 215 - Kth Largest Element in an Array
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace KthLargestElementInAnArray
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var scenarios = new[]
            {
                new Scenario("Example 1", new[] { 3, 2, 1, 5, 6, 4 }, 2, 5),
                new Scenario("Example 2", new[] { 3, 2, 3, 1, 2, 4, 5, 5, 6 }, 4, 4),
                new Scenario("All Identical", Enumerable.Repeat(7, 8).ToArray(), 3, 7),
                new Scenario("Kth is min", new[] { 5, 3, 1, 2, 4 }, 5, 1),
                new Scenario("Two elements", new[] { 1, 2 }, 1, 2),
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
                .GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.DeclaredOnly)
                .Where(m => !m.IsSpecialName)
                .Where(m => m.GetParameters().Length == 2)
                .Where(m => m.GetParameters()[0].ParameterType == typeof(int[]))
                .Where(m => m.GetParameters()[1].ParameterType == typeof(int))
                .Where(m => m.ReturnType == typeof(int))
                .OrderBy(m => m.Name)
                .ToArray();

            foreach (var method in methods)
            {
                var inputCopy = (int[])scenario.Numbers.Clone();
                var sw = Stopwatch.StartNew();
                object? result = null; Exception? ex = null;
                try { result = method.Invoke(method.IsStatic ? null : solution, new object?[] { inputCopy, scenario.K }); }
                catch (Exception e) { ex = e; } finally { sw.Stop(); }
                Console.Write($"{method.Name} | {sw.Elapsed.TotalMilliseconds:0.0000} ms | ");
                if (ex != null) { Console.WriteLine($"ERROR: {ex.GetBaseException().Message}"); continue; }
                var actual = result?.ToString() ?? "null";
                var expected = scenario.Expected.ToString();
                Console.WriteLine($"{actual} | Expected {expected} | {(actual == expected ? "\u2705 PASS" : "\u274c FAIL")}");
            }
        }

        private sealed record Scenario(string Name, int[] Numbers, int K, int Expected);
    }
}