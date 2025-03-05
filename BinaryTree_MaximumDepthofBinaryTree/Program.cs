using System;
using System.Diagnostics;

namespace BinaryTree_MaximumDepthofBinaryTree {
	class Program {
		static void Main(string[] args) {
			var solution = new Solution();

			// Scenario 1: Empty tree
			TreeNode test1 = null;
			RunTest("MaxDepth", () => solution.MaxDepth(test1), 0);

			// Scenario 2: Single node tree
			TreeNode test2 = new TreeNode(1);
			RunTest("MaxDepth", () => solution.MaxDepth(test2), 1);

			// Scenario 3: Tree with depth 3
			//       1
			//      / \
			//     2   3
			//          \
			//           4
			TreeNode test3 = new TreeNode(1, new TreeNode(2), new TreeNode(3, null, new TreeNode(4)));
			RunTest("MaxDepth", () => solution.MaxDepth(test3), 3);

			// Scenario 4: Left skewed tree
			//       1
			//      /
			//     2
			//    /
			//   3
			//  /
			// 4
			TreeNode test4 = new TreeNode(1, new TreeNode(2, new TreeNode(3, new TreeNode(4))));
			RunTest("MaxDepth", () => solution.MaxDepth(test4), 4);

			// Scenario 5: Right skewed tree
			// 1
			//  \
			//   2
			//    \
			//     3
			TreeNode test5 = new TreeNode(1, null, new TreeNode(2, null, new TreeNode(3)));
			RunTest("MaxDepth", () => solution.MaxDepth(test5), 3);
		}

		static void RunTest(string methodName, Func<int> testFunc, int expected) {
			var stopwatch = Stopwatch.StartNew();
			int result = testFunc();
			stopwatch.Stop();
			Console.WriteLine($"{methodName}: {stopwatch.ElapsedTicks} ticks, result: {result}, expected: {expected}");
		}
	}
}
