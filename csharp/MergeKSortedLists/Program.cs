/*
 * Problem Description:
 * Given an array of k linked-list heads, where each linked list is sorted in ascending order,
 * merge all the linked lists into one sorted linked list and return its head.
 *
 * Approach:
 * There are several strategies to solve this problem:
 *   1. Iteratively compare the heads of each list to select the smallest node.
 *   2. Use a min-heap (priority queue) to efficiently extract the minimum value at each step.
 *   3. Utilize a divide and conquer approach to merge lists pair-wise.
 *
 * This file includes a testing harness that:
 *   - Sets up various test scenarios.
 *   - Calls the MergeKLists method from the Solution class.
 *   - Uses a Stopwatch to record the execution time (in ticks).
 *   - Prints the test scenario name, the elapsed ticks, the method result, and the expected result.
 *
 * Note:
 * The Solution.MergeKLists method is only a scaffold. Please implement the merging logic as required.
 */

using System.Diagnostics;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Testing MergeKLists ===");
        // Test Scenario 1: Empty list array
        RunMergeKListsTest("TestScenario1", [], null, "MergeKLists");

        // Test Scenario 2: Array with one empty list
        RunMergeKListsTest("TestScenario2", [null], null, "MergeKLists");

        // Test Scenario 3: Single non-empty list
        var list1 = CreateLinkedList([1, 3, 5]);
        RunMergeKListsTest("TestScenario3", [list1], CreateLinkedList([1, 3, 5]), "MergeKLists");

        // Test Scenario 4: Multiple non-empty lists
        var list2a = CreateLinkedList([1, 3, 5]);
        var list2b = CreateLinkedList([2, 4, 6]);
        var mergedExpected = CreateLinkedList([1, 2, 3, 4, 5, 6]); // expected result from merging list1 and list2
        RunMergeKListsTest("TestScenario4", [list2a, list2b], mergedExpected, "MergeKLists");

        // Test Scenario 5: Use case [[]] - an array with an empty list created as a linked list with no elements
        var emptyListWrapper = CreateLinkedList([]); // returns null
        RunMergeKListsTest("TestScenario5", [emptyListWrapper], null, "MergeKLists");

        Console.WriteLine("\n=== Testing MergeKLists_Iterative ===");
        // Test Scenario 1: Empty list array
        RunMergeKListsTest("TestScenario1", [], null, "MergeKLists_Iterative");

        // Test Scenario 2: Array with one empty list
        RunMergeKListsTest("TestScenario2", [null], null, "MergeKLists_Iterative");

        // Test Scenario 3: Single non-empty list
        var list3 = CreateLinkedList([1, 3, 5]);
        RunMergeKListsTest(
            "TestScenario3",
            [list3],
            CreateLinkedList([1, 3, 5]),
            "MergeKLists_Iterative"
        );

        // Test Scenario 4: Multiple non-empty lists
        var list4a = CreateLinkedList([1, 3, 5]);
        var list4b = CreateLinkedList([2, 4, 6]);
        var mergedExpected2 = CreateLinkedList([1, 2, 3, 4, 5, 6]); // expected result from merging list1 and list2
        RunMergeKListsTest(
            "TestScenario4",
            [list4a, list4b],
            mergedExpected2,
            "MergeKLists_Iterative"
        );

        // Test Scenario 5: Use case [[]] - an array with an empty list created as a linked list with no elements
        var emptyListWrapper2 = CreateLinkedList([]); // returns null
        RunMergeKListsTest("TestScenario5", [emptyListWrapper2], null, "MergeKLists_Iterative");
    }

    static void RunMergeKListsTest(
        string testName,
        ListNode[] lists,
        ListNode expected,
        string methodName
    )
    {
        var solution = new Solution();
        var stopwatch = Stopwatch.StartNew();

        ListNode result = methodName switch
        {
            "MergeKLists" => solution.MergeKLists(lists),
            "MergeKLists_Iterative" => solution.MergeKLists_Iterative(lists),
            _ => throw new ArgumentException($"Unknown method: {methodName}"),
        };

        stopwatch.Stop();
        long elapsedTicks = stopwatch.ElapsedTicks;

        string resultStr = LinkedListToString(result);
        string expectedStr = LinkedListToString(expected);
        bool passed = resultStr == expectedStr;
        string checkmark = passed ? "✓" : "✗";

        Console.WriteLine(
            $"{checkmark} {testName} - {methodName} took {elapsedTicks} ticks. Result: {resultStr}, Expected: {expectedStr}"
        );
    }

    static ListNode CreateLinkedList(int[] values)
    {
        if (values == null || values.Length == 0)
            return null;

        ListNode head = new(values[0]);
        ListNode current = head;
        for (int i = 1; i < values.Length; i++)
        {
            current.next = new ListNode(values[i]);
            current = current.next;
        }
        return head;
    }

    static string LinkedListToString(ListNode? node)
    {
        if (node == null)
            return "null";

        StringBuilder sb = new();
        while (node != null)
        {
            sb.Append(node.val);
            if (node.next != null)
                sb.Append("->");
            node = node?.next;
        }
        return sb.ToString();
    }
}
