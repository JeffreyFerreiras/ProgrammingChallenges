using System.Diagnostics;

namespace LinkedListCycleNeetCode;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("141. Linked List Cycle");
        Console.WriteLine("====================================================================");

        RunScenario(
            "Example: cycle at index 1",
            () => Solution.HasCycle(BuildListWithCycle(new[] { 3, 2, 0, -4 }, 1)),
            "True"
        );

        RunScenario(
            "Edge: no cycle single node",
            () => Solution.HasCycle(BuildListWithCycle(new[] { 1 }, -1)),
            "False"
        );

        RunScenario(
            "Long: 100 nodes cycle at index 50",
            () => Solution.HasCycle(BuildListWithCycle(Enumerable.Range(1, 100).ToArray(), 50)),
            "True"
        );
    }

    private static void RunScenario(string name, Func<bool> action, string expected)
    {
        var stopwatch = Stopwatch.StartNew();
        try
        {
            bool result = action();
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

    private static ListNode? BuildListWithCycle(IReadOnlyList<int> values, int pos)
    {
        if (values.Count == 0)
        {
            return null;
        }

        var nodes = values.Select(value => new ListNode(value)).ToArray();
        for (int i = 0; i < nodes.Length - 1; i++)
        {
            nodes[i].Next = nodes[i + 1];
        }

        if (pos >= 0 && pos < nodes.Length)
        {
            nodes[^1].Next = nodes[pos];
        }

        return nodes[0];
    }
}
