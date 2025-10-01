using System;

namespace LinkedList_OddEvenList
{
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            ListNode head = new ListNode(1);
            ListNode curr = head;

            for (int i = 2; i <= 10; i++)
            {
                curr.next = new ListNode(i);
                curr = curr.next;
            }

            var oddEven = OddEvenList2(head);

            while (oddEven != null)
            {
                Console.WriteLine(oddEven.val);
                oddEven = oddEven.next;
            }
        }

        public static ListNode OddEvenList(ListNode head)
        {
            ListNode current = head;
            ListNode lasthead = head;

            while (lasthead.next != null)
            {
                lasthead = lasthead.next;
            }

            ListNode last = lasthead;

            while (current != lasthead && current.next != lasthead)
            {
                last.next = new ListNode(current.next.val);
                last = last.next;
                current.next = current.next.next;
                current = current.next;
            }

            return head;
        }
        public static ListNode OddEvenList2(ListNode head)
        {
            if (head == null || head.next == null) return head;

            ListNode current = head;
            ListNode evenStart = new ListNode(head.next.val);
            ListNode even = evenStart;

            current.next = current.next.next;

            if (current.next != null)
                current = current.next;

            while (current.next != null)
            {
                even.next = new ListNode(current.next.val);
                even = even.next;
                current.next = current.next.next;

                if (current.next == null) break;

                current = current.next;
            }

            current.next = evenStart;

            return head;
        }
    }
}