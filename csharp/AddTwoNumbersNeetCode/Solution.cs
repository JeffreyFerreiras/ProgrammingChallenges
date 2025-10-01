namespace AddTwoNumbersNeetCode;

public static class Solution
{
    public static ListNode? AddTwoNumbers(ListNode? l1, ListNode? l2)
    {
        throw new NotImplementedException();
    }
}

public sealed class ListNode(int val = 0, ListNode? next = null)
{
    public int Val { get; set; } = val;
    public ListNode? Next { get; set; } = next;
}
