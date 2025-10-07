namespace ReorderListNeetCode;

public static class Solution
{
    public static void ReorderList(ListNode? head)
    {
        if (head?.next == null) return;

        // Step 1: Find the middle of the list
        ListNode slow = head, fast = head;
        while (fast.next?.next != null)
        {
            slow = slow.next!;
            fast = fast.next.next;
        }

        // Step 2: Reverse the second half
        ListNode? secondHalf = ReverseList(slow.next);
        slow.next = null;

        // Step 3: Merge the two halves
        ListNode firstHalf = head;
        while (secondHalf != null)
        {
            ListNode temp1 = firstHalf.next!;
            ListNode? temp2 = secondHalf.next;
            
            firstHalf.next = secondHalf;
            secondHalf.next = temp1;
            
            firstHalf = temp1;
            secondHalf = temp2;
        }
    }

    private static ListNode? ReverseList(ListNode? head)
    {
        ListNode? prev = null;
        ListNode? current = head;
        
        while (current != null)
        {
            ListNode? next = current.next;
            current.next = prev;
            prev = current;
            current = next;
        }
        
        return prev;
    }
}

public sealed class ListNode(int val = 0, ListNode? next = null)
{
    public int val { get; set; } = val;
    public ListNode? next { get; set; } = next;
}
