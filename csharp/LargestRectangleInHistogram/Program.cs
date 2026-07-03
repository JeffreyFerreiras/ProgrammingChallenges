using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace LargestRectangleInHistogram;

internal class Program
{
    private static void Main(string[] args)
    {
        var scenarios = new[]
        {
            new Scenario("Example 1 - [2,1,5,6,2,3]", new int[] { 2,1,5,6,2,3 }, 10),
            new Scenario("Example 2 - [2,4]",           new int[] { 2,4 },          4),
            new Scenario("Single bar [5]",               new int[] { 5 },             5),
            new Scenario("Increasing [1,2,3,4,5]",       new int[] { 1,2,3,4,5 },    9),
            new Scenario("Decreasing [5,4,3,2,1]",       new int[] { 5,4,3,2,1 },    9),
            new Scenario("With zeros [0,1,0,1]",          new int[] { 0,1,0,1 },      1),
            new Scenario("All zeros",                     new int[] { 0,0,0 },         0),
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
            .Where(m => m.ReturnType == typeof(int))
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

            var actual   = result!.ToString()!;
            var expected = scenario.Expected.ToString();
            Console.WriteLine($"{actual} | Expected {expected} | {(actual == expected ? "✅ PASS" : "❌ FAIL")}");
        }
    }

    private sealed record Scenario(string Name, int[] Input, int Expected);
}
