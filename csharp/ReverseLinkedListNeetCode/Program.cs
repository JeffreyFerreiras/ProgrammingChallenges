using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace ReverseLinkedListNeetCode;

internal class Program
{
    private static void Main(string[] args)
    {
        var scenarios = new[]
        {
            new Scenario("[1,2,3,4,5]", Build(1,2,3,4,5), "[5,4,3,2,1]"),
            new Scenario("Empty",        null,              "[]"),
            new Scenario("Single [7]",   Build(7),          "[7]"),
            new Scenario("[1,2]",        Build(1,2),        "[2,1]"),
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
                result = method.Invoke(null, new object?[] { headCopy });
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
        while (node != null) { parts.Add(node.Val); node = node.Next; }
        return "[" + string.Join(",", parts) + "]";
    }

    private static ListNode? Build(params int[] vals)
    {
        ListNode? head = null; ListNode? tail = null;
        foreach (var v in vals) { var n = new ListNode(v); if (head == null) head = tail = n; else { tail!.Next = n; tail = n; } }
        return head;
    }

    private static ListNode? Clone(ListNode? node)
    {
        if (node is null) return null;
        var head = new ListNode(node.Val);
        var cur = head;
        node = node.Next;
        while (node != null) { cur.Next = new ListNode(node.Val); cur = cur.Next; node = node.Next; }
        return head;
    }

    private sealed record Scenario(string Name, ListNode? Head, string Expected);
}
