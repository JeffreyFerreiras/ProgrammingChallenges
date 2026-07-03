using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace AsteroidCollision;

internal class Program
{
    private static void Main(string[] args)
    {
        var scenarios = new[]
        {
            new Scenario("Example 1 - [5,10,-5]",     new int[] { 5, 10, -5 },     new int[] { 5, 10 }),
            new Scenario("Example 2 - [8,-8]",         new int[] { 8, -8 },          new int[] { }),
            new Scenario("No collision [10,2,5]",      new int[] { 10, 2, 5 },       new int[] { 10, 2, 5 }),
            new Scenario("All left [-1,-2,-3]",        new int[] { -1, -2, -3 },     new int[] { -1, -2, -3 }),
            new Scenario("Chain reaction [10,-5,-8]",  new int[] { 10, -5, -8 },     new int[] { 10 }),
            new Scenario("Equal destruction [5,-5]",   new int[] { 5, -5 },          new int[] { }),
            new Scenario("Complex [1,-2,3,-4]",        new int[] { 1, -2, 3, -4 },   new int[] { -2, -4 }),
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
