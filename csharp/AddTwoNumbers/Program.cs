using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

public sealed class ListNode(int val = 0, ListNode? next = null)
{
    public int val = val;
    public ListNode? next = next;
}

class Program
{
    private static void Main(string[] args)
    {
        var scenarios = new[]
        {
            new Scenario("[2,4,3]+[5,6,4]", Build(2,4,3),     Build(5,6,4),     "[7,0,8]"),
            new Scenario("[0]+[0]",          Build(0),          Build(0),          "[0]"),
            new Scenario("[9,9,9,9,9,9,9]+[9,9,9,9]", Build(9,9,9,9,9,9,9), Build(9,9,9,9), "[8,9,9,9,0,0,0,1]"),
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
            .Where(m => m.ReturnType == typeof(ListNode))
            .OrderBy(m => m.Name)
            .ToArray();

        foreach (var method in methods)
        {
            var stopwatch = Stopwatch.StartNew();
            object? result = null;
            Exception? exception = null;

            try
            {
                result = method.Invoke(solution, new object?[] { scenario.L1, scenario.L2 });
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
        ListNode? head = null, tail = null;
        foreach (var v in vals)
        {
            var n = new ListNode(v);
            if (head == null) head = tail = n;
            else { tail!.next = n; tail = n; }
        }
        return head;
    }

    private sealed record Scenario(string Name, ListNode? L1, ListNode? L2, string Expected);
}
