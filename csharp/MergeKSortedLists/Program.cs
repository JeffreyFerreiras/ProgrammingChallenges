using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

class Program
{
    private static void Main(string[] args)
    {
        var scenarios = new[]
        {
            new Scenario("3 sorted lists", new ListNode?[]{ Build(1,4,5), Build(1,3,4), Build(2,6) }, "[1,1,2,3,4,4,5,6]"),
            new Scenario("Empty array",    new ListNode?[]{ },                                          "[]"),
            new Scenario("One null list",  new ListNode?[]{ null },                                     "[]"),
            new Scenario("Single list",    new ListNode?[]{ Build(1,3,5) },                             "[1,3,5]"),
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
            .Where(m => m.GetParameters()[0].ParameterType == typeof(ListNode[]))
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
                result = method.Invoke(solution, new object?[] { scenario.Lists.ToArray() });
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

    private sealed record Scenario(string Name, ListNode?[] Lists, string Expected);
}
