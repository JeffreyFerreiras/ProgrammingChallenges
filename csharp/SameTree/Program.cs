using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SameTree;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("Same Tree");
        Console.WriteLine(new string('=', 9) + "\n");

        var solution = new Solution();

        var scenarios = new[]
        {
            (Name: "Example 1", P: new int?[] { 1, 2, 3 }, Q: new int?[] { 1, 2, 3 }, Expected: true),
            (Name: "Example 2", P: new int?[] { 1, 2 }, Q: new int?[] { 1, null, 2 }, Expected: false),
            (Name: "Example 3", P: new int?[] { 1, 2, 1 }, Q: new int?[] { 1, 1, 2 }, Expected: false),
            (Name: "Edge: Both Empty", P: Array.Empty<int?>(), Q: Array.Empty<int?>(), Expected: true),
            (Name: "Single Node Difference", P: new int?[] { 1 }, Q: new int?[] { 2 }, Expected: false),
            (Name: "Different Structure", P: new int?[] { 1, 2, 3, null, 4 }, Q: new int?[] { 1, 2, 3, 4 }, Expected: false),
            (Name: "Large Match", P: new int?[] { 5, 5, 5, 5, 6 }, Q: new int?[] { 5, 5, 5, 5, 6 }, Expected: true)
        };

        foreach (var scenario in scenarios)
        {
            var pRoot = BuildTree(scenario.P);
            var qRoot = BuildTree(scenario.Q);

            var stopwatch = Stopwatch.StartNew();
            var result = solution.IsSameTree(pRoot, qRoot);
            stopwatch.Stop();

            Console.WriteLine($"Scenario: {scenario.Name}");
            Console.WriteLine($"Method: {nameof(Solution.IsSameTree)}");
            Console.WriteLine($"Tree P: {FormatArray(scenario.P)}");
            Console.WriteLine($"Tree Q: {FormatArray(scenario.Q)}");
            Console.WriteLine($"Result: {result}, Expected: {scenario.Expected}");
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

    private static string FormatArray(IReadOnlyList<int?> values)
    {
        if (values.Count == 0)
        {
            return "[]";
        }

        return "[" + string.Join(",", values.Select(v => v?.ToString() ?? "null")) + "]";
    }
}
