using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace IslandTreasure;

internal class Program
{
    private const int INF = int.MaxValue;

    private static void Main(string[] args)
    {
        var scenarios = new[]
        {
            new Scenario("Example 1",
                new int[][] { new[]{INF,-1,0,INF}, new[]{INF,INF,INF,-1}, new[]{INF,-1,INF,-1}, new[]{0,-1,INF,INF} },
                new int[][] { new[]{3,-1,0,1},      new[]{2,2,1,-1},       new[]{1,-1,2,-1},      new[]{0,-1,3,4} }),
            new Scenario("Example 2",
                new int[][] { new[]{0,-1}, new[]{INF,INF} },
                new int[][] { new[]{0,-1}, new[]{1,2} }),
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
            .Where(m => m.ReturnType == typeof(void))
            .OrderBy(m => m.Name)
            .ToArray();

        foreach (var method in methods)
        {
            var gridCopy = scenario.Grid.Select(r => (int[])r.Clone()).ToArray();
            var stopwatch = Stopwatch.StartNew();
            Exception? exception = null;

            try
            {
                method.Invoke(solution, new object?[] { gridCopy });
            }
            catch (Exception ex) { exception = ex; }
            finally { stopwatch.Stop(); }

            Console.Write($"{method.Name} | {stopwatch.Elapsed.TotalMilliseconds:0.0000} ms | ");

            if (exception != null)
            {
                Console.WriteLine($"ERROR: {exception.GetBaseException().Message}");
                continue;
            }

            var actual   = FormatGrid(gridCopy);
            var expected = FormatGrid(scenario.Expected);
            Console.WriteLine($"{actual} | Expected {expected} | {(actual == expected ? "✅ PASS" : "❌ FAIL")}");
        }
    }

    private static string FormatGrid(int[][] grid) =>
        "[" + string.Join(",", grid.Select(row => "[" + string.Join(",", row) + "]")) + "]";

    private sealed record Scenario(string Name, int[][] Grid, int[][] Expected);
}
