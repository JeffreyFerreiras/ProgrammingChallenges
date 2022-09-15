using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ReverseLinkedList
{
    class Program
    {
        /*
        Reverse a .NET LinkedList while maintaining the best time and space complexity. 
        */

        static void Main(string[] args)
        {
            LinkedList<string> linked = new LinkedList<string>();

            linked.AddLast("one");
            linked.AddLast("two");
            linked.AddLast("three");

            linked.ReverseLinkedList();


            var testNode = PopulateTestCase();
            
            Console.WriteLine("before:\n");

            Print(testNode);

            testNode = ReverseLinkedList(testNode);

            Console.WriteLine("after\n");

            Print(testNode);

            Console.WriteLine("recursive\n");
            Console.WriteLine("before:\n");
            
            testNode = PopulateTestCase();
            Print(testNode);

            Console.WriteLine("after\n");
            Print(ReverseLinkedListRecursive(testNode));
            Console.ReadLine();
        }

        private static void Print(Node testNode)
        {
            do
            {
                Console.WriteLine(testNode?.Value);
                testNode = testNode.Next;
             } while (testNode != null);
        }

        private static Node PopulateTestCase()
        {
            var random = new Random();
            var node = new Node(5);
            var root = node;

            for (int i = 0; i < 2; i++)
            {
                node.Next = new Node(random.Next(100));
                node = node.Next;
            }

            return root;
        }

        private static Node ReverseLinkedListRecursive(Node root)
        {
            Node next = root.Next;
            root.Next = null;

            return Recursive(root, next);

            Node Recursive(Node node, Node nex)
            {
                if(nex is null)
                {
                    return node;
                }

                Node nextToNext = nex.Next;
                nex.Next = node;

                return Recursive(nex, nextToNext);
            }
        }
		
        private static Node ReverseLinkedList(Node root)
        {
            Node current = root;
            Node previous = null;

            while(current != null)
            {
				Node next = current.Next;		//define a container for the next node
				current.Next = previous;		// assign the previous node to next
				previous = current;				// assign the current node to previous
				current = next;					// assign the next node to current
			}

            return previous;
        }

        public class Node
        {
            public int Value { get; set; }
            
            public Node Next { get; set; }

            public Node(int value)
            {
                this.Value = value;
            }
        }
    }
}
