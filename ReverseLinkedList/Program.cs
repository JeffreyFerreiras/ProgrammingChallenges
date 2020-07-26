using System;
using System.Collections.Generic;
using System.Linq;
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

            testNode = ReverseLinkedListRecursive(testNode);

            Console.WriteLine("after\n");

            Print(testNode);

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

        // 1,2,3,4

        private static Node ReverseLinkedListRecursive(Node root)
        {
            var reversed = Reversed(root);

            root.Next = null;

            return reversed;

            Node Reversed(Node node)
            {
                if(node?.Next == null)
                {
                    return node;
                }

                var prev = node;

                var stackNode = Reversed(node.Next);

                if (stackNode != null)
                {
                    stackNode.Next = prev;
                }

                return stackNode;
            }
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
