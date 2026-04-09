namespace LinkedList_DeleteMiddleNode
{
    /*
     * Delete the middle node from a singly linked list, given only access to that node.
     */
    class Program
    {
        static void Main(string[] args)
        {
            var root = new Node(5);
            root.Add(6);
            root.Add(9);

            Node? node = root.Find(6);

            if (node != null)
                new Solution().Delete(node);

            root.Print();
        }
    }
}
