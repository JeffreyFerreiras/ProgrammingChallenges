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

using System;
using System.Diagnostics;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        // Test Scenario 1: Empty list array
        RunMergeKListsTest("TestScenario1", new ListNode[] { }, null);
        
        // Test Scenario 2: Array with one empty list
        RunMergeKListsTest("TestScenario2", new ListNode[] { null }, null);
        
        // Test Scenario 3: Single non-empty list
        var list1 = CreateLinkedList(new int[] { 1, 3, 5 });
        RunMergeKListsTest("TestScenario3", new ListNode[] { list1 }, list1);
        
        // Test Scenario 4: Multiple non-empty lists
        var list2 = CreateLinkedList(new int[] { 2, 4, 6 });
        var mergedExpected = CreateLinkedList(new int[] { 1, 2, 3, 4, 5, 6 }); // expected result from merging list1 and list2
        RunMergeKListsTest("TestScenario4", new ListNode[] { list1, list2 }, mergedExpected);

        // Test Scenario 5: Use case [[]] - an array with an empty list created as a linked list with no elements
        var emptyListWrapper = CreateLinkedList(new int[] { }); // returns null
        RunMergeKListsTest("TestScenario5", new ListNode[] { emptyListWrapper }, null);
    }
    
    static void RunMergeKListsTest(string testName, ListNode[] lists, ListNode expected)
    {
        var solution = new Solution();
        var stopwatch = Stopwatch.StartNew();
        
        ListNode result = solution.MergeKLists(lists);
        
        stopwatch.Stop();
        long elapsedTicks = stopwatch.ElapsedTicks;
        
        string resultStr = LinkedListToString(result);
        string expectedStr = LinkedListToString(expected);
        
        Console.WriteLine($"{testName} - MergeKLists took {elapsedTicks} ticks. Result: {resultStr}, Expected: {expectedStr}");
    }
    
    static ListNode CreateLinkedList(int[] values)
    {
        if (values == null || values.Length == 0)
            return null;
        
        ListNode head = new ListNode(values[0]);
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
        
        StringBuilder sb = new StringBuilder();
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

/**
 * Definition for singly-linked list.
 */
public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode? next = null)
    {
        this.val = val;
        this.next = next;
    }
}

/**
 * Solution class to merge k sorted linked lists.
 */
public class Solution
{
    public ListNode MergeKLists(ListNode[] lists)
    {
        if(lists == null || lists.Length == 0)
            return null;
        // define a priority queue to store the heads of the linked lists
        var priorityQueue = new PriorityQueue<int, int>();
        // loop through the lists and add the heads to the priority queue
        
        //bfs approach
        var bfs = new Queue<ListNode>();

        foreach (ListNode listHeadNode in lists)
        {
            if (listHeadNode != null)
                bfs.Enqueue(listHeadNode);
        }

        while (bfs.Count > 0)
        {
            var current = bfs.Dequeue();
            if (current != null)
            {
                priorityQueue.Enqueue(current.val, current.val);
                bfs.Enqueue(current.next);
            }
        }

        // while the priority queue is not empty, extract the minimum node
        ListNode root = new();
        ListNode node = root;

        if(priorityQueue.Count == 0)
            return null;

        while (priorityQueue.Count > 0)
        {
            var min = priorityQueue.Dequeue();

            if(priorityQueue.Count == 0)
            {
                node.val = min;
                break;
            }
            node.next ??= new ListNode();
            node.val = min;
            node = node.next;
        }

        return root;
    }
}
