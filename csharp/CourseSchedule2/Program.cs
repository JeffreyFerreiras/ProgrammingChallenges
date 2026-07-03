using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace CourseSchedule2;

internal class Program
{
    private static void Main(string[] args)
    {
        // Note: topological sort allows multiple valid orderings; expected shows one valid answer
        var scenarios = new[]
        {
            new Scenario("2 courses [1,0]",          2, new int[][] { new[]{1,0} },                    "0,1"),
            new Scenario("4 courses complex",         4, new int[][] { new[]{1,0},new[]{2,0},new[]{3,1},new[]{3,2} }, "0,1,2,3"),
            new Scenario("1 course []",               1, new int[][] { },                               "0"),
            new Scenario("Cycle - impossible",        2, new int[][] { new[]{1,0},new[]{0,1} },         ""),
            new Scenario("3 courses chain",           3, new int[][] { new[]{1,0},new[]{2,1} },         "0,1,2"),
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
            .Where(m => m.GetParameters()[0].ParameterType == typeof(int))
            .Where(m => m.GetParameters()[1].ParameterType == typeof(int[][]))
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
                result = method.Invoke(solution, new object?[] { scenario.NumCourses, scenario.Prerequisites });
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
            Console.WriteLine($"{actual} | Expected {scenario.Expected} (order may vary) | {(IsValid((int[])result!, scenario.NumCourses, scenario.Prerequisites, scenario.Expected) ? "✅ PASS" : "❌ FAIL")}");
        }
    }

    private static bool IsValid(int[] order, int n, int[][] prereqs, string expectedStr)
    {
        if (expectedStr == "" && order.Length == 0) return true;
        if (order.Length != n) return false;
        if (order.Distinct().Count() != n) return false;
        var pos = new int[n];
        for (int i = 0; i < n; i++) pos[order[i]] = i;
        return prereqs.All(p => pos[p[1]] < pos[p[0]]);
    }

    private sealed record Scenario(string Name, int NumCourses, int[][] Prerequisites, string Expected);
}
