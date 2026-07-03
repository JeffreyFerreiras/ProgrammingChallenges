using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

class Program
{
    private static readonly char[][] Board1 =
    {
        new[] { 'A','B','C','E' },
        new[] { 'S','F','C','S' },
        new[] { 'A','D','E','E' },
    };

    private static void Main(string[] args)
    {
        var scenarios = new[]
        {
            new Scenario("ABCCED", Board1, "ABCCED", true),
            new Scenario("SEE",    Board1, "SEE",    true),
            new Scenario("ABCB",   Board1, "ABCB",   false),
            new Scenario("AAB", new char[][] { new[]{'C','A','A'}, new[]{'A','A','A'}, new[]{'B','C','D'} }, "AAB", true),
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
            .Where(m => m.GetParameters()[0].ParameterType == typeof(char[][]))
            .Where(m => m.GetParameters()[1].ParameterType == typeof(string))
            .Where(m => m.ReturnType == typeof(bool))
            .OrderBy(m => m.Name)
            .ToArray();

        foreach (var method in methods)
        {
            var boardCopy = scenario.Board.Select(r => (char[])r.Clone()).ToArray();
            var stopwatch = Stopwatch.StartNew();
            object? result = null;
            Exception? exception = null;

            try
            {
                result = method.Invoke(solution, new object?[] { boardCopy, scenario.Word });
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

    private sealed record Scenario(string Name, char[][] Board, string Word, bool Expected);
}
