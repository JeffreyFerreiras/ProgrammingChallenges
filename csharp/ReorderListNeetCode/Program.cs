using System.Diagnostics;

namespace ReorderListNeetCode;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("143. Reorder List");
        Console.WriteLine("====================================================================");

        // Basic Examples
        RunScenario(
            "Example 1: [1,2,3,4]",
            BuildList(1, 2, 3, 4),
            "[1,4,2,3]"
        );

        RunScenario(
            "Example 2: [1,2,3,4,5]",
            BuildList(1, 2, 3, 4, 5),
            "[1,5,2,4,3]"
        );

        // Edge Cases
        RunScenario(
            "Edge: empty list",
            BuildList(),
            "[]"
        );

        RunScenario(
            "Edge: single node",
            BuildList(42),
            "[42]"
        );

        RunScenario(
            "Edge: two nodes",
            BuildList(1, 2),
            "[1,2]"
        );

        RunScenario(
            "Edge: three nodes",
            BuildList(1, 2, 3),
            "[1,3,2]"
        );

        // Various Lengths
        RunScenario(
            "Length 6: [1,2,3,4,5,6]",
            BuildList(1, 2, 3, 4, 5, 6),
            "[1,6,2,5,3,4]"
        );

        RunScenario(
            "Length 7: [1,2,3,4,5,6,7]",
            BuildList(1, 2, 3, 4, 5, 6, 7),
            "[1,7,2,6,3,5,4]"
        );

        RunScenario(
            "Length 8: eight nodes",
            BuildList(Enumerable.Range(1, 8)),
            "[1,8,2,7,3,6,4,5]"
        );

        // Different Value Patterns
        RunScenario(
            "Negative values: [-1,-2,-3,-4]",
            BuildList(-1, -2, -3, -4),
            "[-1,-4,-2,-3]"
        );

        RunScenario(
            "Mixed values: [0,1,-1,2]",
            BuildList(0, 1, -1, 2),
            "[0,2,1,-1]"
        );

        RunScenario(
            "Large values: [100,200,300,400,500]",
            BuildList(100, 200, 300, 400, 500),
            "[100,500,200,400,300]"
        );

        RunScenario(
            "Duplicate values: [1,1,2,2]",
            BuildList(1, 1, 2, 2),
            "[1,2,1,2]"
        );

        // Longer Lists
        RunScenario(
            "Length 10: [1..10]",
            BuildList(Enumerable.Range(1, 10)),
            "[1,10,2,9,3,8,4,7,5,6]"
        );

        // Test to demonstrate failure case
        RunScenario(
            "Demo: Failure case",
            BuildList(1, 2),
            "[2,1]" // Deliberately wrong expected result
        );

        Console.WriteLine("\n====================================================================");
        Console.WriteLine("Test Summary:");
        Console.WriteLine("- ✅ = Test passed");
        Console.WriteLine("- ❌ = Test failed"); 
        Console.WriteLine("- ⚠️  = Not implemented");
        Console.WriteLine("- 💥 = Runtime error");
    }

    private static void RunScenario(string name, ListNode? head, string expected)
    {
        var stopwatch = Stopwatch.StartNew();
        try
        {
            ListNode? clone = CloneList(head);
            Solution.ReorderList(clone);
            stopwatch.Stop();
            
            string result = FormatList(clone);
            bool passed = result == expected;
            string status = passed ? "✅ PASS" : "❌ FAIL";
            
            Console.WriteLine($"Scenario: {name}");
            Console.WriteLine($"  Status: {status} [{stopwatch.Elapsed.TotalMilliseconds:F4} ms]");
            Console.WriteLine($"  Result: {result}");
            Console.WriteLine($"  Expected: {expected}");
        }
        catch (NotImplementedException)
        {
            stopwatch.Stop();
            Console.WriteLine($"Scenario: {name}");
            Console.WriteLine($"  Status: ⚠️  NOT IMPLEMENTED [{stopwatch.Elapsed.TotalMilliseconds:F4} ms]");
            Console.WriteLine($"  Expected: {expected}");
        }
        catch (Exception ex)
        {
            stopwatch.Stop();
            Console.WriteLine($"Scenario: {name}");
            Console.WriteLine($"  Status: 💥 ERROR [{stopwatch.Elapsed.TotalMilliseconds:F4} ms]");
            Console.WriteLine($"  Message: {ex.Message}");
            Console.WriteLine($"  Expected: {expected}");
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
            values.Add(current.val);
            current = current.next;
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
            values.Add(current.val);
            current = current.next;
        }

        return $"[{string.Join(",", values)}]";
    }
}
