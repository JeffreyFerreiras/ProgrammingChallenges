using System.Xml;

namespace RemoveNthNodeFromEndNeetCode;

public static class Solution
{
    public static ListNode? RemoveNthFromEnd(ListNode? head, int n)
    {
        // [1,2,3,4,5], n = 2
        ListNode? node = head;
        int length = 0;
        while (node != null)
        {
            length++;
            node = node.Next;
        }

        if (length == n)
        {
            return head?.Next;
        }

        node = head;
        int target = length - n;
        while (target-- > 1)
        {
            node = node.Next;
        }
        if (node != null && target == 0)
        {
            node.Next = node?.Next?.Next;
        }

        return head;
    }
}

public sealed class ListNode(int val = 0, ListNode? next = null)
{
    public int Val { get; set; } = val;
    public ListNode? Next { get; set; } = next;
}
