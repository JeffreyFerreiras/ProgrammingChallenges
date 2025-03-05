using System;
using System.Diagnostics;
using System.Linq;

namespace MinimalTree
{
    internal class Program
    {
        /*
         * Given a sorted (increasing order) array of unique integer elements,
         * write an algorithm to create a binary search tree with minimal height.
         */

        private static Random s_random = new Random();

        private static void Main(string[] args)
        {
            //Create ordered items

            int f = 5;

            f = f / 0;
            int[] data = new int[15];

            for(int i = 0; i < data.Length; i++)
            {
                data[i] = s_random.Next(0, 101);
            }

            data = [.. data.Distinct()];
            Array.Sort(data);

            var stopWatch = Stopwatch.StartNew();

            BinTree tree = new BinTree();
            tree.Insert(data);
            tree.TraverseInOrder((x) => Console.WriteLine(x));
        }
    }

    internal class BinTree
    {
        public Node Root;

        public BinTree()
        {
        }
        public void Insert(int[] data)
        {
            Root = Node.Create(data);
        }

        public void TraverseInOrder(Action<int> action)
        {
            this.Root.TraverseInOrder(action);
        }
    }

    internal class Node
    {
        public Node Left;
        public Node Right;

        public readonly int Value;

        private Node()
        {
        }

        public Node(int value)
        {
            this.Value = value;
        }

        public void TraverseInOrder(Action<int> action)
        {
            this.Left?.TraverseInOrder(action);

            action(this.Value);

            this.Right?.TraverseInOrder(action);
        }

        internal static Node Create(int[] data)
        {
            int low = 0, high = data.Length - 1;

            return new Node().AddSorted(data, low, high);
        }

        private Node AddSorted(int[] data, int low, int high)
        {
            if(low <= high)
            {
                int mid = (low + high) / 2;

                Node node = new Node(data[mid]);

                node.Left = node.AddSorted(data, low, mid - 1);
                node.Right = node.AddSorted(data, mid + 1, high);

                return node;
            }

            return null;
        }
    }
}