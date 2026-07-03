// Add One to a number represented as an array of digits
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace AddOne
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var scenarios = new[]
            {
                new Scenario("Standard carry", new[] { 1, 3, 2, 4 }, "1,3,2,5"),
                new Scenario("Single carry", new[] { 5, 4, 8, 9 }, "5,4,9,0"),
                new Scenario("Multiple carries", new[] { 9, 8, 9, 9 }, "9,9,0,0"),
                new Scenario("Empty array", new int[] { }, "1"),
                new Scenario("All nines", new[] { 9, 9, 9, 9 }, "1,0,0,0,0"),
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
                .Where(m => m.ReturnType == typeof(int[]))
                .OrderBy(m => m.Name)
                .ToArray();

            foreach (var method in methods)
            {
                var inputCopy = (int[])scenario.Digits.Clone();
                var sw = Stopwatch.StartNew();
                object? result = null; Exception? ex = null;
                try { result = method.Invoke(method.IsStatic ? null : solution, new object?[] { inputCopy }); }
                catch (Exception e) { ex = e; } finally { sw.Stop(); }
                Console.Write($"{method.Name} | {sw.Elapsed.TotalMilliseconds:0.0000} ms | ");
                if (ex != null) { Console.WriteLine($"ERROR: {ex.GetBaseException().Message}"); continue; }
                var actual = result is int[] arr ? string.Join(",", arr) : result?.ToString() ?? "null";
                Console.WriteLine($"{actual} | Expected {scenario.Expected} | {(actual == scenario.Expected ? "\u2705 PASS" : "\u274c FAIL")}");
            }
        }

        private sealed record Scenario(string Name, int[] Digits, string Expected);
    }
}
