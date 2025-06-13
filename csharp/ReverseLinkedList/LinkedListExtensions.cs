namespace ReverseLinkedList
{
    static class LinkedListExtensions
    {
        public static void ReverseLinkedList(this LinkedList<string> linkedList)
        {
            if (linkedList == null || linkedList.First == null)
                return;

            LinkedListNode<string> current = linkedList.First;

            while (current.Next != null)
            {
                LinkedListNode<string> next = current.Next;
                linkedList.Remove(next);  // Remove the node after current.
                linkedList.AddFirst(next.Value);  // Prepend it to reverse the list.
            }
        }
    }
}
