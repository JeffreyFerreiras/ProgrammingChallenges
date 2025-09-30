using System.Diagnostics;

namespace MergeKSortedListsNeetCode;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("23. Merge K Sorted Lists");
        Console.WriteLine("====================================================================");

        RunScenario(
            "Example: three sorted lists",
            () => Solution.MergeKLists(new[]
            {
                BuildList(1, 4, 5),
                BuildList(1, 3, 4),
                BuildList(2, 6)
            }),
            "[1,1,2,3,4,4,5,6]"
        );

        RunScenario(
            "Edge: all lists empty",
            () => Solution.MergeKLists(new ListNode?[] { null, null, null }),
            "[]"
        );

        RunScenario(
            "Long: five lists interleaving",
            () => Solution.MergeKLists(new[]
            {
                BuildList(0, 5, 10, 15),
                BuildList(1, 6, 11, 16),
                BuildList(2, 7, 12, 17),
                BuildList(3, 8, 13, 18),
                BuildList(4, 9, 14, 19)
            }),
            "[0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19]"
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
