using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace LetterCombinationsofAPhoneNumber;

internal class Program
{
    private static void Main(string[] args)
    {
        var scenarios = new[]
        {
            new Scenario("digits=23", "23", "ad,ae,af,bd,be,bf,cd,ce,cf"),
            new Scenario("digits=2",  "2",  "a,b,c"),
            new Scenario("empty",     "",   ""),
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
            .Where(m => m.GetParameters()[0].ParameterType == typeof(string))
            .Where(m => m.ReturnType == typeof(IList<string>))
            .OrderBy(m => m.Name)
            .ToArray();

        foreach (var method in methods)
        {
            var stopwatch = Stopwatch.StartNew();
            object? result = null;
            Exception? exception = null;

            try
            {
                result = method.Invoke(solution, new object?[] { scenario.Digits });
            }
            catch (Exception ex) { exception = ex; }
            finally { stopwatch.Stop(); }

            Console.Write($"{method.Name} | {stopwatch.Elapsed.TotalMilliseconds:0.0000} ms | ");

            if (exception != null)
            {
                Console.WriteLine($"ERROR: {exception.GetBaseException().Message}");
                continue;
            }

            var actual = string.Join(",", ((IList<string>)result!).OrderBy(s => s));
            Console.WriteLine($"{actual} | Expected {scenario.Expected} | {(actual == scenario.Expected ? "✅ PASS" : "❌ FAIL")}");
        }
    }

    private sealed record Scenario(string Name, string Digits, string Expected);
}
