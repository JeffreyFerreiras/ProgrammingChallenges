using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace KClosestPointsToOrigin;

internal class Program
{
    private static void Main(string[] args)
    {
        var scenarios = new[]
        {
            new Scenario("Example 1 k=1", new int[][] { new[]{1,3}, new[]{-2,2} },           1, "[[-2,2]]"),
            new Scenario("Example 2 k=2", new int[][] { new[]{3,3}, new[]{5,-1}, new[]{-2,4} }, 2, "[[-2,4],[3,3]]"),
            new Scenario("K=all",         new int[][] { new[]{1,0}, new[]{2,0}, new[]{3,0} }, 3, "[[1,0],[2,0],[3,0]]"),
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
            .Where(m => m.GetParameters().Length == 2)
            .Where(m => m.GetParameters()[0].ParameterType == typeof(int[][]))
            .Where(m => m.GetParameters()[1].ParameterType == typeof(int))
            .Where(m => m.ReturnType == typeof(int[][]))
            .OrderBy(m => m.Name)
            .ToArray();

        foreach (var method in methods)
        {
            var pointsCopy = scenario.Points.Select(r => (int[])r.Clone()).ToArray();
            var stopwatch = Stopwatch.StartNew();
            object? result = null;
            Exception? exception = null;

            try
            {
                result = method.Invoke(solution, new object?[] { pointsCopy, scenario.K });
            }
            catch (Exception ex) { exception = ex; }
            finally { stopwatch.Stop(); }

            Console.Write($"{method.Name} | {stopwatch.Elapsed.TotalMilliseconds:0.0000} ms | ");

            if (exception != null)
            {
                Console.WriteLine($"ERROR: {exception.GetBaseException().Message}");
                continue;
            }

            var actual = FormatPoints((int[][])result!);
            Console.WriteLine($"{actual} | Expected {scenario.Expected} | {(actual == scenario.Expected ? "✅ PASS" : "❌ FAIL")}");
        }
    }

    private static string FormatPoints(int[][] pts) =>
        "[" + string.Join(",", pts
            .Select(p => "[" + string.Join(",", p) + "]")
            .OrderBy(s => s)) + "]";

    private sealed record Scenario(string Name, int[][] Points, int K, string Expected);
}
