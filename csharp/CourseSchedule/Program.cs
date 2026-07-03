// LeetCode 207 - Course Schedule
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace CourseSchedule
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var scenarios = new[]
            {
                new Scenario("Example 1", 2, new int[][] { new[]{1,0} }, true),
                new Scenario("Example 2", 2, new int[][] { new[]{1,0}, new[]{0,1} }, false),
                new Scenario("Three courses", 3, new int[][] { new[]{1,0}, new[]{2,1} }, true),
                new Scenario("Cycle of 4", 4, new int[][] { new[]{1,0}, new[]{2,1}, new[]{3,2}, new[]{0,3} }, false),
                new Scenario("Five sequential", 5, new int[][] { new[]{1,0}, new[]{2,1}, new[]{3,2}, new[]{4,3} }, true),
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
                .GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.DeclaredOnly)
                .Where(m => !m.IsSpecialName)
                .Where(m => m.GetParameters().Length == 2)
                .Where(m => m.GetParameters()[0].ParameterType == typeof(int))
                .Where(m => m.GetParameters()[1].ParameterType == typeof(int[][]))
                .Where(m => m.ReturnType == typeof(bool))
                .OrderBy(m => m.Name)
                .ToArray();

            foreach (var method in methods)
            {
                var sw = Stopwatch.StartNew();
                object? result = null; Exception? ex = null;
                try { result = method.Invoke(method.IsStatic ? null : solution, new object?[] { scenario.NumCourses, scenario.Prerequisites }); }
                catch (Exception e) { ex = e; } finally { sw.Stop(); }
                Console.Write($"{method.Name} | {sw.Elapsed.TotalMilliseconds:0.0000} ms | ");
                if (ex != null) { Console.WriteLine($"ERROR: {ex.GetBaseException().Message}"); continue; }
                var actual = result?.ToString() ?? "null";
                var expected = scenario.Expected.ToString();
                Console.WriteLine($"{actual} | Expected {expected} | {(actual == expected ? "\u2705 PASS" : "\u274c FAIL")}");
            }
        }

        private sealed record Scenario(string Name, int NumCourses, int[][] Prerequisites, bool Expected);
    }
}
