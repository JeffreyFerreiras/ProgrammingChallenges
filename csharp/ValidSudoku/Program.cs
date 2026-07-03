using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace ValidSudoku;

internal class Program
{
    private static void Main(string[] args)
    {
        var valid = new char[][]
        {
            new[]{'5','3','.','.','7','.','.','.','.'},
            new[]{'6','.','.','1','9','5','.','.','.'},
            new[]{'.','9','8','.','.','.','.','6','.'},
            new[]{'8','.','.','.','6','.','.','.','3'},
            new[]{'4','.','.','8','.','3','.','.','1'},
            new[]{'7','.','.','.','2','.','.','.','6'},
            new[]{'.','6','.','.','.','.','2','8','.'},
            new[]{'.','.','.','4','1','9','.','.','5'},
            new[]{'.','.','.','.','8','.','.','7','9'},
        };
        var invalid = new char[][]
        {
            new[]{'8','3','.','.','7','.','.','.','.'},
            new[]{'6','.','.','1','9','5','.','.','.'},
            new[]{'.','9','8','.','.','.','.','6','.'},
            new[]{'8','.','.','.','6','.','.','.','3'},
            new[]{'4','.','.','8','.','3','.','.','1'},
            new[]{'7','.','.','.','2','.','.','.','6'},
            new[]{'.','6','.','.','.','.','2','8','.'},
            new[]{'.','.','.','4','1','9','.','.','5'},
            new[]{'.','.','.','.','8','.','.','7','9'},
        };

        var scenarios = new[]
        {
            new Scenario("Valid board",   valid,   true),
            new Scenario("Invalid board", invalid, false),
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
                result = method.Invoke(solution, new object?[] { boardCopy });
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

    private sealed record Scenario(string Name, char[][] Board, bool Expected);
}
