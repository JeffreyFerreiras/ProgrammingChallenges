namespace LinkedList_OddEvenList
{
    public class ListNode
    {
        public int val;
        public ListNode? next;

        public ListNode(int val = 0, ListNode? next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class Solution
    {
        public ListNode? OddEvenList(ListNode? head)
        {
            if (head == null)
            {
                return null;
            }

            ListNode current = head;
            ListNode lastHead = head;

            while (lastHead.next != null)
            {
                lastHead = lastHead.next;
            }

            ListNode last = lastHead;

            while (current != lastHead && current.next != lastHead)
            {
                last.next = new ListNode(current.next!.val);
                last = last.next;
                current.next = current.next.next;
                current = current.next!;
            }

            return head;
        }

        public ListNode? OddEvenList2(ListNode? head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            ListNode current = head;
            ListNode evenStart = new ListNode(head.next!.val);
            ListNode even = evenStart;

            current.next = current.next.next;

            if (current.next != null)
            {
                current = current.next;
            }

            while (current.next != null)
            {
                even.next = new ListNode(current.next.val);
                even = even.next!;
                current.next = current.next.next;

                if (current.next == null)
                {
                    break;
                }

                current = current.next;
            }

            current.next = evenStart;
            return head;
        }
    }
}