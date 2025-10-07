using System.Diagnostics;

namespace RemoveNthNodeFromEndNeetCode;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("19. Remove Nth Node From End of List");
        Console.WriteLine("====================================================================");

        RunScenario(
            "Example: [1,2,3,4,5], n=2",
            () => Solution.RemoveNthFromEnd(BuildList(1, 2, 3, 4, 5), 2),
            "[1,2,3,5]"
        );

        RunScenario(
            "Edge: remove only node",
            () => Solution.RemoveNthFromEnd(BuildList(10), 1),
            "[]"
        );

        RunScenario(
            "Long: remove head when n equals length",
            () => Solution.RemoveNthFromEnd(BuildList(Enumerable.Range(1, 10)), 10),
            "[2,3,4,5,6,7,8,9,10]"
        );

        // added scenarios
        RunScenario(
            "Remove tail: [1,2,3], n=1",
            () => Solution.RemoveNthFromEnd(BuildList(1, 2, 3), 1),
            "[1,2]"
        );

        RunScenario(
            "Remove middle: [1,2,3], n=2",
            () => Solution.RemoveNthFromEnd(BuildList(1, 2, 3), 2),
            "[1,3]"
        );

        RunScenario(
            "Duplicates: [1,2,3,3,4], n=2 (remove second 3)",
            () => Solution.RemoveNthFromEnd(BuildList(1, 2, 3, 3, 4), 2),
            "[1,2,3,4]"
        );

        RunScenario(
            "Long tail removal: [1..20], n=1",
            () => Solution.RemoveNthFromEnd(BuildList(Enumerable.Range(1, 20)), 1),
            "[" + string.Join(",", Enumerable.Range(1, 19)) + "]"
        );
    }

    private static void RunScenario(string name, Func<ListNode?> action, string expected)
    {
        var stopwatch = Stopwatch.StartNew();
        try
        {
            ListNode? result = action();
            stopwatch.Stop();

            string resultStr = FormatList(result);
            bool pass = resultStr == expected;

            Console.WriteLine($"Scenario: {name}");
            Console.WriteLine($"  Time: {stopwatch.Elapsed.TotalMilliseconds:F4} ms");
            Console.WriteLine($"  Result: {resultStr}");
            Console.WriteLine($"  Expected: {expected}");
            Console.WriteLine($"  Status: {(pass ? "PASS ✓" : "FAIL ✗")}");
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
                tail!.next = node;
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
            current = current.next;
        }

        return $"[{string.Join(",", values)}]";
    }
}
