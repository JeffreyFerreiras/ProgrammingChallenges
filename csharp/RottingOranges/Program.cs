using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace RottingOranges;

internal class Program
{
    private static void Main(string[] args)
    {
        var scenarios = new[]
        {
            new Scenario("Example 1 [[2,1,1],[1,1,0],[0,1,1]]", new int[][] { new[]{2,1,1}, new[]{1,1,0}, new[]{0,1,1} }, 4),
            new Scenario("Example 2 [[2,1,1],[0,1,1],[1,0,1]]", new int[][] { new[]{2,1,1}, new[]{0,1,1}, new[]{1,0,1} }, -1),
            new Scenario("Example 3 [[0,2]]",                   new int[][] { new[]{0,2} },                               0),
            new Scenario("Only empty [[0]]",                     new int[][] { new[]{0} },                                 0),
            new Scenario("No rotten [[1,1],[1,1]]",              new int[][] { new[]{1,1}, new[]{1,1} },                  -1),
            new Scenario("All rotten [[2,2],[2,2]]",             new int[][] { new[]{2,2}, new[]{2,2} },                   0),
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
            .Where(m => m.ReturnType == typeof(int))
            .OrderBy(m => m.Name)
            .ToArray();

        foreach (var method in methods)
        {
            var gridCopy = scenario.Grid.Select(r => (int[])r.Clone()).ToArray();
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

            var actual   = result!.ToString()!;
            var expected = scenario.Expected.ToString();
            Console.WriteLine($"{actual} | Expected {expected} | {(actual == expected ? "✅ PASS" : "❌ FAIL")}");
        }
    }

    private sealed record Scenario(string Name, int[][] Grid, int Expected);
}
