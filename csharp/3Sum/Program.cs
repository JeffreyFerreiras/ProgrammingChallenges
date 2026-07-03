using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace _3Sum;

internal class Program
{
    private static void Main(string[] args)
    {
        var scenarios = new[]
        {
            new Scenario("Example 1 - [-1,0,1,2,-1,-4]", new int[] { -1,0,1,2,-1,-4 },       "[[-1,-1,2],[-1,0,1]]"),
            new Scenario("All zeros",                      new int[] { 0,0,0 },                 "[[0,0,0]]"),
            new Scenario("Empty",                          new int[] { },                        "[]"),
            new Scenario("No triplet",                     new int[] { 1,2,3 },                  "[]"),
        };

        foreach (var scenario in scenarios)
            RunScenario(scenario);

        Console.WriteLine();
    }

    private static void RunScenario(Scenario scenario)
    {
        Console.WriteLine($"\n=== {scenario.Name} ===");

        var methods = typeof(Solution)
            .GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.DeclaredOnly)
            .Where(m => !m.IsSpecialName)
            .Where(m => m.GetParameters().Length == 1)
            .Where(m => m.GetParameters()[0].ParameterType == typeof(int[]))
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
                result = method.Invoke(null, new object?[] { (int[])scenario.Input.Clone() });
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

    private sealed record Scenario(string Name, int[] Input, string Expected);
}
