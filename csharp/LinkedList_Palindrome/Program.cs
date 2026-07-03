using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace LinkedList_Palindrome;

internal class Program
{
    private static void Main(string[] args)
    {
        var scenarios = new[]
        {
            new Scenario("[1,2,0,2,1] palindrome", Build(1,2,0,2,1), true),
            new Scenario("[1,2,1,2] not palindrome", Build(1,2,1,2), false),
            new Scenario("[1] single",               Build(1),        true),
            new Scenario("[1,1] same",               Build(1,1),      true),
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

            var actual   = result!.ToString()!;
            var expected = scenario.Expected.ToString();
            Console.WriteLine($"{actual} | Expected {expected} | {(actual == expected ? "✅ PASS" : "❌ FAIL")}");
        }
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

    private sealed record Scenario(string Name, ListNode? Head, bool Expected);
}
