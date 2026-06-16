using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace WordSearchII
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var scenarios = new[]
            {
                new Scenario(
                    "Scenario 1 - Classic example",
                    new[]
                    {
                        new[] { 'o', 'a', 'a', 'n' },
                        new[] { 'e', 't', 'a', 'e' },
                        new[] { 'i', 'h', 'k', 'r' },
                        new[] { 'i', 'f', 'l', 'v' }
                    },
                    new[] { "oath", "pea", "eat", "rain" },
                    new[] { "eat", "oath" }),
                new Scenario(
                    "Scenario 2 - Empty search set",
                    new[]
                    {
                        new[] { 'a', 'b' },
                        new[] { 'c', 'd' }
                    },
                    Array.Empty<string>(),
                    Array.Empty<string>()),
                new Scenario(
                    "Scenario 3 - No matching words",
                    new[]
                    {
                        new[] { 'a', 'b' },
                        new[] { 'c', 'd' }
                    },
                    new[] { "zz" },
                    Array.Empty<string>())
            };

            foreach (var scenario in scenarios)
            {
                RunScenario(scenario);
            }

            Console.WriteLine();
        }

        private static void RunScenario(Scenario scenario)
        {
            Console.WriteLine($"\n=== {scenario.Name} ===");
            Console.WriteLine($"Board rows: {scenario.Board.Length}");
            Console.WriteLine($"Words: {string.Join(", ", scenario.Words)}");

            var solution = new Solution();
            var methods = typeof(Solution)
                .GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly)
                .Where(method => !method.IsSpecialName)
                .Where(method => method.GetParameters().Length == 2)
                .Where(method => method.GetParameters()[0].ParameterType == typeof(char[][]))
                .Where(method => method.GetParameters()[1].ParameterType == typeof(string[]))
                .Where(method => method.ReturnType == typeof(IList<string>))
                .OrderBy(method => method.Name)
                .ToArray();

            foreach (var method in methods)
            {
                var stopwatch = Stopwatch.StartNew();
                object? result = null;
                Exception? exception = null;

                try
                {
                    result = method.Invoke(solution, new object?[] { scenario.Board, scenario.Words });
                }
                catch (Exception ex)
                {
                    exception = ex;
                }
                finally
                {
                    stopwatch.Stop();
                }

                var elapsedMilliseconds = stopwatch.Elapsed.TotalMilliseconds;
                Console.Write($"{method.Name} | {elapsedMilliseconds:0.0000} ms | ");

                if (exception != null)
                {
                    Console.WriteLine($"ERROR: {exception.GetBaseException().Message}");
                    continue;
                }

                var actualWords = ((IEnumerable<string>?)result ?? Array.Empty<string>())
                    .Where(word => !string.IsNullOrWhiteSpace(word))
                    .OrderBy(word => word)
                    .ToArray();

                var expectedWords = scenario.ExpectedWords
                    .OrderBy(word => word)
                    .ToArray();

                var passed = actualWords.SequenceEqual(expectedWords);
                Console.WriteLine($"{string.Join(", ", actualWords)} | Expected {string.Join(", ", expectedWords)} | {(passed ? "✅ PASS" : "❌ FAIL")}");
            }
        }

        private sealed record Scenario(string Name, char[][] Board, string[] Words, string[] ExpectedWords);
    }
}
