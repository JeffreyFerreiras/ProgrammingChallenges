// LeetCode 53 - Maximum Subarray
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace MaximumSubarray
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var scenarios = new[]
            {
                new Scenario("Example 1", new[] { -2,1,-3,4,-1,2,1,-5,4 }, 6),
                new Scenario("Example 2", new[] { 1 }, 1),
                new Scenario("All Negative", new[] { -2,-1 }, -1),
                new Scenario("All Positive", new[] { 1,2,3,4 }, 10),
                new Scenario("Mixed", new[] { 5,4,-1,7,8 }, 23),
            };
            foreach (var scenario in scenarios) RunScenario(scenario);
            Console.WriteLine();
        }
        private static void RunScenario(Scenario scenario)
        {
            Console.WriteLine($"\n=== {scenario.Name} ===");
            var solution = new Solution();
            var methods = typeof(Solution).GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.DeclaredOnly)
                .Where(m => !m.IsSpecialName)
                .Where(m => m.GetParameters().Length == 1)
                .Where(m => m.GetParameters()[0].ParameterType == typeof(int[]))
                .Where(m => m.ReturnType == typeof(int))
                .OrderBy(m => m.Name).ToArray();
            foreach (var method in methods)
            {
                var inputCopy = (int[])scenario.Nums.Clone();
                var sw = Stopwatch.StartNew(); object? result = null; Exception? ex = null;
                try { result = method.Invoke(method.IsStatic ? null : solution, new object?[] { inputCopy }); }
                catch (Exception e) { ex = e; } finally { sw.Stop(); }
                Console.Write($"{method.Name} | {sw.Elapsed.TotalMilliseconds:0.0000} ms | ");
                if (ex != null) { Console.WriteLine($"ERROR: {ex.GetBaseException().Message}"); continue; }
                var actual = result?.ToString() ?? "null"; var expected = scenario.Expected.ToString();
                Console.WriteLine($"{actual} | Expected {expected} | {(actual == expected ? "\u2705 PASS" : "\u274c FAIL")}");
            }
        }
        private sealed record Scenario(string Name, int[] Nums, int Expected);
    }
}