// LeetCode 438 - Find All Anagrams in a String
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace FindAllAnagramsInAString
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var scenarios = new[]
            {
                new Scenario("Example 1", "cbaebabacd", "abc", "0,6"),
                new Scenario("Example 2", "abab", "ab", "0,1,2"),
                new Scenario("Edge: No Match", "a", "b", ""),
                new Scenario("Edge: Identical", "a", "a", "0"),
                new Scenario("Repeated Characters", "baa", "aa", "1"),
                new Scenario("Long Example", "aaaaaaaaabaaaaaaaaa", "aaab", "6,7,8,9"),
                new Scenario("No Match Extended", "abcdefg", "hij", ""),
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
                .Where(m => m.GetParameters()[0].ParameterType == typeof(string))
                .Where(m => m.GetParameters()[1].ParameterType == typeof(string))
                .Where(m => typeof(IList<int>).IsAssignableFrom(m.ReturnType))
                .OrderBy(m => m.Name)
                .ToArray();

            foreach (var method in methods)
            {
                var sw = Stopwatch.StartNew();
                object? result = null; Exception? ex = null;
                try { result = method.Invoke(method.IsStatic ? null : solution, new object?[] { scenario.S, scenario.P }); }
                catch (Exception e) { ex = e; } finally { sw.Stop(); }
                Console.Write($"{method.Name} | {sw.Elapsed.TotalMilliseconds:0.0000} ms | ");
                if (ex != null) { Console.WriteLine($"ERROR: {ex.GetBaseException().Message}"); continue; }
                var actual = result is IList<int> list ? string.Join(",", list) : result?.ToString() ?? "null";
                Console.WriteLine($"{actual} | Expected {scenario.Expected} | {(actual == scenario.Expected ? "\u2705 PASS" : "\u274c FAIL")}");
            }
        }

        private sealed record Scenario(string Name, string S, string P, string Expected);
    }
}