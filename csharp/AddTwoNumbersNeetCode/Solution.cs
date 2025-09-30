namespace AddTwoNumbersNeetCode;

public static class Solution
{
    public static ListNode? AddTwoNumbers(ListNode? l1, ListNode? l2)
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
