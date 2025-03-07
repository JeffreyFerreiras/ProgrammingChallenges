using System;
using System.Collections.Generic;
using System.Diagnostics;
using ProgrammingChallenges;

namespace ProgrammingChallenges
{
    class Program
    {
        static void Main(string[] args)
        {
            var scenarios = new List<(int?[] input, int?[] expected, string name)>
            {
                (new int?[] {4,2,7,1,3,6,9}, new int?[] {4,7,2,9,6,3,1}, "Scenario 1"),
                (new int?[] {2,1,3}, new int?[] {2,3,1}, "Scenario 2"),
                (new int?[] {}, new int?[] {}, "Scenario 3")
            };

            foreach (var scenario in scenarios)
            {
                var root = BuildTree(scenario.input);
                var expectedTree = BuildTree(scenario.expected);
                var solution = new InvertBinaryTreeSolution();
                var stopwatch = Stopwatch.StartNew();
                try
                {
                    var result = InvertBinaryTreeSolution.InvertTree(root);
                    stopwatch.Stop();
                    Console.WriteLine($"{scenario.name} - InvertTree took {stopwatch.ElapsedTicks} ticks");
                    Console.WriteLine($"Result:   {SerializeTree(result)}");
                    Console.WriteLine($"Expected: {SerializeTree(expectedTree)}");
                }
                catch (NotImplementedException)
                {
                    stopwatch.Stop();
                    Console.WriteLine($"{scenario.name} - InvertTree not implemented.");
                }
                Console.WriteLine("---------------------------------");
            }
        }

        // Build a binary tree from level-order array
        static TreeNode BuildTree(int?[] arr)
        {
            if (arr == null || arr.Length == 0 || arr[0] == null) return null;
            TreeNode root = new TreeNode(arr[0].Value);
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int i = 1;
            while (i < arr.Length)
            {
                TreeNode current = queue.Dequeue();
                if (i < arr.Length && arr[i] != null)
                {
                    current.left = new TreeNode(arr[i].Value);
                    queue.Enqueue(current.left);
                }
                i++;
                if (i < arr.Length && arr[i] != null)
                {
                    current.right = new TreeNode(arr[i].Value);
                    queue.Enqueue(current.right);
                }
                i++;
            }
            return root;
        }

        // Serialize binary tree to a string using level order traversal
        static string SerializeTree(TreeNode root)
        {
            if (root == null) return "[]";
            List<string> result = [];
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while(queue.Count > 0)
            {
                var node = queue.Dequeue();
                if (node == null)
                {
                    result.Add("null");
                    continue;
                }
                result.Add(node.val.ToString());
                queue.Enqueue(node.left);
                queue.Enqueue(node.right);
            }
            // Remove trailing "null"s
            int lastNonNull = result.Count - 1;
            while(lastNonNull >= 0 && result[lastNonNull] == "null")
                lastNonNull--;
            return "[" + string.Join(",", result.GetRange(0, lastNonNull+1)) + "]";
        }
    }
}
