// LeetCode 338 - Counting Bits
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace CountingBits
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var scenarios = new[]
            {
                new Scenario("Example 1", 2, "0,1,1"),
                new Scenario("Example 2", 5, "0,1,1,2,1,2"),
                new Scenario("Edge: Zero", 0, "0"),
                new Scenario("Eight", 8, "0,1,1,2,1,2,2,3,1"),
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
                .Where(m => m.GetParameters()[0].ParameterType == typeof(int))
                .Where(m => m.ReturnType == typeof(int[]))
                .OrderBy(m => m.Name)
                .ToArray();

            foreach (var method in methods)
            {
                var sw = Stopwatch.StartNew();
                object? result = null; Exception? ex = null;
                try { result = method.Invoke(method.IsStatic ? null : solution, new object?[] { scenario.N }); }
                catch (Exception e) { ex = e; } finally { sw.Stop(); }
                Console.Write($"{method.Name} | {sw.Elapsed.TotalMilliseconds:0.0000} ms | ");
                if (ex != null) { Console.WriteLine($"ERROR: {ex.GetBaseException().Message}"); continue; }
                var actual = result is int[] arr ? string.Join(",", arr) : result?.ToString() ?? "null";
                Console.WriteLine($"{actual} | Expected {scenario.Expected} | {(actual == scenario.Expected ? "\u2705 PASS" : "\u274c FAIL")}");
            }
        }

        private sealed record Scenario(string Name, int N, string Expected);
    }
}
