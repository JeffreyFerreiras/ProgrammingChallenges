using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace ReverseLinkedList;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("206. Reverse Linked List\n");

        // Static ListNode-based methods
        var listMethods = typeof(Solution)
            .GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.DeclaredOnly)
            .Where(m => m.GetParameters().Length == 1 && m.GetParameters()[0].ParameterType == typeof(ListNode))
            .Where(m => m.ReturnType == typeof(ListNode))
            .OrderBy(m => m.Name)
            .ToArray();

        var scenarios = new[]
        {
            ("Scenario 1 - [1,2,3]",    Build(1,2,3),  "[3,2,1]"),
            ("Scenario 2 - empty",       (ListNode?)null, "[]"),
            ("Scenario 3 - single [5]",  Build(5),      "[5]"),
        };

        foreach (var (name, head, expected) in scenarios)
        {
            Console.WriteLine($"\n=== {name} ===");
            foreach (var method in listMethods)
            {
                var copy = Clone(head);
                var sw = Stopwatch.StartNew();
                object? result = null;
                Exception? exception = null;

                try { result = method.Invoke(null, new object?[] { copy }); }
                catch (Exception ex) { exception = ex; }
                finally { sw.Stop(); }

                Console.Write($"{method.Name} | {sw.Elapsed.TotalMilliseconds:0.0000} ms | ");
                if (exception != null) { Console.WriteLine($"ERROR: {exception.GetBaseException().Message}"); continue; }
                var actual = Format((ListNode?)result);
                Console.WriteLine($"{actual} | Expected {expected} | {(actual == expected ? "✅ PASS" : "❌ FAIL")}");
            }
        }

        Console.WriteLine();
    }

    private static string Format(ListNode? node)
    {
        var parts = new List<int>();
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
}
