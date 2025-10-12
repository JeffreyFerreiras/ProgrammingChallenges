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

/**
 * Solution class to merge k sorted linked lists.
 */

/**
 * Definition for singly-linked list.
 */
public class ListNode(int val = 0, ListNode? next = null)
{
    public int val = val;
    public ListNode? next = next;
}

public class Solution
{
    public ListNode? MergeKLists(ListNode[] lists)
    {
        if (lists == null || lists.Length == 0)
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

        if (priorityQueue.Count == 0)
            return null;

        while (priorityQueue.Count > 0)
        {
            var min = priorityQueue.Dequeue();

            if (priorityQueue.Count == 0)
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

    public ListNode? MergeKLists_Iterative(ListNode[] lists)
    {
        if (lists == null || lists.Length == 0)
            return null!;
        ListNode? mergedListRoot = null;
        ListNode? mergedListTail = null;
        var minQueue = new PriorityQueue<ListNode, int>();

        foreach (var node in lists)
        {
            if (node != null)
                minQueue.Enqueue(node, node.val);
        }

        while (minQueue.Count > 0)
        {
            var minNode = minQueue.Dequeue();

            if (minNode == null)
                break;

            // If the next node is not null, enqueue it
            if (minNode.next != null)
                minQueue.Enqueue(minNode.next, minNode.next.val);

            // Append the minNode to the merged list
            if (mergedListRoot == null)
            {
                mergedListRoot = new ListNode(minNode.val);
                mergedListTail = mergedListRoot;
            }
            else
            {
                mergedListTail!.next = new ListNode(minNode.val);
                mergedListTail = mergedListTail.next;
            }
        }

        return mergedListRoot;
    }
}
