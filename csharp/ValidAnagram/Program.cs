// LeetCode 242 - Valid Anagram
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace ValidAnagram
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var scenarios = new[]
            {
                new Scenario("Example 1", "anagram", "nagaram", true),
                new Scenario("Example 2", "rat", "car", false),
                new Scenario("Empty strings", "", "", true),
                new Scenario("Different lengths", "ab", "a", false),
                new Scenario("Same chars different freq", "aaab", "aab", false),
            };
            foreach (var scenario in scenarios) RunScenario(scenario);
            Console.WriteLine();
        }
        private static void RunScenario(Scenario scenario)
        {
            Console.WriteLine($"\n=== {scenario.Name} ===");
            var solution = new Solution();
            var methods = typeof(Solution).GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.DeclaredOnly)
                .Where(m => !m.IsSpecialName).Where(m => m.GetParameters().Length == 2)
                .Where(m => m.GetParameters()[0].ParameterType == typeof(string))
                .Where(m => m.GetParameters()[1].ParameterType == typeof(string))
                .Where(m => m.ReturnType == typeof(bool)).OrderBy(m => m.Name).ToArray();
            foreach (var method in methods)
            {
                var sw = Stopwatch.StartNew(); object? result = null; Exception? ex = null;
                try { result = method.Invoke(method.IsStatic ? null : solution, new object?[] { scenario.S, scenario.T }); }
                catch (Exception e) { ex = e; } finally { sw.Stop(); }
                Console.Write($"{method.Name} | {sw.Elapsed.TotalMilliseconds:0.0000} ms | ");
                if (ex != null) { Console.WriteLine($"ERROR: {ex.GetBaseException().Message}"); continue; }
                var actual = result?.ToString() ?? "null"; var expected = scenario.Expected.ToString();
                Console.WriteLine($"{actual} | Expected {expected} | {(actual == expected ? "\u2705 PASS" : "\u274c FAIL")}");
            }
        }
        private sealed record Scenario(string Name, string S, string T, bool Expected);
    }
}