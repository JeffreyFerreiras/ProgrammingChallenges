using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace PacificAtlanticWaterFlow;

internal class Program
{
    private static void Main(string[] args)
    {
        var scenarios = new[]
        {
            new Scenario("Example 1 5x5", new int[][]
            {
                new[]{1,2,2,3,5}, new[]{3,2,3,4,4},
                new[]{2,4,5,3,1}, new[]{6,7,1,4,5}, new[]{5,1,1,2,4}
            }, "[[0,4],[1,3],[1,4],[2,2],[3,0],[3,1],[4,0]]"),
            new Scenario("Example 2 2x2", new int[][]
            {
                new[]{2,1}, new[]{1,2}
            }, "[[0,0],[0,1],[1,0],[1,1]]"),
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
            .GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly)
            .Where(m => !m.IsSpecialName)
            .Where(m => m.GetParameters().Length == 1)
            .Where(m => m.GetParameters()[0].ParameterType == typeof(int[][]))
            .Where(m => m.ReturnType == typeof(IList<IList<int>>))
            .OrderBy(m => m.Name)
            .ToArray();

        foreach (var method in methods)
        {
            var gridCopy = scenario.Heights.Select(r => (int[])r.Clone()).ToArray();
            var stopwatch = Stopwatch.StartNew();
            object? result = null;
            Exception? exception = null;

            try
            {
                result = method.Invoke(solution, new object?[] { gridCopy });
            }
            catch (Exception ex) { exception = ex; }
            finally { stopwatch.Stop(); }

            Console.Write($"{method.Name} | {stopwatch.Elapsed.TotalMilliseconds:0.0000} ms | ");

            if (exception != null)
            {
                Console.WriteLine($"ERROR: {exception.GetBaseException().Message}");
                continue;
            }

            var actual = FormatCoords((IList<IList<int>>)result!);
            Console.WriteLine($"{actual} | Expected {scenario.Expected} | {(actual == scenario.Expected ? "✅ PASS" : "❌ FAIL")}");
        }
    }

    private static string FormatCoords(IList<IList<int>> coords) =>
        "[" + string.Join(",", coords
            .OrderBy(c => c[0]).ThenBy(c => c[1])
            .Select(c => "[" + string.Join(",", c) + "]")) + "]";

    private sealed record Scenario(string Name, int[][] Heights, string Expected);
}
