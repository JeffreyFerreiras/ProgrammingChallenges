using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList_DetectCycle
{
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

            bool hasCycle = HasCycle(linkedList.First);
        }

        private static bool HasCycle(LinkedListNode<int> head)
        {
            if(head == null) return false;

            HashSet<int> hashes = new HashSet<int>();

            var node = head;

            while(node != null)
            {
                if(hashes.Contains(node.GetHashCode()))
                {
                    return true;
                }

                hashes.Add(node.GetHashCode());
                node = node.Next;
            }

            return false;
        }
    }
}
