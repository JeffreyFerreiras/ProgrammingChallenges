using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace _2Sum;

internal class Program
{
    private static void Main(string[] args)
    {
        var scenarios = new[]
        {
            new Scenario("Scenario 1 - [2,7,11,15] t=9", [2, 7, 11, 15], 9, [0, 1]),
            new Scenario("Scenario 2 - [3,2,4] t=6", [3, 2, 4], 6, [1, 2]),
            new Scenario("Scenario 3 - [3,3] t=6", [3, 3], 6, [0, 1]),
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
            .Where(m => m.ReturnType == typeof(int[]))
            .OrderBy(m => m.Name)
            .ToArray();

        foreach (var method in methods)
        {
            var inputCopy = (int[])scenario.Input.Clone();
            var stopwatch = Stopwatch.StartNew();
            object? result = null;

            try
            {
                result = method.Invoke(solution, [inputCopy, scenario.Target]);
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"ERROR: {ex.GetBaseException().Message}");
                continue;
            }
            finally 
            {
                stopwatch.Stop();
                Console.Write($"{method.Name} | {stopwatch.Elapsed.TotalMilliseconds:0.0000} ms | ");
            }

            var formattedResult   = string.Join(",", (int[])result!);
            var expectedResult = string.Join(",", scenario.Expected);
            Console.WriteLine($"{formattedResult} | Expected {expectedResult} | {(formattedResult == expectedResult ? "✅ PASS" : "❌ FAIL")}");
        }
    }

    private sealed record Scenario(
        string Name,
        int[] Input,
        int Target,
        int[] Expected);
}
