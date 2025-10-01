using System.Diagnostics;

namespace ReverseLinkedList
{
    class Program
    {
        /*
        Reverse a .NET LinkedList while maintaining the best time and space complexity. 
        */

        static void Main(string[] args)
        {
            // .NET LinkedList reversal scenario
            var list = new LinkedList<string>();
            list.AddLast("one");
            list.AddLast("two");
            list.AddLast("three");
            var expectedLinked = new List<string> { "three", "two", "one" };
            var sw = Stopwatch.StartNew();
            list.ReverseLinkedList(); // assumed extension method
            sw.Stop();
            Console.WriteLine($"Method: LinkedList.ReverseLinkedList, Time: {sw.ElapsedTicks} ticks, Result: {string.Join(',', list)}, Expected: {string.Join(',', expectedLinked)}");

            // Node iterative reversal scenario
            var testNode = PopulateTestCase();
            sw.Restart();
            var reversedIterative = ReverseLinkedList(testNode);
            sw.Stop();
            Console.WriteLine($"Method: ReverseLinkedList (iterative), Time: {sw.ElapsedTicks} ticks, Result: {GetValues(reversedIterative)}, Expected: 3,2,1");

            // Node recursive reversal scenario
            testNode = PopulateTestCase();
            sw.Restart();
            var reversedRecursive = ReverseLinkedListRecursive(testNode);
            sw.Stop();
            Console.WriteLine($"Method: ReverseLinkedListRecursive (recursive), Time: {sw.ElapsedTicks} ticks, Result: {GetValues(reversedRecursive)}, Expected: 3,2,1");

            Console.ReadLine();
        }

        private static string GetValues(Node node)
        {
            var values = new List<string>();
            while (node != null)
            {
                values.Add(node.Value.ToString());
                node = node.Next;
            }
            return string.Join(",", values);
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
            // Changed: using fixed test case values for consistency.
            var node = new Node(1);
            node.Next = new Node(2);
            node.Next.Next = new Node(3);
            return node;
        }

        private static Node ReverseLinkedListRecursive(Node root)
        {
            Node next = root.Next;
            root.Next = null;

            return Recursive(root, next);

            Node Recursive(Node node, Node nex)
            {
                if (nex is null)
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

            while (current != null)
            {
                Node next = current.Next;       //define a container for the next node
                current.Next = previous;        // assign the previous node to next
                previous = current;             // assign the current node to previous
                current = next;                 // assign the next node to current
            }

            return previous;
        }

        public class Node(int value)
        {
            public int Value { get; set; } = value;

            public Node Next { get; set; }
        }
    }
}