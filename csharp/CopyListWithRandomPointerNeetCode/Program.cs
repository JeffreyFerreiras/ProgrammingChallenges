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
            "Long: alternating random links",
            () =>
            {
                var head = BuildRandomList((1, 3), (2, 0), (3, null), (4, 2), (5, 1), (6, 4));
                var clone = Solution.CopyRandomList(head);
                return FormatRandomList(clone);
            },
            "[(1,3)->(2,0)->(3,null)->(4,2)->(5,1)->(6,4)]"
        );
    }

    private static void RunScenario(string name, Func<string> action, string expected)
    {
        var stopwatch = Stopwatch.StartNew();
        try
        {
            string result = action();
            stopwatch.Stop();
            Console.WriteLine($"Scenario: {name}");
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

    private static RandomNode? BuildRandomList(params (int value, int? randomIndex)[] nodes)
    {
        if (nodes.Length == 0)
        {
            return null;
        }

        var created = nodes.Select(node => new RandomNode(node.value)).ToArray();
        for (int i = 0; i < created.Length; i++)
        {
            created[i].Next = i + 1 < created.Length ? created[i + 1] : null;
            created[i].Random = nodes[i].randomIndex.HasValue ? created[nodes[i].randomIndex.Value] : null;
        }

        return created[0];
    }

    private static string FormatRandomList(RandomNode? head)
    {
        if (head is null)
        {
            return "[]";
        }

        var order = new List<RandomNode>();
        var indices = new Dictionary<RandomNode, int>();
        RandomNode? current = head;
        int index = 0;
        while (current is not null)
        {
            order.Add(current);
            indices[current] = index++;
            current = current.Next;
        }

        var parts = new List<string>(order.Count);
        foreach (RandomNode node in order)
        {
            string randomIndex = node.Random is null ? "null" : indices[node.Random].ToString();
            parts.Add($"({node.Val},{randomIndex})");
        }

        return $"[{string.Join("->", parts)}]";
    }
}
