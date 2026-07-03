using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace CopyListWithRandomPointerNeetCode;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("138. Copy List with Random Pointer\n");

        // Example: [(7,null),(13,0),(11,4),(10,2),(1,0)]
        var head1 = BuildRandomList((7, null), (13, 0), (11, 4), (10, 2), (1, 0));
        var scenarios = new[]
        {
            ("Five nodes", head1, "[(7,null),(13,7),(11,1),(10,11),(1,7)]"),
            ("Single self-ref", BuildRandomList((1, 0)), "[(1,1)]"),
            ("Two mutual", BuildRandomList((1, 1), (2, 0)), "[(1,2),(2,1)]"),
            ("Empty", (Node?)null, "[]"),
        };

        foreach (var (name, input, _) in scenarios)
        {
            Console.WriteLine($"\n=== {name} ===");
            var methods = typeof(Solution)
                .GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.DeclaredOnly)
                .Where(m => !m.IsSpecialName && m.GetParameters().Length == 1 && m.ReturnType == typeof(Node))
                .OrderBy(m => m.Name)
                .ToArray();

            foreach (var method in methods)
            {
                var sw = Stopwatch.StartNew();
                object? result = null;
                Exception? exception = null;

                try { result = method.Invoke(null, new object?[] { input }); }
                catch (Exception ex) { exception = ex; }
                finally { sw.Stop(); }

                Console.Write($"{method.Name} | {sw.Elapsed.TotalMilliseconds:0.0000} ms | ");

                if (exception != null) { Console.WriteLine($"ERROR: {exception.GetBaseException().Message}"); continue; }

                var actual = Format((Node?)result);
                Console.WriteLine($"{actual}");
            }
        }

        Console.WriteLine();
    }

    private static string Format(Node? head)
    {
        if (head is null) return "[]";
        // collect nodes in order
        var nodes = new List<Node>();
        var cur = head;
        while (cur != null) { nodes.Add(cur); cur = cur.next; }
        var parts = nodes.Select(n =>
        {
            var ri = n.random is null ? "null" : nodes.IndexOf(n.random).ToString();
            return $"({n.val},{ri})";
        });
        return "[" + string.Join(",", parts) + "]";
    }

    // (val, randomIndex?) - null means no random
    private static Node? BuildRandomList(params (int val, int? randIdx)[] items)
    {
        if (items.Length == 0) return null;
        var nodes = items.Select(i => new Node(i.val)).ToArray();
        for (int i = 0; i < nodes.Length - 1; i++) nodes[i].next = nodes[i + 1];
        for (int i = 0; i < items.Length; i++)
            if (items[i].randIdx.HasValue) nodes[i].random = nodes[items[i].randIdx!.Value];
        return nodes[0];
    }
}
