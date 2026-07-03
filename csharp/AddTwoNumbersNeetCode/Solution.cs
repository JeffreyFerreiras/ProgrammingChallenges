namespace AddTwoNumbersNeetCode;

public static class Solution
{
    public static ListNode? AddTwoNumbers(ListNode? l1, ListNode? l2)
    {
        var dummy = new ListNode();
        ListNode current = dummy;
        int carry = 0;

        while (l1 is not null || l2 is not null || carry != 0)
        {
            int sum = carry + (l1?.Val ?? 0) + (l2?.Val ?? 0);
            carry = sum / 10;
            current.Next = new ListNode(sum % 10);
            current = current.Next;

            l1 = l1?.Next;
            l2 = l2?.Next;
        }

        return dummy.Next;
    }
}

public sealed class ListNode(int val = 0, ListNode? next = null)
{
    public int Val { get; set; } = val;
    public ListNode? Next { get; set; } = next;
}
