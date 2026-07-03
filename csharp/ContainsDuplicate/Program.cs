// LeetCode 217 - Contains Duplicate
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace ContainsDuplicate
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var scenarios = new[]
            {
                new Scenario("Has duplicate\u2014adjacent", new[] { 1, 1, 2, 3 }, true),
                new Scenario("Has duplicate\u2014non-adjacent", new[] { 1, 2, 3, 1 }, true),
                new Scenario("No duplicate", new[] { 1, 2, 3, 4 }, false),
                new Scenario("Single element", new[] { 42 }, false),
                new Scenario("All same", new[] { 7, 7, 7 }, true),
                new Scenario("Large no-dup", Enumerable.Range(1, 1000).ToArray(), false),
                new Scenario("Large dup-at-end", Enumerable.Range(1, 999).Append(500).ToArray(), true),
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
                .Where(m => m.GetParameters().Length == 1)
                .Where(m => m.GetParameters()[0].ParameterType == typeof(int[]))
                .Where(m => m.ReturnType == typeof(bool))
                .OrderBy(m => m.Name)
                .ToArray();

            foreach (var method in methods)
            {
                var inputCopy = (int[])scenario.Nums.Clone();
                var sw = Stopwatch.StartNew();
                object? result = null; Exception? ex = null;
                try { result = method.Invoke(method.IsStatic ? null : solution, new object?[] { inputCopy }); }
                catch (Exception e) { ex = e; } finally { sw.Stop(); }
                Console.Write($"{method.Name} | {sw.Elapsed.TotalMilliseconds:0.0000} ms | ");
                if (ex != null) { Console.WriteLine($"ERROR: {ex.GetBaseException().Message}"); continue; }
                var actual = result?.ToString() ?? "null";
                var expected = scenario.Expected.ToString();
                Console.WriteLine($"{actual} | Expected {expected} | {(actual == expected ? "\u2705 PASS" : "\u274c FAIL")}");
            }
        }

        private sealed record Scenario(string Name, int[] Nums, bool Expected);
    }
}