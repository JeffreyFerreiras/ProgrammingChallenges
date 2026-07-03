using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace CombinationSum;

internal class Program
{
    private static void Main(string[] args)
    {
        var scenarios = new[]
        {
            new Scenario("[2,3,6,7] t=7", new int[]{2,3,6,7}, 7, "[[2,2,3],[7]]"),
            new Scenario("[2,3,5] t=8",   new int[]{2,3,5},   8, "[[2,2,2,2],[2,3,3],[3,5]]"),
            new Scenario("[2] t=1",        new int[]{2},        1, "[]"),
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
            .Where(m => m.GetParameters()[0].ParameterType == typeof(int[]))
            .Where(m => m.GetParameters()[1].ParameterType == typeof(int))
            .Where(m => m.ReturnType == typeof(IList<IList<int>>))
            .OrderBy(m => m.Name)
            .ToArray();

        foreach (var method in methods)
        {
            var stopwatch = Stopwatch.StartNew();
            object? result = null;
            Exception? exception = null;

            try
            {
                result = method.Invoke(solution, new object?[] { (int[])scenario.Candidates.Clone(), scenario.Target });
            }
            catch (Exception ex) { exception = ex; }
            finally { stopwatch.Stop(); }

            Console.Write($"{method.Name} | {stopwatch.Elapsed.TotalMilliseconds:0.0000} ms | ");

            if (exception != null)
            {
                Console.WriteLine($"ERROR: {exception.GetBaseException().Message}");
                continue;
            }

            var actual = FormatResult((IList<IList<int>>)result!);
            Console.WriteLine($"{actual} | Expected {scenario.Expected} | {(actual == scenario.Expected ? "✅ PASS" : "❌ FAIL")}");
        }
    }

    private static string FormatResult(IList<IList<int>> lists) =>
        "[" + string.Join(",", lists
            .Select(inner => "[" + string.Join(",", inner.OrderBy(x => x)) + "]")
            .OrderBy(s => s)) + "]";

    private sealed record Scenario(string Name, int[] Candidates, int Target, string Expected);
}
