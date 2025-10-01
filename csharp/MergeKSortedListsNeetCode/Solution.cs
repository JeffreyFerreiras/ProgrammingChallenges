namespace MergeKSortedListsNeetCode;

public static class Solution
{
    public static ListNode? MergeKLists(ListNode?[] lists)
    {
        throw new NotImplementedException();
    }
}

public sealed class ListNode(int val = 0, ListNode? next = null)
{
    public int Val { get; set; } = val;
    public ListNode? Next { get; set; } = next;
}
