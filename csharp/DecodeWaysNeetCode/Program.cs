// LeetCode 91 - Decode Ways
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace DecodeWaysNeetCode
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var scenarios = new[]
            {
                new Scenario("Example 1", "12", 2),
                new Scenario("Example 2", "226", 3),
                new Scenario("Example 3", "06", 0),
                new Scenario("Edge: Zero", "0", 0),
                new Scenario("Single Digit", "7", 1),
                new Scenario("Long String", "1111111111", 89),
                new Scenario("Zeros Inside", "1010", 1),
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
                .Where(m => m.GetParameters()[0].ParameterType == typeof(string))
                .Where(m => m.ReturnType == typeof(int))
                .OrderBy(m => m.Name)
                .ToArray();

            foreach (var method in methods)
            {
                var sw = Stopwatch.StartNew();
                object? result = null; Exception? ex = null;
                try { result = method.Invoke(method.IsStatic ? null : solution, new object?[] { scenario.S }); }
                catch (Exception e) { ex = e; } finally { sw.Stop(); }
                Console.Write($"{method.Name} | {sw.Elapsed.TotalMilliseconds:0.0000} ms | ");
                if (ex != null) { Console.WriteLine($"ERROR: {ex.GetBaseException().Message}"); continue; }
                var actual = result?.ToString() ?? "null";
                var expected = scenario.Expected.ToString();
                Console.WriteLine($"{actual} | Expected {expected} | {(actual == expected ? "\u2705 PASS" : "\u274c FAIL")}");
            }
        }

        private sealed record Scenario(string Name, string S, int Expected);
    }
}
