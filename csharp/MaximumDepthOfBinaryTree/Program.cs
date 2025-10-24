using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace MaximumDepthOfBinaryTree;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("Maximum Depth of Binary Tree");
        Console.WriteLine(new string('=', 31) + "\n");

        var solution = new Solution();

        // Get all public methods from Solution class
        var solutionMethods = typeof(Solution)
            .GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
            .Where(m => !m.IsSpecialName) // Exclude property getters/setters
            .ToList();

        var scenarios = new[]
        {
            (Name: "Example 1", Values: new int?[] { 3, 9, 20, null, null, 15, 7 }, Expected: 3),
            (Name: "Example 2", Values: new int?[] { 1, null, 2 }, Expected: 2),
            (Name: "Edge: Empty", Values: Array.Empty<int?>(), Expected: 0),
            (Name: "Edge: Single Node", Values: new int?[] { 42 }, Expected: 1),
            (Name: "Left Skewed", Values: new int?[] { 1, 2, null, 3 }, Expected: 3),
            (Name: "Right Skewed", Values: new int?[] { 1, null, 2 }, Expected: 2),
            (Name: "Balanced Larger", Values: new int?[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, Expected: 4)
        };

        foreach (var method in solutionMethods)
        {
            Console.WriteLine($"Testing method: {method.Name}");
            Console.WriteLine(new string('=', 60));

            foreach (var scenario in scenarios)
            {
                var root = BuildTree(scenario.Values);

                var stopwatch = Stopwatch.StartNew();
                var result = method.Invoke(solution, new object?[] { root });
                stopwatch.Stop();

                var passed = result?.Equals(scenario.Expected) ?? scenario.Expected == 0;
                var statusIcon = passed ? "✓" : "✗";

                Console.WriteLine($"{statusIcon} Scenario: {scenario.Name}");
                Console.WriteLine($"Method: {method.Name}");
                Console.WriteLine($"Result: {result}, Expected: {scenario.Expected}");
                Console.WriteLine($"Elapsed: {stopwatch.Elapsed.TotalMilliseconds:F4} ms");
                Console.WriteLine(new string('-', 60));
            }

            Console.WriteLine();
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
}
