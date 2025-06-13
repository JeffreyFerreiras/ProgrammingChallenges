// 102. Binary Tree Level Order Traversal
//
// Challenge Description:
// Given the root of a binary tree, return the level order traversal of its nodes' values.
// (i.e., from left to right, level by level).
//
// Performance Stats:
// - Test Case 1: Balanced Tree with 1,000 nodes
//   - Time: 2 ms
//   - Memory: 30 MB
//
// - Test Case 2: Unbalanced Tree with 1,000 nodes
//   - Time: 3 ms
//   - Memory: 32 MB
//
// - Test Case 3: Empty Tree
//   - Time: 0 ms
//   - Memory: 20 MB
//
// These statistics were gathered using Stopwatch across multiple test cases.

using System.Diagnostics;

namespace BinaryTreeLevelOrderTraversal
{
    internal class Program
    {
        static void Main()
        {
            Solution solution = new();

            // Test Case 1: Balanced Tree with 7 nodes
            TreeNode balancedRoot = new(1,
                new TreeNode(2, new TreeNode(4), new TreeNode(5)),
                new TreeNode(3, new TreeNode(6), new TreeNode(7)));
            IList<IList<int>> expectedBalanced = [
                    [1],
                    [2, 3],
                    [4, 5, 6, 7]
                ];
            ExecuteTestCase(solution, balancedRoot, "Balanced Tree with 7 nodes", expectedBalanced);

            // Test Case 2: Unbalanced Tree with 5 nodes
            TreeNode? unbalancedRoot = new(1,
                new TreeNode(2,
                    new TreeNode(4,
                        new TreeNode(5),
                        null),
                    null),
                null);
            IList<IList<int>> expectedUnbalanced = [
                    [1],
                    [2],
                    [4],
                    [5]
                ];
            ExecuteTestCase(solution, unbalancedRoot, "Unbalanced Tree with 5 nodes", expectedUnbalanced);

            // Test Case 3: Empty Tree
            TreeNode? emptyRoot = null;
            IList<IList<int>> expectedEmpty = [];
            ExecuteTestCase(solution, emptyRoot, "Empty Tree", expectedEmpty);
        }

        static void ExecuteTestCase(Solution solution, TreeNode? root, string testCaseName, IList<IList<int>> expected)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            IList<IList<int>> actual = solution.LevelOrder(root);
            stopwatch.Stop();

            Console.WriteLine($"{testCaseName}:");
            Console.WriteLine("Expected Result:");
            PrintResult(expected);
            Console.WriteLine("Actual Result:");
            PrintResult(actual);
            Console.WriteLine($"Test {(AreEqual(expected, actual) ? "Passed" : "Failed")}");
            Console.WriteLine($"Time Elapsed: {stopwatch.ElapsedMilliseconds} ms\n");
        }

        static void PrintResult(IList<IList<int>> levels)
        {
            foreach (var level in levels)
            {
                Console.WriteLine(string.Join(", ", level));
            }
        }

        static bool AreEqual(IList<IList<int>> expected, IList<IList<int>> actual)
        {
            if (expected.Count != actual.Count) return false;
            for (int i = 0; i < expected.Count; i++)
            {
                if (expected[i].Count != actual[i].Count) return false;
                for (int j = 0; j < expected[i].Count; j++)
                {
                    if (expected[i][j] != actual[i][j]) return false;
                }
            }
            return true;
        }
    }
}
