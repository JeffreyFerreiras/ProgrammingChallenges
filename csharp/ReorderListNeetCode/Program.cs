using System.Diagnostics;

namespace ReorderListNeetCode;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("143. Reorder List");
        Console.WriteLine("====================================================================");

        RunScenario(
            "Example: [1,2,3,4]",
            BuildList(1, 2, 3, 4),
            "[1,4,2,3]"
        );

        RunScenario(
            "Edge: single node",
            BuildList(42),
            "[42]"
        );

        RunScenario(
            "Long: eight nodes",
            BuildList(Enumerable.Range(1, 8)),
            "[1,8,2,7,3,6,4,5]"
        );
    }

    private static void RunScenario(string name, ListNode? head, string expected)
    {
        var stopwatch = Stopwatch.StartNew();
        try
        {
            ListNode? clone = CloneList(head);
            Solution.ReorderList(clone);
            stopwatch.Stop();
            Console.WriteLine($"Scenario: {name}");
            Console.WriteLine($"  Time: {stopwatch.Elapsed.TotalMilliseconds:F4} ms");
            Console.WriteLine($"  Result: {FormatList(clone)}");
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

    private static ListNode? BuildList(IEnumerable<int> values)
    {
        ListNode? head = null;
        ListNode? tail = null;
        foreach (int value in values)
        {
            var node = new ListNode(value);
            if (head is null)
            {
                head = node;
            }
            else
            {
                tail!.Next = node;
            }

            tail = node;
        }

        return head;
    }

    private static ListNode? BuildList(params int[] values) => BuildList((IEnumerable<int>)values);

    private static ListNode? CloneList(ListNode? head)
    {
        if (head is null)
        {
            return null;
        }

        var values = new List<int>();
        ListNode? current = head;
        while (current is not null)
        {
            values.Add(current.Val);
            current = current.Next;
        }

        return BuildList(values);
    }

    private static string FormatList(ListNode? head)
    {
        if (head is null)
        {
            return "[]";
        }

        var values = new List<int>();
        ListNode? current = head;
        while (current is not null)
        {
            values.Add(current.Val);
            current = current.Next;
        }

        return $"[{string.Join(",", values)}]";
    }
}
