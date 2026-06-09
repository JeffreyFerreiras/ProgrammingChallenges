class Solution
{
    public ListNode? AddTwoNumbers(ListNode? l1, ListNode? l2)
    {
        ListNode? current = null;
        ListNode? head = null;
        int remainder = 0;

        while (l1 != null || l2 != null || remainder > 0)
        {
            int sum = (l1?.val ?? 0) + (l2?.val ?? 0) + remainder;
            remainder = 0;

            if (sum >= 10)
            {
                remainder = sum / 10;
                sum %= 10;
            }

            l1 = l1?.next;
            l2 = l2?.next;

            if (current != null)
            {
                current.next = new ListNode(sum, null);
                current = current.next;
            }
            else
            {
                current = head = new ListNode(sum, null);
            }
        }

        return head;
    }
}