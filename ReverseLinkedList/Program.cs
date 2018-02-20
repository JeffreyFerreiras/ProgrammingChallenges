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
        }
    }
}
