// LeetCode #200 - Number of Islands
// Given an m x n 2D binary grid of '1's (land) and '0's (water), return the number of islands.

using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace NumberOfIslands
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var scenarios = new[]
            {
                new Scenario(
                    "Scenario 1 - Single island",
                    [
                        "11110".ToCharArray(),
                        "11010".ToCharArray(),
                        "11000".ToCharArray(),
                        "00000".ToCharArray()
                    ],
                    1),
                new Scenario(
                    "Scenario 2 - Three islands",
                    [
                        "11000".ToCharArray(),
                        "11000".ToCharArray(),
                        "00100".ToCharArray(),
                        "00011".ToCharArray()
                    ],
                    3),
                new Scenario(
                    "Scenario 3 - 16 islands (4 repeating blocks separated by water rows)",
                    [
                        "11110111101111011110".ToCharArray(),
                        "11010110101101011010".ToCharArray(),
                        "11000110001100011000".ToCharArray(),
                        "00000000000000000000".ToCharArray(),
                        "11110111101111011110".ToCharArray(),
                        "11010110101101011010".ToCharArray(),
                        "11000110001100011000".ToCharArray(),
                        "00000000000000000000".ToCharArray(),
                        "11110111101111011110".ToCharArray(),
                        "11010110101101011010".ToCharArray(),
                        "11000110001100011000".ToCharArray(),
                        "00000000000000000000".ToCharArray(),
                        "11110111101111011110".ToCharArray(),
                        "11010110101101011010".ToCharArray(),
                        "11000110001100011000".ToCharArray(),
                        "00000000000000000000".ToCharArray()
                    ],
                    16),
            };

            foreach (var scenario in scenarios)
                RunScenario(scenario);

            Console.WriteLine();
        }

        private static void RunScenario(Scenario scenario)
        {
            Console.WriteLine($"\n=== {scenario.Name} ===");
            Console.WriteLine($"Grid: {scenario.Grid.Length}x{scenario.Grid[0].Length}");

            var solution = new Solution();
            var methods = typeof(Solution)
                .GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly)
                .Where(m => !m.IsSpecialName)
                .Where(m => m.GetParameters().Length == 1)
                .Where(m => m.GetParameters()[0].ParameterType == typeof(char[][]))
                .Where(m => m.ReturnType == typeof(int))
                .OrderBy(m => m.Name)
                .ToArray();

            foreach (var method in methods)
            {
                // Deep-copy the grid: DFS/BFS mutates cells to '0' during traversal
                var gridCopy = scenario.Grid.Select(row => (char[])row.Clone()).ToArray();

                var stopwatch = Stopwatch.StartNew();
                object? result = null;
                Exception? exception = null;

                try
                {
                    result = method.Invoke(solution, new object?[] { gridCopy });
                }
                catch (Exception ex)
                {
                    exception = ex;
                }
                finally
                {
                    stopwatch.Stop();
                }

                var elapsed = stopwatch.Elapsed.TotalMilliseconds;
                Console.Write($"{method.Name} | {elapsed:0.0000} ms | ");

                if (exception != null)
                {
                    Console.WriteLine($"ERROR: {exception.GetBaseException().Message}");
                    continue;
                }

                var actual   = result?.ToString() ?? "null";
                var expected = scenario.Expected.ToString();
                var passed   = actual == expected;
                Console.WriteLine($"{actual} | Expected {expected} | {(passed ? "✅ PASS" : "❌ FAIL")}");
            }
        }

        private sealed record Scenario(string Name, char[][] Grid, int Expected);
    }
}