using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace SurroundedRegions;

internal class Program
{
    private static void Main(string[] args)
    {
        var scenarios = new[]
        {
            new Scenario("Example 1",
                new char[][] { new[]{'X','X','X','X'}, new[]{'X','O','O','X'}, new[]{'X','X','O','X'}, new[]{'X','O','X','X'} },
                new char[][] { new[]{'X','X','X','X'}, new[]{'X','X','X','X'}, new[]{'X','X','X','X'}, new[]{'X','O','X','X'} }),
            new Scenario("Single X",
                new char[][] { new[]{'X'} },
                new char[][] { new[]{'X'} }),
            new Scenario("O on border",
                new char[][] { new[]{'O','O'}, new[]{'O','O'} },
                new char[][] { new[]{'O','O'}, new[]{'O','O'} }),
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
            .Where(m => m.GetParameters()[0].ParameterType == typeof(char[][]))
            .Where(m => m.ReturnType == typeof(void))
            .OrderBy(m => m.Name)
            .ToArray();

        foreach (var method in methods)
        {
            var boardCopy = scenario.Board.Select(r => (char[])r.Clone()).ToArray();
            var stopwatch = Stopwatch.StartNew();
            Exception? exception = null;

            try
            {
                method.Invoke(solution, new object?[] { boardCopy });
            }
            catch (Exception ex) { exception = ex; }
            finally { stopwatch.Stop(); }

            Console.Write($"{method.Name} | {stopwatch.Elapsed.TotalMilliseconds:0.0000} ms | ");

            if (exception != null)
            {
                Console.WriteLine($"ERROR: {exception.GetBaseException().Message}");
                continue;
            }

            var actual   = FormatBoard(boardCopy);
            var expected = FormatBoard(scenario.Expected);
            Console.WriteLine($"{actual} | Expected {expected} | {(actual == expected ? "✅ PASS" : "❌ FAIL")}");
        }
    }

    private static string FormatBoard(char[][] board) =>
        "[" + string.Join(",", board.Select(row => "[" + string.Join(",", row) + "]")) + "]";

    private sealed record Scenario(string Name, char[][] Board, char[][] Expected);
}
