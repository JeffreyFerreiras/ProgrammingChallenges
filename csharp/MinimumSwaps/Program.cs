// Minimum Swaps - sliding window
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace MinimumSwaps
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var scenarios = new[]
            {
                new Scenario("Example 1", new[] { 1,0,1,0,1 }, 1),
                new Scenario("Example 2", new[] { 0,0,0,1,0 }, 0),
                new Scenario("Example 3", new[] { 1,0,1,0,1,0,0,1,1,0,1 }, 3),
                new Scenario("All ones", new[] { 1,1,1 }, 0),
            };
            foreach (var scenario in scenarios) RunScenario(scenario);
            Console.WriteLine();
        }
        private static void RunScenario(Scenario scenario)
        {
            Console.WriteLine($"\n=== {scenario.Name} ===");
            var solution = new Solution();
            var methods = typeof(Solution).GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.DeclaredOnly)
                .Where(m => !m.IsSpecialName).Where(m => m.GetParameters().Length == 1)
                .Where(m => m.GetParameters()[0].ParameterType == typeof(int[])).Where(m => m.ReturnType == typeof(int))
                .OrderBy(m => m.Name).ToArray();
            foreach (var method in methods)
            {
                var sw = Stopwatch.StartNew(); object? result = null; Exception? ex = null;
                try { result = method.Invoke(method.IsStatic ? null : solution, new object?[] { scenario.Data }); }
                catch (Exception e) { ex = e; } finally { sw.Stop(); }
                Console.Write($"{method.Name} | {sw.Elapsed.TotalMilliseconds:0.0000} ms | ");
                if (ex != null) { Console.WriteLine($"ERROR: {ex.GetBaseException().Message}"); continue; }
                var actual = result?.ToString() ?? "null"; var expected = scenario.Expected.ToString();
                Console.WriteLine($"{actual} | Expected {expected} | {(actual == expected ? "\u2705 PASS" : "\u274c FAIL")}");
            }
        }
        private sealed record Scenario(string Name, int[] Data, int Expected);
    }
}