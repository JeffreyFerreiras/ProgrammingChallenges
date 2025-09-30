using System.Diagnostics;

namespace MergeTwoSortedListsNeetCode;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("21. Merge Two Sorted Lists");
        Console.WriteLine("====================================================================");

        RunScenario(
            "Example: [1,2,4] + [1,3,4]",
            () => Solution.MergeTwoLists(BuildList(1, 2, 4), BuildList(1, 3, 4)),
            "[1,1,2,3,4,4]"
        );

        RunScenario(
            "Edge: both inputs null",
            () => Solution.MergeTwoLists(null, null),
            "[]"
        );

        RunScenario(
            "Long: evens vs odds",
            () => Solution.MergeTwoLists(
                BuildList(0, 2, 4, 6, 8, 10),
                BuildList(1, 3, 5, 7, 9, 11)
            ),
            "[0,1,2,3,4,5,6,7,8,9,10,11]"
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
