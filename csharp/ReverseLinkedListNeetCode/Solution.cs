namespace ReverseLinkedListNeetCode;

public static class Solution
{
    public static ListNode? ReverseList(ListNode? head)
    {
        throw new NotImplementedException();
    }
}

public sealed class ListNode(int val = 0, ListNode? next = null)
{
    public int Val { get; set; } = val;
    public ListNode? Next { get; set; } = next;
}
