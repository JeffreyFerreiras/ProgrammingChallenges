namespace MergeTwoSortedListsNeetCode;

public static class Solution
{
    public static ListNode? MergeTwoLists(ListNode? list1, ListNode? list2)
    {
        throw new NotImplementedException();
    }
}

public sealed class ListNode
{
    public int Val { get; set; }
    public ListNode? Next { get; set; }

    public ListNode(int val = 0, ListNode? next = null)
    {
        Val = val;
        Next = next;
    }
}
