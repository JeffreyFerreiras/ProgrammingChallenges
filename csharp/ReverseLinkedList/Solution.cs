namespace ReverseLinkedList
{
    public class ListNode(int val = 0, ListNode next = null)
    {
        public int val = val;
        public ListNode next = next;
    }

    public class Solution
    {
        // Reverses a .NET LinkedList; stubbed implementation.
        public LinkedList<T> ReverseLinkedList<T>(LinkedList<T> linked)
        {
            throw new NotImplementedException();
        }

        public static ListNode ReverseLinkedListIterative(ListNode root)
        {
            ListNode current = root;

            while(current != null)
            {
                ListNode next = current.next;
                current.next = root;
                root = current;
                current = next;
            }

            return root;            
        }

        public static ListNode ReverseLinkedListRecursive(ListNode root)
        {
            // Added null check to handle empty list
            if(root == null) return null;

            ListNode next = root.next;
            root.next = null!;

            return Recursive(root, next);

            static ListNode Recursive(ListNode node, ListNode nex)
            {
                if(nex is null)
                {
                    return node;
                }

                ListNode nextToNext = nex.next;
                nex.next = node;

                return Recursive(nex, nextToNext);
            }
        }
    }
}