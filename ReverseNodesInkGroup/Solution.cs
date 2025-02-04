using System;

namespace ReverseNodesInkGroup
{
    // Definition for singly-linked list.
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int value = 0, ListNode next = null)
        {
            this.val = value;
            this.next = next;
        }
    }
    public static class Solution
    {
        public static ListNode ReverseKGroup(ListNode head, int k)
        {
            // Count total nodes in the list
            ListNode currentNode = head;
            int nodeCount = 0;
            while (currentNode != null)
            {
                nodeCount++;
                currentNode = currentNode.next;
            }
            currentNode = head; // reset pointer to head

            int completeGroups = nodeCount / k;
            ListNode newHead = null; // will be the new head after reversal

            // Process each complete group
            while (completeGroups-- > 0)
            {
                int count = k;
                ListNode reversedGroupHead = null;
                // Reverse k nodes
                while (count-- > 0)
                {
                    ListNode nextNode = currentNode.next;
                    currentNode.next = reversedGroupHead;
                    reversedGroupHead = currentNode;
                    currentNode = nextNode;
                }

                // For the first group, update the result, otherwise attach it to the previous group
                if (newHead == null)
                    newHead = reversedGroupHead;
                else
                    GetLast(newHead).next = reversedGroupHead;
            }

            // Attach any leftover nodes to the end of the list
            if (newHead != null)
                GetLast(newHead).next = currentNode;

            return newHead;
        }

        private static ListNode GetLast(ListNode head)
        {
            ListNode lastNode = head;
            while (lastNode.next != null)
            {
                lastNode = lastNode.next;
            }
            return lastNode;
        }
    }
}