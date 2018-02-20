using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseLinkedList
{
    static class LinkedListExtensions
    {
        public static void ReverseLinkedList(this LinkedList<string> linkedList)
        {
            LinkedListNode<string> current  = linkedList.First;

            while(current.Next != null)
            {
                LinkedListNode<string> next = current.Next;

                linkedList.Remove(next);            //links current to the removed items .Next
                linkedList.AddFirst(next.Value);

                /*  Eventually current.Next ends up null and the list is reversed.  */
            }
        }
    }
}
