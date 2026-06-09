namespace LinkedList_OddEvenList
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var solution = new Solution();
            ListNode head = new ListNode(1);
            ListNode curr = head;

            for (int i = 2; i <= 10; i++)
            {
                curr.next = new ListNode(i);
                curr = curr.next;
            }

            var oddEven = solution.OddEvenList2(head);

            while (oddEven != null)
            {
                Console.WriteLine(oddEven.val);
                oddEven = oddEven.next;
            }
        }
    }
}