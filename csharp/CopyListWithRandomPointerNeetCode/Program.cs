using System.Diagnostics;

namespace CopyListWithRandomPointerNeetCode;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("138. Copy List With Random Pointer");
        Console.WriteLine("====================================================================");

        RunScenario(
            "Example: five node reference graph",
            () =>
            {
                var head = BuildRandomList((7, null), (13, 0), (11, 4), (10, 2), (1, 0));
                var clone = Solution.CopyRandomList(head);
                return FormatRandomList(clone);
            },
            "[(7,null)->(13,0)->(11,4)->(10,2)->(1,0)]"
        );

        RunScenario(
            "Edge: empty list",
            () =>
            {
                var head = BuildRandomList();
                var clone = Solution.CopyRandomList(head);
                return FormatRandomList(clone);
            },
            "[]"
        );

        RunScenario(
            "Edge: single node self reference",
            () =>
            {
                var head = BuildRandomList((1, 0));
                var clone = Solution.CopyRandomList(head);
                return FormatRandomList(clone);
            },
            "[(1,0)]"
        );

        RunScenario(
            "Edge: single node no random",
            () =>
            {
                var head = BuildRandomList((42, null));
                var clone = Solution.CopyRandomList(head);
                return FormatRandomList(clone);
            },
            "[(42,null)]"
        );

        RunScenario(
            "Edge: two nodes mutual reference",
            () =>
            {
                var head = BuildRandomList((1, 1), (2, 0));
                var clone = Solution.CopyRandomList(head);
                return FormatRandomList(clone);
            },
            "[(1,1)->(2,0)]"
        );

        RunScenario(
            "Edge: all random pointers null",
            () =>
            {
                var head = BuildRandomList((1, null), (2, null), (3, null), (4, null));
                var clone = Solution.CopyRandomList(head);
                return FormatRandomList(clone);
            },
            "[(1,null)->(2,null)->(3,null)->(4,null)]"
        );

        RunScenario(
            "Edge: all random pointers to head",
            () =>
            {
                var head = BuildRandomList((1, 0), (2, 0), (3, 0), (4, 0));
                var clone = Solution.CopyRandomList(head);
                return FormatRandomList(clone);
            },
            "[(1,0)->(2,0)->(3,0)->(4,0)]"
        );

        RunScenario(
            "Edge: all random pointers to tail",
            () =>
            {
                var head = BuildRandomList((1, 3), (2, 3), (3, 3), (4, 3));
                var clone = Solution.CopyRandomList(head);
                return FormatRandomList(clone);
            },
            "[(1,3)->(2,3)->(3,3)->(4,3)]"
        );

        RunScenario(
            "Long: alternating random links",
            () =>
            {
                var head = BuildRandomList((1, 3), (2, 0), (3, null), (4, 2), (5, 1), (6, 4));
                var clone = Solution.CopyRandomList(head);
                return FormatRandomList(clone);
            },
            "[(1,3)->(2,0)->(3,null)->(4,2)->(5,1)->(6,4)]"
        );

        RunScenario(
            "Long: backward chain of random pointers",
            () =>
            {
                var head = BuildRandomList((1, null), (2, 0), (3, 1), (4, 2), (5, 3));
                var clone = Solution.CopyRandomList(head);
                return FormatRandomList(clone);
            },
            "[(1,null)->(2,0)->(3,1)->(4,2)->(5,3)]"
        );

        RunScenario(
            "Long: forward chain of random pointers",
            () =>
            {
                var head = BuildRandomList((1, 1), (2, 2), (3, 3), (4, 4), (5, null));
                var clone = Solution.CopyRandomList(head);
                return FormatRandomList(clone);
            },
            "[(1,1)->(2,2)->(3,3)->(4,4)->(5,null)]"
        );

        RunScenario(
            "Long: complex random graph",
            () =>
            {
                var head = BuildRandomList((10, 2), (20, 4), (30, 1), (40, 0), (50, 3));
                var clone = Solution.CopyRandomList(head);
                return FormatRandomList(clone);
            },
            "[(10,2)->(20,4)->(30,1)->(40,0)->(50,3)]"
        );
    }

    private static void RunScenario(string name, Func<string> action, string expected)
    {
        var stopwatch = Stopwatch.StartNew();
        try
        {
            string result = action();
            stopwatch.Stop();
            bool passed = result == expected;
            string status = passed ? "✓" : "✗";
            Console.WriteLine($"Scenario: {name} {status}");
            Console.WriteLine($"  Time: {stopwatch.Elapsed.TotalMilliseconds:F4} ms");
            Console.WriteLine($"  Result: {result}");
            Console.WriteLine($"  Expected: {expected}");
        }
        catch (NotImplementedException)
        {
            stopwatch.Stop();
            Console.WriteLine($"Scenario: {name}");
            Console.WriteLine($"  Status: NOT IMPLEMENTED [{stopwatch.Elapsed.TotalMilliseconds:F4} ms]");
            Console.WriteLine($"  Expected: {expected}");
        }
        catch (Exception ex)
        {
            stopwatch.Stop();
            Console.WriteLine($"Scenario: {name}");
            Console.WriteLine($"  Status: ERROR [{stopwatch.Elapsed.TotalMilliseconds:F4} ms]");
            Console.WriteLine($"  Message: {ex.Message}");
        }
    }

    private static Node? BuildRandomList(params (int value, int? randomIndex)[] nodes)
    {
        if (nodes.Length == 0)
        {
            return null;
        }

        var created = nodes.Select(node => new Node(node.value)).ToArray();
        for (int i = 0; i < created.Length; i++)
        {
            created[i].next = i + 1 < created.Length ? created[i + 1] : null;
            created[i].random = nodes[i].randomIndex.HasValue ? created[nodes[i].randomIndex.Value] : null;
        }

        return created[0];
    }

    private static string FormatRandomList(Node? head)
    {
        if (head is null)
        {
            return "[]";
        }

        var order = new List<Node>();
        var indices = new Dictionary<Node, int>();
        Node? current = head;
        int index = 0;
        while (current is not null)
        {
            order.Add(current);
            indices[current] = index++;
            current = current.next;
        }

        var parts = new List<string>(order.Count);
        foreach (Node node in order)
        {
            string randomIndex = node.random is null ? "null" : indices[node.random].ToString();
            parts.Add($"({node.val},{randomIndex})");
        }

        return $"[{string.Join("->", parts)}]";
    }
}
