using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace ReverseNodesInkGroup;

internal class Program
{
    private static void Main(string[] args)
    {
        var scenarios = new[]
        {
            new Scenario("[1,2,3,4,5] k=2", Build(1,2,3,4,5), 2, "[2,1,4,3,5]"),
            new Scenario("[1,2,3,4,5] k=3", Build(1,2,3,4,5), 3, "[3,2,1,4,5]"),
            new Scenario("[1,2,3,4,5] k=1", Build(1,2,3,4,5), 1, "[1,2,3,4,5]"),
            new Scenario("[1] k=1",          Build(1),          1, "[1]"),
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
            .Where(m => m.GetParameters().Length == 2)
            .Where(m => m.GetParameters()[1].ParameterType == typeof(int))
            .Where(m => m.ReturnType == typeof(ListNode))
            .OrderBy(m => m.Name)
            .ToArray();

        foreach (var method in methods)
        {
            var headCopy = Clone(scenario.Head);
            var stopwatch = Stopwatch.StartNew();
            object? result = null;
            Exception? exception = null;

            try
            {
                result = method.Invoke(null, new object?[] { headCopy, scenario.K });
            }
            catch (Exception ex) { exception = ex; }
            finally { stopwatch.Stop(); }

            Console.Write($"{method.Name} | {stopwatch.Elapsed.TotalMilliseconds:0.0000} ms | ");

            if (exception != null)
            {
                Console.WriteLine($"ERROR: {exception.GetBaseException().Message}");
                continue;
            }

            var actual = Format((ListNode?)result);
            Console.WriteLine($"{actual} | Expected {scenario.Expected} | {(actual == scenario.Expected ? "✅ PASS" : "❌ FAIL")}");
        }
    }

    private static string Format(ListNode? node)
    {
        var parts = new System.Collections.Generic.List<int>();
        while (node != null) { parts.Add(node.val); node = node.next; }
        return "[" + string.Join(",", parts) + "]";
    }

    private static ListNode? Build(params int[] vals)
    {
        if (vals.Length == 0) return null;
        var head = new ListNode(vals[0]);
        var cur = head;
        for (int i = 1; i < vals.Length; i++) { cur.next = new ListNode(vals[i]); cur = cur.next; }
        return head;
    }

    private static ListNode? Clone(ListNode? node)
    {
        if (node is null) return null;
        var head = new ListNode(node.val);
        var cur = head;
        node = node.next;
        while (node != null) { cur.next = new ListNode(node.val); cur = cur.next; node = node.next; }
        return head;
    }

    private sealed record Scenario(string Name, ListNode? Head, int K, string Expected);
}
