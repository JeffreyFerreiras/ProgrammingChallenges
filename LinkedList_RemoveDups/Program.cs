namespace LinkedList_RemoveDups
{
    /*
     * Write code to remove duplicates from an unsorted linked list.
     *
     * Follow up: How would you solve this problem if a temporary buffer is not allowed.
     */

    internal class Program
    {
        private static void Main(string[] args)
        {
            var data = new LinkedList<int>();
            data.AddFirst(9);
            data.AddFirst(6);
            data.AddFirst(6);
            data.AddFirst(4);
            data.AddFirst(6);
            data.AddFirst(5);
            data.AddFirst(8);

            RemoveDups(data);
        }

        private static void RemoveDups(LinkedList<int> data)
        {
            var set = new HashSet<int>();
            var node = data.First;

            set.Add(node.Value);

            while(node.Next != null)
            {
                if(set.Contains(node.Next.Value))
                {
                    //delete
                    data.Remove(node.Next);
                }

                set.Add(node.Next.Value);
                node = node.Next;
            }
        }
    }
}