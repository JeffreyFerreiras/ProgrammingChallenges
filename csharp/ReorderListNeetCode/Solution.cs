namespace ReorderListNeetCode;

public static class Solution
{
    public static void ReorderList(ListNode? head)
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
