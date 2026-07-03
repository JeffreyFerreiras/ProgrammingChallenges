using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace CarFleet;

internal class Program
{
    private static void Main(string[] args)
    {
        var scenarios = new[]
        {
            new Scenario("Example 1", 12, new int[] { 10,8,0,5,3 },   new int[] { 2,4,1,1,3 }, 3),
            new Scenario("Example 2", 10, new int[] { 3 },             new int[] { 3 },          1),
            new Scenario("Example 3", 100, new int[] { 0,2,4 },        new int[] { 4,2,1 },      1),
            new Scenario("Single",    10, new int[] { 5 },             new int[] { 2 },          1),
            new Scenario("2 same fleet", 10, new int[] { 8,6 },        new int[] { 1,2 },        1),
            new Scenario("2 sep fleets", 10, new int[] { 8,6 },        new int[] { 2,1 },        2),
            new Scenario("All same speed", 100, new int[] { 10,20,30 },new int[] { 5,5,5 },      3),
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
            .Where(m => m.GetParameters().Length == 3)
            .Where(m => m.GetParameters()[0].ParameterType == typeof(int))
            .Where(m => m.GetParameters()[1].ParameterType == typeof(int[]))
            .Where(m => m.GetParameters()[2].ParameterType == typeof(int[]))
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
                result = method.Invoke(null, new object?[] { scenario.Target, (int[])scenario.Position.Clone(), (int[])scenario.Speed.Clone() });
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

    private sealed record Scenario(string Name, int Target, int[] Position, int[] Speed, int Expected);
}
