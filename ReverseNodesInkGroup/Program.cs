// Program.cs
using System;
using System.Diagnostics;

namespace ReverseNodesInkGroup
{
    class Program
    {
        /*
         * Problem Description:
         * Level: Hard
         * Given a linked list, reverse the nodes of a linked list k at a time and return its modified list.
         * k is a positive integer and is less than or equal to the length of the linked list.
         * If the number of nodes is not a multiple of k then left-out nodes in the end should remain as it is.
         * You may not alter the values in the list's nodes, only nodes themselves may be changed.
         * 
         * Example:
         * Input: head = [1,2,3,4,5], k = 2
         * Output: [2,1,4,3,5]
         * 
         * Input: head = [1,2,3,4,5], k = 3
         * Output: [3,2,1,4,5]
         * 
         * Constraints:
         * The number of nodes in the list is in the range [0, 5000].
         * 0 <= Node.val <= 1000
         * The value of k is in the range [1, 5000].
         */

        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();

            // Scenario 1: Linked list 1->2->3->4->5, k = 2
            // Input: 1 -> 2 -> 3 -> 4 -> 5, k = 2
            // Expected result: 2 -> 1 -> 4 -> 3 -> 5
            ListNode head1 = CreateTestList();
            Console.WriteLine("Scenario 1: Linked list 1 -> 2 -> 3 -> 4 -> 5, k = 2");
            sw.Start();
            head1 = Solution.ReverseKGroup(head1, 2);
            sw.Stop();
            Console.WriteLine($"[Solution.ReverseKGroup] Execution Time: {sw.ElapsedMilliseconds} ms");
            PrintList(head1);
            Console.WriteLine("[2 1 4 3 5]");

            // Scenario 2: Linked list 1->2->3->4->5, k = 3
            // Input: 1 -> 2 -> 3 -> 4 -> 5, k = 3
            // Expected result: 3 -> 2 -> 1 -> 4 -> 5
            ListNode head2 = CreateTestList();
            Console.WriteLine("\nScenario 2: Linked list 1 -> 2 -> 3 -> 4 -> 5, k = 3");
            sw.Restart();
            head2 = Solution.ReverseKGroup(head2, 3);
            sw.Stop();
            Console.WriteLine($"[Solution.ReverseKGroup] Execution Time: {sw.ElapsedMilliseconds} ms");
            PrintList(head2);
            Console.WriteLine("[3 2 1 4 5]");

            // Scenario 3: Linked list 1->2->3->4->5, k = 1 (should remain unchanged)
            // Input: 1 -> 2 -> 3 -> 4 -> 5, k = 1
            // Expected result: 1 -> 2 -> 3 -> 4 -> 5
            ListNode head3 = CreateTestList();
            Console.WriteLine("\nScenario 3: Linked list 1 -> 2 -> 3 -> 4 -> 5, k = 1");
            sw.Restart();
            head3 = Solution.ReverseKGroup(head3, 1);
            sw.Stop();
            Console.WriteLine($"[Solution.ReverseKGroup] Execution Time: {sw.ElapsedMilliseconds} ms");
            PrintList(head3);
            Console.WriteLine("[1 2 3 4 5]");

            // Scenario 4: Linked list 1->2->3->4->5, k = 6 (incomplete group)
            // Input: 1 -> 2 -> 3 -> 4 -> 5, k = 6
            // Expected result: 1 -> 2 -> 3 -> 4 -> 5
            ListNode head4 = CreateTestList();
            Console.WriteLine("\nScenario 4: Linked list 1 -> 2 -> 3 -> 4 -> 5, k = 6");
            sw.Restart();
            head4 = Solution.ReverseKGroup(head4, 6);
            sw.Stop();
            Console.WriteLine($"[Solution.ReverseKGroup] Execution Time: {sw.ElapsedMilliseconds} ms");
            PrintList(head4);
            Console.WriteLine("[1 2 3 4 5]");

            // Additional Scenario 5: Empty list, k = 3
            // Input: Empty list, k = 3
            // Expected result: Empty list
            ListNode head5 = null;
            Console.WriteLine("\nScenario 5: Empty list, k = 3");
            sw.Restart();
            head5 = Solution.ReverseKGroup(head5, 3);
            sw.Stop();
            Console.WriteLine($"[Solution.ReverseKGroup] Execution Time: {sw.ElapsedMilliseconds} ms");
            PrintList(head5);
            Console.WriteLine("[Empty list]");
            
            // Additional Scenario 6: Single node list, k = 2
            // Input: 100, k = 2
            // Expected result: 100
            ListNode head6 = new ListNode(100);
            Console.WriteLine("\nScenario 6: Single node list, k = 2");
            sw.Restart();
            head6 = Solution.ReverseKGroup(head6, 2);
            sw.Stop();
            Console.WriteLine($"[Solution.ReverseKGroup] Execution Time: {sw.ElapsedMilliseconds} ms");
            PrintList(head6);
            Console.WriteLine("[100]");

            // Expected Console Output (execution times may vary):
            // Scenario 1:
            //    2 1 4 3 5 
            // Scenario 2:
            //    3 2 1 4 5
            // Scenario 3:
            //    1 2 3 4 5
            // Scenario 4:
            //    1 2 3 4 5
            // Scenario 5:
            //    Empty list
            // Scenario 6:
            //    100
        }

        // Helper method to create a test linked list 1->2->3->4->5
        private static ListNode CreateTestList()
        {
            ListNode head = new ListNode(1);
            ListNode current = head;
            for (int i = 2; i <= 5; i++)
            {
                current.next = new ListNode(i);
                current = current.next;
            }
            return head;
        }

        // Helper method to print the linked list
        private static void PrintList(ListNode head)
        {
            if (head == null)
            {
                Console.WriteLine("Empty list");
                return;
            }
            ListNode current = head;
            while (current != null)
            {
                Console.Write(current.val + " ");
                current = current.next;
            }
            Console.WriteLine();
        }
    }

   
}