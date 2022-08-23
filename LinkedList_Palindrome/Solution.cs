using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList_Palindrome
{
    /*
     * Definition for singly-linked list.
     */
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

    public class Solution
    {
        public static bool IsPalindrome(ListNode head)
        {
            ListNode headptr = head;
            ListNode currentptr = new ListNode(headptr.val, headptr.next);
            ListNode current = currentptr;

            while(headptr != null)
            {
                var node = new ListNode(headptr.val, null);
                currentptr.next = node;
                currentptr = currentptr.next;
                headptr = headptr.next;
            }
            
            ListNode prev = null;

            while (current != null)
            {
                ListNode next = current.next;
                current.next = prev;
                prev = current;
                current = next;
            }
            
            while (head != null && prev != null)
            {
                if (head.val != prev.val)
                {
                    return false;
                }
                head = head.next;
                prev = prev.next;
            }

            return true;
        }
    }
}
