namespace ReverseLinkedListNeetCode;

public static class Solution
{
    public static ListNode? ReverseList(ListNode? head)
    {
        ListNode? previous = null;
        ListNode? current = head;

        while (current is not null)
        {
            ListNode? next = current.Next;
            current.Next = previous;
            previous = current;
            current = next;
        }

        return previous;
    }
}

public sealed class ListNode(int val = 0, ListNode? next = null)
{
    public int Val { get; set; } = val;
    public ListNode? Next { get; set; } = next;
}
