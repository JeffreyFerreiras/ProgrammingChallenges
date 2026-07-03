using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace LinkedListCycleNeetCode;

internal class Program
{
    private static void Main(string[] args)
    {
        var scenarios = new[]
        {
            new Scenario("Cycle at index 1 [3,2,0,-4]", BuildWithCycle(new[]{3,2,0,-4}, 1), true),
            new Scenario("No cycle single node [1]",     BuildWithCycle(new[]{1}, -1),        false),
            new Scenario("Cycle at 0 [1,2]",             BuildWithCycle(new[]{1,2}, 0),       true),
            new Scenario("No cycle [1,2,3]",             BuildWithCycle(new[]{1,2,3}, -1),    false),
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
            .Where(m => m.ReturnType == typeof(bool))
            .OrderBy(m => m.Name)
            .ToArray();

        foreach (var method in methods)
        {
            var stopwatch = Stopwatch.StartNew();
            object? result = null;
            Exception? exception = null;

            try
            {
                result = method.Invoke(null, new object?[] { scenario.Head });
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

    private static ListNode? BuildWithCycle(int[] vals, int pos)
    {
        if (vals.Length == 0) return null;
        var nodes = vals.Select(v => new ListNode(v)).ToArray();
        for (int i = 0; i < nodes.Length - 1; i++) nodes[i].Next = nodes[i + 1];
        if (pos >= 0) nodes[^1].Next = nodes[pos];
        return nodes[0];
    }

    private sealed record Scenario(string Name, ListNode? Head, bool Expected);
}
