using System.Diagnostics;

namespace ReverseLinkedListNeetCode;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("206. Reverse Linked List");
        Console.WriteLine("====================================================================");

        RunScenario(
            "Example: [1,2,3,4,5]",
            () => Solution.ReverseList(BuildList(1, 2, 3, 4, 5)),
            "[5,4,3,2,1]"
        );

        RunScenario(
            "Edge: empty list",
            () => Solution.ReverseList(null),
            "[]"
        );

        RunScenario(
            "Long: 1..15 reversed",
            () => Solution.ReverseList(BuildList(Enumerable.Range(1, 15))),
            "[15,14,13,12,11,10,9,8,7,6,5,4,3,2,1]"
        );
    }

    private static void RunScenario(string name, Func<ListNode?> action, string expected)
    {
        var stopwatch = Stopwatch.StartNew();
        try
        {
            ListNode? result = action();
            stopwatch.Stop();
            Console.WriteLine($"Scenario: {name}");
            Console.WriteLine($"  Time: {stopwatch.Elapsed.TotalMilliseconds:F4} ms");
            Console.WriteLine($"  Result: {FormatList(result)}");
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
