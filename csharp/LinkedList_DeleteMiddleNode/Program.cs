using System;

namespace LinkedList_DeleteMiddleNode
{
    class Program
    {
        /*
         * Delete the middle node from a singly linked list, given only access to that node.
         */

        class Node(int data)
        {
            public Node Next;
            public int Value = data;

            public void Add(int data)
            {
                Node next = this;

                while(next.Next != null)
                {
                    next = next.Next;
                }

                next.Next = new Node(data);
            }

            public Node Find(int num)
            {
                Node node = this;

                while(node != null)
                {
                    if(node.Value == num)
                    {
                        return node;
                    }

                    node = node.Next;
                }

                return null;
            }

            public void Print()
            {
                Node node = this;

                while(node != null)
                {
                    Console.WriteLine(node.Value);

                    node = node.Next;
                }
            }
        }

        static void Main(string[] args)
        {
            var root = new Node(5);
            root.Add(6);
            root.Add(9);

            Node node = root.Find(6);

            Delete(node);
        }

        private static void Delete(Node node)
        {
            if(node.Next != null)
            {
                node.Value = node.Next.Value;
                node.Next = node.Next.Next;
            }
        }
    }
}
