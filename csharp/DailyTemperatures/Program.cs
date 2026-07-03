using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace DailyTemperatures;

internal class Program
{
    private static void Main(string[] args)
    {
        var scenarios = new[]
        {
            new Scenario("Example 1", new int[] { 73,74,75,71,69,72,76,73 }, new int[] { 1,1,4,2,1,1,0,0 }),
            new Scenario("Example 2", new int[] { 30,40,50,60 },              new int[] { 1,1,1,0 }),
            new Scenario("Example 3", new int[] { 30,60,90 },                 new int[] { 1,1,0 }),
            new Scenario("Single",    new int[] { 100 },                       new int[] { 0 }),
            new Scenario("All equal", new int[] { 50,50,50 },                  new int[] { 0,0,0 }),
            new Scenario("Descend",   new int[] { 80,70,60,50 },               new int[] { 0,0,0,0 }),
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
            .Where(m => m.ReturnType == typeof(int[]))
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

            var actual   = string.Join(",", (int[])result!);
            var expected = string.Join(",", scenario.Expected);
            Console.WriteLine($"{actual} | Expected {expected} | {(actual == expected ? "✅ PASS" : "❌ FAIL")}");
        }
    }

    private sealed record Scenario(string Name, int[] Input, int[] Expected);
}
