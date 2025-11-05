using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace BinaryTreeLevelOrderTraversalNeetCode;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("Binary Tree Level Order Traversal");
        Console.WriteLine(new string('=', 37) + "\n");

        var solution = new Solution();

        var scenarios = new[]
        {
            // Very simple cases - 2-3 nodes
            (Name: "2 Nodes: Root and Left", Values: [1, 2], Expected: [[1], [2]]),
            (Name: "2 Nodes: Root and Right", Values: [1, null, 2], Expected: [[1], [2]]),
            (Name: "3 Nodes: Balanced", Values: [1, 2, 3], Expected: [[1], [2, 3]]),
            // Simple cases - single node
            (Name: "Single Node", Values: [1], Expected: [[1]]),
            // Moderate cases
            (
                Name: "Example 1",
                Values: [3, 9, 20, null, null, 15, 7],
                Expected: [[3], [9, 20], [15, 7]]
            ),
            // Complex cases
            (
                Name: "Left-heavy",
                Values: [1, 2, null, 3, null, null, null, 4],
                Expected: [[1], [2], [3], [4]]
            ),
            (
                Name: "Right-heavy",
                Values:
                [
                    1,
                    null,
                    2,
                    null,
                    null,
                    null,
                    3,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    4,
                ],
                Expected: [[1], [2], [3], [4]]
            ),
            (
                Name: "Complete Tree",
                Values: [1, 2, 3, 4, 5, 6, 7],
                Expected: [[1], [2, 3], [4, 5, 6, 7]]
            ),
            // Edge cases
            (Name: "Empty Tree", Values: Array.Empty<int?>(), Expected: Array.Empty<int[]>()),
        };

        foreach (var scenario in scenarios)
        {
            Console.WriteLine($"Scenario: {scenario.Name}");
            Console.WriteLine($"Method: {nameof(Solution.LevelOrder)}");

            var root = BuildTree(scenario.Values);

            var stopwatch = Stopwatch.StartNew();
            var result = solution.LevelOrder(root);
            stopwatch.Stop();

            var isCorrect = AreEqual(result, scenario.Expected);
            var mark = isCorrect ? "✓" : "✗";

            Console.WriteLine($"Result: {FormatLevels(result)}");
            Console.WriteLine($"Expected: {FormatLevels(scenario.Expected)} {mark}");
            Console.WriteLine($"Elapsed: {stopwatch.Elapsed.TotalMilliseconds:F4} ms");
            Console.WriteLine(new string('-', 60));
        }
    }

    private static TreeNode? BuildTree(IReadOnlyList<int?> values)
    {
        if (values.Count == 0)
        {
            return null;
        }

        var nodes = new TreeNode?[values.Count];
        for (var i = 0; i < values.Count; i++)
        {
            if (values[i].HasValue)
            {
                nodes[i] = new TreeNode(values[i]!.Value);
            }
        }

        for (var i = 0; i < values.Count; i++)
        {
            var current = nodes[i];
            if (current is null)
            {
                continue;
            }

            var leftIndex = 2 * i + 1;
            var rightIndex = 2 * i + 2;

            if (leftIndex < values.Count)
            {
                current.Left = nodes[leftIndex];
            }

            if (rightIndex < values.Count)
            {
                current.Right = nodes[rightIndex];
            }
        }

        return nodes[0];
    }

    private static string FormatLevels(IEnumerable<IEnumerable<int>>? levels)
    {
        if (levels is null)
        {
            return "[]";
        }

        var formatted = levels.Select(level => "[" + string.Join(",", level) + "]").ToArray();
        return "[" + string.Join(",", formatted) + "]";
    }

    private static bool AreEqual(
        IEnumerable<IEnumerable<int>>? result,
        IEnumerable<int[]>? expected
    )
    {
        if (result is null && expected is null)
        {
            return true;
        }

        if (result is null || expected is null)
        {
            return false;
        }

        var resultList = result.ToList();
        var expectedList = expected.ToList();

        if (resultList.Count != expectedList.Count)
        {
            return false;
        }

        for (var i = 0; i < resultList.Count; i++)
        {
            var resultLevel = resultList[i].ToList();
            var expectedLevel = expectedList[i].ToList();

            if (resultLevel.Count != expectedLevel.Count)
            {
                return false;
            }

            for (var j = 0; j < resultLevel.Count; j++)
            {
                if (resultLevel[j] != expectedLevel[j])
                {
                    return false;
                }
            }
        }

        return true;
    }
}
