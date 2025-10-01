using System;
using System.Collections.Generic;
using System.Linq;

namespace LinkedList_DetectCycle
{
    public class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }
    }

    class Program
    {
        /*A linked list is said to contain a cycle if any node is visited more than once while traversing the list.
         * Complete the function provided in the editor below. It has one parameter: a pointer to a Node object named that points to the head of a linked list.
         * Your function must return a boolean denoting whether or not there is a cycle in the list.
         * If there is a cycle, return true; otherwise, return false.
         */

        static void Main(string[] args)
        {
            var linkedList = new LinkedList<int>(Enumerable.Range(0, 100));

            bool hasCycle = HasCycle(CreateCycledLinkedList(6));
            bool hasCycle2 = HasCycle2(CreateCycledLinkedList(6));
        }
        /**
         * Turtois and the Hair algorithm
         */
        private static bool HasCycle2(Node node)
        {
            Node turtle = node, hair = node.Next;

            do
            {
                if (hair == null || turtle == null)
                {
                    return false;
                }

                turtle = turtle.Next;
                hair = hair.Next?.Next;
            }
            while (turtle != hair);

            return true;
        }


        private static bool HasCycle(Node head)
        {
            if (head == null) return false;

            var seen = new HashSet<int>();
            var node = head;

            while (node != null)
            {
                if (seen.Contains(node.GetHashCode()))
                {
                    return true;
                }

                seen.Add(node.GetHashCode());
                node = node.Next;
            }

            return false;
        }


        private static Node CreateCycledLinkedList(int size)
        {
            var rand = new Random();
            var randomValues = Enumerable.Range(0, size).Select(x => rand.Next(0, 100)).ToList();
            var randIndex = rand.Next(0, size);
            Node node = new() { Value = rand.Next(0, 100) }, prev = node;

            randomValues.ForEach(val =>
            {
                prev.Next = new Node
                {
                    Value = val
                };
                prev = prev.Next;
            });

            Node current = node;

            for (int i = 0; i < randIndex; i++)
            {
                current = current.Next;
            }

            prev.Next = current;

            return node;
        }
    }
}
