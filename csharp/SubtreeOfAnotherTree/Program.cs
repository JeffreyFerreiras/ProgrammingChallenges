using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SubtreeOfAnotherTree;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("Subtree of Another Tree");
        Console.WriteLine(new string('=', 26) + "\n");

        var solution = new Solution();

        var scenarios = new[]
        {
            (Name: "Example 1", Root: new int?[] { 3, 4, 5, 1, 2 }, SubRoot: new int?[] { 4, 1, 2 }, Expected: true),
            (Name: "Example 2", Root: [3, 4, 5, 1, 2, null, null, null, null, 0], SubRoot: [4, 1, 2], Expected: false),
            (Name: "Edge: Single Node Match", Root: [1], SubRoot: [1], Expected: true),
            (Name: "Edge: Single Node Mismatch", Root: [1], SubRoot: [2], Expected: false),
            (Name: "Deep Candidate", Root: [1, 2, 3, 4, 5, 6, 7, 8, 9, 10], SubRoot: [5, 10], Expected: true),
            (Name: "Large Match", Root: [4, 2, 6, 1, 3, 5, 7, null, null, null, null, null, null, null, 8], SubRoot: [6, 5, 7], Expected: false),
            (Name: "Custom: [3,4,5,1,2] vs [4,1,2]", Root: [3, 4, 5, 1, 2], SubRoot: [4, 1, 2], Expected: true),
            (Name: "Testcase: [1,1] vs [1]", Root: [1, 1], SubRoot: [1], Expected: true)
        };

        foreach (var scenario in scenarios)
        {
            var root = BuildTree(scenario.Root);
            var subRoot = BuildTree(scenario.SubRoot);

            var stopwatch = Stopwatch.StartNew();
            var result = solution.IsSubtree(root, subRoot);
            stopwatch.Stop();

            Console.WriteLine($"Scenario: {scenario.Name}");
            Console.WriteLine($"Method: {nameof(Solution.IsSubtree)}");
            Console.WriteLine($"Root: {FormatArray(scenario.Root)}");
            Console.WriteLine($"SubRoot: {FormatArray(scenario.SubRoot)}");
            var passMark = result == scenario.Expected ? " ✓" : string.Empty;
            Console.WriteLine($"Result: {result}, Expected: {scenario.Expected}{passMark}");
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
                current.left = nodes[leftIndex];
            }

            if (rightIndex < values.Count)
            {
                current.right = nodes[rightIndex];
            }
        }

        return nodes[0];
    }

    private static string FormatArray(IReadOnlyList<int?> values)
    {
        if (values.Count == 0)
        {
            return "[]";
        }

        return "[" + string.Join(",", values.Select(v => v?.ToString() ?? "null")) + "]";
    }
}
