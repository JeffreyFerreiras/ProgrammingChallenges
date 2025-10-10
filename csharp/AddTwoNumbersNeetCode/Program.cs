using System.Diagnostics;

namespace AddTwoNumbersNeetCode;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("2. Add Two Numbers");
        Console.WriteLine("====================================================================");

        RunScenario(
            "Example: [2,4,3] + [5,6,4]",
            () => Solution.AddTwoNumbers(BuildList(2, 4, 3), BuildList(5, 6, 4)),
            "[7,0,8]"
        );

        RunScenario(
            "Edge: zero plus zero",
            () => Solution.AddTwoNumbers(BuildList(0), BuildList(0)),
            "[0]"
        );

        RunScenario(
            "Long: cascading carry",
            () => Solution.AddTwoNumbers(BuildList(9, 9, 9, 9, 9, 9, 9), BuildList(9, 9, 9, 9)),
            "[8,9,9,9,0,0,0,1]"
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
            Console.WriteLine(
                $"  Status: NOT IMPLEMENTED [{stopwatch.Elapsed.TotalMilliseconds:F4} ms]"
            );
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
