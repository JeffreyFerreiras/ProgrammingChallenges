// LeetCode 704 - Binary Search
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace BinarySearch
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var scenarios = new[]
            {
                new Scenario("Example 1", new[] { -1, 0, 3, 5, 9, 12 }, 9, 4),
                new Scenario("Target Missing", new[] { -1, 0, 3, 5, 9, 12 }, 2, -1),
                new Scenario("Single Element Hit", new[] { 5 }, 5, 0),
                new Scenario("Single Element Miss", new[] { 5 }, -5, -1),
                new Scenario("Negative Numbers", new[] { -15, -9, -4, 0, 12, 18, 27 }, -4, 2),
                new Scenario("Sorted Array", Enumerable.Range(-100_000, 200_001).ToArray(), 54_321, 154_321),
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
                var sw = Stopwatch.StartNew();
                object? result = null; Exception? ex = null;
                try { result = method.Invoke(method.IsStatic ? null : solution, new object?[] { scenario.Numbers, scenario.Target }); }
                catch (Exception e) { ex = e; } finally { sw.Stop(); }
                Console.Write($"{method.Name} | {sw.Elapsed.TotalMilliseconds:0.0000} ms | ");
                if (ex != null) { Console.WriteLine($"ERROR: {ex.GetBaseException().Message}"); continue; }
                var actual = result?.ToString() ?? "null";
                var expected = scenario.Expected.ToString();
                Console.WriteLine($"{actual} | Expected {expected} | {(actual == expected ? "\u2705 PASS" : "\u274c FAIL")}");
            }
        }

        private sealed record Scenario(string Name, int[] Numbers, int Target, int Expected);
    }
}